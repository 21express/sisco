using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using Devenlab.Common;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Annotations;

namespace SISCO.Presentation.Billing.Forms
{
    public partial class ImportShipmentListForm : BaseForm
    {

        public class ShipmentDataRow : ShipmentModel, INotifyPropertyChanged
        {
            public PaymentMethodDataManager PaymentMethodDataManager { get; set; }
            public PackageTypeDataManager PackageTypeDataManager { get; set; }

            public bool ImportProcessed { get; set; }
            public bool DupsFound { get; set; }

            private string _paymentMethod;
            public new string PaymentMethod
            {
                get
                {
                    if (string.IsNullOrEmpty(_paymentMethod) && PaymentMethodId != 0)
                    {
                        var model = PaymentMethodDataManager.GetFirst<PaymentMethodModel>(WhereTerm.Default(PaymentMethodId, "id"));
                        if (model != null)
                        {
                            _paymentMethod = string.Format("{0}", model.Name);
                        }
                    }
                    return _paymentMethod;
                }
                set { _paymentMethod = value; }
            }
            private string _packageType;
            public new string PackageType
            {
                get
                {
                    if (string.IsNullOrEmpty(_packageType) && PackageTypeId != 0)
                    {
                        var model =
                            PackageTypeDataManager.GetFirst<PackageTypeModel>(WhereTerm.Default(PackageTypeId, "id"));
                        if (model != null)
                        {
                            _packageType = string.Format("{0}", model.Name);
                        }
                    }
                    return _packageType;
                }
                set { _packageType = value; }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }

            internal void NotifyUpdate(string propertyName)
            {
                OnPropertyChanged(propertyName);

                switch (propertyName)
                {
                    case "PaymentMethodId":
                        PaymentMethod = null;
                        NotifyUpdate("PaymentMethod");
                        break;
                    case "PackageTypeId":
                        base.PackageType = null;
                        NotifyUpdate("PackageType");
                        break;
                }
            }
        }

        public PaymentMethodDataManager PaymentMethodDataManager { get; set; }
        public PackageTypeDataManager PackageTypeDataManager { get; set; }
        public BindingList<ShipmentDataRow> Shipments { get; set; }

