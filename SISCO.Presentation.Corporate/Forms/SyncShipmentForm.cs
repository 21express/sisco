using Devenlab.Common;
using DevExpress.XtraGrid.Views.Grid;
using SISCO.App.Corporate;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Operation.Command;
using SISCO.Presentation.Operation.Forms;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using SISCO.Presentation.Corporate.DataTransferObject;
using System.Web;
using System.Threading;
using System.Globalization;
using Devenlab.Common.Interfaces;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Corporate.Forms
{
    public partial class SyncShipmentForm : BaseForm
    {
        private string BaseAddress { get; set; }
        private string Uri { get; set; }
        private string ErrorBackgroundProcess { get; set; }

        public SyncShipmentForm()
        {
            InitializeComponent();

            form = this;
            Load += SyncShipmentLoad;
            tbxSearch.KeyDown += SearchPodOrderId;
            btnSync.Click += SyncNow;

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void SyncNow(object sender, EventArgs e)
        {
            lblMessage.Text = @"Mohon Tunggu...";
            lblMessage.Visible = true;

            switch((int)cbxSync.SelectedValue)
            {
                case 1:
                    # if(DEBUG)
                    Uri = string.Format("{0}?key={1}&dev={2}", "api/v1/service/g21/order", "jM8xDocB2wCTJJ5m5xcsVyECLkqoZeoFfsAbYdXP", 1);
                    #else
                    Uri = string.Format("{0}?key={1}", "api/v1/service/g21/order", "jM8xDocB2wCTJJ5m5xcsVyECLkqoZeoFfsAbYdXP");
                    # endif
                    BaseAddress = "http://bilna.m-couriersystem.com/";
                    break;
            }

            btnSync.Enabled = false;
            ErrorBackgroundProcess = string.Empty;
            backgroundWorker1.RunWorkerAsync();
        }

        private void SearchPodOrderId(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (!e.Shift)
                    {
                        var pods = GridSync.DataSource as List<ShipmentSyncModel>;
                        if (SyncView.RowCount > 0)
                        {
                            for (int i = 0; i < SyncView.DataRowCount; i++)
                            {
                                string awb = SyncView.GetRowCellValue(i, "Awb").ToString();
                                string orderId = SyncView.GetRowCellValue(i, "OrderId").ToString();
                                if ((awb != null || orderId != null) && (awb.Equals(tbxSearch.Text) || orderId.Contains(tbxSearch.Text)))
                                {
                                    SyncView.FocusedRowHandle = i;
                                    OpenDataEntryForm(SyncView);

                                    tbxSearch.Clear();
                                    return;
                                }
                            }
                        }

                        MessageBox.Show(@"POD or fulfillment not found.");
                        return;
                    }
                    break;
            }
        }

        private void SyncShipmentLoad(object sender, EventArgs e)
        {
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

            SyncView.CustomColumnDisplayText += NumberGrid;
            GridSync.DoubleClick += (sdr, args) => OpenDataEntryForm(SyncView);

            cbxSync.DisplayMember = "Text";
            cbxSync.ValueMember = "Value";

            var items = new List<object>
            {
                new { Text = "Bilna Service", Value = 1 }
            };

            cbxSync.DataSource = items;
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            var sync = new ShipmentSyncDataManager().Get<ShipmentSyncModel>(WhereTerm.Default(false, "imported"));
            GridSync.DataSource = sync;
            SyncView.RefreshData();
        }

        private void OpenDataEntryForm(GridView grid)
        {
            var rows = grid.GetSelectedRows();
            if (grid.RowCount > 0)
            {
                var dataEntryForm = new DataEntryOperationForm();
                BaseControl.CloseOpenedForm = true;
                BaseControl.OpenRelatedForm(dataEntryForm, grid.GetRowCellValue(rows[0], "Awb").ToString(), new DataEntryOperationCommand().GetType(), "Operation");
                if (!dataEntryForm.isAwbAvailable)
                {
                    var numPackage = 0;
                    var parsedPackage = Int32.TryParse(grid.GetRowCellValue(rows[0], "Pieces").ToString(), out numPackage);

                    decimal weight = 0;
                    var parseWeight = decimal.TryParse(grid.GetRowCellValue(rows[0], "ActWeight").ToString(), out weight);

                    decimal packagePrice = 0;
                    var parsePrice = decimal.TryParse(grid.GetRowCellValue(rows[0], "GoodsVal").ToString(), out packagePrice);

                    var phone = grid.GetRowCellValue(rows[0], "Phone").ToString();
                    var customer = lkpGlobalCustomer.Value > 0 ? new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)lkpGlobalCustomer.Value, "id", EnumSqlOperator.Equals)) : null;

                    var destCity = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(grid.GetRowCellValue(rows[0], "City").ToString(), "name", EnumSqlOperator.Equals));
                    var packageType = new PackageTypeDataManager().GetFirst<PackageTypeModel>(WhereTerm.Default("PARCEL", "name", EnumSqlOperator.Equals));
                    var serviceType = new ServiceTypeDataManager().GetFirst<ServiceTypeModel>(WhereTerm.Default(grid.GetRowCellValue(rows[0], "Service").ToString(), "name", EnumSqlOperator.Equals));

                    var shipment = new SISCO.Models.ShipmentModel.ShipmentReportRow
                    {
                        DateProcess = Convert.ToDateTime(grid.GetRowCellValue(rows[0], "PickupDate").ToString()),
                        Code = grid.GetRowCellValue(rows[0], "Awb").ToString(),
                        CustomerId = lkpGlobalCustomer.Value != null ? lkpGlobalCustomer.Value : null,
                        CityId = BaseControl.CityId,
                        DestCityId = destCity != null ? destCity.Id : 0,
                        ShipperName = grid.GetRowCellValue(rows[0], "MerchantContact").ToString() ?? grid.GetRowCellValue(rows[0], "Merchant").ToString(),
                        ShipperAddress = grid.GetRowCellValue(rows[0], "MerchantAddress").ToString() + " " + grid.GetRowCellValue(rows[0], "MerchantDistrict").ToString() + " " + grid.GetRowCellValue(rows[0], "MerchantCity").ToString() + " " + grid.GetRowCellValue(rows[0], "MerchantProvince").ToString(),
                        ShipperPhone = grid.GetRowCellValue(rows[0], "MerchantPhone").ToString(),
                        RefNumber = string.Empty,
                        ConsigneeName = grid.GetRowCellValue(rows[0], "CnName").ToString(),
                        ConsigneeAddress = grid.GetRowCellValue(rows[0], "Address").ToString() + " " + grid.GetRowCellValue(rows[0], "District").ToString() + " " + grid.GetRowCellValue(rows[0], "City").ToString() + " " + grid.GetRowCellValue(rows[0], "Province").ToString(),
                        ConsigneePhone = phone,
                        NatureOfGoods = grid.GetRowCellValue(rows[0], "OrderId").ToString(),
                        Note = grid.GetRowCellValue(rows[0], "ItemName").ToString(),
                        TtlPiece = (short)numPackage,
                        TtlGrossWeight = weight,
                        TtlChargeableWeight = weight,
                        PackageTypeId = packageType != null ? packageType.Id : 0,
                        PaymentMethodId = 0,
                        ServiceTypeId = serviceType != null ? serviceType.Id : 0,
                        Voided = false,
                        Paid = false,
                        IsCod = packagePrice > 0,
                        TotalCod = packagePrice > 0 ? packagePrice : 0,
                        Fulfilment = grid.GetRowCellValue(rows[0], "OrderId").ToString()
                    };

                    dataEntryForm.OpenPopulateForm(shipment);
                    dataEntryForm.Activate();
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            try
            {
                var result = new List<ShipmentDTO>();
                var client = new HttpClient();
                client.BaseAddress = new Uri(BaseAddress);

                backgroundWorker1.ReportProgress(5, "Mohon tunggu...");
                Thread.Sleep(1);
                var task = client.GetAsync(Uri).ContinueWith((s) =>
                {
                    var response = s.Result;
                    var jsonResponse = response.Content.ReadAsStringAsync();
                    jsonResponse.Wait();

                    var jsonConvert = new JavaScriptSerializer();
                    backgroundWorker1.ReportProgress(15, "Unduh 1 file dari Service.");
                    Thread.Sleep(1);
                    var actionResult = jsonConvert.Deserialize<List<ShipmentDTO>>(jsonResponse.Result);
                    if (actionResult != null)
                    {
                        result = actionResult;
                    }

                    var json = new SyncJsonModel
                    {
                        Rowstatus = true,
                        Rowversion = DateTime.Now,
                        Json = jsonResponse.Result,
                        Imported = false,
                        Createdby = BaseControl.UserLogin,
                        Createddate = DateTime.Now,
                        Createdpc = Environment.MachineName
                    };

                    backgroundWorker1.ReportProgress(25, string.Format("Copy {0} pod.", result.Count));
                    new SyncJsonDataManager().Save<SyncJsonModel>(json);
                });

                task.Wait();

                backgroundWorker1.ReportProgress(55, "Extract file...");
                var syncs = new SyncJsonDataManager().Get<SyncJsonModel>(WhereTerm.Default(false, "imported"));
                var i = 0;

                foreach (SyncJsonModel sync in syncs)
                {
                    var jConvert = new JavaScriptSerializer();
                    var aResult = jConvert.Deserialize<List<ShipmentDTO>>(sync.Json);

                    var insertString = new List<string>();
                    i = 0;

                    if (aResult.Count > 0)
                    {
                        foreach (ShipmentDTO obj in result)
                        {
                            i++;
                            int percentage = i * 100 / result.Count;
                            var cod = false;
                            var parseCod = Boolean.TryParse(obj.order.cod, out cod);
                            var shipment = new ShipmentSyncModel
                            {
                                Rowstatus = true,
                                Rowversion = DateTime.Now,
                                Awb = obj.awb,
                                Remark = obj.remark,
                                CnName = HttpUtility.HtmlEncode(obj.consignee.cn_name),
                                Address = HttpUtility.HtmlEncode(obj.consignee.address),
                                District = HttpUtility.HtmlEncode(obj.consignee.distric),
                                City = HttpUtility.HtmlEncode(obj.consignee.city),
                                Province = HttpUtility.HtmlEncode(obj.consignee.province),
                                Country = HttpUtility.HtmlEncode(obj.consignee.country),
                                Phone = HttpUtility.HtmlEncode(obj.consignee.phone),
                                OrderId = HttpUtility.HtmlEncode(obj.order.orderid),
                                ActWeight = obj.order.actweight,
                                Pieces = obj.order.pieces != string.Empty ? Convert.ToInt32(obj.order.pieces) : 0,
                                ItemName = HttpUtility.HtmlEncode(obj.order.items.itemname),
                                GoodsVal = obj.order.goodsval,
                                Insurance = obj.order.insurance,
                                Cod = cod,
                                PickupDate = obj.order.pickupdate,
                                Service = HttpUtility.HtmlEncode(obj.order.service.Equals("REG") ? "REGULAR" : obj.order.service),
                                Imported = false,
                                Merchant = HttpUtility.HtmlEncode(obj.shipper.merchant),
                                MerchantAddress = HttpUtility.HtmlEncode(obj.shipper.merchant_address),
                                MerchantCity = HttpUtility.HtmlEncode(obj.shipper.merchant_city),
                                MerchantDistrict = HttpUtility.HtmlEncode(obj.shipper.merchant_district),
                                MerchantProvince = HttpUtility.HtmlEncode(obj.shipper.merchant_province),
                                MerchantCountry = HttpUtility.HtmlEncode(obj.shipper.merchant_country),
                                MerchantPhone = HttpUtility.HtmlEncode(obj.shipper.merchant_phone),
                                MerchantContact = HttpUtility.HtmlEncode(obj.shipper.merchant_contact),
                                Createddate = DateTime.Now,
                                Createdby = BaseControl.UserLogin,
                                CreatedPc = Environment.MachineName
                            };

                            insertString.Add(string.Format("INSERT INTO shipment_sync(rowstatus, rowversion, awb, remark, cn_name, address, district, city, province, country, phone, order_id, actweight, pieces, itemname, goodsval, insurance, cod, pickupdate, service, merchant, merchant_address, merchant_district, merchant_province, merchant_city, merchant_country, merchant_phone, merchant_contact, imported, createddate, createdby, createdpc) VALUES({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', {12}, {13}, '{14}', {15}, '{16}', {17}, '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', {28}, '{29}', '{30}', '{31}')",
                                1, shipment.Rowversion.ToString("yyyy-MM-dd hh:mm:ss"), shipment.Awb, shipment.Remark, shipment.CnName, shipment.Address, shipment.District,
                                shipment.City, shipment.Province, shipment.Country, shipment.Phone, shipment.OrderId, shipment.ActWeight, shipment.Pieces,
                                shipment.ItemName, shipment.GoodsVal, shipment.Insurance, ((bool)shipment.Cod ? 1 : 0), ((DateTime)shipment.PickupDate).ToString("yyyy-MM-dd hh:mm:ss"), shipment.Service, shipment.Merchant,
                                shipment.MerchantAddress, shipment.MerchantDistrict, shipment.MerchantProvince, shipment.MerchantCity, shipment.MerchantCountry,
                                shipment.MerchantPhone, shipment.MerchantContact, 0, shipment.Createddate.ToString("yyyy-MM-dd hh:mm:ss"), shipment.Createdby, shipment.CreatedPc));

                            backgroundWorker1.ReportProgress(percentage, "Extract file...");
                            Thread.Sleep(1);
                        }

                        new ShipmentSyncDataManager().BulkInsert(string.Join(";", insertString.ToArray()));
                        sync.Imported = true;
                        sync.Modifiedby = BaseControl.UserLogin;
                        sync.Modifieddate = DateTime.Now;
                        sync.Modifiedpc = Environment.MachineName;

                        new SyncJsonDataManager().Update<SyncJsonModel>(sync);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorBackgroundProcess = ex.Message.ToString();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblMessage.Text = e.UserState.ToString();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (ErrorBackgroundProcess != string.Empty)
            {
                lblMessage.Text = ErrorBackgroundProcess;
            }
            else lblMessage.Visible = false;

            progressBar1.Value = 0;
            btnSync.Enabled = true;
            RefreshGrid();
        }
    }
}
