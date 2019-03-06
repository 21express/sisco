using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Corporate.Presentation.Common;
using Corporate.Presentation.Common.Component;
using Corporate.Presentation.Common.Forms;
using Corporate.Presentation.Common.Properties;
using Corporate.Presentation.CounterCash.Popup;
using Corporate.Presentation.CounterCash.Print;
using Corporate.Presentation.MasterData.Popup;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraBars;
using SISCO.App.Administration;
using SISCO.App.Corporate;
using SISCO.App.MasterData;
using SISCO.Models;

namespace Corporate.Presentation.CounterCash.Forms
{
    public partial class CounterCashForm : BaseCrudForm<ShipmentModel, ShipmentDataManager>//BaseToolbarForm//
    {
        private decimal _fixedShippingInsuranceRate;

        // ReSharper disable InconsistentNaming
        const string CURRENCY_IDR = "IDR";
        const int PRICING_PLAN_DOMESTIC = 1;
        // ReSharper restore InconsistentNaming

        public decimal DeliveryTariffMinimumWeight { get; set; }
        public bool IsInternationalShipment { get; set; }
        public CustomerModel Customer { get; set; }

        public CounterCashForm()
        {
            InitializeComponent();
            form = this;

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                WhereTerm.Default(1,"sales_type_id", EnumSqlOperator.Equals),
                WhereTerm.Default(BaseControl.CorporateId, "customer_id", EnumSqlOperator.Equals)
            };

            Customer = new CustomerDataManager().GetFirst<CustomerModel>(
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                WhereTerm.Default(BaseControl.CorporateId, "id", EnumSqlOperator.Equals)
            );
        }

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

            tbxNo.Leave += tbxShipmentNo_Leave;

            lkpDestination.LookupPopup = new CityPopup();
            lkpDestination.AutoCompleteDataManager = new CityDataManager();
            lkpDestination.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpDestination.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpDestination.FieldLabel = "Destination City";
            lkpDestination.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpConsignee.LookupPopup = new ConsigneePopup();
            lkpConsignee.AutoCompleteDataManager = new ConsigneeDataManager();
            lkpConsignee.AutoCompleteDisplayFormater = model => ((ConsigneeModel)model).Name;
            lkpConsignee.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(BaseControl.CorporateId, "corporate_id", EnumSqlOperator.Equals),
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpConsignee.Leave += AutoPopulateConsigneeDetail;

            lkpPackage.LookupPopup = new PackageTypePopup();
            lkpPackage.AutoCompleteDataManager = new PackageTypeDataManager();
            lkpPackage.AutoCompleteDisplayFormater = model => ((PackageTypeModel)model).Name;
            lkpPackage.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpPackage.FieldLabel = "Package Type";
            lkpPackage.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpService.LookupPopup = new ServiceTypePopup();
            lkpService.AutoCompleteDataManager = new ServiceTypeDataManager();
            lkpService.AutoCompleteDisplayFormater = model => ((ServiceTypeModel)model).Name;
            lkpService.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("name.StartsWith(@0)", s);
            lkpService.FieldLabel = "Service Type";
            lkpService.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpPayment.LookupPopup = new PaymentMethodPopup("name.Equals(@0) OR name.Equals(@1)", "COLLECT ", "CREDIT");
            lkpPayment.AutoCompleteDataManager = new PaymentMethodDataManager();
            lkpPayment.AutoCompleteDisplayFormater = model => ((PaymentMethodModel)model).Name;
            lkpPayment.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("name.StartsWith(@0) AND (name.Equals(@1) OR name.Equals(@2))", s, "COLLECT", "CREDIT");
            lkpPayment.FieldLabel = "Payment Method";
            lkpPayment.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            tbxConsigneeName.FieldLabel = "Consignee Name";
            tbxConsigneeName.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            tbxConsigneeAddress.FieldLabel = "Consignee Address";
            tbxConsigneeAddress.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            tbxConsigneePhone.FieldLabel = "Consignee Phone";
            tbxConsigneePhone.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            tbxTtlPiece.EditMask = "###,##0";
            tbxTtlPiece.FieldLabel = "Total Piece";
            tbxTtlPiece.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            tbxTtlGrossWeight.EditMask = "###,##0.0";
            tbxTtlGrossWeight.FieldLabel = "Total Weight";
            tbxTtlGrossWeight.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            tbxTtlChargeable.EditMask = "###,##0.0";
            tbxTtlChargeable.FieldLabel = "Chargeable Weight";
            tbxTtlChargeable.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            tbxDiscount.EditMask = "#0.0%%";
            tbxOther.EditMask = "##,###,##0.00";
            tbxGoodsValue.EditMask = "##,###,##0.00";
            tbxInsurance.EditMask = "##,###,##0.00";

            
            tbxConsigneeName.CharacterCasing = CharacterCasing.Upper;
            tbxConsigneeAddress.CharacterCasing = CharacterCasing.Upper;
            tbxConsigneePhone.CharacterCasing = CharacterCasing.Upper;
            tbxNote.CharacterCasing = CharacterCasing.Upper;
            tbxNatureOfGood.CharacterCasing = CharacterCasing.Upper;

