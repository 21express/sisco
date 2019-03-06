using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Corporate.Presentation.Common;
using Corporate.Presentation.Common.Component;
using Corporate.Presentation.Common.Forms;
using Corporate.Presentation.Common.Properties;
using Corporate.Presentation.DataEntry.Popup;
using Corporate.Presentation.DataEntry.Print;
using Corporate.Presentation.MasterData.Popup;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraBars;
using SISCO.App.Corporate;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.LocalStorage;

namespace Corporate.Presentation.DataEntry.Forms
{
    public partial class EntryEconnoteForm : BaseCrudForm<ShipmentModel, ShipmentDataManager>//BaseToolbarForm//
    {
        private decimal _fixedShippingInsuranceRate;

        // ReSharper disable InconsistentNaming
        const string CURRENCY_IDR = "IDR";
        const int PRICING_PLAN_DOMESTIC = 1;
        const string SERVICE_TYPE_CITY_COURIER = "CITY COURIER";
        // ReSharper restore InconsistentNaming

        public decimal DeliveryTariffMinimumWeight { get; set; }
        public bool IsInternationalShipment { get; set; }
        public CustomerModel Customer { get; set; }

        public EntryEconnoteForm()
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

            lkpDestination.LookupPopup = new CityPopup();
            lkpDestination.AutoCompleteDataManager = new CityServices();
            lkpDestination.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpDestination.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpDestination.FieldLabel = "Destination City";
            lkpDestination.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            lkpDestination.Leave += (s, o) =>
            {
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

                RefreshServiceType();
            };

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
            lkpPackage.AutoCompleteDataManager = new PackageTypeServices();
            lkpPackage.AutoCompleteDisplayFormater = model => ((PackageTypeModel)model).Name;
            lkpPackage.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpPackage.FieldLabel = "Package Type";
            lkpPackage.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            lkpPackage.EditValueChanged += (s, o) => RefreshTariff();
            lkpPackage.Leave += (s, o) => NoServiceMessage();

            lkpService.LookupPopup = new ServiceTypePopup("name.Equals(@0) OR name.Equals(@1) OR name.Equals(@2) OR name.Equals(@3) OR name.Equals(@4) OR name.Equals(@5)", "REGULAR", "ONS", "DARAT", "CITY COURIER", "SDS", "LAUT");
            lkpService.AutoCompleteDataManager = new ServiceTypeServices();
            lkpService.AutoCompleteDisplayFormater = model => ((ServiceTypeModel)model).Name;
            lkpService.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("name.StartsWith(@0) AND (name.Equals(@1) OR name.Equals(@2) OR name.Equals(@3) OR name.Equals(@4) OR name.Equals(@5) OR name.Equals(@6))", s, "REGULAR", "ONS", "DARAT", "CITY COURIER", "SDS", "LAUT");
            lkpService.FieldLabel = "Service Type";
            lkpService.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            lkpService.EditValueChanged += (s, o) => RefreshTariff();
            lkpService.Leave += (s, o) => NoServiceMessage();

            lkpPayment.LookupPopup = new PaymentMethodPopup("name.Equals(@0)", "CREDIT");
            lkpPayment.AutoCompleteDataManager = new PaymentMethodServices();
            lkpPayment.AutoCompleteDisplayFormater = model => ((PaymentMethodModel)model).Name;
            lkpPayment.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("name.StartsWith(@0) AND name.Equals(@1)", s, "CREDIT");
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
            tbxTtlPiece.EditValueChanged += (s, o) => RefreshGrandTotal();
            tbxTtlGrossWeight.EditMask = "###,##0.0";
            tbxTtlGrossWeight.FieldLabel = "Total Weight";
            tbxTtlGrossWeight.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            tbxTtlGrossWeight.EditValueChanged += (s, o) => RefreshGrandTotal();
            tbxTtlChargeable.EditMask = "###,##0.0";
            tbxTtlChargeable.FieldLabel = "Chargeable Weight";
            tbxTtlChargeable.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            tbxL.EditValueChanged += (s, o) => VolumeCalculation();
            tbxW.EditValueChanged += (s, o) => VolumeCalculation();
            tbxH.EditValueChanged += (s, o) => VolumeCalculation();

