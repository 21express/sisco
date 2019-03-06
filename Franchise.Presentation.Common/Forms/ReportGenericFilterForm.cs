using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using Franchise.Presentation.Common.Component;
using Franchise.Presentation.Common.Component.Interfaces;

namespace Franchise.Presentation.Common.Forms
{
    public partial class ReportGenericFilterForm<T> : Form
    {
        // ReSharper disable once InconsistentNaming
        private const string _defaultExportFilename = "Report_{0}";

        public string DefaultExportFilename { get; set; }
        public Func<Dictionary<string, ReportParameter>, IEnumerable<T>> DataSourceFunc { get; set; }
        public Func<IEnumerable<T>, IEnumerable<object>> CustomTabularExportFormat { get; set; }
        public Func<IEnumerable<T>, IEnumerable<object>> CustomReportFormat { get; set; }
        public new Action<XtraReport, Dictionary<string, ReportParameter>> OnLoad { get; set; }
        public Dictionary<string, ReportParameter> Parameters { get; set; }
        public XtraReport Report { get; set; }

        public ReportGenericFilterForm()
        {
            InitializeComponent();

            Parameters = new Dictionary<string, ReportParameter>();

            Load += (sender, args) =>
            {
                Parameters.First().Value.Control.Focus();

                Report.RequestParameters = false;

                foreach (var t in Report.Parameters)
                {
                    t.Visible = false;
                }

                foreach (var key in Parameters.Keys)
                {
                    if (!Parameters[key].Visible) break;

                    var i = AddTableRow();
                    var control = Parameters[key].Control;

                    //if (control is BaseEdit) ((BaseEdit)control).Properties.BeginInit();

                    control.Margin = new Padding(0);

                    tableLayoutPanel1.Controls.Add(new Label
                    {
                        Text = Parameters[key].Label,
                        Margin = new Padding(0),
                        ForeColor = Color.Black
                    }, 0, i);

                    tableLayoutPanel1.Controls.Add(control, 1, i);

                    //if (control is BaseEdit) ((BaseEdit)control).Properties.EndInit();

                    if (Parameters[key].DefaultValue != null)
                    {
                        Parameters[key].Value = Parameters[key].DefaultValue;
                    }

                    if (control.GetType() == typeof (dLookupF))
                    {
                        ((dLookupF)control).Properties.ButtonClick += (o, eventArgs) =>
                        {
                            var dlookup = o as dLookupF;

                            if (dlookup != null && dlookup.Enabled) dlookup.OpenLookupPopup();
                        };
                    }

                    if (control.GetType() == typeof (CheckedListBox))
                    {
                        for (var ix = 0; ix < ((CheckedListBox) control).Items.Count; ix ++)
                        {
                            ((CheckedListBox) control).SetItemChecked(ix, true);
                        }
                    }
                }
            };

            btnPrint.Click += (sender, args) =>
            {
                var errors = ComponentValidationHelper.Validate(Parameters.Values.OfType<IValidatableComponent>().ToArray());

                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors));
                    return;
                }

