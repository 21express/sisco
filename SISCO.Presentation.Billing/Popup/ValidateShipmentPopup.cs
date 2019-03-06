using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Billing.Forms;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Billing.Popup
{
    public partial class ValidateShipmentPopup : BaseForm
    {
        private decimal _fixedShippingInsuranceRate;

        public ShipmentModel ValidateShipment { get; set; }
        public ShipmentModel ReValidateShipment { get; set; }
        // ReSharper disable InconsistentNaming
        const string CURRENCY_IDR = "IDR";
        const string SERVICE_TYPE_CITY_COURIER = "CITY COURIER";
        const int PRICING_PLAN_DOMESTIC = 1;
        // ReSharper restore InconsistentNaming

        private decimal DeliveryTariffMinimumWeight { get; set; }
        private bool IsInternationalShipment { get; set; }

        private decimal MaximumBranchDiscount { get; set; }
        private decimal CustomerDiscount { get; set; }

        public ValidateShipmentPopup(string _shipmentNo)
        {
            InitializeComponent();
            form = this;

            txtShipmentNo.Text = _shipmentNo;
            Load += ValidateLoad;
            Shown += ValidateShow;
        }

        private void ValidateShow(object sender, EventArgs e)
        {
            ValidateShipment = null;
            if (ReValidateShipment != null)
            {
                CurrentModel = ReValidateShipment;
                PopulateForm(ReValidateShipment);
            }
            else
            {
                var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(txtShipmentNo.Text, "code"));
                if (shipment == null) MessageBox.Show("Nomor resi tidak dikenali");
                else
                {
                    CurrentModel = shipment;
                    PopulateForm(shipment);
                }
            }
        }

        private void ValidateLoad(object sender, EventArgs e)
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

            lkpCustomer.LookupPopup = new CustomerPopup(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            lkpCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpCustomer.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) and branch_id = @1", s, BaseControl.BranchId);
            lkpCustomer.FieldLabel = "Customer";
            lkpCustomer.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpCustomerCollect.LookupPopup = new CustomerPopup(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            lkpCustomerCollect.AutoCompleteDataManager = new CustomerDataManager();
            lkpCustomerCollect.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpCustomerCollect.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) and branch_id = @1", s, BaseControl.BranchId);
            lkpCustomerCollect.FieldLabel = "Customer Collect";
            lkpCustomerCollect.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

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
            lkpPaymentMethod.AutoCompleteWhereExpression = (s, param) => param.SetWhereExpression("name.StartsWith(@0) AND UPPER(name) IN ('COLLECT', 'CREDIT')");
            lkpPaymentMethod.FieldLabel = "Payment Method";
            lkpPaymentMethod.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpMessenger.LookupPopup = new EmployeePopup(EmployeeModel.EmployeeType.Messenger);
            lkpMessenger.AutoCompleteDataManager = new EmployeeDataManager();
            lkpMessenger.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " " + ((EmployeeModel)model).Name;
            lkpMessenger.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_messenger", s);

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
            txtChargeableWeight.EditMask = "###,##0.0";
            txtChargeableWeight.FieldLabel = "Chargeable Weight";
            txtChargeableWeight.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtDiscount.EditMask = "#0.0%%";
            txtPackingFee.EditMask = "##,###,##0.00";
            txtOtherFee.EditMask = "##,###,##0.00";
            txtGoodsValue.EditMask = "##,###,##0.00";
            txtInsuranceFee.EditMask = "##,###,##0.00";

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

            txtTotalWeight.TextChanged += TxtTotalWeightOnTextChanged;

            txtTariffPerKg.TextChanged += (o, args) => RefreshGrandTotal(true);
            txtTariffTotal.KeyUp += (o, args) => { if (Convert.ToInt16(args.KeyCode) != 13) RefreshGrandTotal(false); };
            txtHandlingFee.TextChanged += (o, args) => RefreshGrandTotal(true);
            txtPackingFee.TextChanged += (o, args) => RefreshGrandTotal(true);
            txtOtherFee.TextChanged += (o, args) => RefreshGrandTotal(true);
            txtGoodsValue.TextChanged += (o, args) =>
            {
                txtInsuranceFee.Value = txtGoodsValue.Value * ((decimal)_fixedShippingInsuranceRate);
                RefreshGrandTotal(true);
            };
            txtInsuranceFee.TextChanged += (o, args) => RefreshGrandTotal(true);
            txtTotalWeight.TextChanged += (o, args) => RefreshGrandTotal(true);
            txtChargeableWeight.TextChanged += (o, args) =>
            {
                if (((ShipmentModel)CurrentModel).PricingPlanId != PRICING_PLAN_DOMESTIC)
                {
                    RefreshTariff(true);
                }
                else
                {
                    RefreshGrandTotal();
                }

                RefreshDeliveryTariff();
            };
            txtDeliveryTariff1.TextChanged += (o, args) => RefreshDeliveryTariff();

            txtDeliveryTariff1.TextChanged += (o, args) => RefreshDeliveryTariff();

            lkpOriginCity.EditValueChanged += (o, args) => RefreshServiceType();
            lkpDestinationCity.EditValueChanged += (o, args) =>
            {
                var cityDataManager = new CityDataManager();
                var countryDataManager = new CountryDataManager();

                var cityModel =
                    cityDataManager.GetFirst<CityModel>(WhereTerm.Default(lkpDestinationCity.Value ?? 0, "Id"));

                if (cityModel != null)
                {
                    var countryModel =
                        countryDataManager.GetFirst<CountryModel>(WhereTerm.Default(cityModel.CountryId, "Id"));

                    if (countryModel != null)
                    {
                        ((ShipmentModel)CurrentModel).PricingPlanId = countryModel.PricingPlanId;
                    }
                }

                cityDataManager.Dispose();
                countryDataManager.Dispose();

                RefreshServiceType();
                RefreshTariff();
            };

            lkpPackageType.EditValueChanged += (o, args) => RefreshTariff();
            lkpServiceType.EditValueChanged += (o, args) => RefreshTariff();

            lkpPaymentMethod.EditValueChanged += (o, args) =>
            {
                lkpCustomerCollect.Enabled = lkpPaymentMethod.Text.ToUpper().Equals("COLLECT");
            };

            //using (var branchDm = new BranchDataManager())
            //{
            //    var branch = branchDm.GetFirst<BranchModel>(WhereTerm.Default((int)lkpBranch.Value, "id"));
            //    MaximumBranchDiscount = branch.MaxDiscount > 0 ? branch.MaxDiscount : 0;
            //}

            txtDate.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            btnRefreshTariff.Click += (o, args) => RefreshTariff(true);
            btnPost.Click += btnSave_Click;
            btnViewPublishedTariff.Click += btnViewPublishedTariff_Click;

            lkpCustomer.TextChanged += lkpCustomer_TextChanged;
            txtDiscount.TextChanged += (o, args) =>
            {
                var upperLimit = Math.Max(CustomerDiscount, MaximumBranchDiscount);
                if (txtDiscount.Value > upperLimit)
                {
                    txtDiscount.Value = upperLimit;
                }

                RefreshTariff();
            };

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
                if (cbxPacking.Checked)
                {
                    txtPackingFee.Value = PackingCalculation(tbxL.Value, tbxW.Value, tbxH.Value);
                    txtPackingFee.Enabled = true;
                }
                else
                {
                    txtPackingFee.Value = 0;
                    txtPackingFee.Enabled = false;
                }
            };

            btnRefreshTariff.Enabled = true;
            btnPost.Enabled = true;
            btnViewPublishedTariff.Enabled = false;

            NavigationMenu.NewStrip.Enabled = false;
        }

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

            txtChargeableWeight.Value = ceiled;

            RefreshGrandTotal();
        }

        private void RefreshGrandTotal(bool forceChangeTariffPerKg = false)
        {
            if (string.IsNullOrEmpty(txtDiscountTotal.Text) || string.IsNullOrEmpty(txtDiscount.Text) ||
                string.IsNullOrEmpty(txtTariffNet.Text) || string.IsNullOrEmpty(txtTariffTotal.Text) ||
                string.IsNullOrEmpty(txtInsuranceFee.Text) || string.IsNullOrEmpty(txtPackingFee.Text) ||
                string.IsNullOrEmpty(txtOtherFee.Text) || string.IsNullOrEmpty(txtInsuranceFee.Text)) return;

            //if (forceChangeTariffPerKg && ((ShipmentModel)CurrentModel).PricingPlanId != PRICING_PLAN_DOMESTIC)
            //{
            //    ((ShipmentModel)CurrentModel).PricingPlanId = PRICING_PLAN_DOMESTIC;
            //    ((ShipmentModel)CurrentModel).CurrencyId = null;
            //    ((ShipmentModel)CurrentModel).CurrencyRate = 1;
            //}

            //if (((ShipmentModel)CurrentModel).PricingPlanId == PRICING_PLAN_DOMESTIC)
            //{
            //    txtTariffTotal.Value = (txtTariffPerKg.Value * txtChargeableWeight.Value) + txtHandlingFee.Value;
            //}

            txtDiscountTotal.Value = (txtDiscount.Value / 100) * txtTariffTotal.Value;
            txtTariffNet.Value = txtTariffTotal.Value - txtDiscountTotal.Value;

            //txtInsuranceFee.Value = txtGoodsValue.Value * ((float) _fixedShippingInsuranceRate);

            var grandTotal = txtTariffNet.Value + txtPackingFee.Value + txtOtherFee.Value + txtInsuranceFee.Value + txtGoodsValue.Value;

            if (((ShipmentModel)CurrentModel).CurrencyId != null)
            {
                grandTotal *= ((ShipmentModel)CurrentModel).CurrencyRate;
            }

            txtGrandTotal.Value = grandTotal;
        }

        private void RefreshTariff(bool force = false)
        {
            if (lkpOriginCity.Value == null || lkpDestinationCity.Value == null) return;

            var customerTariffModel = GetCustomerTariff();
            if (customerTariffModel != null)
            {
                if (txtChargeableWeight.Value < customerTariffModel.MinWeight) txtChargeableWeight.Value = customerTariffModel.MinWeight;

                if (((ShipmentModel)CurrentModel).PricingPlanId == PRICING_PLAN_DOMESTIC)
                {
                    txtTariffPerKg.Value = customerTariffModel.Tariff;

                    txtTariffPerKg.Enabled = true;
                }
                else
                {
                    //txtTariffPerKg.Value = 0;
                    //txtTariffTotal.Value = customerTariffModel.Tariff;
                    txtTariffTotal.Value = txtTariffPerKg.Value + txtHandlingFee.Value;

                    txtTariffPerKg.Enabled = true;
                }

                txtHandlingFee.Value = customerTariffModel.HandlingFee;
                chkRA.Checked = customerTariffModel.Ra ?? false;

                if (customerTariffModel.NextTariff > 0)
                {
                    decimal diff = 0;
                    if (customerTariffModel.ToWeight > 0)
                    {
                        diff = txtChargeableWeight.Value - (decimal)customerTariffModel.ToWeight;
                        if (customerTariffModel.FromWeight <= txtChargeableWeight.Value && customerTariffModel.ToWeight >= txtChargeableWeight.Value)
                        {
                            if (customerTariffModel.Tariff > 0)
                            {
                                txtTariffTotal.Value = (txtTariffPerKg.Value * txtChargeableWeight.Value) + txtHandlingFee.Value;
                            }

                            if (customerTariffModel.FixedTariff > 0)
                            {
                                txtTariffTotal.Value = (decimal)customerTariffModel.FixedTariff + txtHandlingFee.Value;
                            }
                        }
                        else if (txtChargeableWeight.Value > customerTariffModel.ToWeight)
                        {
                            if (customerTariffModel.Tariff > 0)
                            {
                                txtTariffTotal.Value = (txtTariffPerKg.Value * (txtChargeableWeight.Value - diff)) + txtHandlingFee.Value;
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
                }
                else
                {
                    if (((ShipmentModel)CurrentModel).PricingPlanId == PRICING_PLAN_DOMESTIC)
                    {
                        txtTariffTotal.Value = (txtTariffPerKg.Value * txtChargeableWeight.Value) + txtHandlingFee.Value;
                    }

                    txtDiscountTotal.Value = (txtDiscount.Value / 100) * txtTariffTotal.Value;
                }
            }
            else
            {
                txtTariffPerKg.Value = 0;
                txtHandlingFee.Value = 0;
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
                        txtDiscount.Value = CustomerDiscount;
                        txtDiscount.Enabled = false;
                    }
                    else txtDiscount.Enabled = true;
                }
            }


            if (lkpServiceType.Text.Equals("CITY COURIER"))
            {
                txtDiscount.Value = 0;
                txtDiscount.Enabled = false;
            }
            else
            {
                //txtDiscount.Enabled = true;

                var upperLimit = Math.Max(CustomerDiscount, MaximumBranchDiscount);
                if (txtDiscount.Value > upperLimit)
                {
                    txtDiscount.Value = upperLimit;
                }
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

        private void RefreshDeliveryTariff()
        {
            txtDeliveryTariff2.Value = txtDeliveryTariff1.Value * Math.Max(txtChargeableWeight.Value, DeliveryTariffMinimumWeight);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            ValidateShipment = CurrentModel as ShipmentModel;
            ValidateShipment = PopulateModel(ValidateShipment);
            ReValidateShipment = null;

            Close();
        }

        void btnViewPublishedTariff_Click(object sender, EventArgs e)
        {
            if (lkpOriginCity.Value == null)
            {
                MessageBox.Show(@"Please select origin city!");
                return;
            }

            if (lkpDestinationCity.Value == null)
            {
                MessageBox.Show(@"Please select destination city!");
                return;
            }

            if (lkpServiceType.Value == null)
            {
                MessageBox.Show(@"Please select a service type!");
                return;
            }

            var customerTariffModel = GetCustomerTariff(false);

            using (var dialog = new ViewPublishedTariffDialogForm
            {
                //MdiParent = MdiParent,
                StartPosition = FormStartPosition.CenterScreen,
                OriginCity = lkpOriginCity.Text,
                DestinationCity = lkpDestinationCity.Text,
                ServiceType = lkpServiceType.Text,
                TariffPerKg = customerTariffModel == null ? 0 : customerTariffModel.Tariff,
                HandlingFee = customerTariffModel == null ? 0 : customerTariffModel.HandlingFee
            })
            {
                dialog.ShowDialog();
            }
        }

        public int LastCustomerId { get; set; }

        void lkpCustomer_TextChanged(object sender, EventArgs e)
        {
            if (lkpCustomer.Value == LastCustomerId) return;

            LastCustomerId = lkpCustomer.Value ?? 0;

            using (var customerDataManager = new CustomerDataManager())
            {
                var customer = customerDataManager.GetFirst<CustomerModel>(WhereTerm.Default(lkpCustomer.Value ?? 0, "id"));
                if (customer != null)
                {
                    txtShipperName.Text = customer.Name;
                    txtShipperAddress.Text = customer.Address;
                    txtShipperPhone.Text = customer.Phone;

                    //((ShipmentModel)CurrentModel).ShipperSaved = true;
                    txtDiscount.Enabled = false;

                    CustomerDiscount = customer.Discount;
                    txtDiscount.Value = CustomerDiscount;
                    RefreshTariff();
                } else txtDiscount.Enabled = true;
            }
        }

        protected CustomerTariffModel GetCustomerTariff(bool includeCustomerTariff = true)
        {
            if (lkpOriginCity.Value == null || lkpDestinationCity.Value == null) return null;

            if (((ShipmentModel)CurrentModel).PricingPlanId != PRICING_PLAN_DOMESTIC)
            {
                using (var tariffInternationalDataManager = new TariffInternationalDataManager())
                {
                    var tariffIntModel = tariffInternationalDataManager.GetTariff(
                        ((ShipmentModel)CurrentModel).PricingPlanId ?? 0,
                        lkpPackageType.Value ?? 0,
                        txtChargeableWeight.Value
                        );

                    if (tariffIntModel != null)
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

                        return new CustomerTariffModel
                        {
                            Tariff = tariffIntModel.Tariff,
                            HandlingFee = tariffIntModel.HandlingFee ?? 0,
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

            if (includeCustomerTariff && lkpCustomer.Value != null)
            {
                using (var customerTariffDataManager = new CustomerTariffDataManager())
                {
                    var customerTariffModel = customerTariffDataManager.GetTariff(
                        (int)lkpOriginCity.Value,
                        (int)lkpDestinationCity.Value,
                        lkpServiceType.Value ?? 0,
                        lkpPackageType.Value ?? 0,
                        lkpCustomer.Value ?? 0,
                        txtChargeableWeight.Value
                        );
                    if (customerTariffModel != null)
                    {
                        txtTariffPerKg.Value = customerTariffModel.Tariff;
                        txtHandlingFee.Value = customerTariffModel.HandlingFee;

                        return new CustomerTariffModel
                        {
                            Tariff = customerTariffModel.Tariff,
                            HandlingFee = customerTariffModel.HandlingFee,
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
                    txtChargeableWeight.Value
                    );
                if (tariffModel != null)
                {
                    if (includeCustomerTariff)
                    {
                        txtTariffPerKg.Value = tariffModel.Tariff;
                        txtHandlingFee.Value = tariffModel.HandlingFee;
                    }

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
                Tariff = 0,
                HandlingFee = 0,
                Ra = false,
            };

        }

        protected void PopulateForm(ShipmentModel model)
        {
            LastCustomerId = model.CustomerId ?? 0;
            txtPackingFee.Enabled = false;
            tbxCod.Enabled = false;
            ClearForm();
            txtShipmentNo.Enabled = false;
            tbxBranch.Enabled = false;
            txtShipmentNo.Enabled = false;
            chkRA.Enabled = false;

            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(model.Id, "shipment_id"));

            txtDate.Text = model.DateProcess.ToString();

            chkRA.Checked = model.NeedRa;

            txtDate.Text = model.DateProcess.ToString();

            txtShipmentNo.Text = model.Code;

            lkpOriginCity.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CityId, "id") };
            lkpDestinationCity.DefaultValue = new IListParameter[] { WhereTerm.Default(model.DestCityId, "id") };

            lkpCustomerCollect.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CollectCustomerId ?? 0, "id") };

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

            txtNatureOfGoods.Text = model.NatureOfGoods;
            txtNote.Text = model.Note;

            txtTotalPiece.Value = model.TtlPiece;
            txtTotalWeight.Value = model.TtlGrossWeight;
            txtChargeableWeight.Value = model.TtlChargeableWeight;

            txtTariffPerKg.Value = model.Tariff;
            txtHandlingFee.Value = model.HandlingFeeTotal;
            txtTariffTotal.Value = model.TariffTotal;
            txtDiscount.Value = model.DiscountPercent;
            txtDiscountTotal.Value = model.DiscountTotal;
            txtTariffNet.Value = model.TariffNet;

            txtPackingFee.Enabled = model.PackingFee > 0;
            cbxPacking.Checked = expand != null ? expand.UsePacking : model.PackingFee > 0;
            txtPackingFee.Value = model.PackingFee;
            txtOtherFee.Value = model.OtherFee;
            txtGoodsValue.Value = model.GoodsValue;
            txtInsuranceFee.Value = model.InsuranceFee;

            txtGrandTotal.Value = model.Total;

            txtDiscountTotal.Value = model.DiscountTotal;

            txtDeliveryTariff1.Value = model.DeliveryFee;
            txtDeliveryTariff2.Value = model.DeliveryFeeTotal;

            txtPersonal.Text = model.PersonalName;

            cbxCod.Checked = expand != null ? expand.IsCod : false;
            tbxCod.SetValue(expand != null ? expand.TotalCod : 0);
            tbxCod.Enabled = cbxCod.Checked;
            tbxFulfilment.Text = expand != null ? expand.Fulfilment : string.Empty;

            tbxL.SetValue(expand != null ? expand.VolumeL : 0);
            tbxW.SetValue(expand != null ? expand.VolumeW : 0);
            tbxH.SetValue(expand != null ? expand.VolumeH : 0);

            btnViewPublishedTariff.Enabled = true;

            if (lkpPaymentMethod.Text.ToUpper().Equals("COLLECT"))
            {
                using (var custDm = new CustomerDataManager())
                {
                    var customer = custDm.GetFirst<CustomerModel>(WhereTerm.Default(model.CustomerId ?? 0, "id"));

                    lkpCustomer.Text = customer != null ? string.Format("{0} - {1}", customer.Code, customer.Name) : model.CustomerName;
                    lkpCustomer.Value = model.CustomerId;
                    lkpCustomer.Enabled = false;
                }
            }
            else
            {
                lkpCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CustomerId ?? 0, "id") };
                lkpCustomer.Enabled = true;
            }

            if (model.Invoiced == 1 || model.Voided)
            {
                if (model.Voided)
                {
                    MessageBox.Show(string.Format("POD sudah di-VOID"));
                }
                else if (model.Invoiced == 1)
                {
                    MessageBox.Show(string.Format("Sudah dibuat invoice.\nNo Invoice: {0}\nNo Kwitansi: {1}", model.InvoiceRef, model.PaymentReceiptNumber));
                }
            }
            else
            {
                if (model.Posted)
                {
                    AutoClosingMessageBox.Show(@"POD sudah divalidasi");
                }

                txtDiscount.Enabled = !lkpServiceType.Text.ToUpper().Equals("CITY COURIER");

                btnRefreshTariff.Enabled = model.SalesTypeId != 3;

                lkpCustomerCollect.Enabled = lkpPaymentMethod.Text.ToUpper().Equals("COLLECT");

                txtTariffPerKg.Enabled = true;
            }

            if (!model.Posted) RefreshTariff(true);
            txtDate.Focus();
        }

        protected ShipmentModel PopulateModel(ShipmentModel model)
        {
            model.Id = CurrentModel.Id;
            model.BranchId = ((ShipmentModel)CurrentModel).BranchId;

            model.Code = txtShipmentNo.Text;
            model.DateProcess = txtDate.DateTime;

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

            model.CollectCustomerId = lkpCustomerCollect.Value;
            model.CollectCustomerName = lkpCustomerCollect.Text;

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

            model.NatureOfGoods = txtNatureOfGoods.Text;
            model.Note = txtNote.Text;

            model.TtlPiece = (short)txtTotalPiece.Value;
            model.TtlGrossWeight = txtTotalWeight.Value;
            model.TtlChargeableWeight = txtChargeableWeight.Value;

            model.Tariff = txtTariffPerKg.Value;
            model.HandlingFeeTotal = txtHandlingFee.Value;
            model.HandlingFee = txtHandlingFee.Value;
            model.TariffTotal = txtTariffTotal.Value;
            model.DiscountPercent = txtDiscount.Value;
            model.DiscountTotal = txtDiscountTotal.Value;
            model.TariffNet = txtTariffNet.Value;

            model.PackingFee = txtPackingFee.Value;
            model.OtherFee = txtOtherFee.Value;
            model.GoodsValue = txtGoodsValue.Value;
            model.InsuranceFee = txtInsuranceFee.Value;

            model.Total = txtGrandTotal.Value;

            model.DiscountTotal = txtDiscountTotal.Value;

            model.Posted = true;

            model.PersonalName = txtPersonal.Text;
            model.Personal = !string.IsNullOrEmpty(txtPersonal.Text);

            model.DeliveryFee = txtDeliveryTariff1.Value;
            model.DeliveryFeeTotal = txtDeliveryTariff2.Value;

            using (var dm = new CurrencyDataManager())
            {
                var currency = dm.GetFirst<CurrencyModel>(WhereTerm.Default(model.CurrencyId ?? 0, "id"));
                if (currency != null)
                {
                    model.Currency = currency.Code;
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
            }

            return model;
        }
    }
}