            tbxOther.EditMask = "##,###,##0.00";
            tbxOther.EditValueChanged += (s, o) => RefreshGrandTotal();
            tbxGoodsValue.EditMask = "##,###,###,##0.00";
            tbxGoodsValue.EditValueChanged += (s, o) =>
            {
                var goodsvalue = tbxGoodsValue.Value;
                if (goodsvalue == 0) tbxInsurance.Value = 0;
                else tbxInsurance.Value = Math.Round((goodsvalue * BaseControl.GoodValuesInsurance) + BaseControl.GoodValuesAdministration, 0, MidpointRounding.AwayFromZero);
                RefreshGrandTotal();
            };
            tbxInsurance.EditMask = "##,###,###,##0.00";
            tbxInsurance.EditValueChanged += (s, o) => RefreshGrandTotal();

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

            FormTrackingStatus = EnumTrackingStatus.CorporateDataEntry;

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

            lkpService.EditValueChanged += (s, args) =>
            {
                RefreshServiceType();

                if (lkpService.Text == "DARAT") MinWeight = 10;
                if (lkpService.Text == "LAUT") MinWeight = 30;

                if (tbxTtlGrossWeight.Value < MinWeight) tbxTtlGrossWeight.SetValue(MinWeight);
            };

            using (var branchDm = new BranchDataManager())
            {
                var branch = branchDm.GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id"));
                MaximumBranchDiscount = branch.MaxDiscount > 0 ? branch.MaxDiscount : 0;
            }

            cbxPacking.Click += (s, o) =>
            {
                var fee = ((tbxL.Value + tbxW.Value + tbxH.Value + 18) / 3) * 2000;
                if (cbxPacking.Checked) tbxPacking.Value = fee;
                else tbxPacking.Value = 0;

                RefreshGrandTotal();
            };

            rbPod.Visible = true;
            rbPod_Void.Enabled = false;
            rbPod_Void.ItemClick += Void;
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
        public decimal MinWeight { get; set; }

        public int LastCustomerId { get; set; }

        private void TxtTotalWeightOnTextChanged(object sender, EventArgs eventArgs)
        {
            if (CurrentModel == null) return;
            decimal ceiled;

            if (MinWeight > 0 && tbxTtlGrossWeight.Value < MinWeight) tbxTtlGrossWeight.Value = MinWeight;

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

            var service = new ServiceDataManager().GetFirst<ServiceTypeModel>(WhereTerm.Default(model.ServiceTypeId, "id"));
            if (service.Name == "DARAT") MinWeight = 10;
            if (service.Name == "LAUT") MinWeight = 30;

            tbxNatureOfGood.Text = model.NatureOfGoods;
            tbxNote.Text = model.Note;

            tbxTtlPiece.Value = model.TtlPiece;
            tbxTtlGrossWeight.Value = model.TtlGrossWeight;
            tbxTtlChargeable.Value = model.TtlChargeableWeight;

            tbxTariff.Value = model.Tariff;
            tbxHandlingFee.Value = model.HandlingFee;
            tbxTtlTariff.Value = model.TariffTotal;
            tbxTariffNet.Value = model.TariffNet;

            tbxOther.Value = model.OtherFee;
            tbxGoodsValue.Value = model.GoodsValue;
            tbxPacking.Value = model.PackingFee;
            tbxInsurance.Value = model.InsuranceFee;
            tbxGrandTotal.Value = model.Total;

            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(model.Id, "shipment_id"));
            if (expand != null)
            {
                tbxL.Value = expand.VolumeL;
                tbxW.Value = expand.VolumeW;
                tbxH.Value = expand.VolumeH;
                cbxPacking.Checked = expand.UsePacking;
            }