            tbxConsigneeName.MaxLength = 100;
            tbxConsigneeAddress.MaxLength = 254;
            tbxConsigneePhone.MaxLength = 50;
            
            tbxNote.MaxLength = 100;
            tbxNatureOfGood.MaxLength = 50;

            tbxTtlGrossWeight.TextChanged += TxtTotalWeightOnTextChanged;
            tbxDiscount.TextChanged += (o, args) => RefreshTariff();

            FormTrackingStatus = EnumTrackingStatus.CorporateDateEntry;

            rbLayout_Print.ItemClick += (o, args) =>
            {
                var printout = new EConnotePrintout
                {
                    DataSource = GetPrintDataSource()
                };
                printout.PrintDialog();
            };
            rbLayout_PrintPreview.ItemClick += (o, args) =>
            {
                var printout = new EConnotePrintout
                {
                    DataSource = GetPrintDataSource()
                };
                printout.PrintPreview();
            };

            lkpDestination.EditValueChanged += lkpDestination_EditValueChanged;
            lkpPackage.EditValueChanged += lkpPackageType_EditValueChanged;
            lkpService.EditValueChanged += lkpServiceType_EditValueChanged;
            tbxOther.EditValueChanged += txtOtherFee_EditValueChanged;
            tbxGoodsValue.EditValueChanged += txtGoodsValue_EditValueChanged;
            tbxTtlPiece.EditValueChanged += txtTotalPiece_EditValueChanged;
            tbxTtlGrossWeight.EditValueChanged += txtTotalWeight_EditValueChanged;
            tbxTtlChargeable.EditValueChanged += txtChargeable_EditValueChanged;
            tbxDiscount.EditValueChanged += tbxDiscount_EditValueChanged;

            using (var branchDm = new BranchDataManager())
            {
                var branch = branchDm.GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id"));
                MaximumBranchDiscount = branch.MaxDiscount > 0 ? branch.MaxDiscount : 0;
            }

