using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraReports.UI;
using SISCO.App.Administration;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Operation.Popup;
using SISCO.Presentation.Operation.Reports;
using BaseControl = SISCO.Presentation.Common.BaseControl;
using SISCO.Presentation.Operation.Command;
using SISCO.Presentation.Common;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class AcceptanceForm : BaseCrudForm<ShipmentModel, ShipmentDataManager>//BaseToolbarForm//
    {
        public AcceptanceForm()
        {
            InitializeComponent();

            form = this;
            Load += AcceptanceLoad;

            tbxWeight.Leave += Calculate;
            tbxNo.Leave += (sender, args) =>
            {
                if (CheckCn() && !string.IsNullOrEmpty(tbxNo.Text))
                {
                    var model = new ShipmentNumberAllocationDataManager().GetFirst<ShipmentAllocationModel>(
                        WhereTerm.Default(Convert.ToInt64(tbxNo.Text), "shipment_code_start", EnumSqlOperator.LesThanEqual),
                        WhereTerm.Default(Convert.ToInt64(tbxNo.Text), "shipment_code_end", EnumSqlOperator.GreatThanEqual)
                    );

                    if (model != null)
                    {
                        if (model.FranchiseId != null)
                        {
                            var code = tbxNo.Text;

                            New();

                            var dataEntryForm = new DataEntryFranchiseForm();
                            BaseControl.OpenDataEntryFranchiseForm(dataEntryForm, code, new DataEntryFranchiseCommand().GetType(), "Operation");
                        }

                        if (model.DropPointId != null)
                        {
                            var code = tbxNo.Text;

                            New();

                            MessageForm.Warning(form, "POD Cash", string.Format("POD {0} sudah dialokasi untuk transaksi Cash. Silakan info ke Counter Cash.", code));
                            return;
                        }

                        if (model.CustomerId != null)
                        {
                            var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)model.CustomerId, "id"));
                            if (customer != null)
                            {
                                if (customer.ServiceTypeId != null)
                                {
                                    tbxService.DefaultValue = new IListParameter[] { WhereTerm.Default((int)customer.ServiceTypeId, "id") };
                                }
                            }
                        }
                    }
                }
            };

            FormTrackingStatus = EnumTrackingStatus.Acceptance;
            btnSave.Click += (sender, args) => Save();

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                WhereTerm.Default(0,"sales_type_id", EnumSqlOperator.Equals)
            };

            tbxDestination.Leave += (sender, args) => CheckCityCourier();
            tbxDate.KeyDown += CursorBarcode;

            tsBaseTxt_Code.KeyDown += SearchBarcodeCursor;
            btnSave.PreviewKeyDown += (sender, args) =>
            {
                if (args.KeyCode == Keys.Up)
                    tbxChargeable.Focus();
                if (args.KeyCode == Keys.Down)
                    tsBaseTxt_Code.Focus();
            };
        }

        private void SearchBarcodeCursor(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                case Keys.Up:
                    btnSave.Focus();
                    break;
                case Keys.Left:
                case Keys.Down:
                    tbxDate.Focus();
                    break;
            }
        }

        private void CursorBarcode(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                case Keys.Up:
                    tsBaseTxt_Code.Focus();
                    break;
            }
        }

        private void CheckCityCourier()
        {
            if (tbxDestination.Value == null) return;
            var cityCourier = new BranchCityListDataManager().GetFirst<BranchCityListModel>(new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                WhereTerm.Default((int) tbxDestination.Value, "city_id", EnumSqlOperator.Equals)
            });

            if (cityCourier != null)
            {
                tbxService.DefaultValue = new IListParameter[] { WhereTerm.Default("CITY COURIER", "name", EnumSqlOperator.Equals) };
            }
        }

        private void Calculate(object sender, EventArgs e)
        {
            base.OnLeave(e);
            var isDomestic = true;

            if (tbxDestination.Value != null)
            {
                var city = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default((int) tbxDestination.Value,"id",EnumSqlOperator.Equals));
                var country =
                    new CountryDataManager().GetFirst<CountryModel>(WhereTerm.Default(city.CountryId, "id",
                        EnumSqlOperator.Equals));
                if (country.PricingPlanId != null)
                {
                    var zone = new PricingPlanDataManager().GetFirst<PricingPlanModel>(WhereTerm.Default((int) country.PricingPlanId,"id", EnumSqlOperator.Equals));
                    if (zone.Zone != "DOMESTIK") isDomestic = false;
                }
            }

            RoundedUp(tbxWeight.Value, tbxChargeable, isDomestic);
        }

        private void AcceptanceLoad(object sender, EventArgs e)
        {
            VisibleBtnSave = false;
            VisibleBtnPrint = false;
            VisibleBtnPrintPreview = false;
            EnableBtnSearch = true;
            btnSave.Enabled = false;

            btnPrint.Click += PrintBarcode;
            SearchPopup = new AcceptanceFilterPopup();

            tbxPIC.LookupPopup = new MessengerPopup();
            tbxPIC.AutoCompleteDataManager = new EmployeeDataManager();
            tbxPIC.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            tbxPIC.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_messenger AND branch_id = @1", s, BaseControl.BranchId);

            tbxPIC2.LookupPopup = new MessengerPopup();
            tbxPIC2.AutoCompleteDataManager = new EmployeeDataManager();
            tbxPIC2.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            tbxPIC2.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_messenger AND branch_id = @1", s, BaseControl.BranchId);

            tbxDestination.LookupPopup = new CityPopup();
            tbxDestination.AutoCompleteDataManager = new CityDataManager();
            tbxDestination.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            tbxDestination.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            tbxPackage.LookupPopup = new PackagePopup();
            tbxPackage.AutoCompleteDataManager = new PackageDataManager();
            tbxPackage.AutoCompleteDisplayFormater = model => ((PackageTypeModel)model).Name;
            tbxPackage.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            tbxService.LookupPopup = new ServicePopup();
            tbxService.AutoCompleteDataManager = new ServiceDataManager();
            tbxService.AutoCompleteDisplayFormater = model => ((ServiceTypeModel)model).Name;
            tbxService.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            tbxPayment.LookupPopup = new PaymentMethodPopup(new IListParameter[] { WhereTerm.Default("CASH", "name", EnumSqlOperator.NotEqual) });
            tbxPayment.AutoCompleteDataManager = new PaymentMethodDataManager();
            tbxPayment.AutoCompleteDisplayFormater = model => ((PaymentMethodModel)model).Name;
            tbxPayment.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith),
                WhereTerm.Default("CASH", "name", EnumSqlOperator.NotEqual)
            };

            tbxPiece.IsNumber = true;
            tbxStart.IsNumber = true;
            tbxEnd.IsNumber = true;
        }

        private void PrintBarcode(object sender, EventArgs e)
        {
            var mdl = CurrentModel as ShipmentModel;

            if (tbxStart.Value < 2) tbxStart.Value = 2;
            if (tbxEnd.Value > mdl.TtlPiece) tbxEnd.Value = mdl.TtlPiece;

            var shipment = DataManager.GetFirst<ShipmentModel>(WhereTerm.Default(mdl.Id, "id", EnumSqlOperator.Equals));
            var orig = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(shipment.CityId, "id",
                EnumSqlOperator.Equals));
            var dest = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(shipment.DestCityId, "id",
                EnumSqlOperator.Equals));
            var service = new ServiceTypeDataManager().GetFirst<ServiceTypeModel>(WhereTerm.Default(mdl.ServiceTypeId, "id", EnumSqlOperator.Equals));
            var barcode = new List<PrintBarcode>();
            for (var i = tbxStart.Value; i <= tbxEnd.Value; i++)
            {
                barcode.Add(new PrintBarcode
                {
                    DateProcess = mdl.DateProcess,
                    BranchName = orig.Name,
                    DestBranchName = dest.Name,
                    Number = i.ToString("#"),
                    Code = shipment.Code + i.ToString("000"),
                    Count = mdl.TtlPiece,
                    ServiceType = service.Name,
                    GrossWeight = shipment.TtlChargeableWeight
                });
            }

            var a = new CnBarcodeCard();
            a.DataSource = barcode;
            a.CreateDocument();

            var printTool = new ReportPrintTool(a);
            printTool.PrintingSystem.StartPrint += (o, args) =>
            {
                args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.Barcode;
            };
            printTool.Print();
        }

        public override void New()
        {
            int? pic;
            int? pic2 = null;

            if (CurrentModel != null)
            {
                pic = ((ShipmentModel) CurrentModel).MessengerId;
                pic2 = ((ShipmentModel)CurrentModel).MessengerId2;
            }
            else pic = BaseControl.EmployeeId;

            var printBarcode = cbxPrint.Checked;

            base.New();

            _ClearForm(pnlBody1);
            _ClearForm(pnlBody2);

            ToolbarCode = string.Empty;

            btnSave.Enabled = true;
            gbPrint.Visible = false;

            if (pic != null)
            {
                var employee =
                    new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int) pic, "id",
                        EnumSqlOperator.Equals));
                if (employee != null && employee.AsMessenger)
                    tbxPIC.DefaultValue = new IListParameter[] {WhereTerm.Default((int) pic, "id", EnumSqlOperator.Equals)};
            }

            if (pic2 != null)
            {
                var employee =
                    new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)pic2, "id",
                        EnumSqlOperator.Equals));
                if (employee != null && employee.AsMessenger)
                    tbxPIC2.DefaultValue = new IListParameter[] { WhereTerm.Default((int)pic2, "id", EnumSqlOperator.Equals) };
            }

            tbxPackage.DefaultValue = new IListParameter[] { WhereTerm.Default("PARCEL", "name", EnumSqlOperator.Equals) };
            tbxService.DefaultValue = new IListParameter[] { WhereTerm.Default("REGULAR", "name", EnumSqlOperator.Equals) };
            tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default("CREDIT", "name", EnumSqlOperator.Equals) };
            
            tbxPayment.Enabled = false;
            tbxPayment.Properties.Buttons[0].Enabled = false;

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            tbxPiece.SetValue(Resources.default_number);
            tbxWeight.SetValue(Resources.default_number);
            tbxChargeable.SetValue(Resources.default_number);

            tbxDate.Text = DateTime.Now.ToString();
            tbxPIC.Focus();
            tbxNo.ReadOnly = false;

            cbxPrint.Checked = printBarcode;
        }

        private bool CheckCn()
        {
            if (tbxNo.Text != "")
            {
                if (tbxNo.Text.Length != 12)
                {
                    MessageBox.Show(Resources.cn_less_12, Resources.information, MessageBoxButtons.OK);
                    tbxNo.Text = string.Empty;
                    tbxNo.Focus();
                    return false;
                }

                var ship = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxNo.Text, "code", EnumSqlOperator.Equals));
                if (ship != null)
                {
                    if (ship.Id != CurrentModel.Id)
                    {
                        MessageBox.Show(Resources.cn_exists, Resources.information, MessageBoxButtons.OK);
                        //tbxNo.Focus();
                        tsBaseTxt_Code.Text = tbxNo.Text;
                        tbxNo.Text = "";
                        tsBaseTxt_Code.Focus();
                        return false;
                    }
                }

                if (!((ShipmentDataManager) DataManager).CheckPrefixBranchShipment(BaseControl.BranchId, tbxNo.Text))
                {
                    MessageBox.Show(Resources.invalid_stt, Resources.invalid_stt_title, MessageBoxButtons.OK);
                    tbxNo.Text = string.Empty;
                    tbxNo.Focus();
                    return false;
                }
            }

            return true;
        }

        public override void Save()
        {
            if (!CheckCn()) return;

            if (((ShipmentModel) CurrentModel).Invoiced == 1)
            {
                MessageBox.Show(Resources.invoiced, Resources.information, MessageBoxButtons.OK);
                return;
            }

            /*var acceptance = CurrentModel as ShipmentModel;
            Debug.Assert(acceptance != null, "acceptance != null");
            if (acceptance.Id > 0 && acceptance.TrackingStatusId != (int)EnumTrackingStatus.Acceptance)
            {
                MessageBox.Show(Resources.status_invalid, Resources.information, MessageBoxButtons.OK);
                return;
            }*/

            if (!ValidateForm())
            {
                MessageBox.Show(Resources.alert_empty_field, @"Warning");
                return;
            }

            if (!ValidateFormWithAlert())
            {
                return;
            }

            CurrentModel = PopulateModel(CurrentModel as ShipmentModel);
            var mdl = CurrentModel as ShipmentModel;
            if (mdl.Tariff == 0)
            {
                MessageBox.Show("Tidak ada layanan pengiriman untuk tujuan atau service tersebut. Silakan menghubungi CS untuk info lebih lanjut.");
                return;
            }

            using (var scope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, new TimeSpan(0, 10, 0)))
            {
                if (CurrentModel.Id == 0)
                {
                    InsertTracking = true;
                    CurrentModel.Rowstatus = true;
                    CurrentModel.Rowversion = DateTime.Now;
                    CurrentModel.Createddate = DateTime.Now;
                    CurrentModel.Createdby = BaseControl.UserLogin;

                    new ShipmentDataManager().Save<ShipmentModel>(CurrentModel);

                    SaveDetail();
                }
                else
                {
                    InsertTracking = false;
                    CurrentModel.Rowversion = DateTime.Now;
                    CurrentModel.Modifieddate = DateTime.Now;
                    CurrentModel.Modifiedby = BaseControl.UserLogin;

                    new ShipmentDataManager().Update<ShipmentModel>(CurrentModel);

                    SaveDetail(true);
                }

                scope.Complete();
            }

            TotalPage = 1;
            StateChange = EnumStateChange.Update;
            CrudState = EnumStateChange.Update;

            RefreshToolbarState();

            Dirty = false;
            AfterSave();
            Buttons();

            form.Activate();
        }

        protected override void AfterSave()
        {
            PodStatusModel.ShipmentId = CurrentModel.Id;
            PodStatusModel.PositionStatusId = BaseControl.BranchId;
            PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();
            
            var messengerId = ((ShipmentModel)CurrentModel).MessengerId;
            var messengerId2 = ((ShipmentModel)CurrentModel).MessengerId2;
            if (messengerId != null && messengerId > 0)
            {
                var mess = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)messengerId, "id", EnumSqlOperator.Equals));
                PodStatusModel.StatusBy = mess.Code;
            }

            ShipmentStatusUpdate();

            if (cbxPrint.Checked)
            {
                var mdl = CurrentModel as ShipmentModel;
                if (mdl.TtlPiece > 1)
                {
                    var shipment = DataManager.GetFirst<ShipmentModel>(WhereTerm.Default(mdl.Id, "id", EnumSqlOperator.Equals));
                    var orig = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(shipment.CityId, "id",
                        EnumSqlOperator.Equals));
                    var dest = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(shipment.DestCityId, "id",
                        EnumSqlOperator.Equals));
                    var service = new ServiceTypeDataManager().GetFirst<ServiceTypeModel>(WhereTerm.Default(mdl.ServiceTypeId, "id", EnumSqlOperator.Equals));
                    var barcode = new List<PrintBarcode>();
                    for (var i = 2; i <= mdl.TtlPiece; i++)
                    {
                        barcode.Add(new PrintBarcode
                        {
                            DateProcess = mdl.DateProcess,
                            BranchName = orig.Name,
                            DestBranchName = dest.Name,
                            Number = i.ToString("#"),
                            Code = shipment.Code + i.ToString("000"),
                            Count = mdl.TtlPiece,
                            ServiceType = service.Name,
                            GrossWeight = shipment.TtlChargeableWeight
                        });
                    }

                    var a = new CnBarcodeCard();
                    a.DataSource = barcode;
                    a.CreateDocument();

                    var printTool = new ReportPrintTool(a);
                    printTool.PrintingSystem.StartPrint += (o, args) =>
                    {
                        args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.Barcode;  
                    };
                    printTool.Print();
                }
            }

            New();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "" && tbxNo.Text != "" && tbxDestination.Text != "" && tbxPackage.Text != "" &&
                tbxService.Text != "" && tbxPayment.Text != "" && tbxPiece.Text != "" &&
                tbxWeight.Text != "" && tbxChargeable.Text != "") return true;

            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return false;
            }

            if (tbxNo.Text == "")
            {
                tbxNo.Focus();
                return false;
            }

            if (tbxDestination.Text == "")
            {
                tbxDestination.Focus();
                return false;
            }

            if (tbxPackage.Text == "")
            {
                tbxPackage.Focus();
                return false;
            }

            if (tbxService.Text == "")
            {
                tbxService.Focus();
                return false;
            }

            if (tbxPayment.Text == "")
            {
                tbxPayment.Focus();
                return false;
            }

            if (tbxPiece.Text == "")
            {
                tbxPiece.Focus();
                return false;
            }

            if (tbxWeight.Text == "")
            {
                tbxWeight.Focus();
                return false;
            }

            if (tbxChargeable.Text == "")
            {
                tbxChargeable.Focus();
                return false;
            }

            return false;
        }

        protected override void PopulateForm(ShipmentModel model)
        {
            _ClearForm(pnlBody1);
            _ClearForm(pnlBody2);

            gbPrint.Visible = false;
            btnSave.Enabled = true;

            if (model == null) return;
            ToolbarCode = model.Code;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = model.DateProcess.ToString();
            
            if (model.MessengerId != null)
                tbxPIC.DefaultValue = new IListParameter[] { WhereTerm.Default((int) model.MessengerId, "id", EnumSqlOperator.Equals) };
            if (model.MessengerId2 != null)
                tbxPIC2.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.MessengerId2, "id", EnumSqlOperator.Equals) };

            tbxNo.Text = model.Code;
            tbxNo.Enabled = false;
            tbxDestination.DefaultValue = new IListParameter[] { WhereTerm.Default(model.DestCityId, "id", EnumSqlOperator.Equals) };
            tbxPackage.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PackageTypeId, "id", EnumSqlOperator.Equals) };
            tbxService.DefaultValue = new IListParameter[] { WhereTerm.Default(model.ServiceTypeId, "id", EnumSqlOperator.Equals) };
            tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PaymentMethodId, "id", EnumSqlOperator.Equals) };

            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxPiece.SetValue(model.TtlPiece.ToString());
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxWeight.SetValue(model.TtlGrossWeight.ToString());
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxChargeable.SetValue(model.TtlChargeableWeight.ToString());

            if (model.Voided)
            {
                MessageForm.Info(form, Resources.information, @"Nomor CN sudah divoid");
                EnabledForm(false);
            }
            else EnabledForm(true);

            if (model.Paid) EnableBtnSave = false;

            if (model != null && (model.Voided || model.Posted || model.Invoiced == 1 || (DateTime.Now - model.DateProcess).TotalDays > 3))
            {
                EnabledForm(false);
                btnSave.Enabled = false;
                tsBaseBtn_Save.Enabled = false;
                NavigationMenu.SaveStrip.Enabled = false;
                tsBaseBtn_Delete.Enabled = false;
                NavigationMenu.DeleteStrip.Enabled = false;
            }

            tbxNo.Focus();
            tbxNo.ReadOnly = true;

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            if (model.TtlPiece > 1)
            {
                gbPrint.Visible = true;
                tbxStart.SetValue((decimal)2);
                tbxEnd.SetValue((decimal)model.TtlPiece);
            }
        }

        protected override ShipmentModel PopulateModel(ShipmentModel model)
        {
            model.DateProcess = tbxDate.Value;
            model.Code = tbxNo.Text;
            model.BranchId = BaseControl.BranchId;
            model.DestCityId = Convert.ToInt32(tbxDestination.Value);
            model.DestCity = tbxDestination.Text;
            model.PackageTypeId = Convert.ToInt32(tbxPackage.Value);
            model.ServiceTypeId = Convert.ToInt32(tbxService.Value);
            model.PaymentMethodId = Convert.ToInt32(tbxPayment.Value);

            model.MessengerId = (int?) tbxPIC.Value;
            model.MessengerName = tbxPIC.Text;

            model.MessengerId2 = (int?) tbxPIC2.Value;
            model.MessengerName2 = tbxPIC2.Text;
            
            model.CityId = BaseControl.CityId;
            model.CityName = BaseControl.CityName;

            model.DestCountryId = BaseControl.CountryId;
            model.DestCountry = BaseControl.CountryName;

            var destCity =
                new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(model.DestCityId, "id",
                    EnumSqlOperator.Equals));
            var destBranch =
                new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(destCity.BranchId, "id",
                    EnumSqlOperator.Equals));

            model.DestBranchId = destBranch.Id;
            model.DestBranchName = destBranch.Name;
                
            model.TtlPiece = (short) tbxPiece.Value;
            model.TtlGrossWeight = tbxWeight.Value;
            model.TtlChargeableWeight = tbxChargeable.Value;
            if (model.Id == 0) model.TrackingStatusId = (int) EnumTrackingStatus.Acceptance;
            model.PricingPlanId = 0;

            if (model.Id == 0)
            {
                try
                {
                    var allocation =
                        new ShipmentNumberAllocationDataManager().GetAllocationByCustomer(Convert.ToInt64(tbxNo.Text),
                            BaseControl.BranchId);
                    if (allocation != null)
                    {
                        model.CustomerId = allocation.CustomerId;

                        var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)allocation.CustomerId, "id", EnumSqlOperator.Equals));
                        if (customer != null)
                        {
                            model.CustomerName = customer.Name;
                            model.ShipperName = customer.Name;
                            model.ShipperAddress = customer.Address;
                            model.ShipperPhone = customer.Phone;
                        }
                    }
                }
                catch {}

                model.CreatedPc = Environment.MachineName;
                model.AcceptanceEmployee = BaseControl.EmployeeCode;
                model.DataEntryEmployee = string.Empty;
            }
            else model.ModifiedPc = Environment.MachineName;

            model = new ShipmentDataManager().GetTariff(model, BaseControl.CountryId);

            return model;
        }

        protected override ShipmentModel Find(string searchTerm)
        {
            var param = new IListParameter[]
            {
                WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
            };
            var obj = DataManager.GetFirst<ShipmentModel>(param);
            //PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as ShipmentModel;

            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }
    }
}