            rbPod_Void.Enabled = true;

            EnabledForm(true);

            if (model.Voided)
            {
                MessageBox.Show(@"POD sudah di-VOID!");

                rbPod_Void.Enabled = false;
                EnabledForm(false);
            }

            if (model.Posted || (DateTime.Now - model.DateProcess).TotalDays > 0 || model.Voided || model.TrackingStatusId != (int)EnumTrackingStatus.CorporateDataEntry)
            {
                rbPod_Void.Enabled = false;
                EnabledForm(false);
            }

            tbxTtlChargeable.Enabled = false;
            tbxPacking.Enabled = false;
        }

        protected override ShipmentModel PopulateModel(ShipmentModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.BranchId = BaseControl.BranchId;
            model.AutoNumber = true;

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
            model.DiscountPercent = 0;
            model.DiscountTotal = 0;
            model.TariffNet = tbxTariffNet.Value;

            model.PackingFee = tbxPacking.Value;
            model.OtherFee = tbxOther.Value;
            model.GoodsValue = tbxGoodsValue.Value;
            model.InsuranceFee = tbxInsurance.Value;

            model.Total = tbxGrandTotal.Value;

            model.SalesTypeId = 1;

            if (CurrentModel.Id == 0)
            {
                model.PODStatus = (int)EnumPodStatus.None;
                model.CreatedPc = Environment.MachineName;
                model.Code = new ShipmentDataManager().GenerateCorporatePODCode(model);
                model.TrackingStatusId = (int)EnumTrackingStatus.CorporateDataEntry;
            }

            return model;
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            if (tbxGrandTotal.Value == 0 && lkpDestination.Value > 0)
            {
                MessageBox.Show("Tidak ada layanan pengiriman untuk tujuan atau service tersebut.");
                return false;
            }

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
            tbxTariffNet.Value = 0;

            tbxL.Value = 1;
            tbxW.Value = 1;
            tbxH.Value = 1;

            tbxOther.Value = 0;
            tbxGoodsValue.Value = 0;
            tbxInsurance.Value = 0;

            tbxGrandTotal.Value = 0;

            tbxDate.DateTime = DateTime.Now;

            lkpPackage.DefaultValue = new IListParameter[] { WhereTerm.Default("PARCEL", "name") };
            lkpService.DefaultValue = new IListParameter[] { WhereTerm.Default("REGULAR", "name") };
            lkpPayment.DefaultValue = new IListParameter[] { WhereTerm.Default("COLLECT", "name") };

            lkpDestination.Focus();
        }

        public override void New()
        {
            base.New();

            cbxRa.Enabled = false;
            tbxTariff.Enabled = false;
            tbxTariffNet.Enabled = false;
            tbxHandlingFee.Enabled = false;
            tbxTtlTariff.Enabled = false;
            tbxTtlChargeable.Enabled = false;
            tbxTariffNet.Enabled = false;
            tbxGrandTotal.Enabled = false;
            tbxInsurance.Enabled = false;
            tbxDate.Enabled = false;
            tbxPacking.Enabled = false;
            
            lkpPayment.DefaultValue = new IListParameter[] { WhereTerm.Default("CREDIT", "name") };
            rbPod_Void.Enabled = false;

            MinWeight = 0;
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
                        BaseControl.CorporateId,
                        tbxTtlChargeable.Value
                        );

