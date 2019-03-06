using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.App.Administration;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.Common.Reports;
using SISCO.Presentation.CounterCash.Popup;
using SISCO.Presentation.CounterCash.Print;
using SISCO.Presentation.MasterData.Popup;
using System;
using SISCO.LocalStorage;
using SISCO.Presentation.Operation.Forms;
using SISCO.Presentation.Operation.Command;
using System.Text.RegularExpressions;
using SISCO.App.Operation;
using SISCO.App;

namespace SISCO.Presentation.CounterCash.Forms
{
    public partial class CounterCashForm : BaseCrudForm<ShipmentModel, ShipmentDataManager>//BaseToolbarForm//
    {
        // ReSharper disable once NotAccessedField.Local
        private decimal _fixedShippingInsuranceRate;

        // ReSharper disable InconsistentNaming
        const string CURRENCY_IDR = "IDR";
        const string SERVICE_TYPE_CITY_COURIER = "CITY COURIER";
        const int PRICING_PLAN_DOMESTIC = 1;
        // ReSharper restore InconsistentNaming

        public decimal DeliveryTariffMinimumWeight { get; set; }
        public bool IsInternationalShipment { get; set; }
        private decimal MinWeight { get; set; }
        private int? promoId { get; set; }
        private int? dropPointId { get; set; }
        private int? sprinterId { get; set; }
        private bool isPopulatingForm { get; set; }

        private LookupModel _lookup { get; set; }
        private string _minInsurance { get; set; }
        private string _adminInsurance { get; set; }

        public CounterCashForm()
        {
            InitializeComponent();
            form = this;

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                WhereTerm.Default(1,"sales_type_id", EnumSqlOperator.Equals)
            };
        }

        /*protected override void BindDataSource<T>()
        {
            CurrentModel = LoadModel<T>(WhereTerm.Default(1, "sales_type_id"), WhereTerm.Default(BaseControl.BranchId, "branch_id"));
        }*/

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            EnableBtnSearch = true;
            SearchPopup = new ShipmentPopup();

