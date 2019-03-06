using System;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Administration.Forms.Popup;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Common.Properties;
using Devenlab.Common.WinControl.MessageBox;

namespace SISCO.Presentation.Administration.Forms
{
    // ReSharper disable once InconsistentNaming
    public partial class PODCorrectionForm : BaseCrudForm<ShipmentModel, ShipmentDataManager>//BaseToolbarForm//
    {
        private decimal _fixedShippingInsuranceRate;

        // ReSharper disable InconsistentNaming
        const string CURRENCY_IDR = "IDR";
        const string SERVICE_TYPE_CITY_COURIER = "CITY COURIER";
        const int PRICING_PLAN_DOMESTIC = 1;
        private int? dropPointId { get; set; }
        private int? sprinterId { get; set; }
        // ReSharper restore InconsistentNaming

        public decimal DeliveryTariffMinimumWeight { get; set; }
        public bool IsInternationalShipment { get; set; }

        public PODCorrectionForm()
        {
            InitializeComponent();
            form = this;
        }

        protected override void BindDataSource<T>()
        {
            CurrentModel = LoadModel<T>(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
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

            base.LoadForm(sender, e);

            EnableBtnSearch = true;


            txtDate.FieldLabel = "Date";
            txtDate.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpBranch.LookupPopup = new BranchPopup();
            lkpBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code;
            lkpBranch.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            lkpCustomer.LookupPopup = new CustomerPopup(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            lkpCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpCustomer.AutoCompleteWhereExpression = (s, param) => param.SetWhereExpression("(code = @0 or name.StartsWith(@0)) and branch_id = @1", s, BaseControl.BranchId);
            lkpCustomer.FieldLabel = "Customer";
            lkpCustomer.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpOriginCity.LookupPopup = new CityPopup();
            lkpOriginCity.AutoCompleteDataManager = new CityDataManager();
            lkpOriginCity.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpOriginCity.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpOriginCity.FieldLabel = "Origin City";
            lkpOriginCity.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpDestinationCity.LookupPopup = new CityPopup();
            lkpDestinationCity.AutoCompleteDataManager = new CityDataManager();
            lkpDestinationCity.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpDestinationCity.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpDestinationCity.FieldLabel = "Destination City";
            lkpDestinationCity.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpPackageType.LookupPopup = new PackageTypePopup();
            lkpPackageType.AutoCompleteDataManager = new PackageTypeDataManager();
            lkpPackageType.AutoCompleteDisplayFormater = model => ((PackageTypeModel)model).Name;
            lkpPackageType.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpPackageType.FieldLabel = "Package Type";
            lkpPackageType.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpServiceType.LookupPopup = new ServiceTypePopup();
            lkpServiceType.AutoCompleteDataManager = new ServiceTypeDataManager();
            lkpServiceType.AutoCompleteDisplayFormater = model => ((ServiceTypeModel)model).Name;
            lkpServiceType.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpServiceType.FieldLabel = "Service Type";
            lkpServiceType.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpPaymentMethod.LookupPopup = new PaymentMethodPopup();
            lkpPaymentMethod.AutoCompleteDataManager = new PaymentMethodDataManager();
            lkpPaymentMethod.AutoCompleteDisplayFormater = model => ((PaymentMethodModel)model).Name;
            lkpPaymentMethod.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpPaymentMethod.FieldLabel = "Payment Method";
            lkpPaymentMethod.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpMessenger.LookupPopup = new EmployeePopup(EmployeeModel.EmployeeType.Messenger);
            lkpMessenger.AutoCompleteDataManager = new EmployeeDataManager();
            lkpMessenger.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " " + ((EmployeeModel)model).Name;
            lkpMessenger.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_messenger AND branch_id = @1", s, BaseControl.BranchId);

            lkpMessenger2.LookupPopup = new EmployeePopup(EmployeeModel.EmployeeType.Messenger);
            lkpMessenger2.AutoCompleteDataManager = new EmployeeDataManager();
            lkpMessenger2.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " " + ((EmployeeModel)model).Name;
            lkpMessenger2.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_messenger AND branch_id = @1", s, BaseControl.BranchId);

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
            txtPackingFee.EditMask = "#,###,###,##0.00";
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

            btnVoid.Click += BtnVoidOnClick;
            txtTotalWeight.TextChanged += TxtTotalWeightOnTextChanged;
            txtChargeable.TextChanged += TxtChargeableTextChanged;
            lkpCustomer.TextChanged += lkpCustomer_TextChanged;
            txtDiscount.TextChanged += (o, args) => RefreshTariff();
            txtDeliveryTariff1.TextChanged += (o, args) => RefreshDeliveryTariff();
            txtInsuranceFee.TextChanged += txtInsuranceFee_EditValueChanged;

            lkpBranch.TextChanged += (o, args) =>
            {
                if (lkpBranch.Value != null)
                {
                    using (var branchDm = new BranchDataManager())
                    {
                        var branch = branchDm.GetFirst<BranchModel>(WhereTerm.Default((int) lkpBranch.Value, "id"));
                        MaximumBranchDiscount = branch.MaxDiscount > 0 ? branch.MaxDiscount : 0;
                    }
                }
            };

            tsBaseTxt_Code.KeyPress += (o, args) =>
            {
                if (args.KeyChar == 13)
                {
                    txtDate.SelectAll();
                    txtDate.Focus();
                }
            };

            btnRefreshTariff.Enabled = false;
            btnSave.Enabled = false;
            btnVoid.Enabled = false;
            btnSave.PreviewKeyDown += (o, args) =>
            {
                if (args.KeyCode == Keys.Up || args.KeyCode == Keys.Left)
                {
                    txtInsuranceFee.Focus();
                }
            };

            NavigationMenu.NewStrip.Enabled = false;
            tsBaseBtn_New.Enabled = false;

            SearchPopup = new ShipmentPopup();

            tbxL.EditValueChanged += (s, o) => VolumeCalculation(tbxL.Value, tbxW.Value, tbxH.Value, lkpServiceType.Text, txtTotalWeight.Value, txtChargeable);
            tbxW.EditValueChanged += (s, o) => VolumeCalculation(tbxL.Value, tbxW.Value, tbxH.Value, lkpServiceType.Text, txtTotalWeight.Value, txtChargeable);
            tbxH.EditValueChanged += (s, o) => VolumeCalculation(tbxL.Value, tbxW.Value, tbxH.Value, lkpServiceType.Text, txtTotalWeight.Value, txtChargeable);

            cbxCod.Click += (s, a) =>
            {
                tbxCod.Enabled = cbxCod.Checked;
                if (cbxCod.Checked)
                {
                    tbxCod.Focus();
                }
                else
                {
                    tbxCod.SetValue((decimal)0);
                    tbxFulfilment.Focus();
                }
            };

            cbxPacking.Click += (s, o) =>
            {
                if (cbxPacking.Checked) txtPackingFee.Value = PackingCalculation(tbxL.Value, tbxW.Value, tbxH.Value);
                else txtPackingFee.Value = 0;
            };

            lkpDestinationCity.Leave += DestCityLeave;
            lkpPackageType.Leave += (s, a) => RefreshTariff(true);
            lkpServiceType.Leave += (s, a) => RefreshTariff(true);
        }

        private void TxtChargeableTextChanged(object sender, EventArgs e)
        {
            RefreshTariff(true);
        }

        private void DestCityLeave(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;
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

                    if (!_isPopulatingForm)
                    {
                        txtShipperName.Text = customer.Name;
                        txtShipperAddress.Text = customer.Address;
                        txtShipperPhone.Text = customer.Phone;

                        ((ShipmentModel)CurrentModel).ShipperSaved = true;

                        txtDiscount.Value = CustomerDiscount;
                        txtDiscount.Enabled = false;

                        RefreshTariff(true);
                    }
                }
                else txtDiscount.Enabled = true;
            }
        }

