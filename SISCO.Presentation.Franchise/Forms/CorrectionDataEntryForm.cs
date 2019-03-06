using System;
using SISCO.Presentation.Common.Forms;
using SISCO.App.Franchise;
using SISCO.Models;
using System.Windows.Forms;
using Devenlab.Common.Interfaces;
using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Presentation.Franchise.Popup;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using Devenlab.Common.Fault;
using Devenlab.Common.WinControl.MessageBox;
using System.Collections.Generic;
using SISCO.Presentation.CounterCash.Print;

namespace SISCO.Presentation.Franchise.Forms
{
    public partial class CorrectionDataEntryForm : BaseCrudForm<ShipmentModel, ShipmentDataManager>//BaseToolbarForm//
    {
        const string CURRENCY_IDR = "IDR";
        const string SERVICE_TYPE_CITY_COURIER = "CITY COURIER";
        const int PRICING_PLAN_DOMESTIC = 1;
        public decimal MaximumBranchDiscount { get; set; }
        public decimal CustomerDiscount { get; set; }
        public decimal DeliveryTariffMinimumWeight { get; set; }
        public int LastCustomerId { get; set; }
        private bool setVoid { get; set; }
        public CorrectionDataEntryForm()
        {
            InitializeComponent();

            form = this;
            Load += CorrectionDataEntryLoad;
            Shown += CorrectionDataEntryForm_Shown;
        }

        private void CorrectionDataEntryForm_Shown(object sender, EventArgs e)
        {
            cbxFranchise.Enabled = true;
        }