        public ImportShipmentListForm()
        {
            InitializeComponent();

            Shipments = new BindingList<ShipmentDataRow>();
            PackageTypeDataManager = new PackageTypeDataManager();
            PaymentMethodDataManager = new PaymentMethodDataManager();

            grid.DataSource = Shipments;

            gridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.Appearance.FocusedCell.Options.UseForeColor = false;
            gridView.OptionsNavigation.UseTabKey = false;
            gridView.OptionsBehavior.FocusLeaveOnTab = true;

            gridView.RowCellStyle += (o, args) =>
            {
                if (args.RowHandle < 0) return;

                if (((bool)gridView.GetRowCellValue(args.RowHandle, "DupsFound")))
                {
                    args.Appearance.ForeColor = Color.Red;
                }
                else if (((bool)gridView.GetRowCellValue(args.RowHandle, "ImportProcessed")))
                {
                    args.Appearance.ForeColor = Color.Blue;
                }
                else
                {
                    args.Appearance.ForeColor = Color.Black;
                }
            };

            btnImport.Click += (sender, args) =>
            {
                var skippedColumns = new[] { "Printed", "Cancelled", "Invoiced", "Voided", "InvoiceRef", "InvoiceId", "PaymentReceiptNumber", "Paid", "PaidDelivery", "Manifested", "PodSent", "PodReceived", "PodReturned", "PaidMc" };
                
                using (var dialog = new OpenFileDialog())
                {
                    dialog.InitialDirectory = Directory.GetCurrentDirectory();
                    dialog.Filter = @"Microsoft Excel 2007 files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (!File.Exists(dialog.FileName)) return;

                        var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; data source={0}; Extended Properties=\"Excel 12.0 Xml;HDR=YES\"", dialog.FileName);
                        using (var conn = new OleDbConnection(connectionString))
                        {
                            conn.Open();

                            var modelProperties = typeof(ShipmentModel).GetProperties();
                            var expectedColumnCount = modelProperties.Count();
                            var properties = modelProperties.Where(row => !skippedColumns.Contains(row.Name)).ToArray();

                            var fieldNames = properties.Select(row => row.Name).ToArray();
                            var mapping = new int[properties.Length];

                            using (var cmd = new OleDbCommand("SELECT * FROM [Sheet$]", conn))
                            {
                                var reader = cmd.ExecuteReader();

                                if (reader.HasRows)
                                {
                                    if (reader.FieldCount != expectedColumnCount)
                                    {
                                        MessageBox.Show(@"The column count does not match with the expected excel template");
                                        return;
                                    }

                                    for (var i = 0; i < reader.FieldCount; i++)
                                    {
                                        var inflected = reader.GetName(i).Replace(" ", string.Empty);
                                        var pos = Array.IndexOf(fieldNames, inflected);

                                        if (pos >= 0)
                                        {
                                            mapping[pos] = i;
                                        }
                                    }
                                }

                                Shipments.RaiseListChangedEvents = false;

                                while (reader.Read())
                                {
                                    var instance = Activator.CreateInstance(typeof(ShipmentDataRow));

                                    for (var i = 0; i < mapping.Length; i++)
                                    {
                                        if (reader.IsDBNull(mapping[i])) continue;

                                        var t = Nullable.GetUnderlyingType(properties[i].PropertyType) ?? properties[i].PropertyType;
                                        var value = reader.GetValue(mapping[i]);

                                        if (t == typeof(EnumStateChange))
                                        {
                                            continue;
                                        }
                                        if (t == typeof(Boolean))
                                        {
                                            if (value.Equals("Unchecked"))
                                            {
                                                value = false;
                                            }
                                            else if (value.Equals("Checked"))
                                            {
                                                value = true;
                                            }
                                        }

                                        properties[i].SetValue(instance, Convert.ChangeType(value, t), null);
                                    }

                                    ((ShipmentDataRow)instance).PackageTypeDataManager = PackageTypeDataManager;
                                    ((ShipmentDataRow)instance).PaymentMethodDataManager = PaymentMethodDataManager;

                                    Shipments.Add(instance as ShipmentDataRow);
                                }

                                var existingIds = new ShipmentDataManager().GetByCodes(Shipments.Select(row => row.Code));

                                Shipments.ForEach(row =>
                                {
                                    if (existingIds.Contains(row.Code))
                                    {
                                        row.DupsFound = true;
                                    }
                                });

                                Shipments.RaiseListChangedEvents = true;
                                Shipments.ResetBindings();
                            }

                            conn.Close();
                        }
                    }
                }
            };

            btnSave.Click += (sender, args) =>
            {
                if (Shipments.Count == 0) return;

                var found = 0;
                Shipments.RaiseListChangedEvents = false;
             
                using (var scope = new TransactionScope())
                {
                    var shipmentDM = new ShipmentDataManager();

                    Shipments.ForEach(row =>
                    {
                        if (row.DupsFound) return;

                        shipmentDM.Save<ShipmentModel>(row);

                        row.ImportProcessed = true;

                        found++;
                    });

                    shipmentDM.Dispose();

                    scope.Complete();
                }

                Shipments.RaiseListChangedEvents = true;
                Shipments.ResetBindings();

                if (found > 0)
                {
                    MessageBox.Show(string.Format("{0} shipment record successfully imported", found));
                    Shipments.Clear();
                    Shipments.ResetBindings();
                }
                else
                {
                    MessageBox.Show(@"No shipment record imported!");
                }
            };

            grid.DoubleClick += (o, args) =>
            {
                var rows = gridView.GetSelectedRows();

                if (rows.Count() > 0 && (((bool)gridView.GetRowCellValue(rows[0], "DupsFound")) || ((bool)gridView.GetRowCellValue(rows[0], "ImportProcessed"))))
                {
                    BaseControl.OpenRelatedForm(new ValidateShipmentOrderForm(), gridView.GetRowCellValue(rows[0], "Code").ToString(), CallingCommand);
                }
            };
        }
    }
}