        public int LastCustomerId { get; set; }

        private void TxtTotalWeightOnTextChanged(object sender, EventArgs eventArgs)
        {
            decimal ceiled;

            if (((ShipmentModel)CurrentModel).PricingPlanId == PRICING_PLAN_DOMESTIC)
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

            RefreshGrandTotal();
        }

        private void BtnVoidOnClick(object sender, EventArgs eventArgs)
        {
            DialogResult r = MessageBox.Show(@"Apa anda yakin untuk mem-VOID POD ini?", "",
                MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                btnVoid.Text = @"Voided";
                btnVoid.Enabled = false;
                btnSave.Enabled = false;
                EnabledForm(false);

                ((ShipmentModel) CurrentModel).Voided = true;

                Save();

                RefreshToolbarState();
            }
        }

        protected override void PopulateForm(ShipmentModel model)
        {
            ClearForm();
            if (model == null) return;
            LastCustomerId = model.CustomerId ?? 0;
            tbxPromo.Enabled = false;

            txtDate.DateTime = model.DateProcess;
            lkpBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(model.BranchId, "id") };

            chkRA.Checked = model.NeedRa;

            tsBaseTxt_Code.Text = model.Code;
            txtShipmentNo.Text = model.Code;

            lkpOriginCity.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CityId, "id") };
            lkpDestinationCity.DefaultValue = new IListParameter[] {WhereTerm.Default(model.DestCityId, "id")};

            lkpCustomer.DefaultValue = new IListParameter[] {WhereTerm.Default(model.CustomerId ?? 0, "id")};

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
            if (model.MessengerId != null)
                lkpMessenger.DefaultValue = new IListParameter[] { WhereTerm.Default((int) model.MessengerId, "id") };
            if (model.MessengerId2 != null)
                lkpMessenger2.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.MessengerId2, "id") };

            txtNatureOfGoods.Text = model.NatureOfGoods;
            txtNote.Text = model.Note;

            txtTotalPiece.Value = model.TtlPiece;
            txtTotalWeight.Value = model.TtlGrossWeight;
            txtChargeable.Value = model.TtlChargeableWeight;

            txtTariffPerKg.Value = model.Tariff;
            txtHandlingFee.Value = model.HandlingFeeTotal;
            txtTariffTotal.Value = model.TariffTotal;
            txtDiscount.Value = model.DiscountPercent;
            txtDiscountTotal.Value = model.DiscountTotal;
            txtTariffNet.Value = model.TariffNet;

            txtPackingFee.Value = model.PackingFee;
            txtOtherFee.Value = model.OtherFee;
            txtGoodsValue.Value = model.GoodsValue;
            txtInsuranceFee.Value = model.InsuranceFee;

            txtDiscount.Enabled = !lkpServiceType.Text.ToUpper().Equals("CITY COURIER");

            txtGrandTotal.Value = model.Total;
            txtDiscountTotal.Value = model.DiscountTotal;

            txtDeliveryTariff1.Value = model.DeliveryFee;
            txtDeliveryTariff2.Value = model.DeliveryFeeTotal;

            if (model.AutoNumber ||
                (model.SalesTypeId == 3 && lkpPaymentMethod.Text.ToUpper().Equals("CASH")) ||
                (model.SalesTypeId == 1 && lkpPaymentMethod.Text.ToUpper().Equals("CASH"))
                )
            {
                lkpCustomer.ValidationRules = new ComponentValidationRule[] { };
            }
            else
            {
                lkpCustomer.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            }

            tbxPromo.Text = model.PromoCode;
            tbxDp.Clear();
            tbxSprinter.Clear();
            dropPointId = null;
            sprinterId = null;
            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(model.Id, "shipment_id"));
            if (expand != null)
            {
                tbxL.SetValue(expand.VolumeL);
                tbxW.SetValue(expand.VolumeW);
                tbxH.SetValue(expand.VolumeH);

                cbxPacking.Checked = expand.UsePacking;
                cbxCod.Checked = expand.IsCod;
                tbxCod.SetValue(expand.TotalCod);
                tbxFulfilment.Text = expand.Fulfilment;

                if (expand.IsCod) tbxCod.Enabled = true;

                if (expand.DropPointId != null)
                {
                    var dp = new DropPointDataManager().GetFirst<DropPointModel>(WhereTerm.Default((int)expand.DropPointId, "id"));
                    if (dp != null)
                    {
                        tbxDp.Text = dp.Code;
                        dropPointId = dp.Id;
                        txtDiscount.Enabled = false;
                    }
                }

                if (expand.SprinterId != null)
                {
                    var emp = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)expand.SprinterId, "id"));
                    if (emp != null)
                    {
                        tbxSprinter.Text = emp.Code;
                        sprinterId = emp.Id;
                    }
                }
            }
            else
            {
                tbxL.SetValue(Resources.default_number);
                tbxW.SetValue(Resources.default_number);
                tbxH.SetValue(Resources.default_number);
                tbxCod.SetValue((decimal)0);
            }

            tbxCod.Enabled = cbxCod.Checked;

            if (model.Voided || model.Invoiced == 1)
            {
                if (model.Voided)
                {
                    MessageBox.Show(@"POD sudah di-VOID!");
                    btnVoid.Text = @"Voided";
                }
                else
                {
                    MessageBox.Show(@"POD sudah di-INVOICE!");
                }
                btnVoid.Enabled = false;
                btnSave.Enabled = false;
                btnRefreshTariff.Enabled = false;
                EnabledForm(false);
            }
            else
            {
                btnVoid.Text = @"Void";
                btnVoid.Enabled = (model.Invoiced == 0);

                lkpBranch.Enabled = false;
                lkpPaymentMethod.Enabled = !model.AutoNumber;

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

                txtDeliveryTariff2.Enabled = false;

                btnRefreshTariff.Enabled = model.SalesTypeId != 3;
                btnSave.Enabled = true;
            }
        }

        protected override ShipmentModel PopulateModel(ShipmentModel model)
        {
            if (lkpBranch.Value == null)
                throw new BusinessException(""); // TODO: BERI MESSAGE ERROR
            model.BranchId = (int) lkpBranch.Value;

            model.DateProcess = txtDate.DateTime;
            model.Code = txtShipmentNo.Text;

            model.NeedRa = chkRA.Checked;

            if (lkpOriginCity.Value == null)
                throw new BusinessException(""); // TODO: BERI MESSAGE ERROR
            model.CityId = (int)lkpOriginCity.Value;
            model.CityName = lkpOriginCity.Text;

            if (lkpDestinationCity.Value == null)
                throw new BusinessException(""); // TODO: BERI MESSAGE ERROR
            model.DestCity = lkpDestinationCity.Text;
            model.DestCityId = (int)lkpDestinationCity.Value;

            using (var dm = new CityDataManager())
            {
                var city = dm.GetFirst<CityModel>(WhereTerm.Default(model.DestCityId, "id"));
                if (city != null)
                {
                    model.DestBranchId = city.BranchId;
                    model.DestCountryId = city.CountryId;
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
                if (customer != null)
                {
                    model.CustomerName = customer.Name;
                }
                else
                {
                    model.CustomerName = string.Empty;
                }
            }

            model.ShipperName = txtShipperName.Text;
            model.ShipperAddress = txtShipperAddress.Text;
            model.ShipperPhone = txtShipperPhone.Text;
            model.RefNumber = txtShipperRef.Text;

            model.ConsigneeName = txtConsigneeName.Text;
            model.ConsigneeAddress = txtConsigneeAddress.Text;
            model.ConsigneePhone = txtConsigneePhone.Text;

            if (lkpPackageType.Value == null)
                throw new BusinessException("");// TODO: BERI MESSAGE ERROR
            model.PackageTypeId = (int)lkpPackageType.Value;
            model.PackageType = lkpPackageType.Text;

            if (lkpServiceType.Value == null)
                throw new BusinessException("");// TODO: BERI MESSAGE ERROR
            model.ServiceTypeId = (int)lkpServiceType.Value;

            if (lkpPaymentMethod.Value == null)
                throw new BusinessException("");// TODO: BERI MESSAGE ERROR
            model.PaymentMethodId = (int)lkpPaymentMethod.Value;
            model.PaymentMethod = lkpPaymentMethod.Text;

            model.MessengerName = lkpMessenger.Text;
            model.MessengerId = lkpMessenger.Value;

            model.MessengerId2 = lkpMessenger2.Value;
            model.MessengerName2 = lkpMessenger2.Text;

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

            model.DeliveryFee = txtDeliveryTariff1.Value;
            model.DeliveryFeeTotal = txtDeliveryTariff2.Value;

            model.Total = txtGrandTotal.Value;

            model.DiscountTotal = txtDiscountTotal.Value;

            if (model.FranchiseId == null)
            {
                if (model.PaymentMethod.ToUpper().Equals("CASH") && model.SalesTypeId != 1 && model.SalesTypeId != 3)
                {
                    model.SalesTypeId = 1;
                }
            }

            return model;
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            // ReSharper disable LocalizableElement
            if (txtDate.Text == string.Empty)
            {
                MessageBox.Show("Please enter the date!");
                return false;
            }
            if (lkpOriginCity.Value == null)
            {
                MessageBox.Show("Please enter the origin city!");
                return false;
            }
            if (lkpDestinationCity.Value == null)
            {
                MessageBox.Show("Please enter the destination city!");
                return false;
            }
            if (txtShipperName.Text == string.Empty)
            {
                MessageBox.Show("Please enter the shipper name!");
                return false;
            }
            if (txtShipperAddress.Text == string.Empty)
            {
                MessageBox.Show("Please enter the shipper address!");
                return false;
            }
            if (txtShipperPhone.Text == string.Empty)
            {
                MessageBox.Show("Please enter the shipper phone number!");
                return false;
            }
            if (txtConsigneeName.Text == string.Empty)
            {
                MessageBox.Show("Please enter the consignee name!");
                return false;
            }
            if ((((ShipmentModel) CurrentModel).AutoNumber ||
                 (((ShipmentModel) CurrentModel).SalesTypeId == 3 && lkpPaymentMethod.Text.ToUpper().Equals("CASH"))) ||
                (((ShipmentModel)CurrentModel).SalesTypeId == 1 && lkpPaymentMethod.Text.ToUpper().Equals("CASH")) ||
                (((ShipmentModel)CurrentModel).SalesTypeId == 0 && lkpPaymentMethod.Text.ToUpper().Equals("CASH")))
            {
            }
            else
            {
                if (lkpCustomer.Value == null)
                {
                    MessageBox.Show("Customer harus diisi!");
                    return false;
                }
            }
            if (txtConsigneeAddress.Text == string.Empty)
            {
                MessageBox.Show("Please enter the consignee address!");
                return false;
            }
            if (txtConsigneePhone.Text == string.Empty)
            {
                MessageBox.Show("Please enter the consignee phone number!");
                return false;
            }
            if (lkpPackageType.Value == null)
            {
                MessageBox.Show("Please select the package type!");
                return false;
            }
            if (lkpServiceType.Value == null)
            {
                MessageBox.Show("Please select the service type!");
                return false;
            }
            if (lkpPaymentMethod.Value == null)
            {
                MessageBox.Show("Please select the payment method type!");
                return false;
            }
            if (txtTotalPiece.Value == 0)
            {
                MessageBox.Show("Please fill the total piece field!");
                return false;
            }
            if (txtTotalWeight.Value == 0)
            {
                MessageBox.Show("Please wnter the total weight!");
                return false;
            }
            if (txtChargeable.Value == 0)
            {
                MessageBox.Show("Please enter the chargeable weight!");
                return false;
            }
            // ReSharper restore LocalizableElement

            return true;
        }

        protected override ShipmentModel Find(string searchTerm)
        {
            DataManager = new ShipmentDataManager();
            return DataManager.GetFirst<ShipmentModel>(
                WhereTerm.Default(searchTerm, "code"),
                WhereTerm.Default(BaseControl.BranchId, "branch_id"));
        }

        protected override void AfterSave()
        {
            var expandModel = new ShipmentExpandModel
            {
                ShipmentId = CurrentModel.Id,
                VolumeL = tbxL.Value,
                VolumeW = tbxW.Value,
                VolumeH = tbxH.Value,
                UsePacking = cbxPacking.Checked,
                IsCod = cbxCod.Checked,
                TotalCod = tbxCod.Value,
                Fulfilment = tbxFulfilment.Text,
                DropPointId = dropPointId,
                SprinterId = sprinterId
            };
            SaveExpand(expandModel);

            ClearForm();
            txtDate.Text = "";

            tsBaseTxt_Code.Focus();
        }

        private void RefreshServiceType()
        {
            if (lkpOriginCity.Value == null || lkpDestinationCity.Value == null) return;
            RefreshTariff(true);
        }

        private void RefreshDeliveryTariff()
        {
            if (_isPopulatingForm) return;

            txtDeliveryTariff2.Value = txtDeliveryTariff1.Value * Math.Max(txtChargeable.Value, DeliveryTariffMinimumWeight);
        }

        protected CustomerTariffModel GetCustomerTariff()
        {
            DialogResult dialog;
            var modelCurrent = (ShipmentModel)CurrentModel;

            if (lkpOriginCity.Value == null || lkpDestinationCity.Value == null) return null;

            if (((ShipmentModel)CurrentModel).PricingPlanId != PRICING_PLAN_DOMESTIC)
            {
                using (var tariffInternationalDataManager = new TariffInternationalDataManager())
                {
                    var tariffIntModel = tariffInternationalDataManager.GetTariff(
                        ((ShipmentModel)CurrentModel).PricingPlanId ?? 0,
                        lkpPackageType.Value ?? 0,
                        txtChargeable.Value
                        );

                    if (tariffIntModel != null)
                    {
                        if (tariffIntModel.Tariff != modelCurrent.Tariff)
                        {
                            dialog = MessageForm.Ask(form, "Perubahan Tariff", "Apa anda akan menggunakan tariff baru, karena ada perubahaan tariff dengan tariff sebelumnya?", true);
                            if (dialog == DialogResult.Yes)
                            {
                                txtTariffPerKg.Value = tariffIntModel.Tariff;
                                txtHandlingFee.Value = tariffIntModel.HandlingFee ?? 0;

                                ((ShipmentModel)CurrentModel).CurrencyId = tariffIntModel.CurrencyId;

                                using (var currencyDm = new CurrencyDataManager())
                                {
                                    var currencyModel =
                                        currencyDm.GetFirst<CurrencyModel>(WhereTerm.Default(tariffIntModel.CurrencyId, "id"));

                                    if (currencyModel != null)
                                    {
                                        ((ShipmentModel)CurrentModel).Currency = currencyModel.Code;
                                        ((ShipmentModel)CurrentModel).CurrencyRate = currencyModel.Rate;
                                    }
                                }
                            }
                        }

                        return new CustomerTariffModel
                        {
                            Tariff = txtTariffPerKg.Value,
                            HandlingFee = txtHandlingFee.Value
                        };
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
                        ((ShipmentModel)CurrentModel).Currency = currencyModel.Code;
                        ((ShipmentModel)CurrentModel).CurrencyRate = currencyModel.Rate;
                    }
                }
            }

            if (lkpCustomer.Value != null)
            {
                using (var customerTariffDataManager = new CustomerTariffDataManager())
                {
                    var customerTariffModel = customerTariffDataManager.GetTariff(
                        (int)lkpOriginCity.Value,
                        (int)lkpDestinationCity.Value,
                        lkpServiceType.Value ?? 0,
                        lkpPackageType.Value ?? 0,
                        lkpCustomer.Value ?? 0,
                        txtChargeable.Value
                        );
                    if (customerTariffModel != null)
                    {
                        if (customerTariffModel.Tariff != modelCurrent.Tariff)
                        {
                            dialog = MessageForm.Ask(form, "Perubahan Tariff", "Apa anda akan menggunakan tariff baru, karena ada perubahaan tariff dengan tariff sebelumnya?", true);
                            if (dialog == DialogResult.Yes)
                            {
                                txtTariffPerKg.Value = customerTariffModel.Tariff;
                                txtHandlingFee.Value = customerTariffModel.HandlingFee;

                                return new CustomerTariffModel
                                {
                                    Tariff = customerTariffModel.Tariff,
                                    FixedTariff = customerTariffModel.FixedTariff,
                                    NextTariff = customerTariffModel.NextTariff,
                                    FromWeight = customerTariffModel.FromWeight,
                                    ToWeight = customerTariffModel.ToWeight,
                                    MinWeight = customerTariffModel.MinWeight,
                                    HandlingFee = customerTariffModel.HandlingFee,
                                    Ra = customerTariffModel.Ra,
                                };
                            }
                        }

                        return new CustomerTariffModel
                        {
                            Tariff = txtTariffPerKg.Value,
                            FixedTariff = customerTariffModel.FixedTariff,
                            NextTariff = customerTariffModel.NextTariff,
                            FromWeight = customerTariffModel.FromWeight,
                            ToWeight = customerTariffModel.ToWeight,
                            MinWeight = customerTariffModel.MinWeight,
                            HandlingFee = txtHandlingFee.Value,
                            Ra = customerTariffModel.Ra,
                        };
                    }
                }
            }

            using (var tariffDataManager = new TariffDataManager())
            {
                var tariffModel = tariffDataManager.GetTariff(
                    (int)lkpOriginCity.Value,
                    (int)lkpDestinationCity.Value,
                    lkpServiceType.Value ?? 0,
                    lkpPackageType.Value ?? 0,
                    txtChargeable.Value
                    );
                if (tariffModel != null)
                {
                    if (tariffModel.Tariff != modelCurrent.Tariff)
                    {
                        dialog = MessageForm.Ask(form, "Perubahan Tariff", "Apa anda akan menggunakan tariff baru, karena ada perubahaan tariff dengan tariff sebelumnya?", true);
                        if (dialog == DialogResult.Yes)
                        {
                            txtTariffPerKg.Value = tariffModel.Tariff;
                            txtHandlingFee.Value = tariffModel.HandlingFee;

                            return new CustomerTariffModel
                            {
                                Tariff = tariffModel.Tariff,
                                HandlingFee = tariffModel.HandlingFee,
                                Ra = tariffModel.Ra,
                            };
                        }
                    }

                    return new CustomerTariffModel
                    {
                        Tariff = txtTariffPerKg.Value,
                        HandlingFee = txtHandlingFee.Value,
                        Ra = tariffModel.Ra,
                    };
                }
            }

            return new CustomerTariffModel
            {
                Tariff = 0,
                HandlingFee = 0,
                Ra = false,
            };

        }

        private void RefreshTariff(bool force = false)
        {
            if (_isPopulatingForm) return;

            if (lkpOriginCity.Value == null || lkpDestinationCity.Value == null) return;

            if (_isPopulatingForm) return;

            if (((ShipmentModel)CurrentModel).Posted || ((ShipmentModel)CurrentModel).Voided) return;

            if (dropPointId == null)
            {
                var customerTariffModel = GetCustomerTariff();
                if (customerTariffModel != null)
                {
                    if (txtChargeable.Value < customerTariffModel.MinWeight) txtChargeable.Value = customerTariffModel.MinWeight;

                    if (((ShipmentModel)CurrentModel).PricingPlanId == PRICING_PLAN_DOMESTIC)
                    {
                        txtTariffPerKg.Value = customerTariffModel.Tariff;
                    }
                    else
                    {
                        //txtTariffPerKg.Value = 0;
                        //txtTariffTotal.Value = customerTariffModel.Tariff;
                        txtTariffTotal.Value = txtTariffPerKg.Value + txtHandlingFee.Value;
                    }

                    txtHandlingFee.Value = customerTariffModel.HandlingFee;
                    chkRA.Checked = customerTariffModel.Ra ?? false;

                    decimal diff = 0;
                    if (customerTariffModel.ToWeight > 0)
                    {
                        diff = txtChargeable.Value - (decimal)customerTariffModel.ToWeight;
                        if (customerTariffModel.FromWeight <= txtChargeable.Value && customerTariffModel.ToWeight >= txtChargeable.Value)
                        {
                            if (customerTariffModel.Tariff > 0)
                            {
                                txtTariffTotal.Value = (txtTariffPerKg.Value * txtChargeable.Value) + txtHandlingFee.Value;
                            }

                            if (customerTariffModel.FixedTariff > 0)
                            {
                                txtTariffTotal.Value = (decimal)customerTariffModel.FixedTariff + txtHandlingFee.Value;
                            }
                        }
                        else if (txtChargeable.Value > customerTariffModel.ToWeight)
                        {
                            if (customerTariffModel.Tariff > 0)
                            {
                                txtTariffTotal.Value = (txtTariffPerKg.Value * (txtChargeable.Value - diff)) + txtHandlingFee.Value;
                                decimal diffTariff1 = (decimal)customerTariffModel.NextTariff * diff;
                                txtTariffTotal.Value += diffTariff1;
                            }

                            if (customerTariffModel.FixedTariff > 0)
                            {
                                txtTariffTotal.Value = (decimal)customerTariffModel.FixedTariff + txtHandlingFee.Value;
                                decimal diffTariff = (decimal)customerTariffModel.NextTariff * diff;
                                txtTariffTotal.Value += diffTariff;
                            }
                        }
                    }
                    else
                    {
                        if (customerTariffModel.Tariff > 0)
                        {
                            txtTariffTotal.Value = (txtTariffPerKg.Value * txtChargeable.Value) + txtHandlingFee.Value;
                        }

                        if (customerTariffModel.FixedTariff > 0)
                        {
                            txtTariffTotal.Value = (decimal)customerTariffModel.FixedTariff + txtHandlingFee.Value;
                        }
                    }
                }
                else
                {
                    txtTariffPerKg.Value = 0;
                    txtHandlingFee.Value = 0;
                }
            }

            if (force)
            {
                using (var customerDataManager = new CustomerDataManager())
                {
                    var customer = customerDataManager.GetFirst<CustomerModel>(WhereTerm.Default(lkpCustomer.Value ?? 0, "id"));
                    if (customer != null)
                    {
                        txtShipperName.Text = customer.Name;
                        txtShipperAddress.Text = customer.Address;
                        txtShipperPhone.Text = customer.Phone;

                        //((ShipmentModel)CurrentModel).ShipperSaved = true;

                        CustomerDiscount = customer.Discount;

                        if (!_isPopulatingForm)
                        {
                            var upperLimit = Math.Max(CustomerDiscount, MaximumBranchDiscount);
                            if (CustomerDiscount > upperLimit) CustomerDiscount = upperLimit;
                            if (((ShipmentModel)CurrentModel).DiscountPercent != CustomerDiscount)
                            {
                                var dialog = MessageForm.Ask(form, "Perubahan Discount", "Apa anda akan menggunakan discount baru, karena ada perubahaan discount dengan sebelumnya?", true);
                                if (dialog == DialogResult.Yes)
                                {
                                    txtDiscount.Enabled = false;
                                    txtDiscount.Value = CustomerDiscount;
                                }
                            }
                        }
                    }
                    else txtDiscount.Enabled = true;
                }
            }

            if (lkpServiceType.Text.Equals("CITY COURIER"))
            {
                txtDiscount.Value = 0;
                txtDiscount.Enabled = false;
            }

            if (true)
            {
                using (var dm = new DeliveryTariffDataManager())
                {
                    DeliveryTariffModel dlvTariff = null;
                    if (lkpPackageType.Value != null)
                    {
                        dlvTariff = dm.GetByPackageTypeAndWeight((int)lkpPackageType.Value,
                            (int)lkpDestinationCity.Value, txtTotalWeight.Value);
                    }

                    if (dlvTariff != null)
                    {
                        txtDeliveryTariff1.Value = dlvTariff.Tariff;
                        DeliveryTariffMinimumWeight = dlvTariff.MinWeight;
                    }
                    else
                    {
                        txtDeliveryTariff1.Value = 0;
                        DeliveryTariffMinimumWeight = 0;
                    }
                }
            }

            RefreshGrandTotal();
        }

        private void RefreshGrandTotal(bool forceChangeTariffPerKg = false)
        {
            if (_isPopulatingForm) return;

            if (string.IsNullOrEmpty(txtDiscountTotal.Text) || string.IsNullOrEmpty(txtDiscount.Text) ||
                string.IsNullOrEmpty(txtTariffNet.Text) || string.IsNullOrEmpty(txtTariffTotal.Text) ||
                string.IsNullOrEmpty(txtInsuranceFee.Text) || string.IsNullOrEmpty(txtPackingFee.Text) ||
                string.IsNullOrEmpty(txtOtherFee.Text) || string.IsNullOrEmpty(txtInsuranceFee.Text)) return;

            //if (!_isPopulatingForm && forceChangeTariffPerKg && ((ShipmentModel)CurrentModel).PricingPlanId != PRICING_PLAN_DOMESTIC)
            //{
            //    ((ShipmentModel)CurrentModel).PricingPlanId = PRICING_PLAN_DOMESTIC;
            //    ((ShipmentModel)CurrentModel).CurrencyId = null;
            //    ((ShipmentModel)CurrentModel).CurrencyRate = 1;
            //}

            //if (((ShipmentModel)CurrentModel).PricingPlanId == PRICING_PLAN_DOMESTIC && !isTariffTotal)
            //{
            //    txtTariffTotal.Value = (txtTariffPerKg.Value * txtChargeableWeight.Value) + txtHandlingFee.Value;
            //}

            txtDiscountTotal.Value = (txtDiscount.Value / 100) * txtTariffTotal.Value;
            txtTariffNet.Value = txtTariffTotal.Value - txtDiscountTotal.Value;

            var grandTotal = txtTariffNet.Value + txtPackingFee.Value + txtOtherFee.Value + txtInsuranceFee.Value;

            if (((ShipmentModel)CurrentModel).CurrencyId != null)
            {
                grandTotal *= ((ShipmentModel)CurrentModel).CurrencyRate;
            }

            txtGrandTotal.Value = grandTotal;
        }

        private void lkpBranch_EditValueChanged(object sender, EventArgs e)
        {
            RefreshServiceType();
        }

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
            txtInsuranceFee.Value = txtGoodsValue.Value * ((decimal)_fixedShippingInsuranceRate);
        }

        private void txtInsuranceFee_EditValueChanged(object sender, EventArgs e)
        {
            RefreshGrandTotal();
        }

        private void txtTotalWeight_EditValueChanged(object sender, EventArgs e)
        {
            RefreshGrandTotal();
        }

        private void txtChargeable_EditValueChanged(object sender, EventArgs e)
        {
            if (((ShipmentModel) CurrentModel).PricingPlanId != PRICING_PLAN_DOMESTIC)
            {
                RefreshTariff(true);
            }
            else
            {
                RefreshGrandTotal();
            }

            RefreshDeliveryTariff();
        }

        private void btnRefreshTariff_Click(object sender, EventArgs e)
        {
            RefreshTariff(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();

            // todo: print
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            NavigationMenu.NewStrip.Enabled = false;
            NavigationMenu.DeleteStrip.Enabled = false;
            tsBaseBtn_New.Enabled = false;
            tsBaseBtn_Delete.Enabled = false;

            var model = CurrentModel as ShipmentModel;
            if (model != null && (model.Voided || model.Posted || model.Invoiced == 1))
            {
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