        private void CorrectionDataEntryLoad(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            var Franchises = new FranchiseDataManager().Get<FranchiseModel>();

            cbxFranchise.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxFranchise.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxFranchise.DataSource = Franchises;
            cbxFranchise.DisplayMember = "Name";
            cbxFranchise.ValueMember = "Id";
            cbxFranchise.SelectedValueChanged += (s, a) => SetDataManager();

            lkpCustomer.LookupPopup =
                new CustomerPopup(new IListParameter[]
                {
                    WhereTerm.Default("0", "disabled", EnumSqlOperator.Equals),
                    WhereTerm.Default((int)cbxFranchise.SelectedValue, "franchise_id", EnumSqlOperator.Equals)
                });
            lkpCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpCustomer.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND disabled = @1 AND franchise_id = @2", s, "0", (int) cbxFranchise.SelectedValue);

            lkpCustomer.Leave += AutoPopulateCustomerDetail;

            lkpDestination.LookupPopup = new CityPopup();
            lkpDestination.AutoCompleteDataManager = new CityDataManager();
            lkpDestination.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpDestination.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpDestination.FieldLabel = "Destination City";
            lkpDestination.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpPackageType.LookupPopup = new PackageTypePopup();
            lkpPackageType.AutoCompleteDataManager = new PackageTypeDataManager();
            lkpPackageType.AutoCompleteDisplayFormater = model => ((PackageTypeModel)model).Name;
            lkpPackageType.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpPackageType.FieldLabel = "Package Type";
            lkpPackageType.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpServiceType.LookupPopup = new ServiceTypePopup("name.Equals(@0) OR name.Equals(@1) OR name.Equals(@2) OR name.Equals(@3)", "ECO", "SDS", "ONS", "DARAT");
            lkpServiceType.AutoCompleteDataManager = new ServiceTypeDataManager();
            lkpServiceType.AutoCompleteDisplayFormater = model => ((ServiceTypeModel)model).Name;
            lkpServiceType.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("name.StartsWith(@0) AND (name.Equals(@1) OR name.Equals(@2) OR name.Equals(@3) OR name.Equals(@4))", s, "ECO", "SDS", "ONS", "DARAT");
            lkpServiceType.FieldLabel = "Service Type";
            lkpServiceType.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpPaymentMethod.LookupPopup = new PaymentMethodPopup("name.Equals(@0)", "CASH");
            lkpPaymentMethod.AutoCompleteDataManager = new PaymentMethodDataManager();
            lkpPaymentMethod.AutoCompleteDisplayFormater = model => ((PaymentMethodModel)model).Name;
            lkpPaymentMethod.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("name.StartsWith(@0) AND name.Equals(@1)", s, "CASH");
            lkpPaymentMethod.FieldLabel = "Payment Method";
            lkpPaymentMethod.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            tbxShipperName.FieldLabel = "Shipper Name";
            tbxShipperName.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            tbxShipperAddress.FieldLabel = "Shipper Address";
            tbxShipperAddress.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            tbxShipperPhone.FieldLabel = "Shipper Phone";
            tbxShipperPhone.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            tbxConsigneeName.FieldLabel = "Consignee Name";
            tbxConsigneeName.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            tbxConsigneeAddress.FieldLabel = "Consignee Address";
            tbxConsigneeAddress.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            tbxConsigneePhone.FieldLabel = "Consignee Phone";
            tbxConsigneePhone.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            tbxTtlPiece.EditMask = "###,##0";
            tbxTtlPiece.FieldLabel = "Total Piece";
            tbxTtlPiece.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            tbxTtlWeight.EditMask = "###,##0.0";
            tbxTtlWeight.FieldLabel = "Total Weight";
            tbxTtlWeight.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            tbxTtlChargeable.EditMask = "###,##0.0";
            tbxTtlChargeable.FieldLabel = "Chargeable Weight";
            tbxTtlChargeable.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            tbxDiscount.EditMask = "#0.0%%";
            tbxOther.EditMask = "##,###,##0.00";
            tbxGoodValue.EditMask = "##,###,###,##0.00";
            tbxInsurance.EditMask = "##,###,###,##0.00";

            tbxShipperName.CharacterCasing = CharacterCasing.Upper;
            tbxShipperAddress.CharacterCasing = CharacterCasing.Upper;
            tbxShipperPhone.CharacterCasing = CharacterCasing.Upper;
            tbxConsigneeName.CharacterCasing = CharacterCasing.Upper;
            tbxConsigneeAddress.CharacterCasing = CharacterCasing.Upper;
            tbxConsigneePhone.CharacterCasing = CharacterCasing.Upper;
            tbxRef.CharacterCasing = CharacterCasing.Upper;
            tbxNote.CharacterCasing = CharacterCasing.Upper;
            tbxNatureOfGoods.CharacterCasing = CharacterCasing.Upper;

            tbxShipperName.MaxLength = 100;
            tbxShipperAddress.MaxLength = 254;
            tbxShipperPhone.MaxLength = 50;
            tbxConsigneeName.MaxLength = 100;
            tbxConsigneeAddress.MaxLength = 254;
            tbxConsigneePhone.MaxLength = 50;
            tbxRef.MaxLength = 50;
            tbxNote.MaxLength = 100;
            tbxNatureOfGoods.MaxLength = 50;

            lkpDestination.EditValueChanged += lkpDestination_EditValueChanged;
            tbxGoodValue.EditValueChanged += txtGoodsValue_EditValueChanged;
            tbxDiscount.EditValueChanged += tbxDiscount_EditValueChanged;

            btnRefreshTariff.Click += (o, args) =>
            {
                RefreshTariff();
                NoServiceMessage();
            };

            btnRefreshCommission.Click += (o, args) =>
            {
                var dialog = MessageForm.Ask(form, "Komisi", "Anda yakin akan menghitung ulang komisi untuk POD ini? Jika iya data komisi sebelumnya akan ditimpa dengan perhitungan baru.");
                if (dialog == DialogResult.Yes)
                {
                    var model = CurrentModel as ShipmentModel;
                    new FranchiseCommissionDataManager().CalculateCommission(model, (int)cbxFranchise.SelectedValue, BaseControl.UserLogin);
                    PerformFind();
                }
            };

            using (var branchDm = new BranchDataManager())
            {
                var branch = branchDm.GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id"));
                MaximumBranchDiscount = branch.MaxDiscount > 0 ? branch.MaxDiscount : 0;
            }

            tbxTtlWeight.TextChanged += TxtTotalWeightOnTextChanged;
            tbxDiscount.TextChanged += (o, args) => RefreshTariff();

            tsBaseBtn_Print.Click += (o, args) =>
            {
                var printout = new EConnotePrintout
                {
                    DataSource = GetPrintDataSource()
                };
                printout.Print();

                new ShipmentExpandDataManager().Printing(CurrentModel.Id);
            };

            tsBaseBtn_PrintPreview.Click += (o, args) =>
            {
                var printout = new EConnotePrintout
                {
                    DataSource = GetPrintDataSource()
                };
                printout.PrintPreview();
            };

            btnUnVoid.Click += Unvoid;
            SetDataManager();
        }

