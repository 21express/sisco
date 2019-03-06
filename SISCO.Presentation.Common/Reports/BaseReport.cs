using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using SISCO.Presentation.Common.Component;

namespace SISCO.Presentation.Common.Reports
{
    //public abstract class BaseReport : XtraReport
    //{
    //    // ReSharper disable once InconsistentNaming
    //    private const string _defaultExportFilename = "Report_{0}";

    //    public string DefaultExportFilename { get; set; }
    //    public Dictionary<string, ReportParameter> ReportParameters { get; set; }
    //    public Func<IEnumerable<object>, IEnumerable<object>> CustomTabularExportFormat { get; set; }

    //    public abstract IEnumerable<T> PopulateDataSource<T>(Dictionary<string, ReportParameter> parameters);

    //    public virtual IEnumerable<object> CustomReportFields<T>(IEnumerable<T> data)
    //    {
    //        return (IEnumerable<object>) data;
    //    }

    //    private void InitializeComponent()
    //    {
    //        this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
    //        this.detailBand1 = new DevExpress.XtraReports.UI.DetailBand();
    //        this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
    //        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
    //        // 
    //        // topMarginBand1
    //        // 
    //        this.topMarginBand1.Name = "topMarginBand1";
    //        // 
    //        // detailBand1
    //        // 
    //        this.detailBand1.Name = "detailBand1";
    //        // 
    //        // bottomMarginBand1
    //        // 
    //        this.bottomMarginBand1.Name = "bottomMarginBand1";
    //        // 
    //        // BaseReport
    //        // 
    //        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
    //        this.topMarginBand1,
    //        this.detailBand1,
    //        this.bottomMarginBand1});
    //        this.Version = "13.2";
    //        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    //    }
    //}

    //public class ReportParameter
    //{
    //    public string Label { get; set; }
    //    public Control Control { get; set; }
    //    public object DefaultValue { get; set; }

    //    private object _value;
    //    public object Value
    //    {
    //        // ReSharper disable CanBeReplacedWithTryCastAndCheckForNull
    //        get
    //        {
    //            if (Control is dCalendar)
    //            {
    //                return ((dCalendar)Control).DateTime;
    //            }
    //            if (Control is dLookup)
    //            {
    //                return ((dLookup)Control).Value;
    //            }
    //            if (Control is dComboBox)
    //            {
    //                return ((dComboBox)Control).SelectedValue ?? Control.Text;
    //            }
    //            if (Control is CheckBox)
    //            {
    //                return ((CheckBox)Control).Checked;
    //            }
    //            if (Control != null)
    //            {
    //                return Control.Text;
    //            }

    //            return _value;
    //        }
    //        set
    //        {
    //            if (Control is dCalendar)
    //            {
    //                ((dCalendar)Control).DateTime = (DateTime)value;
    //            }
    //            else if (Control is dLookup)
    //            {
    //                ((dLookup)Control).DefaultValue = new IListParameter[] { WhereTerm.Default(Convert.ToInt32(value), "id") };
    //            }
    //            else if (Control is dComboBox)
    //            {
    //                ((dComboBox)Control).SelectedValue = value;
    //            }
    //            else if (Control is CheckBox)
    //            {
    //                ((CheckBox)Control).Checked = (bool)value;
    //            }
    //            else if (Control != null)
    //            {
    //                Control.Text = value.ToString();
    //            }

    //            _value = value;
    //        }
    //        // ReSharper restore CanBeReplacedWithTryCastAndCheckForNull
    //    }
    //}
}
