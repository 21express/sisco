using System;
using SISCO.Presentation.Common.Forms;
using SISCO.App.Franchise;
using SISCO.Models;
using System.Windows.Forms;
using Devenlab.Common.Interfaces;
using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using Devenlab.Common.Fault;
using Devenlab.Common.WinControl.MessageBox;
using System.Collections.Generic;
using SISCO.App.Administration;
using SISCO.Presentation.Common.Properties;
using System.Linq;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class DataEntryFranchiseForm : BaseCrudForm<ShipmentModel, ShipmentDataManager>//BaseToolbarForm//
    {
        const string CURRENCY_IDR = "IDR";
        const string SERVICE_TYPE_CITY_COURIER = "CITY COURIER";
        const int PRICING_PLAN_DOMESTIC = 1;
        //public decimal MaximumBranchDiscount { get; set; }
        public decimal CustomerDiscount { get; set; }
        public decimal DeliveryTariffMinimumWeight { get; set; }
        private int _franchise_id { get; set; }
        private int? promoId { get; set; }

        public DataEntryFranchiseForm()
        {
            InitializeComponent();

            form = this;
            Load += DataEntryFranchiseLoad;

            tbxNo.Leave += ShipmentNo_Leave;

            FormTrackingStatus = EnumTrackingStatus.Acceptance;
            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                WhereTerm.Default(5,"sales_type_id", EnumSqlOperator.Equals),
                WhereTerm.Default(0, "franchise_id", EnumSqlOperator.GreatThan)
            };
        }

        private void DataEntryFranchiseLoad(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            tbxDate.FieldLabel = "Date";
            tbxDate.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            tbxNo.FieldLabel = "No";
            tbxNo.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpOrigin.LookupPopup = new CityPopup();
            lkpOrigin.AutoCompleteDataManager = new CityDataManager();
            lkpOrigin.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpOrigin.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpOrigin.FieldLabel = "Origin City";
            lkpOrigin.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

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

            lkpOrigin.Leave += (o, args) =>
            {
                if (_isPopulatingForm) return;
                RefreshTariff();
            };
            lkpDestination.Leave += lkpDestination_Leave;
            lkpPackageType.Leave += (o, args) =>
            {
                if (_isPopulatingForm) return;
                RefreshTariff();
            };
            lkpServiceType.Leave += (o, args) =>
            {
                if (_isPopulatingForm) return;
                RefreshTariff();
            };

            tbxOther.EditValueChanged += tbxOtherFee_EditValueChanged;
            tbxGoodValue.EditValueChanged += txtGoodsValue_EditValueChanged;
            tbxDiscount.EditValueChanged += tbxDiscount_EditValueChanged;

            //using (var branchDm = new BranchDataManager())
            //{
            //    var branch = branchDm.GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id"));
            //    MaximumBranchDiscount = branch.MaxDiscount > 0 ? branch.MaxDiscount : 0;
            //}

            tbxTtlWeight.Leave += TxtTotalWeightOnTextLeave;
            tbxDiscount.TextChanged += (o, args) =>
            {
                if (_isPopulatingForm) return;
                RefreshTariff();
            };
            btnSave.Click += (o, args) => { Save(); };
        }

        private void TxtTotalWeightOnTextLeave(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;
            decimal ceiled = 0;
            if (CurrentModel == null) return;

            if (((ShipmentModel)CurrentModel).PricingPlanId == PRICING_PLAN_DOMESTIC)
            {
                ceiled = Math.Ceiling(tbxTtlWeight.Value);
            }
            else
            {
                ceiled = Math.Ceiling(tbxTtlWeight.Value * 2) / 2;
            }

            if (ceiled > 999999) MessageBox.Show(@"Chargeable maximal 999,999 kg");

            tbxTtlChargeable.Value = ceiled;

            RefreshGrandTotal();
        }

        private void lkpDestination_Leave(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;
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

        private void tbxOtherFee_EditValueChanged(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;
            RefreshGrandTotal();
        }

        private void txtGoodsValue_EditValueChanged(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;
            var goodsvalue = tbxGoodValue.Value;
            if (goodsvalue == 0) tbxInsurance.Value = 0;
            else tbxInsurance.Value = Math.Round((goodsvalue * BaseControl.GoodValuesInsurance) + BaseControl.GoodValuesAdministration, 0, MidpointRounding.AwayFromZero);
            RefreshGrandTotal();
        }

        private void tbxDiscount_EditValueChanged(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;
            if (tbxDiscount.Value > 20) tbxDiscount.Value = 20;
        }

        private void RefreshTariff()
        {
            if (_isPopulatingForm) return;

            if (CurrentModel == null) return;

            if (((ShipmentModel)CurrentModel).Posted || ((ShipmentModel)CurrentModel).Voided) return;

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
                var upperLimit = Math.Max(CustomerDiscount, 15);
                if (lkpServiceType.Text.Equals("DARAT") || promoId > 0)
                {
                    upperLimit = 5;
                }
                else if (lkpServiceType.Text.Equals("SUPER ECONOMI"))
                {
                    upperLimit = 10;
                }

                tbxDiscount.Enabled = true;

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

            using (var tariffDataManager = new TariffDataManager())
            {
                if (lkpDestination.Value != null)
                {
                    var tariffModel = tariffDataManager.GetTariff(
                        (int)lkpOrigin.Value,
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
            if (_isPopulatingForm) return;

            CheckPromo();

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

        protected override void PopulateForm(ShipmentModel model)
        {
            ClearForm();
            _isPopulatingForm = true;

            cbxRa.Checked = model.NeedRa;
            
            tbxAgent.Enabled = false;
            var franchise = new FranchiseDataManager().GetFirst<FranchiseModel>(WhereTerm.Default((int)model.FranchiseId, "id"));
            if (franchise != null) tbxAgent.Text = string.Format("{0} - {1}", franchise.Code, franchise.Name);

            tbxDate.DateTime = model.DateProcess;
            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;
            tsBaseTxt_Code.Text = model.Code;

            tbxNo.Text = model.Code;
            lkpOrigin.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CityId, "id") };

            _franchise_id = (int) model.FranchiseId;

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

            btnSave.Enabled = true;
            EnabledForm(model.TrackingStatusId == (int)EnumTrackingStatus.FranchiseDataEntry);
            if (model.Voided)
            {
                MessageBox.Show(@"POD sudah di-VOID!");
            }

            EnabledForm(false);
            btnSave.Enabled = false;
            tsBaseBtn_Save.Enabled = false;

            promoId = null;
            if (model.PromoId != null)
            {
                var promo = new PromoDataManager().GetFirst<PromoModel>(WhereTerm.Default((int)model.PromoId, "id"));

                if (promo != null)
                {
                    tbxPromo.Text = promo.Code;
                    promoId = promo.Id;
                }
            }

            _isPopulatingForm = false;
        }

        protected override ShipmentModel PopulateModel(ShipmentModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.BranchId = model.BranchId;
            model.AutoNumber = true;

            model.NeedRa = cbxRa.Checked;

            model.CityId = (int)lkpOrigin.Value;
            model.CityName = lkpOrigin.Text;

            model.Code = tbxNo.Text;

            var franchise = new FranchiseDataManager().GetFirst<FranchiseModel>(WhereTerm.Default(_franchise_id, "id"));
            var branch = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(franchise.BranchId, "id"));
            model.BranchId = franchise.BranchId;
            model.BranchName = branch.Code;

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
            model.Voided = false;
            model.FranchiseId = _franchise_id;
            model.PODStatus = (int)EnumPodStatus.None;

            if (promoId != null) model.PromoId = promoId;

            if (CurrentModel.Id == 0)
            {
                model.TrackingStatusId = (int)EnumTrackingStatus.Acceptance;
                model.CreatedPc = Environment.MachineName;
                model.DataEntryEmployee = BaseControl.EmployeeCode;
            }
            else
                model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            if (lkpOrigin .Value == null)
            {
                MessageBox.Show(@"Please enter the origin city!");
                lkpOrigin.SelectAll();
                lkpOrigin.Focus();
                return false;
            }
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

        protected override void BeforeNew()
        {
            ClearForm();

            tbxTtlPiece.Value = 1;
            tbxTtlWeight.Value = 1;
            tbxTtlChargeable.Value = 1;

            tbxTariff.Value = 0;
            tbxHandlingFee.Value = 0;
            tbxTtlTarif.Value = 0;
            tbxDiscount.Value = 0;
            tbxTtlDiscount.Value = 0;
            tbxNetTariff.Value = 0;

            tbxOther.Value = 0;
            tbxGoodValue.Value = 0;
            tbxInsurance.Value = 0;

            tbxGrandTtl.Value = 0;
            btnSave.Enabled = true;

            tbxDate.DateTime = DateTime.Now;
            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;
            tbxPromo.Enabled = false;
        }

        public override void New()
        {
            base.New();

            tbxDate.DateTime = DateTime.Now;
            tbxNo.Focus();
            tbxAgent.Enabled = false;

            lkpOrigin.DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.CityId, "id") };
            lkpPackageType.DefaultValue = new IListParameter[] { WhereTerm.Default("PARCEL", "name", EnumSqlOperator.Equals) };
            lkpServiceType.DefaultValue = new IListParameter[] { WhereTerm.Default("ECO", "name", EnumSqlOperator.Equals) };
            lkpPaymentMethod.DefaultValue = new IListParameter[] { WhereTerm.Default("CASH", "name", EnumSqlOperator.Equals) };

            tbxTtlPiece.SetValue(Resources.default_number);
            tbxTtlWeight.SetValue(Resources.default_number);
            tbxTtlChargeable.SetValue(Resources.default_number);
        }

        protected override ShipmentModel Find(string searchTerm)
        {
            return DataManager.GetFirst<ShipmentModel>(
                WhereTerm.Default(searchTerm, "code"));
        }

        protected override void AfterSave()
        {
            PodStatusModel.ShipmentId = CurrentModel.Id;
            PodStatusModel.PositionStatusId = BaseControl.BranchId;
            PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();
            PodStatusModel.StatusBy = BaseControl.UserLogin;

            ShipmentStatusUpdate();

            var model = CurrentModel as ShipmentModel;

            if (model == null) return;

            tsBaseTxt_Code.Text = model.Code;
            new FranchiseCommissionDataManager().CalculateCommission(model, (int) _franchise_id, BaseControl.UserLogin);
            ClearForm();
            PerformFind();
        }

        private void ShipmentNo_Leave(object sender, EventArgs e)
        {
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

            if (!CheckCn())
            {
                return;
            }

            var model = new ShipmentNumberAllocationDataManager().GetFirst<ShipmentAllocationModel>(
                WhereTerm.Default(Convert.ToInt64(tbxNo.Text), "shipment_code_start", EnumSqlOperator.LesThanEqual),
                WhereTerm.Default(Convert.ToInt64(tbxNo.Text), "shipment_code_end", EnumSqlOperator.GreatThanEqual),
                WhereTerm.Default(0, "franchise_id", EnumSqlOperator.GreatThan)
                );

            if (model == null)
            {
                MessageBox.Show(@"Nomor POD tidak dikenali sebagai POD Agent Franchise!");
                tbxNo.Clear();
                tbxNo.Focus();
                return;
            }
            else _franchise_id = (int) model.FranchiseId;

            var franchise = new FranchiseDataManager().GetFirst<FranchiseModel>(WhereTerm.Default(_franchise_id, "id"));
            if (franchise != null)
            {
                tbxAgent.Text = string.Format("{0} {1}", franchise.Code, franchise.Name);
                lkpOrigin.DefaultValue = new IListParameter[] { WhereTerm.Default(franchise.CityId, "id") };
            }
        }

        bool CheckCn()
        {
            var ship = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxNo.Text, "code", EnumSqlOperator.Equals));
            if (ship != null)
            {
                if (ship.Id != CurrentModel.Id)
                {
                    MessageBox.Show(Resources.cn_exists, Resources.information, MessageBoxButtons.OK);
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

        private bool SetPromo(PromoModel promo)
        {
            promoId = null;
            tbxPromo.Text = string.Empty;

            if (promo.CityOrigId != null) if (promo.CityOrigId != lkpOrigin.Value) return false;
            if (promo.CityDestId != null) if (promo.CityDestId != lkpDestination.Value) return false;
            if (promo.PackageTypeId != null) if (promo.PackageTypeId != lkpPackageType.Value) return false;
            if (promo.ServiceTypeId != null) if (promo.ServiceTypeId != lkpServiceType.Value) return false;

            if (promo.MinWeight != null && tbxTtlWeight.Value < promo.MinWeight)
            {
                tbxPromo.Text = string.Empty;
                promoId = null;

                return false;
            }

            promoId = promo.Id;
            tbxPromo.Text = promo.Code;

            if (promo.Tariff != null) tbxTariff.Value = (decimal)promo.Tariff;
            if (promo.Discount != null) tbxDiscount.Value = (decimal)promo.Discount;
            return true;
        }

        private void CheckPromo()
        {
            var now = DateTime.Now;
            var promoes = new PromoDataManager().Get<PromoModel>(new IListParameter[]
                {
                    WhereTerm.Default(new DateTime(now.Year, now.Month, now.Day, 23, 59, 59), "expired_date", EnumSqlOperator.GreatThanEqual),
                    WhereTerm.Default(true, "active"),
                    WhereTerm.Default(tbxDate.DateTime, "createddate", EnumSqlOperator.LesThanEqual)
                }).ToList();

            if (promoes.Count() > 0)
            {
                // check promo based on origin city
                var origbase = promoes.Where(p => p.CityOrigId == lkpOrigin.Value).ToList();
                if (origbase.Count() > 0)
                {
                    if (origbase.Count() == 1)
                    {
                        if (SetPromo(origbase.FirstOrDefault())) return;
                        else origbase = promoes.Where(p => p.CityOrigId != lkpOrigin.Value).ToList();
                    }

                    promoes = origbase;
                }
                else
                {
                    promoes = promoes.Where(p => p.CityOrigId == null).ToList();
                    origbase = promoes;
                }

                //based on destination city
                var destbase = origbase.Where(p => p.CityDestId == lkpDestination.Value).ToList();
                if (destbase.Count() > 0)
                {
                    if (destbase.Count() == 1)
                    {
                        if (SetPromo(destbase.FirstOrDefault())) return;
                        else destbase = origbase.Where(p => p.CityDestId != lkpDestination.Value).ToList();
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

        public override void SetNoPod(string code)
        {
            tbxNo.Text = code;
            tbxNo.Focus();
            lkpOrigin.Focus();
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            var model = CurrentModel as ShipmentModel;
            if (model != null && model.Id > 0)
            {
                EnableBtnSave = false;
                EnabledForm(false);
                tsBaseBtn_Save.Enabled = false;
            }
        }
    }
}