            rbPod.Visible = true;
            rbPod_Void.Enabled = false;
            rbPod_Void.ItemClick += Void;
        }

        private void tbxShipmentNo_Leave(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;

            if (string.IsNullOrEmpty(tbxNo.Text)) return;

            if (tbxNo.Text.Length != 12)
            {
                MessageBox.Show(@"Nomor POD harus 12 digit!");
                tbxNo.Clear();
                tbxNo.Focus();
                return;
            }

            if (!tbxNo.Text.All(c => char.IsDigit(c)))
            {
                MessageBox.Show(@"Nomor POD harus berupa angka!");
                tbxNo.Clear();
                tbxNo.Focus();
                return;
            }

            if (!CheckCn()) return;
        }

        private bool CheckCn()
        {
            var ship = DataManager.GetFirst<ShipmentModel>(WhereTerm.Default(tbxNo.Text, "code", EnumSqlOperator.Equals));
            if (ship != null)
            {
                if (ship.Id != CurrentModel.Id)
                {
                    MessageBox.Show(Resources.cn_exists, Resources.title_information, MessageBoxButtons.OK);
                    tbxNo.Text = string.Empty;
                    tbxNo.Focus();
                    return false;
                }
            }


            if (tbxNo.Text.Length > 4 && !((ShipmentDataManager)DataManager).CheckPrefixBranchShipment(BaseControl.BranchId, tbxNo.Text, true))
            {
                MessageBox.Show(Resources.invalid_stt, Resources.invalid_stt_title, MessageBoxButtons.OK);
                tbxNo.Text = string.Empty;
                tbxNo.Focus();
                return false;
            }

            return true;
        }

        private void Void(object sender, ItemClickEventArgs e)
        {
            var model = CurrentModel as ShipmentModel;
            if (model == null) return;
            if (!model.Voided)
            {
                var dialog = MessageForm.Ask(form, Resources.void_confirm, Resources.void_confirm_msg);
                if (dialog == DialogResult.Yes)
                {
                    model.Voided = true;
                    model.Tariff = 0;
                    model.HandlingFeeTotal = 0;
                    model.TariffTotal = 0;
                    model.DiscountPercent = 0;
                    model.DiscountTotal = 0;
                    model.TariffNet = 0;
                    model.OtherFee = 0;
                    model.GoodsValue = 0;
                    model.InsuranceFee = 0;
                    model.Total = 0;
                    model.Rowversion = DateTime.Now;
                    model.ModifiedPc = Environment.MachineName;
                    model.Modifiedby = BaseControl.UserLogin;
                    model.Modifieddate = DateTime.Now;

                    new ShipmentDataManager().Update<ShipmentModel>(model);
                    PerformFind();
                }
            }
        }

        private void AutoPopulateConsigneeDetail(object sender, EventArgs e)
        {
            if (lkpConsignee.Value != null)
            {
                var consignee = new ConsigneeDataManager().GetFirst<ConsigneeModel>(WhereTerm.Default((int)lkpConsignee.Value, "id", EnumSqlOperator.Equals));

                if (consignee != null)
                {
                    tbxConsigneeName.Text = consignee.Name;
                    tbxConsigneeAddress.Text = consignee.Address;
                    tbxConsigneePhone.Text = consignee.Phone;

                    lkpPackage.Focus();
                }
            }
        }

        public decimal MaximumBranchDiscount { get; set; }
        public decimal CustomerDiscount { get; set; }

        public int LastCustomerId { get; set; }

        private void TxtTotalWeightOnTextChanged(object sender, EventArgs eventArgs)
        {
            decimal ceiled;
            if (CurrentModel == null) return;

            if (((ShipmentModel)CurrentModel).PricingPlanId == PRICING_PLAN_DOMESTIC)
            {
                ceiled = Math.Ceiling(tbxTtlGrossWeight.Value);
            }
            else
            {
                ceiled = Math.Ceiling(tbxTtlGrossWeight.Value * 2) / 2;
            }

            if (ceiled > 999999) MessageBox.Show(@"Chargeable maximal 999,999 kg");

            tbxTtlChargeable.Value = ceiled;

            RefreshGrandTotal();
        }

        protected override void PopulateForm(ShipmentModel model)
        {
            LastCustomerId = model.CustomerId ?? 0;

            cbxRa.Checked = model.NeedRa;

            tbxDate.DateTime = model.DateProcess;
            tbxNo.Text = model.Code;
            tbxSearch_Code.Text = model.Code;

            if (model.CustomerId != null)
            {
                Customer =
                    new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int) model.CustomerId, "id"));
                lkpConsignee.DefaultValue = new IListParameter[] { WhereTerm.Default(Customer.Id, "id") };
            }

            lkpDestination.DefaultValue = new IListParameter[] {WhereTerm.Default(model.DestCityId, "id")};

            tbxConsigneeName.Text = model.ConsigneeName;
            tbxConsigneeAddress.Text = model.ConsigneeAddress;
            tbxConsigneePhone.Text = model.ConsigneePhone;

            lkpPackage.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PackageTypeId, "id") };
            lkpService.DefaultValue = new IListParameter[] { WhereTerm.Default(model.ServiceTypeId, "id") };
            lkpPayment.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PaymentMethodId, "id") };

            tbxNatureOfGood.Text = model.NatureOfGoods;
            tbxNote.Text = model.Note;

            tbxTtlPiece.Value = model.TtlPiece;
            tbxTtlGrossWeight.Value = model.TtlGrossWeight;
            tbxTtlChargeable.Value = model.TtlChargeableWeight;

            tbxTariff.Value = model.Tariff;
            tbxHandlingFee.Value = model.HandlingFee;
            tbxTtlTariff.Value = model.TariffTotal;
            tbxDiscount.Value = model.DiscountPercent;
            tbxTtlDiscount.Value = model.DiscountTotal;
            tbxTariffNet.Value = model.TariffNet;

            tbxOther.Value = model.OtherFee;
            tbxGoodsValue.Value = model.GoodsValue;
            tbxInsurance.Value = model.InsuranceFee;

            tbxDiscount.Enabled = !lkpService.Text.ToUpper().Equals("CITY COURIER");

            tbxGlobalTotal.Value = model.Total;

            tbxTtlDiscount.Value = model.DiscountTotal;
            rbPod_Void.Enabled = true;

            EnabledForm(false);

            if (model.Voided)
            {
                MessageBox.Show(@"POD sudah di-VOID!");

                rbPod_Void.Enabled = false;
                EnabledForm(false);

                tbxDiscount.Enabled = false;
            }
        }

        protected override ShipmentModel PopulateModel(ShipmentModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.BranchId = BaseControl.BranchId;
            model.AutoNumber = true;

            model.Code = tbxNo.Text;

            model.NeedRa = cbxRa.Checked;

            model.CityId = BaseControl.CityId;
            model.CityName = BaseControl.CityName;

            if (lkpDestination.Value == null)
                throw new BusinessException("");

            model.DestCityId = (int) lkpDestination.Value;
            model.DestCity = lkpDestination.Text;

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

            model.CustomerId = BaseControl.CorporateId;
            Customer =
                new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)model.CustomerId, "id"));
            model.CustomerName = Customer.Name;

            model.ShipperName = Customer.Name;
            model.ShipperAddress = Customer.Address;
            model.ShipperPhone = Customer.Phone;
            model.RefNumber = string.Empty;

            model.ConsigneeName = tbxConsigneeName.Text;
            model.ConsigneeAddress = tbxConsigneeAddress.Text;
            model.ConsigneePhone = tbxConsigneePhone.Text;

            if (lkpPackage.Value == null)
                throw new BusinessException("");
            model.PackageTypeId = (int)lkpPackage.Value;
            model.PackageType = lkpPackage.Text;

            if (lkpService.Value == null)
                throw new BusinessException("");
            model.ServiceTypeId = (int)lkpService.Value;

            if (lkpPayment.Value == null)
                throw new BusinessException("");
            model.PaymentMethodId = (int)lkpPayment.Value;
            model.PaymentMethod = lkpPayment.Text;

            model.NatureOfGoods = tbxNatureOfGood.Text;
            model.Note = tbxNote.Text;

            model.TtlPiece = Convert.ToInt16(tbxTtlPiece.Value);
            model.TtlGrossWeight = tbxTtlGrossWeight.Value;
            model.TtlChargeableWeight = tbxTtlChargeable.Value;

            model.Tariff = tbxTariff.Value;
            model.HandlingFeeTotal = tbxHandlingFee.Value;
            model.TariffTotal = tbxTtlTariff.Value;
            model.DiscountPercent = tbxDiscount.Value;
            model.DiscountTotal = tbxTtlDiscount.Value;
            model.TariffNet = tbxTariffNet.Value;

            model.OtherFee = tbxOther.Value;
            model.GoodsValue = tbxGoodsValue.Value;
            model.InsuranceFee = tbxInsurance.Value;

            model.Total = tbxGlobalTotal.Value;

            model.SalesTypeId = 1;

            if (CurrentModel.Id == 0)
            {
                model.CreatedPc = Environment.MachineName;
                model.TrackingStatusId = (int)EnumTrackingStatus.CorporateDateEntry;
            }

            model.PODStatus = (int) EnumPodStatus.None;
            return model;
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            if (lkpDestination.Value == null)
            {
                MessageBox.Show(@"Please enter the destination city!");
                lkpDestination.SelectAll();
                lkpDestination.Focus();
                return false;
            }
            if (tbxConsigneeName.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter the consignee name!");
                tbxConsigneeName.SelectAll();
                tbxConsigneeName.Focus();
                return false;
            }
            if (tbxConsigneeAddress.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter the consignee address!");
                tbxConsigneeAddress.SelectAll();
                tbxConsigneeAddress.Focus();
                return false;
            }
            if (tbxConsigneePhone.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter the consignee phone number!");
                tbxConsigneePhone.SelectAll();
                tbxConsigneePhone.Focus();
                return false;
            }
            if (lkpPackage.Value == null)
            {
                MessageBox.Show(@"Please select the package type!");
                lkpPackage.SelectAll();
                lkpPackage.Focus();
                return false;
            }
            if (lkpService.Value == null)
            {
                MessageBox.Show(@"Please select the service type!");
                lkpService.SelectAll();
                lkpService.Focus();
                return false;
            }
            if (lkpPayment.Value == null)
            {
                MessageBox.Show(@"Please select the payment method type!");
                lkpPayment.SelectAll();
                lkpPayment.Focus();
                return false;
            }
            if (tbxTtlPiece.Value == 0)
            {
                MessageBox.Show(@"Please fill the total piece field!");
                tbxTtlPiece.SelectAll();
                tbxTtlPiece.Focus();
                return false;
            }
            if (tbxTtlGrossWeight.Value == 0)
            {
                MessageBox.Show(@"Please wnter the total weight!");
                tbxTtlGrossWeight.SelectAll();
                tbxTtlGrossWeight.Focus();
                return false;
            }
            if (tbxTtlChargeable.Value == 0)
            {
                MessageBox.Show(@"Please enter the chargeable weight!");
                tbxTtlChargeable.SelectAll();
                tbxTtlChargeable.Focus();
                return false;
            }
            // ReSharper restore LocalizableElement

            return true;
        }

        protected override ShipmentModel Find(string searchTerm)
        {
            return new ShipmentDataManager().GetFirst<ShipmentModel>(
                WhereTerm.Default(searchTerm, "code"));
        }

        protected override void BeforeNew()
        {
            ClearForm();

            tbxTtlPiece.Value = 1;
            tbxTtlGrossWeight.Value = 1;
            tbxTtlChargeable.Value = 1;

            tbxTariff.Value = 0;
            tbxHandlingFee.Value = 0;
            tbxTtlTariff.Value = 0;
            tbxDiscount.Value = 0;
            tbxTtlDiscount.Value = 0;
            tbxTariffNet.Value = 0;

            tbxOther.Value = 0;
            tbxGoodsValue.Value = 0;
            tbxInsurance.Value = 0;

            tbxGlobalTotal.Value = 0;

            tbxDate.DateTime = DateTime.Now;

            lkpPackage.DefaultValue = new IListParameter[] { WhereTerm.Default("PARCEL", "name") };
            lkpService.DefaultValue = new IListParameter[] { WhereTerm.Default("ECO", "name") };
            lkpPayment.DefaultValue = new IListParameter[] { WhereTerm.Default("COLLECT", "name") };

            tbxNo.Focus();
        }

        public override void New()
        {
            base.New();

            cbxRa.Enabled = false;
            tbxTariff.Enabled = false;
            tbxTariffNet.Enabled = false;
            tbxHandlingFee.Enabled = false;
            tbxTtlTariff.Enabled = false;
            tbxTtlDiscount.Enabled = false;
            tbxTariffNet.Enabled = false;
            tbxGlobalTotal.Enabled = false;
            tbxInsurance.Enabled = false;
            tbxDate.Enabled = false;
            
            if (Customer != null ) tbxDiscount.Value = Customer.Discount;
            lkpPayment.DefaultValue = new IListParameter[] { WhereTerm.Default("COLLECT", "name") };
            rbPod_Void.Enabled = false;
        }

        private void RefreshDeliveryTariff()
        {
            if (_isPopulatingForm) return;
            if (CurrentModel == null) return;

            ((ShipmentModel)CurrentModel).DeliveryFeeTotal = ((ShipmentModel)CurrentModel).DeliveryFee * Math.Max(tbxTtlChargeable.Value, DeliveryTariffMinimumWeight);
        }

        private void RefreshTariff()
        {
            if (_isPopulatingForm) return;

            if (CurrentModel == null) return;

            if (((ShipmentModel)CurrentModel).Posted || ((ShipmentModel)CurrentModel).Voided) return;

            tbxTariff.Value = 0;
            tbxHandlingFee.Value = 0;
            cbxRa.Checked = false;

            if (lkpService.Text.Equals("CITY COURIER"))
            {
                tbxDiscount.Enabled = false;
                tbxDiscount.Value = 0;
            }
            else
            {
                tbxDiscount.Enabled = true;

                var upperLimit = Math.Max(CustomerDiscount, MaximumBranchDiscount);
                if (tbxDiscount.Value > upperLimit)
                {
                    tbxDiscount.Value = upperLimit;
                }
            }

            using (var dm = new DeliveryTariffDataManager())
            {
                DeliveryTariffModel dlvTariff = null;
                if (lkpPackage.Value != null)
                {
                    if (lkpDestination.Value != null)
                        dlvTariff = dm.GetByPackageTypeAndWeight((int)lkpPackage.Value, (int)lkpDestination.Value, tbxTtlGrossWeight.Value);
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

            if (((ShipmentModel)CurrentModel).PricingPlanId != PRICING_PLAN_DOMESTIC)
            {
                using (var tariffInternationalDataManager = new TariffInternationalDataManager())
                {
                    var tariffIntModel = tariffInternationalDataManager.GetTariff(
                        ((ShipmentModel)CurrentModel).PricingPlanId ?? 0,
                        lkpPackage.Value ?? 0,
                        tbxTtlChargeable.Value
                        );

                    if (tariffIntModel != null)
                    {
                        tbxTariff.Value = 0;
                        tbxTtlTariff.Value = tariffIntModel.Tariff;

                        tbxHandlingFee.Value = tariffIntModel.HandlingFee ?? 0;
                        ((ShipmentModel)CurrentModel).CurrencyId = tariffIntModel.CurrencyId;

                        using (var currencyDm = new CurrencyDataManager())
                        {
                            var currencyModel =
                                currencyDm.GetFirst<CurrencyModel>(WhereTerm.Default(tariffIntModel.CurrencyId, "id"));

                            if (currencyModel != null)
                            {
                                ((ShipmentModel)CurrentModel).Currency = currencyModel.Name;
                                ((ShipmentModel)CurrentModel).CurrencyRate = currencyModel.Rate;
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

            using (var customerTariffDataManager = new CustomerTariffDataManager())
            {
                if (lkpDestination.Value != null)
                {
                    var customerTariffModel = customerTariffDataManager.GetTariff(
                        BaseControl.CityId,
                        (int)lkpDestination.Value,
                        lkpService.Value ?? 0,
                        lkpPackage.Value ?? 0,
                        Customer == null ? 0 : Customer.Id,
                        tbxTtlChargeable.Value
                        );

                    if (customerTariffModel != null)
                    {
                        tbxTariff.Value = customerTariffModel.Tariff;
                        tbxHandlingFee.Value = customerTariffModel.HandlingFee;

                        cbxRa.Checked = customerTariffModel.Ra ?? false;

                        RefreshGrandTotal();
                        return;
                    }
                }
            }

            using (var tariffDataManager = new TariffDataManager())
            {
                if (lkpDestination.Value != null)
                {
                    var tariffModel = tariffDataManager.GetTariff(
                        BaseControl.CityId,
                        (int)lkpDestination.Value,
                        lkpService.Value ?? 0,
                        lkpPackage.Value ?? 0,
                        tbxTtlChargeable.Value
                        );
                    if (tariffModel != null)
                    {
                        tbxTariff.Value = tariffModel.Tariff;
                        tbxHandlingFee.Value = tariffModel.HandlingFee;

                        cbxRa.Checked = tariffModel.Ra ?? false;

                        RefreshGrandTotal();
                        return;
                    }
                }
            }

            tbxTariff.Text = @"0";
            tbxHandlingFee.Text = @"0";

            RefreshGrandTotal();
        }

        private void RefreshGrandTotal()
        {
            if (CurrentModel == null) return;
            if (string.IsNullOrEmpty(tbxTtlDiscount.Text) || string.IsNullOrEmpty(tbxDiscount.Text) ||
                string.IsNullOrEmpty(tbxTariffNet.Text) || string.IsNullOrEmpty(tbxTtlTariff.Text) ||
                string.IsNullOrEmpty(tbxInsurance.Text) || string.IsNullOrEmpty(tbxOther.Text) || 
                string.IsNullOrEmpty(tbxInsurance.Text)) return;

            if (((ShipmentModel)CurrentModel).PricingPlanId == PRICING_PLAN_DOMESTIC)
            {
                tbxTtlTariff.Value = (tbxTariff.Value * tbxTtlChargeable.Value) + tbxHandlingFee.Value;
            }

            tbxTtlDiscount.Value = (tbxDiscount.Value / 100) * tbxTtlTariff.Value;
            tbxTariffNet.Value = tbxTtlTariff.Value - tbxTtlDiscount.Value;

            //txtInsuranceFee.Value = txtGoodsValue.Value * ((float) _fixedShippingInsuranceRate);

            var grandTotal = tbxTariffNet.Value + tbxOther.Value + tbxInsurance.Value;

            if (((ShipmentModel)CurrentModel).CurrencyId != null)
            {
                grandTotal *= ((ShipmentModel)CurrentModel).CurrencyRate;
            }

            tbxGlobalTotal.Value = grandTotal;
        }

        private void lkpDestination_EditValueChanged(object sender, EventArgs e)
        {
            if (CurrentModel == null) return;
            var cityDataManager = new CityDataManager();
            var countryDataManager = new CountryDataManager();

            var cityModel = cityDataManager.GetFirst<CityModel>(WhereTerm.Default(lkpDestination.Value ?? 0, "Id"));

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
            RefreshTariff();
        }

        private void lkpPackageType_EditValueChanged(object sender, EventArgs e)
        {
            RefreshTariff();
        }

        private void lkpServiceType_EditValueChanged(object sender, EventArgs e)
        {
            RefreshTariff();
        }

        private void txtOtherFee_EditValueChanged(object sender, EventArgs e)
        {
            RefreshGrandTotal();
        }

        private void txtGoodsValue_EditValueChanged(object sender, EventArgs e)
        {
            var goodsvalue = tbxGoodsValue.Value;
            if (goodsvalue == 0) tbxInsurance.Value = 0;
            else tbxInsurance.Value = Math.Round((goodsvalue*BaseControl.GoodValuesInsurance) + BaseControl.GoodValuesAdministration, 0, MidpointRounding.AwayFromZero);
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
            if (CurrentModel == null) return;
            if (((ShipmentModel)CurrentModel).PricingPlanId != PRICING_PLAN_DOMESTIC)
            {
                RefreshTariff();
            }
            else
            {
                RefreshGrandTotal();
            }

            RefreshDeliveryTariff();
        }

        private void tbxDiscount_EditValueChanged(object sender, EventArgs e)
        {
            if (tbxDiscount.Value > 20) tbxDiscount.Value = 20;
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

            return new List<ShipmentModel.ShipmentReportRow>
            {
                model
            };
        }

        protected override void AfterSave()
        {
            //base.AfterSave();
            tbxSearch_Code.Focus();

            PodStatusModel.ShipmentId = CurrentModel.Id;
            PodStatusModel.PositionStatusId = BaseControl.BranchId;
            PodStatusModel.PositionStatus = EnumPositionStatus.Agent.ToString();

            ShipmentStatusUpdate();
            var model = CurrentModel as ShipmentModel;

            if (model == null) return;

            tbxSearch_Code.Text = model.Code;
            PerformFind();
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            if (TotalPage > 0)
            {
                rbLayout_Print.Enabled = true;
                rbLayout_PrintPreview.Enabled = true;
            }

            var model = CurrentModel as ShipmentModel;
            if (model != null && (model.Voided || model.Posted || model.Invoiced == 1) && model.PODStatus > 0)
            {
                rbData_New.Enabled = true;
                rbData_Delete.Enabled = false;

                rbData_Save.Enabled = false;
                EnabledForm(false);
            }
        }
    }
}