                    if (customerTariffModel != null)
                    {
                        tbxTariff.Value = customerTariffModel.Tariff;
                        tbxHandlingFee.Value = customerTariffModel.HandlingFee;

                        cbxRa.Checked = customerTariffModel.Ra ?? false;
                        MinWeight = customerTariffModel.MinWeight;
                        if (MinWeight > 0 && tbxTtlGrossWeight.Value < MinWeight) tbxTtlGrossWeight.Value = MinWeight;
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
                        MinWeight = tariffModel.MinWeight;
                        if (MinWeight > 0 && tbxTtlGrossWeight.Value < MinWeight) tbxTtlGrossWeight.Value = MinWeight;
                        RefreshGrandTotal();
                        return;
                    }
                }
            }

            tbxTariff.Text = @"0";
            tbxHandlingFee.Text = @"0";

            MinWeight = 0;
            RefreshGrandTotal();
        }

        private void RefreshGrandTotal()
        {
            if (_isPopulatingForm) return;
            if (CurrentModel == null) return;

            if (string.IsNullOrEmpty(tbxTariffNet.Text) || string.IsNullOrEmpty(tbxTtlTariff.Text) ||
                string.IsNullOrEmpty(tbxInsurance.Text) || string.IsNullOrEmpty(tbxOther.Text) ||
                string.IsNullOrEmpty(tbxInsurance.Text)) return;

            if (((ShipmentModel)CurrentModel).PricingPlanId == PRICING_PLAN_DOMESTIC)
            {
                tbxTtlTariff.Value = (tbxTariff.Value * tbxTtlChargeable.Value) + tbxHandlingFee.Value;
            }

            tbxTariffNet.Value = tbxTtlTariff.Value;

            //txtInsuranceFee.Value = txtGoodsValue.Value * ((float) _fixedShippingInsuranceRate);

            var grandTotal = tbxTariffNet.Value + tbxPacking.Value + tbxOther.Value + tbxInsurance.Value;

            if (((ShipmentModel)CurrentModel).CurrencyId != null)
            {
                grandTotal *= ((ShipmentModel)CurrentModel).CurrencyRate;
            }

            tbxGrandTotal.Value = grandTotal;
        }

        private void RefreshServiceType()
        {
            if (lkpDestination.Value == null) return;
            int originBranchId = 0;

            using (var cityDataManager = new CityDataManager())
            {
                var originCity = cityDataManager.GetFirst<CityModel>(WhereTerm.Default(BaseControl.CityId, "id"));
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
                    WhereTerm.Default((int)lkpDestination.Value, "city_id")
                    );
            }

            if (branchCityListModel != null)
            {
                lkpService.DefaultValue = new IListParameter[] { WhereTerm.Default(SERVICE_TYPE_CITY_COURIER, "Name") };
            }
            else RefreshTariff();
        }

        private void NoServiceMessage()
        {
            if (tbxGrandTotal.Value == 0 && lkpDestination.Value > 0) MessageBox.Show("Tidak ada layanan pengiriman untuk tujuan atau service tersebut.");
        }

        private void VolumeCalculation()
        {
            var volume = tbxL.Value * tbxW.Value * tbxH.Value;
            if (lkpService.Text == "DARAT" || lkpService.Text == "CITY COURIER" || lkpService.Text == "LAUT") volume = volume / 4000;
            else volume = volume / 6000;

            if (volume > tbxTtlGrossWeight.Value)
            {
                var ceiled = Math.Ceiling(volume);
                if (ceiled > 999999) MessageBox.Show(@"Chargeable maximal 999,999 kg");

                tbxTtlChargeable.Value = ceiled;
                RefreshGrandTotal();
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

            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(CurrentModel.Id, "shipment_id"));
            if (expand != null)
            {
                expand.VolumeL = tbxL.Value;
                expand.VolumeW = tbxW.Value;
                expand.VolumeH = tbxH.Value;
                expand.UsePacking = cbxPacking.Checked;
                expand.IsCod = false;
                expand.TotalCod = 0;

                new ShipmentExpandDataManager().Update<ShipmentExpandModel>(expand);
            }
            else
            {
                expand.ShipmentId = CurrentModel.Id;
                expand.VolumeL = tbxL.Value;
                expand.VolumeW = tbxW.Value;
                expand.VolumeH = tbxH.Value;
                expand.UsePacking = cbxPacking.Checked;
                expand.IsCod = false;
                expand.TotalCod = 0;

                new ShipmentExpandDataManager().Save<ShipmentExpandModel>(expand);
            }

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