        private void Unvoid(object sender, EventArgs e)
        {
            var dialog = MessageForm.Ask(form, "Un-void Confirmation", "Anda yakin akan un-void POD ini?");
            if (dialog == DialogResult.Yes)
            {
                setVoid = false;
                Save();
            }
        }

        private void TxtTotalWeightOnTextChanged(object sender, EventArgs e)
        {
            decimal ceiled = 0;
            if (CurrentModel == null) return;

            if (tbxTtlWeight.Value > 0)
            {
                var number = tbxTtlWeight.Value.ToString()[0].ToString();
                var decPoint = tbxTtlWeight.Value - Convert.ToDecimal(number);

                if (decPoint < (decimal)0.4) ceiled = Convert.ToDecimal(number);
                else ceiled = Convert.ToDecimal(number) + 1;
            }

            //ceiled = Math.Ceiling(tbxTtlGrossWeight.Value * 2) / 2;

            if (ceiled > 999999) MessageBox.Show(@"Chargeable maximal 999,999 kg");

            tbxTtlChargeable.Value = ceiled;

            RefreshGrandTotal();
        }

        private void AutoPopulateCustomerDetail(object sender, EventArgs e)
        {
            if (lkpCustomer.Value != null)
            {
                var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)lkpCustomer.Value, "id", EnumSqlOperator.Equals));

