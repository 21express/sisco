using SISCO.Presentation.Common.Forms;
using System;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Data;
using NPOI.SS.UserModel;
using System.Collections;
using System.Collections.Generic;
using SISCO.Presentation.Operation.Forms;
using DevExpress.XtraGrid.Views.Grid;
using SISCO.Presentation.Common.Interfaces;
using System.Windows.Forms;
using SISCO.Presentation.Common;
using SISCO.Models;
using Devenlab.Common.Interfaces;
using SISCO.Presentation.MasterData.Popup;
using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Presentation.Operation.Command;
using System.Linq;
using System.Drawing;

namespace SISCO.Presentation.Corporate.Forms
{
    public partial class BulkDataEntryForm : BaseForm
    {
        public BulkDataEntryForm()
        {
            InitializeComponent();

            form = this;
            Load += BulkDataEntryLoad;
        }

        private void BulkDataEntryLoad(object sender, EventArgs e)
        {
            ImportView.CustomColumnDisplayText += NumberGrid;
            GridImport.DoubleClick += (sdr, args) => OpenDataEntryForm(ImportView);
            GridImport.KeyDown += (sdr, args) =>
            {
                switch (args.KeyCode)
                {
                    case Keys.Enter:
                        OpenDataEntryForm(ImportView);
                        break;
                }

                base.OnKeyDown(args);
            };

            lkpGlobalCustomer.LookupPopup =
                new CustomerPopup(new IListParameter[]
                {
                    WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                    WhereTerm.Default("0", "disabled", EnumSqlOperator.Equals)
                });
            lkpGlobalCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpGlobalCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpGlobalCustomer.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1 AND disabled = @2", s, BaseControl.BranchId, "0");

            lkpGlobalService.LookupPopup = new ServicePopup();
            lkpGlobalService.AutoCompleteDataManager = new ServiceDataManager();
            lkpGlobalService.AutoCompleteDisplayFormater = model => ((ServiceTypeModel)model).Name;
            lkpGlobalService.AutoCompleteWheretermFormater = s => new IListParameter[]
                {
                    WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
                };

            lkpGlobalPayment.LookupPopup = new PaymentMethodPopup(new IListParameter[] { WhereTerm.Default("CASH", "name", EnumSqlOperator.NotEqual) });
            lkpGlobalPayment.AutoCompleteDataManager = new PaymentMethodDataManager();
            lkpGlobalPayment.AutoCompleteDisplayFormater = model => ((PaymentMethodModel)model).Name;
            lkpGlobalPayment.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            btnOpen.Click += (s, eargs) => ofd1.ShowDialog();
            cbxTypeData.DisplayMember = "Text";
            cbxTypeData.ValueMember = "Value";

            var items = new List<object>
            {
                new { Text = "Excel Bilna", Value = 1 },
                new { Text = "Excel Quantium", Value = 2 },
                new { Text = "Excel Oriflame", Value = 3 },
                new { Text = "Excel Blanik/Etoobe", Value = 4 }
            };

            cbxTypeData.DataSource = items;
            ofd1.FileOk += GetFile;

            tbxSearchPod.KeyDown += SearchPod;
            ImportView.RowStyle += ChangeColor;
        }

        private void SearchPod(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (!e.Shift)
                    {
                        var pods = GridImport.DataSource as List<ExcelDataTransferModel>;
                        if (ImportView.RowCount > 0)
                        {
                            for (int i = 0; i < ImportView.DataRowCount; i++)
                            {
                                object b = ImportView.GetRowCellValue(i, "AWB");
                                if (b != null && b.Equals(tbxSearchPod.Text))
                                {
                                    ImportView.FocusedRowHandle = i;
                                    OpenDataEntryForm(ImportView);

                                    tbxSearchPod.Clear();
                                    return;
                                }
                            }
                        }

                        MessageBox.Show(@"POD not found.");
                        return;
                    }
                    break;
            }
        }