                using (var printTool = new ReportPrintTool(Report))
                {
                    _fillDataSource();
                    printTool.PrintDialog();
                }
            };

            btnPrintPreview.Click += (sender, args) =>
            {
                var errors = ComponentValidationHelper.Validate(Parameters.Values.OfType<IValidatableComponent>().ToArray());

                if (errors.Count > 0)
                {
                    MessageBox.Show(string.Join("\n", errors));
                    return;
                }

                using (var printTool = new ReportPrintTool(Report))
                {
                    _fillDataSource();
                    printTool.ShowPreviewDialog();
                }
            };

            btnExport.Click += (sender, args) => ExportToExcel();
        }

        private int AddTableRow()
        {
            int index = tableLayoutPanel1.RowCount++;
            var style = new RowStyle(SizeType.AutoSize);
            tableLayoutPanel1.RowStyles.Add(style);

            return index;
        }

        private void ExportToExcel()
        {
            //gridControl1.DataSource = new object[0];
            var dataSource = DataSourceFunc(Parameters);

            // ReSharper disable once PossibleMultipleEnumeration
            if (dataSource == null || !dataSource.Any())
            {
                MessageBox.Show(@"No data found");
                return;
            }

            using (var dialog = new SaveFileDialog())
            {
                dialog.FileName =
                    string.Format(
                        !string.IsNullOrEmpty(DefaultExportFilename) ? DefaultExportFilename : _defaultExportFilename,
                        DateTime.Now.ToString("yyyyMMddHHmm")) + ".xlsx";

                dialog.Filter = @"Microsoft Excel 2007 files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (CustomTabularExportFormat != null)
                    {
                        // ReSharper disable once PossibleMultipleEnumeration
                        gridControl1.DataSource = CustomTabularExportFormat(dataSource);
                    }
                    else
                    {
                        gridControl1.DataSource = dataSource;
                    }

                    gridView1.ExportToXlsx(dialog.FileName, new XlsxExportOptions
                    {
                        TextExportMode = TextExportMode.Text,
                        ExportMode = XlsxExportMode.SingleFile,
                        ShowGridLines = true,
                        RawDataMode = true,
                    });
                }


                if (File.Exists(dialog.FileName))
                {
                    System.Diagnostics.Process.Start("explorer.exe", @"/select,""" + dialog.FileName + "\"");
                }
            }
        }

        private void _fillDataSource()
        {
            Report.DataSource = new object[0];
            
            var dataSource = (CustomReportFormat != null) ? CustomReportFormat(DataSourceFunc(Parameters)) : DataSourceFunc(Parameters) as IEnumerable<object>;

            if (dataSource != null)
            {
                Report.DataSource = dataSource;
            }

            Report.RequestParameters = false;

            foreach (var key in Parameters.Keys)
            {
                if (Report.Parameters[key] == null)
                {
                    Report.Parameters.Add(new Parameter
                    {
                        Name = key
                    });
                }

                Report.Parameters[key].Value = Parameters[key].Value;
                Report.Parameters[key].Visible = false;
            }

            if (OnLoad != null)
            {
                OnLoad(Report, Parameters);
            }

            Report.CreateDocument();
        }
    }

    public class ReportParameter
    {
        public string Label { get; set; }
        public Control Control { get; set; }
        public object DefaultValue { get; set; }
        public bool Visible { get; set; }

        public CheckedListBox.CheckedItemCollection CheckedItems
        {
            get { return ((CheckedListBox) Control).CheckedItems; }
        }

        private object _value;
        public object Value
        {
            // ReSharper disable CanBeReplacedWithTryCastAndCheckForNull
            get
            {
                if (Control is dCalendar)
                {
                    return ((dCalendar) Control).DateTime;
                }
                if (Control is dLookupF)
                {
                    return ((dLookupF)Control).Value;
                }
                if (Control is dComboBox)
                {
                    return ((dComboBox)Control).SelectedValue ?? Control.Text;
                }
                if (Control is CheckBox)
                {
                    return ((CheckBox) Control).Checked;
                }
                if (Control != null)
                {
                    return Control.Text;
                }

                return _value;
            }
            set
            {
                if (Control is dCalendar)
                {
                    ((dCalendar)Control).DateTime = (DateTime) value;
                }
                else if (Control is dLookupF)
                {
                    ((dLookupF)Control).DefaultValue = new IListParameter[] { WhereTerm.Default(Convert.ToInt32(value), "id") };
                }
                else if (Control is dComboBox)
                {
                    ((dComboBox)Control).SelectedValue = value;
                }
                else if (Control is dCheckBox)
                {
                    ((dCheckBox)Control).Checked = (bool)value;
                }
                else if (Control is CheckBox)
                {
                    ((CheckBox)Control).Checked = (bool)value;
                }
                else if (Control != null)
                {
                    Control.Text = value.ToString();
                }

                _value = value;
            }
            // ReSharper restore CanBeReplacedWithTryCastAndCheckForNull
        }

        public ReportParameter()
        {
            Visible = true;
        }
    }
}