                if (customer != null)
                {
                    tbxShipperName.Text = customer.Name;
                    tbxShipperAddress.Text = customer.Address;
                    tbxShipperPhone.Text = customer.Phone;
                }
            }
        }

        private void SetDataManager()
        {
            if (cbxFranchise.SelectedValue != null)
            {
                DataManager.DefaultParameters = new IListParameter[]
                {
                    WhereTerm.Default((int) cbxFranchise.SelectedValue, "franchise_id", EnumSqlOperator.Equals),
                    WhereTerm.Default(5,"sales_type_id", EnumSqlOperator.Equals),
                };

                EnableBtnSearch = true;
                SearchPopup = new ShipmentPopup((int)cbxFranchise.SelectedValue);
            }
            else
            {
                DataManager.DefaultParameters = new IListParameter[]
                {
                    WhereTerm.Default(-1, "franchise_id", EnumSqlOperator.Equals)
                };

                EnableBtnSearch = false;
            }

            ClearForm();
            tsBaseTxt_Code.Text = "";
            tsBaseBtn_Print.Enabled = false;
            tsBaseBtn_PrintPreview.Enabled = false;
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
        }

        private void txtGoodsValue_EditValueChanged(object sender, EventArgs e)
        {
            var goodsvalue = tbxGoodValue.Value;
            if (goodsvalue == 0) tbxInsurance.Value = 0;
            else tbxInsurance.Value = Math.Round((goodsvalue * BaseControl.GoodValuesInsurance) + BaseControl.GoodValuesAdministration, 0, MidpointRounding.AwayFromZero);
            RefreshGrandTotal();
        }

        private void tbxDiscount_EditValueChanged(object sender, EventArgs e)
        {
            if (tbxDiscount.Value > 20) tbxDiscount.Value = 20;
        }

        private void RefreshTariff()
        {
            if (_isPopulatingForm) return;

            if (CurrentModel == null) return;

            if (((ShipmentModel)CurrentModel).Posted || ((ShipmentModel)CurrentModel).Voided) return;

            var tempModel = (ShipmentModel)CurrentModel;

            tbxTariff.Value = 0;
            tbxHandlingFee.Value = 0;
            cbxRa.Checked = false;

            if (lkpServiceType.Text.Equals("CITY COURIER"))
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
                if (lkpPackageType.Value != null)
                {
                    if (lkpDestination.Value != null)
                        dlvTariff = dm.GetByPackageTypeAndWeight((int)lkpPackageType.Value, (int)lkpDestination.Value, tbxTtlWeight.Value);
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
                        lkpPackageType.Value ?? 0,
                        tbxTtlChargeable.Value
                        );

                    if (tariffIntModel != null)
                    {
                        tbxTariff.Value = 0;
                        tbxTtlTarif.Value = tariffIntModel.Tariff;

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
                if (lkpDestination.Value != null && lkpCustomer.Value != null)
                {
                    var customerTariffModel = customerTariffDataManager.GetTariff(
                        tempModel.CityId,
                        (int)lkpDestination.Value,
                        lkpServiceType.Value ?? 0,
                        lkpPackageType.Value ?? 0,
                        (int) lkpCustomer.Value,
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
                        tempModel.CityId,
                        (int)lkpDestination.Value,
                        lkpServiceType.Value ?? 0,
                        lkpPackageType.Value ?? 0,
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
                string.IsNullOrEmpty(tbxNetTariff.Text) || string.IsNullOrEmpty(tbxTtlTarif.Text) ||
                string.IsNullOrEmpty(tbxInsurance.Text) || string.IsNullOrEmpty(tbxOther.Text) ||
                string.IsNullOrEmpty(tbxInsurance.Text)) return;

            if (((ShipmentModel)CurrentModel).PricingPlanId == PRICING_PLAN_DOMESTIC)
            {
                tbxTtlTarif.Value = (tbxTariff.Value * tbxTtlChargeable.Value) + tbxHandlingFee.Value;
            }

            tbxTtlDiscount.Value = (tbxDiscount.Value / 100) * tbxTtlTarif.Value;
            tbxNetTariff.Value = tbxTtlTarif.Value - tbxTtlDiscount.Value;

            //txtInsuranceFee.Value = txtGoodsValue.Value * ((float) _fixedShippingInsuranceRate);

            var grandTotal = tbxNetTariff.Value + tbxOther.Value + tbxInsurance.Value;

            if (((ShipmentModel)CurrentModel).CurrencyId != null)
            {
                grandTotal *= ((ShipmentModel)CurrentModel).CurrencyRate;
            }

            tbxGrandTtl.Value = grandTotal;
        }

        private void RefreshDeliveryTariff()
        {
            if (_isPopulatingForm) return;
            if (CurrentModel == null) return;

            ((ShipmentModel)CurrentModel).DeliveryFeeTotal = ((ShipmentModel)CurrentModel).DeliveryFee * Math.Max(tbxTtlChargeable.Value, DeliveryTariffMinimumWeight);
        }

        private void NoServiceMessage()
        {
            if (tbxTariff.Value == 0) MessageBox.Show("Tidak ada layanan pengiriman untuk tujuan atau service tersebut.");
        }

        public override void New()
        {
            base.New();

            tbxPromo.Enabled = false;
        }

        protected override void PopulateForm(ShipmentModel model)
        {
            ClearForm();
            LastCustomerId = model.CustomerId ?? 0;

            cbxRa.Checked = model.NeedRa;

            tbxDate.DateTime = model.DateProcess;
            tsBaseTxt_Code.Text = model.Code;

            if (model.CustomerId > 0)
            {
                var customer =
                    new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)model.CustomerId, "id"));
                lkpCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default(customer.Id, "id") };
            }

            lkpDestination.DefaultValue = new IListParameter[] { WhereTerm.Default(model.DestCityId, "id") };

            tbxShipperName.Text = model.ShipperName;
            tbxShipperAddress.Text = model.ShipperAddress;
            tbxShipperPhone.Text = model.ShipperPhone;
            tbxRef.Text = model.RefNumber;

            tbxConsigneeName.Text = model.ConsigneeName;
            tbxConsigneeAddress.Text = model.ConsigneeAddress;
            tbxConsigneePhone.Text = model.ConsigneePhone;

            lkpPackageType.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PackageTypeId, "id") };
            lkpServiceType.DefaultValue = new IListParameter[] { WhereTerm.Default(model.ServiceTypeId, "id") };
            lkpPaymentMethod.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PaymentMethodId, "id") };

            tbxNatureOfGoods.Text = model.NatureOfGoods;
            tbxNote.Text = model.Note;

            tbxTtlPiece.Value = model.TtlPiece;
            tbxTtlWeight.Value = model.TtlGrossWeight;
            tbxTtlChargeable.Value = model.TtlChargeableWeight;

            tbxTariff.Value = model.Tariff;
            tbxHandlingFee.Value = model.HandlingFee;
            tbxTtlTarif.Value = model.TariffTotal;
            tbxDiscount.Value = model.DiscountPercent;
            tbxTtlDiscount.Value = model.DiscountTotal;
            tbxNetTariff.Value = model.TariffNet;

            tbxOther.Value = model.OtherFee;
            tbxGoodValue.Value = model.GoodsValue;
            tbxInsurance.Value = model.InsuranceFee;

            tbxDiscount.Enabled = !lkpServiceType.Text.ToUpper().Equals("CITY COURIER");

            tbxGrandTtl.Value = model.Total;

            tbxTtlDiscount.Value = model.DiscountTotal;

            btnUnVoid.Enabled = false;

            EnabledForm(model.TrackingStatusId == (int)EnumTrackingStatus.FranchiseDataEntry);
            btnRefreshTariff.Enabled = model.TrackingStatusId == (int)EnumTrackingStatus.FranchiseDataEntry;
            btnRefreshCommission.Enabled = !model.Paid;
            tsBaseBtn_Save.Enabled = model.TrackingStatusId == (int)EnumTrackingStatus.FranchiseDataEntry;

            if (model.Voided)
            {
                MessageBox.Show(@"POD sudah di-VOID!");
                EnabledForm(false);

                tbxDiscount.Enabled = false;
                btnUnVoid.Enabled = true;

                tsBaseBtn_Save.Enabled = false;
            }

            if ((DateTime.Now - model.DateProcess).TotalDays > 4)
            {
                EnabledForm(false);
                btnUnVoid.Enabled = false;
                btnRefreshTariff.Enabled = false;

                tsBaseBtn_Save.Enabled = false;
            }
            
            if (model.PromoId != null)
            {
                var promo = new PromoDataManager().GetFirst<PromoModel>(WhereTerm.Default((int)model.PromoId, "id"));
                if (promo != null)
                {
                    tbxPromo.Text = promo.Code;
                }
            }

            setVoid = model.Voided;
            tsBaseBtn_Print.Enabled = true;
            tsBaseBtn_PrintPreview.Enabled = false;
            tbxPromo.Enabled = false;

            var commission = new FranchiseCommissionDataManager().GetFirst<FranchiseCommissionModel>(WhereTerm.Default(model.Id, "shipment_id"));
            if (commission != null)
            {
                tbxTtlSales.SetValue(commission.TotalSales);
                tbxPPn.SetValue(commission.PPN);
                tbxCommission.SetValue(commission.Commission);
                tbxPPh.SetValue(commission.PPH23);
                tbxNetCommission.SetValue(commission.TotalNetCommission);
                tbxDebs.SetValue(commission.Debs);
            }

            tbxTtlSales.Enabled = false;
            tbxPPn.Enabled = false;
            tbxCommission.Enabled = false;
            tbxPPh.Enabled = false;
            tbxNetCommission.Enabled = false;
            tbxDebs.Enabled = false;
        }

        protected override ShipmentModel PopulateModel(ShipmentModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.BranchId = model.BranchId;
            model.AutoNumber = true;

            model.NeedRa = cbxRa.Checked;

            model.CityId = model.CityId;
            model.CityName = model.CityName;

            if (lkpDestination.Value == null)
                throw new BusinessException("");
            model.DestCity = lkpDestination.Text;
            model.DestCityId = (int)lkpDestination.Value;

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

            if (lkpCustomer.Value != null)
            {
                model.CustomerId = lkpCustomer.Value;
                var customer =
                    new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)model.CustomerId, "id"));
                model.CustomerName = customer.Name;
            }

            model.ShipperName = tbxShipperName.Text;
            model.ShipperAddress = tbxShipperAddress.Text;
            model.ShipperPhone = tbxShipperPhone.Text;
            model.RefNumber = tbxRef.Text;

            model.ConsigneeName = tbxConsigneeName.Text;
            model.ConsigneeAddress = tbxConsigneeAddress.Text;
            model.ConsigneePhone = tbxConsigneePhone.Text;

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

            model.NatureOfGoods = tbxNatureOfGoods.Text;
            model.Note = tbxNote.Text;

            model.TtlPiece = Convert.ToInt16(tbxTtlPiece.Value);
            model.TtlGrossWeight = tbxTtlWeight.Value;
            model.TtlChargeableWeight = tbxTtlChargeable.Value;

            model.Tariff = tbxTariff.Value;
            model.HandlingFeeTotal = tbxHandlingFee.Value;
            model.TariffTotal = tbxTtlTarif.Value;
            model.DiscountPercent = tbxDiscount.Value;
            model.DiscountTotal = tbxTtlDiscount.Value;
            model.TariffNet = tbxNetTariff.Value;

            model.OtherFee = tbxOther.Value;
            model.GoodsValue = tbxGoodValue.Value;
            model.InsuranceFee = tbxInsurance.Value;

            model.Total = tbxGrandTtl.Value;

            model.SalesTypeId = 5;
            model.Voided = setVoid;

            if (CurrentModel.Id == 0)
            {
                model.CreatedPc = Environment.MachineName;
            }
            else
                model.ModifiedPc = Environment.MachineName;

            model.FranchiseId = (int)model.FranchiseId;

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
            if (tbxShipperName.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter the shipper name!");
                tbxShipperName.SelectAll();
                tbxShipperName.Focus();
                return false;
            }
            if (tbxShipperAddress.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter the shipper address!");
                tbxShipperAddress.SelectAll();
                tbxShipperAddress.Focus();
                return false;
            }
            if (tbxShipperPhone.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter the shipper phone number!");
                tbxShipperPhone.SelectAll();
                tbxShipperPhone.Focus();
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
            if (lkpPackageType.Value == null)
            {
                MessageBox.Show(@"Please select the package type!");
                lkpPackageType.SelectAll();
                lkpPackageType.Focus();
                return false;
            }
            if (lkpServiceType.Value == null)
            {
                MessageBox.Show(@"Please select the service type!");
                lkpServiceType.SelectAll();
                lkpServiceType.Focus();
                return false;
            }
            if (lkpPaymentMethod.Value == null)
            {
                MessageBox.Show(@"Please select the payment method type!");
                lkpPaymentMethod.SelectAll();
                lkpPaymentMethod.Focus();
                return false;
            }
            if (tbxTtlPiece.Value == 0)
            {
                MessageBox.Show(@"Please fill the total piece field!");
                tbxTtlPiece.SelectAll();
                tbxTtlPiece.Focus();
                return false;
            }
            if (tbxTtlWeight.Value == 0)
            {
                MessageBox.Show(@"Please wnter the total weight!");
                tbxTtlWeight.SelectAll();
                tbxTtlWeight.Focus();
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
            return DataManager.GetFirst<ShipmentModel>(
                WhereTerm.Default(searchTerm, "code"));
        }

        protected override void AfterSave()
        {
            //base.AfterSave();
            var model = CurrentModel as ShipmentModel;

            if (model == null) return;

            tsBaseTxt_Code.Text = model.Code;
            PerformFind();
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            var model = CurrentModel as ShipmentModel;
            if (model != null && (model.Voided || model.Posted || model.Invoiced == 1) && model.PODStatus > 0)
            {
                EnableBtnSave = false;
                EnabledForm(false);
            }

            if (model != null)
            {
                tsBaseBtn_Save.Enabled = model.TrackingStatusId == (int)EnumTrackingStatus.FranchiseDataEntry;
                if ((DateTime.Now - model.DateProcess).TotalDays > 4) tsBaseBtn_Save.Enabled = false;
            }

            cbxFranchise.Enabled = true;
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

            if (model.FranchiseId.HasValue)
            using (var franchiseDm = new FranchiseDataManager())
            {
                var franchise = franchiseDm.GetFirst<FranchiseModel>(WhereTerm.Default((int)model.FranchiseId, "id"));
                if (franchise != null)
                {
                    model.FranchiseCode = franchise.Code;
                    model.FranchiseName = franchise.Name;
                }
            }

            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(model.Id, "shipment_id"));
            model.Printed = expand != null ? expand.Printed : (short)0;
            model.VolumeL = expand != null ? expand.VolumeL : 1;
            model.VolumeH = expand != null ? expand.VolumeH : 1;
            model.VolumeW = expand != null ? expand.VolumeW : 1;

            return new List<ShipmentModel.ShipmentReportRow>
            {
                model
            };
        }
    }
}