        private void ChangeColor(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;

                if (view == null) return;

                e.Appearance.ForeColor = Color.Black;
                if ((bool)view.GetRowCellValue(e.RowHandle, view.Columns["Exists"]))
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.Transparent;
                }
            }
        }

        private void OpenDataEntryForm(GridView grid)
        {
            var rows = grid.GetSelectedRows();
            if (grid.RowCount > 0)
            {
                var dataEntryForm = new DataEntryEcommerceForm();
                BaseControl.CloseOpenedForm = true;
                BaseControl.OpenRelatedForm(dataEntryForm, grid.GetRowCellValue(rows[0], "AWB").ToString(), new DataEntryEcommerceCommand().GetType(), "Operation");
                if (!dataEntryForm.isAwbAvailable)
                {
                    var numPackage = 0;
                    var parsedPackage = Int32.TryParse(grid.GetRowCellValue(rows[0], "NumberPackage").ToString(), out numPackage);

                    decimal weight = 0;
                    var parseWeight = decimal.TryParse(grid.GetRowCellValue(rows[0], "Weight").ToString(), out weight);

                    decimal packagePrice = 0;
                    var parsePrice = decimal.TryParse(grid.GetRowCellValue(rows[0], "PackagePrice").ToString(), out packagePrice);

                    var phone = grid.GetRowCellValue(rows[0], "ConsigneePhone1").ToString() ?? grid.GetRowCellValue(rows[0], "ConsigneePhone2").ToString() ?? grid.GetRowCellValue(rows[0], "ConsigneePhone3").ToString();

                    var destCity = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(grid.GetRowCellValue(rows[0], "ConsigneeCity").ToString(), "name", EnumSqlOperator.Like));
                    var customer = lkpGlobalCustomer.Value > 0 ? new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)lkpGlobalCustomer.Value, "id", EnumSqlOperator.Equals)) : null;

                    var packageType = new PackageTypeDataManager().GetFirst<PackageTypeModel>(WhereTerm.Default(grid.GetRowCellValue(rows[0], "PackageType").ToString(), "name", EnumSqlOperator.Equals));
                    var paymentMethod = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default(grid.GetRowCellValue(rows[0], "PaymentMethod").ToString(), "name", EnumSqlOperator.Equals));
                    var serviceType = new ServiceTypeDataManager().GetFirst<ServiceTypeModel>(WhereTerm.Default(grid.GetRowCellValue(rows[0], "ServiceType").ToString(), "name", EnumSqlOperator.Equals));

                    var shipment = new SISCO.Models.ShipmentModel.ShipmentReportRow
                    {
                        DateProcess = tbxGlobalDate.Text != string.Empty ? tbxGlobalDate.Value : DateTime.Now,
                        Code = grid.GetRowCellValue(rows[0], "AWB").ToString(),
                        CustomerId = lkpGlobalCustomer.Value != null ? lkpGlobalCustomer.Value : null,
                        CityId = BaseControl.CityId,
                        DestCityId = 0,
                        ShipperName = grid.GetRowCellValue(rows[0], "ShipperName").ToString() != string.Empty ? grid.GetRowCellValue(rows[0], "ShipperName").ToString() : customer != null ? customer.Name : string.Empty,
                        ShipperAddress = grid.GetRowCellValue(rows[0], "ShipperAddress").ToString() != string.Empty ? grid.GetRowCellValue(rows[0], "ShipperAddress").ToString() : customer != null ? customer.Address : string.Empty,
                        ShipperPhone = grid.GetRowCellValue(rows[0], "ShipperPhone").ToString() != string.Empty ? grid.GetRowCellValue(rows[0], "ShipperPhone").ToString() : customer != null ? customer.Phone : string.Empty,
                        RefNumber = string.Empty,
                        ConsigneeName = grid.GetRowCellValue(rows[0], "ConsigneeName").ToString(),
                        ConsigneeAddress = grid.GetRowCellValue(rows[0], "ConsigneeAddress").ToString(),
                        ConsigneePhone = phone,
                        GoodsValue = packagePrice,
                        Note = grid.GetRowCellValue(rows[0], "PackageDescription").ToString(),
                        TtlPiece = (short)numPackage,
                        TtlGrossWeight = weight,
                        TtlChargeableWeight = weight,
                        PackageTypeId = packageType != null ? packageType.Id : 0,
                        PaymentMethodId = lkpGlobalPayment.Value != null ? (int)lkpGlobalPayment.Value : (paymentMethod != null ? paymentMethod.Id : 0),
                        ServiceTypeId = lkpGlobalService.Value != null ? (int)lkpGlobalService.Value : (serviceType != null ? serviceType.Id : 0),
                        Voided = false,
                        Paid = false,
                        IsCod = packagePrice > 0,
                        TotalCod = packagePrice > 0 ? packagePrice : 0,
                        Fulfilment = grid.GetRowCellValue(rows[0], "FulFillment").ToString(),
                        PrintEconnote = cbxPrintConnote.Checked
                    };

                    dataEntryForm.OpenPopulateForm(shipment, this);
                    dataEntryForm.Activate();
                }
            }
        }

        private void GetFile(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var path = ofd1.FileName;
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                if (Path.GetExtension(ofd1.FileName) == ".xls")
                {
                    var hssWorkbook = new HSSFWorkbook(file);

                    ISheet sheet = hssWorkbook.GetSheetAt(0);
                    IEnumerator rows = sheet.GetRowEnumerator();

                    GridImport.DataSource = ExtractData(rows);
                }
                else
                {
                    var wssWorkbook = new XSSFWorkbook(file);

                    ISheet sheet = wssWorkbook.GetSheetAt(0);
                    IEnumerator rows = sheet.GetRowEnumerator();

                    GridImport.DataSource = ExtractData(rows);
                }

                ImportView.RefreshData();
                if (ImportView.RowCount > 0) CheckExists();

                tbxSearchPod.Clear();
                tbxSearchPod.Focus();
            }
        }

        private void CheckExists()
        {
            var pod = new List<string>();
            for(var i = 0; i < ImportView.RowCount; i++)
            {
                var code = ImportView.GetRowCellValue(i, "AWB").ToString();
                if (!string.IsNullOrEmpty(code)) pod.Add(code);
            }

            var shipmentcodes = new ShipmentDataManager().CheckPodNumber(pod.ToArray());
            foreach (string s in shipmentcodes)
            {
                var rowhandle = ImportView.LocateByValue("AWB", s);
                ImportView.SetRowCellValue(rowhandle, ImportView.Columns["Exists"], true);
            }
        }

        private List<ExcelDataTransferModel> ExtractData(IEnumerator rows)
        {
            var dataTransfer = new List<ExcelDataTransferModel>();
            switch ((int)cbxTypeData.SelectedValue)
            {
                case 1 :
                    dataTransfer = ExtractData1(rows);
                    break;
                case 2:
                    dataTransfer = ExtractData2(rows);
                    break;
                case 3:
                    dataTransfer = ExtractData3(rows);
                    break;
                case 4:
                    dataTransfer = ExtractData4(rows);
                    break;
            }

            return dataTransfer;
        }

        private List<ExcelDataTransferModel> ExtractData1(IEnumerator rows)
        {
            rows.MoveNext();
            rows.MoveNext();

            var dataTransfer = new List<ExcelDataTransferModel>();
            while (rows.MoveNext())
            {
                IRow row = (XSSFRow)rows.Current;

                if (row.GetCell(0) == null) break;

                var numPackage = 0;
                var parsedPackage = Int32.TryParse(row.GetCell(3).ToString(), out numPackage);

                decimal weight = 0;
                var parseWeight = decimal.TryParse(row.GetCell(12).ToString(), out weight);

                decimal packagePrice = 0;
                var parsePrice = decimal.TryParse(row.GetCell(17).ToString(), out packagePrice);

                var excelRow = new ExcelDataTransferModel
                {
                    ServiceType = row.GetCell(2).ToString().Equals("REG") ? "REGULAR" : row.GetCell(2).ToString(),
                    PackageType = "PARCEL",
                    PaymentMethod = "COLLECT",
                    NumberPackage = numPackage,
                    ConsigneeName = row.GetCell(5).ToString(),
                    ConsigneeAddress = row.GetCell(6).ToString(),
                    ConsigneeCity = row.GetCell(21).ToString(),
                    ConsigneePhone1 = row.GetCell(9).ToString(),
                    ConsigneePhone2 = row.GetCell(10).ToString(),
                    ConsigneePhone3 = row.GetCell(11).ToString(),
                    Weight = weight,
                    PackageDescription = row.GetCell(13).ToString(),
                    FulFillment = row.GetCell(15).ToString(),
                    AWB = row.GetCell(16).ToString(),
                    PackagePrice = packagePrice,
                    ShipperName = string.Empty,
                    ShipperAddress = string.Empty,
                    ShipperPhone = string.Empty
                };

                dataTransfer.Add(excelRow);
            }

            return dataTransfer;
        }

        private List<ExcelDataTransferModel> ExtractData2(IEnumerator rows)
        {
            rows.MoveNext();
            rows.MoveNext();

            var dataTransfer = new List<ExcelDataTransferModel>();
            while (rows.MoveNext())
            {
                IRow row = (XSSFRow)rows.Current;

                if (row.GetCell(0) == null) break;

                var numPackage = 0;
                var parsedPackage = Int32.TryParse(row.GetCell(4).ToString(), out numPackage);

                decimal weight = 0;
                var parseWeight = decimal.TryParse(row.GetCell(5).ToString(), out weight);

                decimal packagePrice = 0;
                var parsePrice = decimal.TryParse(row.GetCell(20).ToString(), out packagePrice);

                var excelRow = new ExcelDataTransferModel
                {
                    ServiceType = row.GetCell(18).ToString(),
                    PackageType = row.GetCell(17).ToString(),
                    PaymentMethod = row.GetCell(19).ToString(),
                    NumberPackage = numPackage,
                    ConsigneeName = row.GetCell(14).ToString(),
                    ConsigneeAddress = row.GetCell(15).ToString(),
                    ConsigneeCity = row.GetCell(7).ToString(),
                    ConsigneePhone1 = row.GetCell(16).ToString(),
                    ConsigneePhone2 = string.Empty,
                    ConsigneePhone3 = string.Empty,
                    Weight = weight,
                    PackageDescription = string.Empty,
                    FulFillment = row.GetCell(13).ToString(),
                    AWB = row.GetCell(1).ToString(),
                    PackagePrice = packagePrice,
                    ShipperName = row.GetCell(10).ToString(),
                    ShipperAddress = row.GetCell(11).ToString(),
                    ShipperPhone = row.GetCell(12).ToString()
                };

                dataTransfer.Add(excelRow);
            }

            return dataTransfer;
        }

        private List<ExcelDataTransferModel> ExtractData3(IEnumerator rows)
        {
            rows.MoveNext();
            rows.MoveNext();
            rows.MoveNext();
            rows.MoveNext();

            var dataTransfer = new List<ExcelDataTransferModel>();
            while (rows.MoveNext())
            {
                IRow row = (IRow)rows.Current;// Path.GetExtension(ofd1.FileName) == "xls" ? (IRow)rows.Current : rows.Current;

                if (string.IsNullOrEmpty(row.GetCell(2).ToString())) break;

                var numPackage = 1;

                decimal weight = 0;
                var parseWeight = decimal.TryParse(row.GetCell(10).ToString(), out weight);

                decimal packagePrice = 0;
                var parsePrice = decimal.TryParse(row.GetCell(12).ToString(), out packagePrice);

                var excelRow = new ExcelDataTransferModel
                {
                    ServiceType = "REG",
                    PackageType = "PARCEL",
                    PaymentMethod = "CREDIT",
                    NumberPackage = numPackage,
                    ConsigneeName = string.Format("{0} {1}", row.GetCell(3).ToString(), row.GetCell(4).ToString()),
                    ConsigneeAddress = row.GetCell(5).ToString(),
                    ConsigneeCity = string.Empty,
                    ConsigneePhone1 = row.GetCell(6).ToString(),
                    ConsigneePhone2 = string.Empty,
                    ConsigneePhone3 = string.Empty,
                    Weight = weight,
                    PackageDescription = string.Empty,
                    FulFillment = row.GetCell(8).ToString(),
                    AWB = row.GetCell(15).ToString(),
                    PackagePrice = packagePrice,
                    ShipperName = string.Empty,
                    ShipperAddress = string.Empty,
                    ShipperPhone = string.Empty
                };

                dataTransfer.Add(excelRow);
            }

            return dataTransfer;
        }

        private List<ExcelDataTransferModel> ExtractData4(IEnumerator rows)
        {
            rows.MoveNext();

            var dataTransfer = new List<ExcelDataTransferModel>();
            while (rows.MoveNext())
            {
                IRow row = (IRow)rows.Current;// Path.GetExtension(ofd1.FileName) == "xls" ? (IRow)rows.Current : rows.Current;

                if (string.IsNullOrEmpty(row.GetCell(1).ToString())) break;

                var numPackage = 1;

                decimal weight = 0;
                var parseWeight = decimal.TryParse(row.GetCell(5).ToString(), out weight);

                decimal packagePrice = 0;
                var parsePrice = decimal.TryParse(row.GetCell(12).ToString(), out packagePrice);

                var excelRow = new ExcelDataTransferModel
                {
                    ServiceType = "ECO",
                    PackageType = "PARCEL",
                    PaymentMethod = "CREDIT",
                    NumberPackage = numPackage,
                    ConsigneeName = row.GetCell(8).ToString(),
                    ConsigneeAddress = row.GetCell(9).ToString(),
                    ConsigneeCity = row.GetCell(6).ToString(),
                    ConsigneePhone1 = row.GetCell(10).ToString(),
                    ConsigneePhone2 = string.Empty,
                    ConsigneePhone3 = string.Empty,
                    Weight = weight,
                    PackageDescription = row.GetCell(2).ToString(),
                    FulFillment = row.GetCell(7).ToString(),
                    AWB = row.GetCell(1).ToString(),
                    PackagePrice = packagePrice,
                    ShipperName = string.Empty,
                    ShipperAddress = string.Empty,
                    ShipperPhone = string.Empty,
                    Exists = false
                };

                dataTransfer.Add(excelRow);
            }

            return dataTransfer;
        }

        public override void AdditionalAction()
        {
            CheckExists();
        }
    }

    public class ExcelDataTransferModel
    {
        public string ServiceType { get; set; }
        public int NumberPackage { get; set; }
        public string ShipperName { get; set; }
        public string ShipperAddress { get; set; }
        public string ShipperPhone { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneeAddress { get; set; }
        public string ConsigneeCity { get; set; }
        public string ConsigneePhone1 { get; set; }
        public string ConsigneePhone2 { get; set; }
        public string ConsigneePhone3 { get; set; }
        public decimal Weight { get; set; }
        public string PackageDescription { get; set; }
        public string FulFillment { get; set; }
        public string AWB { get; set; }
        public decimal PackagePrice { get; set; }
        public string PackageType { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsCod { get; set; }
        public decimal TotalCod { get; set; }
        public bool Exists { get; set; }
    }
}