            try
            {
                using (var configDm = new ConfigDataManager())
                {
                    _fixedShippingInsuranceRate = decimal.Parse(configDm.Get("FixedShippingInsuranceRate"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"The insurance rate setting must be correctly set in the config table (FixedShippingInsuranceRate)", @"Error!");
                throw new Exception("The insurance rate setting must be correctly set in the config table (FixedShippingInsuranceRate)", ex);
            }

            lkpBranch.LookupPopup = new BranchPopup();
            lkpBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code;
            lkpBranch.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            lkpCustomer.LookupPopup = new CustomerPopup(WhereTerm.Default(BaseControl.BranchId, "branch_id"), WhereTerm.Default("0", "disabled"));
            lkpCustomer.AutoCompleteDataManager = new CustomerServices();
            lkpCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpCustomer.AutoCompleteWhereExpression = (s, param) => param.SetWhereExpression("(code = @0 or name.StartsWith(@0)) and branch_id = @1 and disabled = @2", s, BaseControl.BranchId, "0");
            lkpCustomer.Enabled = false;
            lkpCustomer.Properties.Buttons[0].Enabled = false;

            lkpOriginCity.LookupPopup = new CityPopup();
            lkpOriginCity.AutoCompleteDataManager = new CityServices();
            lkpOriginCity.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpOriginCity.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpOriginCity.FieldLabel = "Origin City";
            lkpOriginCity.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpDestinationCity.LookupPopup = new CityPopup();
            lkpDestinationCity.AutoCompleteDataManager = new CityServices();
            lkpDestinationCity.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpDestinationCity.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpDestinationCity.FieldLabel = "Destination City";
            lkpDestinationCity.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpPackageType.LookupPopup = new PackageTypePopup();
            lkpPackageType.AutoCompleteDataManager = new PackageTypeServices();
            lkpPackageType.AutoCompleteDisplayFormater = model => ((PackageTypeModel)model).Name;
            lkpPackageType.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpPackageType.FieldLabel = "Package Type";
            lkpPackageType.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpServiceType.LookupPopup = new ServiceTypePopup();
            lkpServiceType.AutoCompleteDataManager = new ServiceTypeServices();
            lkpServiceType.AutoCompleteDisplayFormater = model => ((ServiceTypeModel)model).Name;
            lkpServiceType.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpServiceType.FieldLabel = "Service Type";
            lkpServiceType.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpPaymentMethod.LookupPopup = new PaymentMethodPopup("(name.Equals(@0) OR name.Equals(@1))", "CASH", "COLLECT");
            lkpPaymentMethod.AutoCompleteDataManager = new PaymentMethodServices();
            lkpPaymentMethod.AutoCompleteDisplayFormater = model => ((PaymentMethodModel)model).Name;
            lkpPaymentMethod.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("name.StartsWith(@0) AND (name.Equals(@1) OR name.Equals(@2))", s, "CASH", "COLLECT");
            lkpPaymentMethod.FieldLabel = "Payment Method";
            lkpPaymentMethod.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpMessenger.LookupPopup = new EmployeePopup(EmployeeModel.EmployeeType.Messenger);
            lkpMessenger.AutoCompleteDataManager = new MessengerServices();
            lkpMessenger.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " " + ((EmployeeModel)model).Name;
            lkpMessenger.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0))", s);
            lkpMessenger.FieldLabel = "Messenger";
            lkpMessenger.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpMessenger2.LookupPopup = new EmployeePopup(EmployeeModel.EmployeeType.Messenger);
            lkpMessenger2.AutoCompleteDataManager = new MessengerServices();
            lkpMessenger2.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " " + ((EmployeeModel)model).Name;
            lkpMessenger2.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0))", s);
            lkpMessenger2.FieldLabel = "Messenger";
            lkpMessenger2.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtShipmentNo.FieldLabel = "Shipment Number";
            txtShipmentNo.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtShipperName.FieldLabel = "Shipper Name";
            txtShipperName.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            txtShipperAddress.FieldLabel = "Shipper Address";
            txtShipperAddress.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            txtShipperPhone.FieldLabel = "Shipper Phone";
            txtShipperPhone.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtConsigneeName.FieldLabel = "Consignee Name";
            txtConsigneeName.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            txtConsigneeAddress.FieldLabel = "Consignee Address";
            txtConsigneeAddress.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            txtConsigneePhone.FieldLabel = "Consignee Phone";
            txtConsigneePhone.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtTotalPiece.EditMask = "###,##0";
            txtTotalPiece.FieldLabel = "Total Piece";
            txtTotalPiece.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            txtTotalWeight.EditMask = "###,##0.0";
            txtTotalWeight.FieldLabel = "Total Weight";
            txtTotalWeight.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            txtChargeable.EditMask = "###,##0.0";
            txtChargeable.FieldLabel = "Chargeable Weight";
            txtChargeable.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtDiscount.EditMask = "#0.0%%";
            txtPackingFee.EditMask = "###,###,##0.00";
            txtOtherFee.EditMask = "##,###,###,###,##0.00";
            txtGoodsValue.EditMask = "##,###,###,###,##0.00";
            txtInsuranceFee.EditMask = "##,###,###,###,##0.00";

            txtShipperName.CharacterCasing = CharacterCasing.Upper;
            txtShipperAddress.CharacterCasing = CharacterCasing.Upper;
            txtShipperPhone.CharacterCasing = CharacterCasing.Upper;
            txtConsigneeName.CharacterCasing = CharacterCasing.Upper;
            txtConsigneeAddress.CharacterCasing = CharacterCasing.Upper;
            txtConsigneePhone.CharacterCasing = CharacterCasing.Upper;
            txtShipperRef.CharacterCasing = CharacterCasing.Upper;
            txtNote.CharacterCasing = CharacterCasing.Upper;
            txtNatureOfGoods.CharacterCasing = CharacterCasing.Upper;

            txtShipperName.MaxLength = 100;
            txtShipperAddress.MaxLength = 254;
            txtShipperPhone.MaxLength = 50;
            txtConsigneeName.MaxLength = 100;
            txtConsigneeAddress.MaxLength = 254;
            txtConsigneePhone.MaxLength = 50;
            txtShipperRef.MaxLength = 50;
            txtNote.MaxLength = 100;
            txtNatureOfGoods.MaxLength = 50;

            btnRefreshTariff.Enabled = false;
            btnSave.Enabled = false;

            txtTotalWeight.TextChanged += TxtTotalWeightOnTextChanged;
            txtShipmentNo.Leave += txtShipmentNo_Leave;
            lkpCustomer.TextChanged += lkpCustomer_TextChanged;
            txtDiscount.TextChanged += (o, args) => RefreshTariff();

            tbxL.EditValueChanged += (s, o) => VolumeCalculation(tbxL.Value, tbxW.Value, tbxH.Value, lkpServiceType.Text, txtTotalWeight.Value, txtChargeable);
            tbxW.EditValueChanged += (s, o) => VolumeCalculation(tbxL.Value, tbxW.Value, tbxH.Value, lkpServiceType.Text, txtTotalWeight.Value, txtChargeable);
            tbxH.EditValueChanged += (s, o) => VolumeCalculation(tbxL.Value, tbxW.Value, tbxH.Value, lkpServiceType.Text, txtTotalWeight.Value, txtChargeable);

            cbxPacking.Click += (s, o) =>
            {
                if (cbxPacking.Checked) txtPackingFee.Value = PackingCalculation(tbxL.Value, tbxW.Value, tbxH.Value);
                else txtPackingFee.Value = 0;

                RefreshGrandTotal();
            };

            cbxMobilePoint.Click += (s, o) =>
            {
                if (cbxMobilePoint.Checked)
                {
                    tbxEmailPoint.Focus();
                    tbxEmailPoint.Enabled = true;
                }
                else
                {
                    tbxEmailPoint.Clear();
                    tbxEmailPoint.Enabled = false;
                }
            };

            lkpBranch.TextChanged += (o, args) =>
            {
                if (lkpBranch.Value != null)
                {
                    using (var branchDm = new BranchDataManager())
                    {
                        var branch = branchDm.GetFirst<BranchModel>(WhereTerm.Default((int)lkpBranch.Value, "id"));
                        MaximumBranchDiscount = branch.MaxDiscount > 0 ? branch.MaxDiscount : 0;
                    }
                }
            };

            FormTrackingStatus = EnumTrackingStatus.Acceptance;

            tsBaseBtn_Print.Click += (o, args) => Print();
            tsBaseBtn_PrintPreview.Click += (o, args) =>
            {
                var printout = new EConnotePrintout
                {
                    DataSource = GetPrintDataSource()
                };
                printout.PrintPreview();
            };

            tsBaseTxt_Code.KeyPress += (o, args) =>
            {
                if (args.KeyChar == 13)
                {
                    lkpCustomer.SelectAll();
                    lkpCustomer.Focus();
                }
            };

            lkpPaymentMethod.Leave += (o, args) =>
            {
                if (chkAutoGen.Checked && lkpPaymentMethod.Value != null && !lkpPaymentMethod.Text.Equals("CASH"))
                {
                    MessageBox.Show(@"Nomor CN harus CASH");

                    lkpPaymentMethod.DefaultValue = new IListParameter[] { WhereTerm.Default("CASH", "name") };
                }
            };

            btnAcceptance1.Click += AcceptanceDropPoint;
            _lookup = new LookupDataManager().Get("FixCashInsurance");
            _minInsurance = new LookupDataManager().Get("MinInsurance").Value;
            _adminInsurance = new LookupDataManager().Get("AdminInsurance").Value;
        }

        private void AcceptanceDropPoint(object sender, EventArgs e)
        {
            InsertTracking = true;
            PodStatusModel.ShipmentId = CurrentModel.Id;
            PodStatusModel.PositionStatusId = BaseControl.BranchId;
            PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();

            ShipmentStatusUpdate();
            CurrentModel.Createdby = BaseControl.UserLogin;
            Save();
        }

        public override void Print()
        {
            var printout = new EConnotePrintout
            {
                DataSource = GetPrintDataSource()
            };

            printout.Print();
            new ShipmentExpandDataManager().Printing(CurrentModel.Id);
        }

        public decimal MaximumBranchDiscount { get; set; }
        public decimal CustomerDiscount { get; set; }

        void lkpCustomer_TextChanged(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;
            if (((ShipmentModel)CurrentModel).Voided || ((ShipmentModel)CurrentModel).Posted) return;
            if (lkpCustomer.Value == LastCustomerId) return;

            LastCustomerId = lkpCustomer.Value ?? 0;

            using (var customerDataManager = new CustomerDataManager())
            {
                var customer = customerDataManager.GetFirst<CustomerModel>(WhereTerm.Default(lkpCustomer.Value ?? 0, "id"));
                if (customer != null)
                {
                    CustomerDiscount = customer.Discount;

                    if (!_isPopulatingForm && CurrentModel.Id == 0)
                    {
                        txtShipperName.Text = customer.Name;
                        txtShipperAddress.Text = customer.Address;
                        txtShipperPhone.Text = customer.Phone;

                        ((ShipmentModel) CurrentModel).ShipperSaved = true;

                        txtDiscount.Value = CustomerDiscount;

                        RefreshTariff();
                    }
                }
            }
        }

        public int LastCustomerId { get; set; }

        void txtShipmentNo_Leave(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;
            if (CurrentModel.Id > 0) return;

            if (string.IsNullOrEmpty(txtShipmentNo.Text)) return;

            if (txtShipmentNo.Text.Length != 12)
            {
                MessageBox.Show(@"Nomor POD harus 12 digit!");
                txtShipmentNo.Clear();
                txtShipmentNo.Focus();
                return;
            }

            if (!txtShipmentNo.Text.All(c => char.IsDigit(c)))
            {
                MessageBox.Show(@"Nomor POD harus berupa angka!");
                txtShipmentNo.Clear();
                txtShipmentNo.Focus();
                return;
            }

            if (!CheckCn())
            {
                return;
            }

            var model = new ShipmentNumberAllocationDataManager().GetFirst<ShipmentAllocationModel>(
                WhereTerm.Default(Convert.ToInt64(txtShipmentNo.Text), "shipment_code_start", EnumSqlOperator.LesThanEqual),
                WhereTerm.Default(Convert.ToInt64(txtShipmentNo.Text), "shipment_code_end", EnumSqlOperator.GreatThanEqual),
                WhereTerm.Default(0, "customer_id", EnumSqlOperator.GreatThan)
                );

            dropPointId = null;
            sprinterId = null;
            tbxDp.Text = string.Empty;
            tbxSprinter.Text = string.Empty;
            txtDiscount.SetValue((float)0);
            if (model != null)
            {
                lkpCustomer.DefaultValue = new IListParameter[] {WhereTerm.Default((int)model.CustomerId, "id")};

                txtShipperName.Text = model.CustomerName;
                txtShipperAddress.Text = model.CustomerAddress;
                using (var customerDataManager = new CustomerDataManager())
                {
                    var customer = customerDataManager.GetFirst<CustomerModel>(WhereTerm.Default((int)model.CustomerId, "id"));
                    if (customer != null)
                    {
                        txtShipperPhone.Text = customer.Phone;
                    }
                }

                lkpCustomer.Enabled = false;
                lkpCustomer.Properties.Buttons[0].Enabled = false;
                txtShipperName.Enabled = false;
                txtShipperAddress.Enabled = false;
                txtShipperPhone.Enabled = false;
            }
            else
            {
                var franchisepod = new ShipmentNumberAllocationDataManager().GetFirst<ShipmentAllocationModel>(
                        WhereTerm.Default(Convert.ToInt64(txtShipmentNo.Text), "shipment_code_start", EnumSqlOperator.LesThanEqual),
                        WhereTerm.Default(Convert.ToInt64(txtShipmentNo.Text), "shipment_code_end", EnumSqlOperator.GreatThanEqual)
                    );

                if (franchisepod != null)
                {
                    if (franchisepod.FranchiseId != null)
                    {
                        var code = txtShipmentNo.Text;
                        New();

                        var dataEntryForm = new DataEntryFranchiseForm();
                        BaseControl.OpenDataEntryFranchiseForm(dataEntryForm, code, new DataEntryFranchiseCommand().GetType(), "Operation");
                        return;
                    }

                    if (franchisepod.DropPointId != null)
                    {
                        var dp = new DropPointDataManager().GetFirst<DropPointModel>(WhereTerm.Default((int)franchisepod.DropPointId, "id"));
                        if (dp != null)
                        {
                            dropPointId = franchisepod.DropPointId;
                            tbxDp.Text = dp.Code;
                            txtDiscount.SetValue(dp.Commission);
                            txtDiscount.Enabled = false;
                            LastCustomerId = 0;
                        }
                    }
                }

                lkpCustomer.Enabled = false;
                lkpCustomer.Properties.Buttons[0].Enabled = false;
                lkpCustomer.Value = null;
                lkpCustomer.Text = string.Empty;
                txtShipperName.Enabled = true;
                txtShipperAddress.Enabled = true;
                txtShipperPhone.Enabled = true;
            }
        }

        private void TxtTotalWeightOnTextChanged(object sender, EventArgs eventArgs)
        {
            decimal ceiled;

            if (MinWeight > 0 && txtTotalWeight.Value < MinWeight) txtTotalWeight.Value = MinWeight;

            if (((ShipmentModel) CurrentModel).PricingPlanId == PRICING_PLAN_DOMESTIC)
            {
                ceiled = Math.Ceiling(txtTotalWeight.Value);
            }
            else
            {
                ceiled = Math.Ceiling(txtTotalWeight.Value * 2) / 2;
            }

            if (ceiled > 999999) MessageBox.Show(@"Chargeable maximal 999,999 kg");

            txtChargeable.Value = ceiled;
            VolumeCalculation(tbxL.Value, tbxW.Value, tbxH.Value, lkpServiceType.Text, txtTotalWeight.Value, txtChargeable);
        }

        protected override void PopulateForm(ShipmentModel model)
        {
            isPopulatingForm = true;
            ClearForm();
            LastCustomerId = model.CustomerId ?? 0;

            lkpBranch.DefaultValue = new IListParameter[] {WhereTerm.Default(model.BranchId, "id")};

            chkRA.Checked = model.NeedRa;

            txtDate.DateTime = model.DateProcess;

            tsBaseTxt_Code.Text = model.Code;
            txtShipmentNo.Text = model.Code;
            chkAutoGen.Checked = model.AutoNumber;

            chkAutoGen.Checked = model.AutoNumber;
            chkAutoGen.Enabled = model.Id == 0;

            lkpOriginCity.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CityId, "id") };
            lkpDestinationCity.DefaultValue = new IListParameter[] { WhereTerm.Default(model.DestCityId, "id") };

            lkpCustomer.DefaultValue = new IListParameter[] {WhereTerm.Default(model.CustomerId ?? 0, "id")};
            lkpCustomer.Enabled = false;
            lkpCustomer.Properties.Buttons[0].Enabled = false;

            txtShipperName.Text = model.ShipperName;
            txtShipperAddress.Text = model.ShipperAddress;
            txtShipperPhone.Text = model.ShipperPhone;
            txtShipperRef.Text = model.RefNumber;

            txtConsigneeName.Text = model.ConsigneeName;
            txtConsigneeAddress.Text = model.ConsigneeAddress;
            txtConsigneePhone.Text = model.ConsigneePhone;

            lkpPackageType.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PackageTypeId, "id") };
            lkpServiceType.DefaultValue = new IListParameter[] { WhereTerm.Default(model.ServiceTypeId, "id") };
            lkpPaymentMethod.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PaymentMethodId, "id") };
            lkpMessenger.DefaultValue = new IListParameter[] { WhereTerm.Default(model.MessengerId ?? 0, "id") };
            lkpMessenger2.DefaultValue = new IListParameter[] { WhereTerm.Default(model.MessengerId2 ?? 0, "id") };

            txtNatureOfGoods.Text = model.NatureOfGoods;
            txtNote.Text = model.Note;

            txtTotalPiece.Value = model.TtlPiece;
            txtTotalWeight.Value = model.TtlGrossWeight;
            txtChargeable.Value = model.TtlChargeableWeight;

            txtTariffPerKg.Value = model.Tariff;
            txtHandlingFee.Value = model.HandlingFee;
            txtTariffTotal.Value = model.TariffTotal;
            txtDiscount.Value = model.DiscountPercent;
            txtDiscountTotal.Value = model.DiscountTotal;
            txtTariffNet.Value = model.TariffNet;

            txtPackingFee.Value = model.PackingFee;
            txtPackingFee.Enabled = false;
            txtOtherFee.Value = model.OtherFee;
            txtGoodsValue.Value = model.GoodsValue;
            txtInsuranceFee.Value = model.InsuranceFee;

            MinWeight = 0;

            if (((ShipmentModel)CurrentModel).PricingPlanId == PRICING_PLAN_DOMESTIC)
            {
                CustomerTariffModel customerTariffModel = null;
                if (lkpCustomer.Value != null)
                {
                    customerTariffModel = new CustomerTariffDataManager().GetTariff(
                        (int)lkpOriginCity.Value,
                        (int)lkpDestinationCity.Value,
                        lkpServiceType.Value ?? 0,
                        lkpPackageType.Value ?? 0,
                        (int)lkpCustomer.Value,
                        txtChargeable.Value
                        );
                }

                if (customerTariffModel == null)
                {
                    var tariffModel = new TariffDataManager().GetTariff(
                    (int)lkpOriginCity.Value,
                    (int)lkpDestinationCity.Value,
                    lkpServiceType.Value ?? 0,
                    lkpPackageType.Value ?? 0,
                    txtChargeable.Value
                    );

                    if (tariffModel != null)
                    {
                        MinWeight = tariffModel.MinWeight;
                        if (MinWeight > 0 && txtTotalWeight.Value < MinWeight) txtTotalWeight.Value = MinWeight;
                    }
                }
                else
                {
                    MinWeight = customerTariffModel.MinWeight;
                    if (MinWeight > 0 && txtTotalWeight.Value < MinWeight) txtTotalWeight.Value = MinWeight;
                }
            }

            txtGrandTotal.Value = model.Total;
            txtDiscount.Enabled = !lkpServiceType.Text.ToUpper().Equals("CITY COURIER");
            txtDiscountTotal.Value = model.DiscountTotal;

            promoId = null;
            if (model.PromoId != null)
            {
                tbxPromo.Text = model.PromoCode;
                promoId = model.PromoId;
            }

            tbxPromo.Enabled = false;
            tbxDp.Enabled = false;
            tbxSprinter.Enabled = false;

            if (model.Posted)
            {
                MessageBox.Show(@"POD sudah divalidasi di billing dan tidak bisa dikoreksi");

                btnSave.Enabled = false;
                btnRefreshTariff.Enabled = false;
                EnabledForm(false);
            }
            else if (model.Voided)
            {
                MessageBox.Show(@"POD sudah di-VOID!");

                btnSave.Enabled = false;
                btnRefreshTariff.Enabled = false;
                EnabledForm(false);

                txtDiscount.Enabled = false;
            }
            else
            {
                lkpBranch.Enabled = false;

                txtDate.Enabled = false;
                txtShipmentNo.Enabled = false;
                chkRA.Enabled = false;

                txtTariffPerKg.Enabled = false;
                txtTariffNet.Enabled = false;
                txtHandlingFee.Enabled = false;
                txtTariffTotal.Enabled = false;
                txtDiscountTotal.Enabled = false;
                txtTariffNet.Enabled = false;
                txtGrandTotal.Enabled = false;
                txtInsuranceFee.Enabled = true;

                btnRefreshTariff.Enabled = true;
                btnSave.Enabled = true;
            }

            dropPointId = null;
            sprinterId = null;
            tbxEmailPoint.Enabled = false;
            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(model.Id, "shipment_id"));
            if (expand != null)
            {
                tbxL.SetValue(expand.VolumeL);
                tbxW.SetValue(expand.VolumeW);
                tbxH.SetValue(expand.VolumeH);
                cbxPacking.Checked = expand.UsePacking;
                
                if (expand.DropPointId != null)
                {
                    var dp = new DropPointDataManager().GetFirst<DropPointModel>(WhereTerm.Default((int)expand.DropPointId, "id"));
                    if (dp != null)
                    {
                        dropPointId = expand.DropPointId;
                        tbxDp.Text = dp.Code;

                        txtDiscount.Enabled = false;
                    }
                }

                if (!string.IsNullOrEmpty(expand.EmailPoint))
                {
                    cbxMobilePoint.Checked = true;
                    tbxEmailPoint.Enabled = true;
                    tbxEmailPoint.Text = expand.EmailPoint;
                }

                if (expand.SprinterId != null)
                {
                    var emp = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)expand.SprinterId, "id"));
                    tbxSprinter.Text = emp.Code;
                }
            }

            ActiveControl = tsBaseTxt_Code.Control;
            txtInsuranceFee.Enabled = false;

            isPopulatingForm = false;

            btnAcceptance1.Visible = false;
            if (expand != null && expand.DropPointId != null)
            {
                var status = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                {
                    WhereTerm.Default(model.Id, "shipment_id"),
                    WhereTerm.Default((int)EnumTrackingStatus.Acceptance, "tracking_status_id")
                });

                if (status == null) btnAcceptance1.Visible = true;
            }
        }

        protected override ShipmentModel PopulateModel(ShipmentModel model)
        {
            model.DateProcess = txtDate.DateTime;

            if (lkpBranch.Value == null)
                throw new BusinessException("");
            model.BranchId = (int)lkpBranch.Value;

            model.Code = txtShipmentNo.Text;
            model.AutoNumber = chkAutoGen.Checked;

            model.NeedRa = chkRA.Checked;

            if (lkpOriginCity.Value == null)
                throw new BusinessException("");
            model.CityId = (int)lkpOriginCity.Value;
            model.CityName = lkpOriginCity.Text;

            if (lkpDestinationCity.Value == null)
                throw new BusinessException("");
            model.DestCityId = (int)lkpDestinationCity.Value;

            using (var dm = new CityDataManager())
            {
                var city = dm.GetFirst<CityModel>(WhereTerm.Default(model.DestCityId, "id"));
                if (city != null)
                {
                    model.DestBranchId = city.BranchId;
                    model.DestCountryId = city.CountryId;
                    model.DestCity = city.Name;

                    var destBranch =
                        new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(city.BranchId, "id",
                            EnumSqlOperator.Equals));

                    if (destBranch != null) model.DestBranchName = destBranch.Name;
                }
                else
                {
                    model.DestBranchId = 0;
                    model.DestCountryId = 0;
                }
            }

            model.CustomerId = lkpCustomer.Value;
            using (var dm = new CustomerDataManager())
            {
                var customer = dm.GetFirst<CustomerModel>(WhereTerm.Default(lkpCustomer.Value ?? 0, "id"));
                model.CustomerName = customer != null ? customer.Name : string.Empty;
            }

            model.ShipperName = txtShipperName.Text;
            model.ShipperAddress = txtShipperAddress.Text;
            model.ShipperPhone = txtShipperPhone.Text;
            model.RefNumber = txtShipperRef.Text;

            model.ConsigneeName = txtConsigneeName.Text;
            model.ConsigneeAddress = txtConsigneeAddress.Text;
            model.ConsigneePhone = txtConsigneePhone.Text;

            if (lkpPackageType.Value == null)
                throw new BusinessException("");
            model.PackageTypeId = (int)lkpPackageType.Value;
            model.PackageType = lkpPackageType.Text;

            if (lkpServiceType.Value == null)
                throw new BusinessException("");
            model.ServiceTypeId = (int)lkpServiceType.Value;

            if (lkpPaymentMethod.Value == null)
                throw new BusinessException("");
            model.PaymentMethodId = (int)lkpPaymentMethod.Value;
            model.PaymentMethod = lkpPaymentMethod.Text;

            model.MessengerName = lkpMessenger.Text;
            model.MessengerId = lkpMessenger.Value;

            model.MessengerName2 = lkpMessenger2.Text;
            model.MessengerId2 = lkpMessenger2.Value;

            model.NatureOfGoods = txtNatureOfGoods.Text;
            model.Note = txtNote.Text;

            model.TtlPiece = Convert.ToInt16(txtTotalPiece.Value);
            model.TtlGrossWeight = txtTotalWeight.Value;
            model.TtlChargeableWeight = txtChargeable.Value;

            model.Tariff = txtTariffPerKg.Value;
            model.HandlingFeeTotal = txtHandlingFee.Value;
            model.TariffTotal = txtTariffTotal.Value;
            model.DiscountPercent = txtDiscount.Value;
            model.DiscountTotal = txtDiscountTotal.Value;
            model.TariffNet = txtTariffNet.Value;

            model.PackingFee = txtPackingFee.Value;
            model.OtherFee = txtOtherFee.Value;
            model.GoodsValue = txtGoodsValue.Value;
            model.InsuranceFee = txtInsuranceFee.Value;

            model.TrackingStatusId = (int)EnumTrackingStatus.Acceptance;

            model.Total = txtGrandTotal.Value;

            model.DiscountTotal = txtDiscountTotal.Value;
            if (promoId != null) model.PromoId = promoId;
            model.PromoCode = tbxPromo.Text;

            model.SalesTypeId = 1;

            if (CurrentModel.Id == 0)
            {
                model.CreatedPc = Environment.MachineName;
            }

            return model;
        }

        protected override bool ValidateForm()
        {
            if (cbxMobilePoint.Checked && string.IsNullOrEmpty(tbxEmailPoint.Text))
            {
                tbxEmailPoint.Focus();
                return false;
            }

            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            // ReSharper disable LocalizableElement
            if (!chkAutoGen.Checked)
            {
                if (txtShipmentNo.Text == string.Empty)
                {
                    MessageBox.Show("Please enter the shipment number!");
                    txtShipmentNo.SelectAll();
                    txtShipmentNo.Focus();
                    return false;
                }

                if (!CheckCn())
                {
                    return false;
                }
            }

            if (lkpOriginCity.Value == null)
            {
                MessageBox.Show("Please enter the origin city!");
                lkpOriginCity.SelectAll();
                lkpOriginCity.Focus();
                return false;
            }
            if (lkpDestinationCity.Value == null)
            {
                MessageBox.Show("Please enter the destination city!");
                lkpDestinationCity.SelectAll();
                lkpDestinationCity.Focus();
                return false;
            }
            if (txtShipperName.Text == string.Empty)
            {
                MessageBox.Show("Please enter the shipper name!");
                txtShipperName.SelectAll();
                txtShipperName.Focus();
                return false;
            }
            if (txtShipperAddress.Text == string.Empty)
            {
                MessageBox.Show("Please enter the shipper address!");
                txtShipperAddress.SelectAll();
                txtShipperAddress.Focus();
                return false;
            }
            if (txtShipperPhone.Text == string.Empty)
            {
                MessageBox.Show("Please enter the shipper phone number!");
                txtShipperPhone.SelectAll();
                txtShipperPhone.Focus();
                return false;
            }
            if (txtConsigneeName.Text == string.Empty)
            {
                MessageBox.Show("Please enter the consignee name!");
                txtConsigneeName.SelectAll();
                txtConsigneeName.Focus();
                return false;
            }
            if (txtConsigneeAddress.Text == string.Empty)
            {
                MessageBox.Show("Please enter the consignee address!");
                txtConsigneeAddress.SelectAll();
                txtConsigneeAddress.Focus();
                return false;
            }
            if (txtConsigneePhone.Text == string.Empty)
            {
                MessageBox.Show("Please enter the consignee phone number!");
                txtConsigneePhone.SelectAll();
                txtConsigneePhone.Focus();
                return false;
            }
            if (lkpPackageType.Value == null)
            {
                MessageBox.Show("Please select the package type!");
                lkpPackageType.SelectAll();
                lkpPackageType.Focus();
                return false;
            }
            if (lkpServiceType.Value == null)
            {
                MessageBox.Show("Please select the service type!");
                lkpServiceType.SelectAll();
                lkpServiceType.Focus();
                return false;
            }
            if (lkpPaymentMethod.Value == null)
            {
                MessageBox.Show("Please select the payment method type!");
                lkpPaymentMethod.SelectAll();
                lkpPaymentMethod.Focus();
                return false;
            }
            if (txtTotalPiece.Value == 0)
            {
                MessageBox.Show("Please fill the total piece field!");
                txtTotalPiece.SelectAll();
                txtTotalPiece.Focus();
                return false;
            }
            if (txtTotalWeight.Value == 0)
            {
                MessageBox.Show("Please wnter the total weight!");
                txtTotalWeight.SelectAll();
                txtTotalWeight.Focus();
                return false;
            }
            if (txtChargeable.Value == 0)
            {
                MessageBox.Show("Please enter the chargeable weight!");
                txtChargeable.SelectAll();
                txtChargeable.Focus();
                return false;
            }
            // ReSharper restore LocalizableElement

            if (cbxMobilePoint.Checked && !string.IsNullOrEmpty(tbxEmailPoint.Text))
            {
                string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                if (!Regex.IsMatch(tbxEmailPoint.Text, expresion))
                {
                    MessageBox.Show(@"Silakan masukkan alamat email yang valid.");
                    tbxEmailPoint.Focus();
                    return false;
                }
            }

            return true;
        }

        protected override ShipmentModel Find(string searchTerm)
        {
            return DataManager.GetFirst<ShipmentModel>(
                WhereTerm.Default(searchTerm, "code"),
                WhereTerm.Default(1, "sales_type_id"));
        }

        protected override void BeforeNew()
        {
            ClearForm();
            chkAutoGen.Checked = true;
            btnAcceptance1.Visible = false;

            lkpBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "Id") };
            lkpOriginCity.DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.CityId, "Id") };
            lkpCustomer.Enabled = false;

            txtTotalPiece.Value = 1;
            txtTotalWeight.Value = 1;
            txtChargeable.Value = 1;

            txtTariffPerKg.Value = 0;
            txtHandlingFee.Value = 0;
            txtTariffTotal.Value = 0;
            txtDiscount.Value = 0;
            txtDiscountTotal.Value = 0;
            txtTariffNet.Value = 0;

            txtPackingFee.Value = 0;
            txtOtherFee.Value = 0;
            txtGoodsValue.Value = 0;
            txtInsuranceFee.Value = 0;

            tbxL.Value = 1;
            tbxW.Value = 1;
            tbxH.Value = 1;

            txtGrandTotal.Value = 0;

            txtDate.DateTime = DateTime.Now;

            lkpPackageType.DefaultValue = new IListParameter[] { WhereTerm.Default("PARCEL", "name") };
            lkpServiceType.DefaultValue = new IListParameter[] { WhereTerm.Default("ECO", "name") };
            lkpPaymentMethod.DefaultValue = new IListParameter[] { WhereTerm.Default("CASH", "name") };

            using (var employeeDm = new EmployeeDataManager())
            {
                if (employeeDm.GetFirst<EmployeeModel>(WhereTerm.Default(BaseControl.EmployeeId, "id"), WhereTerm.Default(true, "as_messenger")) != null)
                {
                    lkpMessenger.DefaultValue = new IListParameter[] {WhereTerm.Default(BaseControl.EmployeeId, "id")};
                }
                else
                {
                    lkpMessenger.DefaultValue = new IListParameter[] {WhereTerm.Default(0, "id")};
                }
            }

            btnRefreshTariff.Enabled = true;
            btnSave.Enabled = true;

            chkPrintOrder.Checked = true;
            chkPrintContinuous.Checked = true;

            lkpDestinationCity.Focus();
            txtPackingFee.Enabled = false;
        }

        public override void New()
        {
            base.New();

            chkRA.Enabled = false;
            txtTariffPerKg.Enabled = false;
            txtTariffNet.Enabled = false;
            txtHandlingFee.Enabled = false;
            txtTariffTotal.Enabled = false;
            txtDiscountTotal.Enabled = false;
            txtTariffNet.Enabled = false;
            txtGrandTotal.Enabled = false;
            txtInsuranceFee.Enabled = false;
            txtDate.Enabled = false;
            lkpBranch.Enabled = false;
            tbxPromo.Enabled = false;
            tbxDp.Enabled = false;
            tbxSprinter.Enabled = false;
            tbxEmailPoint.Enabled = false;

            MinWeight = 0;
            promoId = null;
            dropPointId = null;
            sprinterId = null;
            LastCustomerId = 0;
        }

        private void RefreshServiceType()
        {
            if (lkpOriginCity.Value == null || lkpDestinationCity.Value == null) return;
            int originBranchId = 0;

            using (var cityDataManager = new CityDataManager())
            {
                var originCity = cityDataManager.GetFirst<CityModel>(WhereTerm.Default(lkpOriginCity.Value ?? 0, "id"));
                if (originCity != null)
                {
                    originBranchId = originCity.BranchId;
                }
            }

            BranchCityListModel branchCityListModel;
            using (var branchCityListDataManager = new BranchCityListDataManager())
            {
                branchCityListModel = branchCityListDataManager.GetFirst<BranchCityListModel>(
                    WhereTerm.Default(originBranchId, "branch_id"),
                    WhereTerm.Default((int)lkpDestinationCity.Value, "city_id")
                    );
            }

            if (branchCityListModel != null)
            {
                lkpServiceType.DefaultValue = new IListParameter[] { WhereTerm.Default(SERVICE_TYPE_CITY_COURIER, "Name") };
            }
        }

        private void RefreshDeliveryTariff()
        {
            if (_isPopulatingForm) return;

            ((ShipmentModel)CurrentModel).DeliveryFeeTotal = ((ShipmentModel)CurrentModel).DeliveryFee * Math.Max(txtChargeable.Value, DeliveryTariffMinimumWeight);
        }

        private void RefreshTariff()
        {
            if (isPopulatingForm) return;

            if (lkpOriginCity.Value == null || lkpDestinationCity.Value == null) return;

            if (_isPopulatingForm) return;

            if (((ShipmentModel) CurrentModel).Posted || ((ShipmentModel) CurrentModel).Voided) return;

            txtTariffPerKg.Value = 0;
            txtHandlingFee.Value = 0;
            chkRA.Checked = false;

            if (dropPointId == null)
            {
                if (lkpServiceType.Text.Equals("CITY COURIER"))
                {
                    txtDiscount.Enabled = false;
                    txtDiscount.Value = 0;
                }
                else
                {
                    txtDiscount.Enabled = true;

                    var upperLimit = Math.Max(CustomerDiscount, MaximumBranchDiscount);
                    if (txtDiscount.Value > upperLimit)
                    {
                        txtDiscount.Value = upperLimit;
                    }
                }
            }

            using (var dm = new DeliveryTariffDataManager())
            {
                DeliveryTariffModel dlvTariff = null;
                if (lkpPackageType.Value != null)
                {
                    dlvTariff = dm.GetByPackageTypeAndWeight((int)lkpPackageType.Value, (int) lkpDestinationCity.Value, txtTotalWeight.Value);
                }

                if (dlvTariff != null)
                {
                    ((ShipmentModel)CurrentModel).DeliveryFee = dlvTariff.Tariff;
                    DeliveryTariffMinimumWeight = dlvTariff.MinWeight;
                }
                else
                {
                    ((ShipmentModel)CurrentModel).DeliveryFee = 0;
                    DeliveryTariffMinimumWeight = 0;
                }
            }

            if (((ShipmentModel) CurrentModel).PricingPlanId != PRICING_PLAN_DOMESTIC)
            {
                using (var tariffInternationalDataManager = new TariffInternationalDataManager())
                {
                    var tariffIntModel = tariffInternationalDataManager.GetTariff(
                        ((ShipmentModel) CurrentModel).PricingPlanId ?? 0,
                        lkpPackageType.Value ?? 0,
                        txtChargeable.Value
                        );

                    if (tariffIntModel != null)
                    {
                        txtTariffPerKg.Value = 0;
                        txtTariffTotal.Value = tariffIntModel.Tariff;

                        txtHandlingFee.Value = tariffIntModel.HandlingFee??0;
                        ((ShipmentModel) CurrentModel).CurrencyId = tariffIntModel.CurrencyId;

                        using (var currencyDm = new CurrencyDataManager())
                        {
                            var currencyModel =
                                currencyDm.GetFirst<CurrencyModel>(WhereTerm.Default(tariffIntModel.CurrencyId, "id"));

                            if (currencyModel != null)
                            {
                                ((ShipmentModel) CurrentModel).Currency = currencyModel.Name;
                                ((ShipmentModel) CurrentModel).CurrencyRate = currencyModel.Rate;
                            }
                        }

                        RefreshGrandTotal();
                        return;
                    }
                }
            }
            else
            {
                using (var currencyDm = new CurrencyDataManager())
                {
                    var currencyModel =
                        currencyDm.GetFirst<CurrencyModel>(WhereTerm.Default(CURRENCY_IDR, "code"));

                    if (currencyModel != null)
                    {
                        ((ShipmentModel)CurrentModel).CurrencyId = currencyModel.Id;
                        ((ShipmentModel)CurrentModel).Currency = currencyModel.Name;
                        ((ShipmentModel)CurrentModel).CurrencyRate = currencyModel.Rate;
                    }
                }
            }

            if (lkpCustomer.Value != null)
            {
                using (var customerTariffDataManager = new CustomerTariffDataManager())
                {
                    var customerTariffModel = customerTariffDataManager.GetTariff(
                        (int) lkpOriginCity.Value,
                        (int) lkpDestinationCity.Value,
                        lkpServiceType.Value ?? 0,
                        lkpPackageType.Value ?? 0,
                        lkpCustomer.Value ?? 0,
                        txtChargeable.Value
                        );
                    if (customerTariffModel != null)
                    {
                        txtTariffPerKg.Value = customerTariffModel.Tariff;
                        txtHandlingFee.Value = customerTariffModel.HandlingFee;

                        chkRA.Checked = customerTariffModel.Ra ?? false;
                        MinWeight = customerTariffModel.MinWeight;
                        if (MinWeight > 0 && txtTotalWeight.Value < MinWeight) txtTotalWeight.Value = MinWeight;
                        RefreshGrandTotal();
                        return;
                    }
                }
            }

            using (var tariffDataManager = new TariffDataManager())
            {
                var tariffModel = tariffDataManager.GetTariff(
                    (int) lkpOriginCity.Value,
                    (int) lkpDestinationCity.Value,
                    lkpServiceType.Value ?? 0,
                    lkpPackageType.Value ?? 0,
                    txtChargeable.Value
                    );
                if (tariffModel != null)
                {
                    txtTariffPerKg.Value = tariffModel.Tariff;
                    txtHandlingFee.Value = tariffModel.HandlingFee;

                    chkRA.Checked = tariffModel.Ra ?? false;
                    MinWeight = tariffModel.MinWeight;
                    if (MinWeight > 0 && txtTotalWeight.Value < MinWeight) txtTotalWeight.Value = MinWeight;
                    RefreshGrandTotal();
                    return;
                }
            }

            txtTariffPerKg.Text = @"0";
            txtHandlingFee.Text = @"0";

            MinWeight = 0;
            RefreshGrandTotal();
        }

        private bool SetPromo(PromoModel promo)
        {
            promoId = null;
            tbxPromo.Text = string.Empty;

            if (promo.CityOrigId != null) if (promo.CityOrigId != lkpOriginCity.Value) return false;
            if (promo.CityDestId != null) if (promo.CityDestId != lkpDestinationCity.Value) return false;
            if (promo.PackageTypeId != null) if (promo.PackageTypeId != lkpPackageType.Value) return false;
            if (promo.ServiceTypeId != null) if (promo.ServiceTypeId != lkpServiceType.Value) return false;

            if (promo.MinWeight != null && txtTotalWeight.Value < promo.MinWeight)
            {
                tbxPromo.Text = string.Empty;
                promoId = null;

                RefreshTariff();

                return false;
            }

            promoId = promo.Id;
            tbxPromo.Text = promo.Code;

            if (promo.Tariff != null) txtTariffPerKg.Value = (decimal)promo.Tariff;
            if (promo.Discount != null) txtDiscount.Value = (decimal)promo.Discount;
            return true;
        }

        private void CheckPromo()
        {
            var now = DateTime.Now;
            var promoes = new PromoDataManager().Get<PromoModel>(new IListParameter[]
                {
                    WhereTerm.Default(new DateTime(now.Year, now.Month, now.Day, 23, 59, 59), "expired_date", EnumSqlOperator.GreatThanEqual),
                    WhereTerm.Default(true, "active"),
                    WhereTerm.Default(txtDate.DateTime, "createddate", EnumSqlOperator.LesThanEqual)
                }).ToList();

            if (promoes.Count() > 0)
            {
                // check promo based on origin city
                var origbase = promoes.Where(p => p.CityOrigId == lkpOriginCity.Value).ToList();
                if (origbase.Count() > 0)
                {
                    if (origbase.Count() == 1)
                    {
                        if (SetPromo(origbase.FirstOrDefault())) return;
                        else origbase = promoes.Where(p => p.CityOrigId != lkpOriginCity.Value).ToList();
                    }

                    promoes = origbase;
                }
                else
                {
                    promoes = promoes.Where(p => p.CityOrigId == null).ToList();
                    origbase = promoes;
                }

                //based on destination city
                var destbase = origbase.Where(p => p.CityDestId == lkpDestinationCity.Value).ToList();
                if (destbase.Count() > 0)
                {
                    if (destbase.Count() == 1)
                    {
                        if (SetPromo(destbase.FirstOrDefault())) return;
                        else destbase = origbase.Where(p => p.CityDestId != lkpDestinationCity.Value).ToList();
                    }
                    
                    promoes = destbase;
                }
                else
                {
                    promoes = promoes.Where(p => p.CityDestId == null).ToList();
                    destbase = promoes;
                }

                //based on package type
                var packbase = destbase.Where(p => p.PackageTypeId == lkpPackageType.Value).ToList();
                if (packbase.Count() > 0)
                {
                    if (packbase.Count() == 1)
                    {
                        if (SetPromo(packbase.FirstOrDefault())) return;
                        else packbase = destbase.Where(p => p.PackageTypeId != lkpPackageType.Value).ToList();
                    }
                    
                    promoes = packbase;
                }
                else
                {
                    promoes = promoes.Where(p => p.PackageTypeId == null).ToList();
                    packbase = promoes;
                }
   
                //based on service type
                var servbase = packbase.Where(p => p.ServiceTypeId == lkpServiceType.Value).ToList();

                if (servbase.Count() > 0)
                {
                    if (servbase.Count() == 1)
                    {
                        SetPromo(servbase.FirstOrDefault());
                        return;
                    }
                }
                else promoes = promoes.Where(p => p.ServiceTypeId == null).ToList();

                if (promoes.Count() == 1) SetPromo(promoes.FirstOrDefault());
            }
        }

        private void RefreshGrandTotal()
        {
            if (isPopulatingForm) return;
            if (dropPointId == null) CheckPromo();

            if (string.IsNullOrEmpty(txtDiscountTotal.Text) || string.IsNullOrEmpty(txtDiscount.Text) ||
                string.IsNullOrEmpty(txtTariffNet.Text) || string.IsNullOrEmpty(txtTariffTotal.Text) ||
                string.IsNullOrEmpty(txtInsuranceFee.Text) || string.IsNullOrEmpty(txtPackingFee.Text) ||
                string.IsNullOrEmpty(txtOtherFee.Text) || string.IsNullOrEmpty(txtInsuranceFee.Text)) return;

            if (((ShipmentModel) CurrentModel).PricingPlanId == PRICING_PLAN_DOMESTIC)
            {
                txtTariffTotal.Value = (txtTariffPerKg.Value*txtChargeable.Value) + txtHandlingFee.Value;
            }

            txtDiscountTotal.Value = (txtDiscount.Value / 100) * txtTariffTotal.Value;
            txtTariffNet.Value = txtTariffTotal.Value - txtDiscountTotal.Value;

            //txtInsuranceFee.Value = txtGoodsValue.Value * ((float) _fixedShippingInsuranceRate);

            var grandTotal = txtTariffNet.Value + txtPackingFee.Value + txtOtherFee.Value + txtInsuranceFee.Value;

            if (((ShipmentModel)CurrentModel).CurrencyId != null)
            {
                grandTotal *= ((ShipmentModel)CurrentModel).CurrencyRate;
            }

            txtGrandTotal.Value = grandTotal;
        }

        private void chkAutoGen_CheckedChanged(object sender, EventArgs e)
        {
            if (StateChange == EnumStateChange.Insert)
            {
                txtShipmentNo.Enabled = !chkAutoGen.Checked;
                txtShipmentNo.Focus();

                if (chkAutoGen.Checked && lkpPaymentMethod.Value != null && !lkpPaymentMethod.Text.Equals("CASH"))
                {
                    MessageBox.Show(@"Nomor CN harus CASH");

                    lkpPaymentMethod.DefaultValue = new IListParameter[] {WhereTerm.Default("CASH", "name")};
                }
            }
        }

        private void lkpBranch_EditValueChanged(object sender, EventArgs e)
        {
            RefreshServiceType();
        }

        private void lkpOriginCity_EditValueChanged(object sender, EventArgs e)
        {
            RefreshServiceType();
        }

        private void lkpDestinationCity_EditValueChanged(object sender, EventArgs e)
        {
            var cityDataManager = new CityDataManager();
            var countryDataManager = new CountryDataManager();
            
            var cityModel = cityDataManager.GetFirst<CityModel>(WhereTerm.Default(lkpDestinationCity.Value ?? 0, "Id"));

            if (cityModel != null)
            {
                var countryModel = countryDataManager.GetFirst<CountryModel>(WhereTerm.Default(cityModel.CountryId, "Id"));

                if (countryModel != null)
                {
                    ((ShipmentModel)CurrentModel).PricingPlanId = countryModel.PricingPlanId;
                }
            }
            
            cityDataManager.Dispose();
            countryDataManager.Dispose();

            RefreshServiceType();
        }

        private void lkpPackageType_EditValueChanged(object sender, EventArgs e)
        {
            RefreshTariff();
            NoServiceMessage();
        }

        private void lkpServiceType_EditValueChanged(object sender, EventArgs e)
        {
            RefreshTariff();
            NoServiceMessage();
        }

        //private void txtDiscount_EditValueChanged(object sender, EventArgs e)
        //{
        //    RefreshGrandTotal();
        //}

        private void txtPackingFee_EditValueChanged(object sender, EventArgs e)
        {
            RefreshGrandTotal();
        }

        private void txtOtherFee_EditValueChanged(object sender, EventArgs e)
        {
            RefreshGrandTotal();
        }

        private void txtGoodsValue_EditValueChanged(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;

            var goodsvalue = txtGoodsValue.Value;
            if (goodsvalue == 0) txtInsuranceFee.Value = 0;
            //else txtInsuranceFee.Value = Math.Round((goodsvalue * BaseControl.GoodValuesInsurance) + BaseControl.GoodValuesAdministration, 0, MidpointRounding.AwayFromZero);
            else
            {
                var insurance = Math.Round(goodsvalue * (Convert.ToDecimal(_lookup.Value) / 100));

                if (Convert.ToDecimal(_minInsurance) > insurance) txtInsuranceFee.Value = Convert.ToDecimal(_minInsurance);
                else txtInsuranceFee.Value = insurance;

                txtInsuranceFee.Value = txtInsuranceFee.Value + Convert.ToDecimal(_adminInsurance);
            }

            RefreshGrandTotal();
        }

        private void txtInsuranceFee_EditValueChanged(object sender, EventArgs e)
        {
            RefreshGrandTotal();
        }

        private void txtTotalPiece_EditValueChanged(object sender, EventArgs e)
        {
            RefreshGrandTotal();
        }

        private void txtTotalWeight_EditValueChanged(object sender, EventArgs e)
        {
            RefreshGrandTotal();
        }

        private void txtChargeable_EditValueChanged(object sender, EventArgs e)
        {
            if (((ShipmentModel)CurrentModel).PricingPlanId != PRICING_PLAN_DOMESTIC)
            {
                RefreshTariff();
            }
            else
            {
                RefreshGrandTotal();
            }

            RefreshDeliveryTariff();
            CheckPromo();
        }

        private void lkpDestinationCity_Leave(object sender, EventArgs e)
        {
            RefreshTariff();
            NoServiceMessage();
        }

        private void btnRefreshTariff_Click(object sender, EventArgs e)
        {
            RefreshTariff();
            NoServiceMessage();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        public override void Save()
        {
            if (txtTariffNet.Value == 0)
            {
                MessageBox.Show("Tidak ada layanan pengiriman untuk tujuan atau service tersebut.");
                return;
            }

            if (chkAutoGen.Checked)
            {
                dropPointId = null;
                sprinterId = null;
                base.Save();
            }
            else if (CheckCn()) base.Save();
        }

        private void NoServiceMessage()
        {
            if (txtGrandTotal.Value == 0 && lkpDestinationCity.Value > 0) MessageBox.Show("Tidak ada layanan pengiriman untuk tujuan atau service tersebut.");
        }

        private void PrintPOD()
        {
            var dataSource = GetPrintDataSource();
            if (chkPrintOrder.Checked)
            {
                if (chkAutoGen.Checked)
                {
                    var printout = new EConnotePrintout
                    {
                        DataSource = dataSource
                    };

                    printout.Print();
                    new ShipmentExpandDataManager().Printing(CurrentModel.Id);
                }
                else
                {
                    if (chkPrintContinuous.Checked)
                    {
                        var printout = new ConsignmentNoteContinuous
                        {
                            DataSource = dataSource
                        };

                        if (printout.Print())
                        {
                            new ShipmentExpandDataManager().Printing(CurrentModel.Id);
                        }
                    }
                    else
                    {
                        var printout = new ConsignmentNote
                        {
                            DataSource = dataSource
                        };

                        if (printout.Print())
                        {
                            new ShipmentExpandDataManager().Printing(CurrentModel.Id);
                        }
                    }
                }
            }

            if (chkPrintBarcode.Checked)
            {
                var barcodeDataSource = new List<ShipmentModel.ShipmentReportRow>();
                var modelMaster = dataSource.First();

                for (var i = 2; i <= ((ShipmentModel) CurrentModel).TtlPiece; i++)
                {
                    var model = ConvertModel<ShipmentModel.ShipmentReportRow, ShipmentModel.ShipmentReportRow>(modelMaster);
                    model.Code += i.ToString("000");
                    model.Number = i;
                    model.Count = ((ShipmentModel) CurrentModel).TtlPiece;
                    barcodeDataSource.Add(model);
                }

                var printout = new CnBarcodeCard
                {
                    DataSource = barcodeDataSource
                };

                printout.Print();
            }
        }

        private IEnumerable<ShipmentModel.ShipmentReportRow> GetPrintDataSource()
        {
            var model = ConvertModel<ShipmentModel, ShipmentModel.ShipmentReportRow>(CurrentModel as ShipmentModel);

            if (model == null) return null;

            using (var customerDm = new CustomerDataManager())
            {
                var customer = customerDm.GetFirst<CustomerModel>(WhereTerm.Default(model.CustomerId ?? 0, "id"));
                if (customer != null)
                {
                    model.CustomerCode = customer.Code;
                }
            }

            using (var serviceTypeDm = new ServiceTypeDataManager())
            {
                var serviceType = serviceTypeDm.GetFirst<ServiceTypeModel>(WhereTerm.Default(model.ServiceTypeId, "id"));
                if (serviceType != null)
                {
                    model.ServiceType = serviceType.Name;
                }
            }

            using (var employeeDm = new EmployeeDataManager())
            {
                var employee = employeeDm.GetFirst<EmployeeModel>(WhereTerm.Default(model.MessengerId ?? 0, "id"));
                if (employee != null)
                {
                    model.MessengerCode = employee.Code;
                }
            }

            using (var paymentMethodDm = new PaymentMethodDataManager())
            {
                var paymentMethod = paymentMethodDm.GetFirst<PaymentMethodModel>(WhereTerm.Default(model.PaymentMethodId, "id"));
                if (paymentMethod != null)
                {
                    model.PaymentMethod = paymentMethod.Name;
                }
            }

            using (var branchDm = new BranchDataManager())
            {
                var branch = branchDm.GetFirst<BranchModel>(WhereTerm.Default(model.BranchId, "id"));
                if (branch != null)
                {
                    model.ShipmentHeader = branch.HeaderShipment;
                }
            }

            using (var packageDm = new PackageTypeDataManager())
            {
                var package = packageDm.GetFirst<PackageTypeModel>(WhereTerm.Default(model.PackageTypeId, "id"));
                if (package != null)
                {
                    model.PackageType = package.Name;
                }
            }

            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(model.Id, "shipment_id"));
            model.VolumeL = expand != null ? expand.VolumeL : 1;
            model.VolumeH = expand != null ? expand.VolumeH : 1;
            model.VolumeW = expand != null ? expand.VolumeW : 1;
            model.Printed = expand != null ? expand.Printed : (short)0;

            return new List<ShipmentModel.ShipmentReportRow>
            {
                model
            };
        }

        protected override void AfterSave()
        {
            //base.AfterSave();
            tsBaseTxt_Code.Focus();

            PodStatusModel.ShipmentId = CurrentModel.Id;
            PodStatusModel.PositionStatusId = BaseControl.BranchId;
            PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();

            ShipmentStatusUpdate();

            ActiveControl = tsBaseTxt_Code.Control;

            tsBaseTxt_Code.Text = ((ShipmentModel)CurrentModel).Code;
            txtShipmentNo.Text = ((ShipmentModel)CurrentModel).Code;
            chkAutoGen.Enabled = false;

            var expandModel = new ShipmentExpandModel
            {
                ShipmentId = CurrentModel.Id,
                VolumeL = tbxL.Value,
                VolumeW = tbxW.Value,
                VolumeH = tbxH.Value,
                UsePacking = cbxPacking.Checked,
                IsCod = false,
                TotalCod = 0,
                Printed = 0,
                DropPointId = dropPointId,
                EmailPoint = tbxEmailPoint.Text,
                SprinterId = sprinterId
            };
            SaveExpand(expandModel);

            PrintPOD();

            tsBaseBtn_New.PerformClick();
        }

        bool CheckCn()
        {
            var ship = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(txtShipmentNo.Text, "code", EnumSqlOperator.Equals));
            if (ship != null)
            {
                if (ship.Id != CurrentModel.Id)
                {
                    MessageBox.Show(Resources.cn_exists, Resources.information, MessageBoxButtons.OK);
                    txtShipmentNo.Text = string.Empty;
                    txtShipmentNo.Focus();
                    return false;
                }
            }

            if (txtShipmentNo.Text.Length > 4 && !((ShipmentDataManager)DataManager).CheckPrefixBranchShipment(BaseControl.BranchId, txtShipmentNo.Text, true))
            {
                MessageBox.Show(Resources.invalid_stt, Resources.invalid_stt_title, MessageBoxButtons.OK);
                txtShipmentNo.Text = string.Empty;
                txtShipmentNo.Focus();
                return false;
            }

            return true;
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            if (TotalPage > 0)
            {
                tsBaseBtn_Print.Enabled = true;
                tsBaseBtn_PrintPreview.Enabled = false;
            }

            var model = CurrentModel as ShipmentModel;
            if (model != null && model.Id > 0 && (model.Voided || model.Posted || model.Invoiced == 1 || (DateTime.Now - model.DateProcess).TotalDays > 1))
            {
                EnabledForm(false);
                btnSave.Enabled = false;
                tsBaseBtn_Save.Enabled = false;
                NavigationMenu.SaveStrip.Enabled = false;
                tsBaseBtn_Delete.Enabled = false;
                NavigationMenu.DeleteStrip.Enabled = false;
            }
        }

        protected override void VolumeCalculation(decimal L, decimal W, decimal H, string serviceType, decimal Gw, dTextBoxNumber chargeable)
        {
            base.VolumeCalculation(L, W, H, serviceType, Gw, chargeable);
            if (cbxPacking.Checked) txtPackingFee.SetValue(PackingCalculation(L, W, H));
        }
    }
}