using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraBars;
using Franchise.Presentation.Common;
using Franchise.Presentation.Common.Component;
using Franchise.Presentation.Common.Forms;
using Franchise.Presentation.Common.Properties;
using Franchise.Presentation.CounterCash.Popup;
using Franchise.Presentation.CounterCash.Print;
using Franchise.Presentation.MasterData.Popup;
using SISCO.App.Franchise;
using SISCO.App.MasterData;
using SISCO.Models;
using System.Linq;
using SISCO.LocalStorage;
using System.IO;
using System.Text.RegularExpressions;
using SISCO.App;

namespace Franchise.Presentation.CounterCash.Forms
{
    public partial class CounterCashForm : BaseCrudForm<ShipmentModel, ShipmentDataManager>//BaseToolbarForm//
    {
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
                WhereTerm.Default(5,"sales_type_id", EnumSqlOperator.Equals),
                WhereTerm.Default(BaseControl.FranchiseId, "franchise_id", EnumSqlOperator.Equals)
            };
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            _isPopulatingForm = false;

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

            lkpCustomer.LookupPopup =
                new CustomerPopup(new IListParameter[]
                {
                    WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                    WhereTerm.Default("0", "disabled", EnumSqlOperator.Equals),
                    WhereTerm.Default(BaseControl.FranchiseId, "franchise_id", EnumSqlOperator.Equals)
                });
            lkpCustomer.AutoCompleteDataManager = new CustomerServices();
            lkpCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpCustomer.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0))", s);
            
            lkpCustomer.Leave += AutoPopulateCustomerDetail;

            lkpDestination.LookupPopup = new CityPopup();
            lkpDestination.AutoCompleteDataManager = new CityServices();
            lkpDestination.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpDestination.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpDestination.FieldLabel = "Destination City";
            lkpDestination.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpPackage.LookupPopup = new PackageTypePopup();
            lkpPackage.AutoCompleteDataManager = new PackageTypeServices();
            lkpPackage.AutoCompleteDisplayFormater = model => ((PackageTypeModel)model).Name;
            lkpPackage.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpPackage.FieldLabel = "Package Type";
            lkpPackage.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpService.LookupPopup = new ServiceTypePopup("name.Equals(@0) OR name.Equals(@1) OR name.Equals(@2) OR name.Equals(@3) OR name.Equals(@4)", "ECO", "SDS", "ONS", "DARAT", "SUPER ECONOMI");
            lkpService.AutoCompleteDataManager = new ServiceTypeServices();
            lkpService.AutoCompleteDisplayFormater = model => ((ServiceTypeModel)model).Name;
            lkpService.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("name.StartsWith(@0) AND (name.Equals(@1) OR name.Equals(@2) OR name.Equals(@3) OR name.Equals(@4) OR name.Equals(@5))", s, "ECO", "SDS", "ONS", "DARAT", "SUPER ECONOMI");
            lkpService.FieldLabel = "Service Type";
            lkpService.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpPayment.LookupPopup = new PaymentMethodPopup("name.Equals(@0)", "CASH");
            lkpPayment.AutoCompleteDataManager = new PaymentMethodServices();
            lkpPayment.AutoCompleteDisplayFormater = model => ((PaymentMethodModel)model).Name;
            lkpPayment.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("name.StartsWith(@0) AND name.Equals(@1)", s, "CASH");
            lkpPayment.FieldLabel = "Payment Method";
            lkpPayment.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            tbxName.FieldLabel = "Shipper Name";
            tbxName.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            tbxAddress.FieldLabel = "Shipper Address";
            tbxAddress.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            tbxPhone.FieldLabel = "Shipper Phone";
            tbxPhone.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

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
            tbxGoodsValue.EditMask = "##,###,###,##0.00";
            tbxInsurance.EditMask = "##,###,###,##0.00";

            tbxName.CharacterCasing = CharacterCasing.Upper;
            tbxAddress.CharacterCasing = CharacterCasing.Upper;
            tbxPhone.CharacterCasing = CharacterCasing.Upper;
            tbxConsigneeName.CharacterCasing = CharacterCasing.Upper;
            tbxConsigneeAddress.CharacterCasing = CharacterCasing.Upper;
            tbxConsigneePhone.CharacterCasing = CharacterCasing.Upper;
            tbxRef.CharacterCasing = CharacterCasing.Upper;
            tbxNote.CharacterCasing = CharacterCasing.Upper;
            tbxNatureOfGood.CharacterCasing = CharacterCasing.Upper;

            tbxName.MaxLength = 100;
            tbxAddress.MaxLength = 254;
            tbxPhone.MaxLength = 50;
            tbxConsigneeName.MaxLength = 100;
            tbxConsigneeAddress.MaxLength = 254;
            tbxConsigneePhone.MaxLength = 50;
            tbxRef.MaxLength = 50;
            tbxNote.MaxLength = 100;
            tbxNatureOfGood.MaxLength = 50;

            btnSave.Enabled = false;

            tbxTtlGrossWeight.TextChanged += TxtTotalWeightOnTextChanged;
            tbxDiscount.TextChanged += (o, args) =>
            {
                if (_isPopulatingForm) return;
                RefreshTariff();
            };

            FormTrackingStatus = EnumTrackingStatus.FranchiseDataEntry;

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

            rbLayout_Print.ItemClick += (o, args) =>
            {
                var printout = new EConnotePrintout
                {
                    DataSource = GetPrintDataSource()
                };
                printout.Print();
                new ShipmentExpandDataManager().Printing(CurrentModel.Id);
            };
            rbLayout_PrintPreview.ItemClick += (o, args) =>
            {
                var printout = new EConnotePrintout
                {
                    DataSource = GetPrintDataSource()
                };
                printout.PrintPreview();
            };
            rbLayout_Pdf.ItemClick += (o, args) =>
            {
                var printout = new EConnotePrintout
                {
                    DataSource = GetPrintDataSource()
                };

                using (var dialog = new SaveFileDialog())
                {
                    dialog.FileName = string.Format("{0}.pdf", tbxSearch_Code.Text);
                    dialog.Filter = @"PDF files |*.pdf|All files (*.*)|*.*";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        printout.ExportToPdf(dialog.FileName);
                        if (File.Exists(dialog.FileName))
                        {
                            System.Diagnostics.Process.Start("explorer.exe", @"/select,""" + dialog.FileName + "\"");
                        }
                    }
                }
            };

            lkpDestination.EditValueChanged += lkpDestination_EditValueChanged;
            lkpDestination.Leave += lkpDestination_Leave;
            lkpPackage.Leave += lkpPackageType_EditValueChanged;
            lkpService.Leave += lkpServiceType_EditValueChanged;
            tbxOther.EditValueChanged += txtOtherFee_EditValueChanged;
            tbxGoodsValue.EditValueChanged += txtGoodsValue_EditValueChanged;
            tbxTtlPiece.EditValueChanged += txtTotalPiece_EditValueChanged;
            tbxTtlGrossWeight.EditValueChanged += txtTotalWeight_EditValueChanged;
            tbxTtlChargeable.EditValueChanged += txtChargeable_EditValueChanged;
            tbxDiscount.EditValueChanged += tbxDiscount_EditValueChanged;
            btnSave.Click += btnSave_Click;

            //using (var branchDm = new BranchDataManager())
            //{
            //    var branch = branchDm.GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id"));
            //    MaximumBranchDiscount = branch.MaxDiscount > 0 ? branch.MaxDiscount : 0;
            //}

            rbPod.Visible = true;
            rbPod_Void.Enabled = false;
            rbPod_Void.ItemClick += Void;
            rbLayout_Pdf.Enabled = false;

            _lookup = new LookupDataManager().Get("FixCashInsurance");
            _minInsurance = new LookupDataManager().Get("MinInsurance").Value;
            _adminInsurance = new LookupDataManager().Get("AdminInsurance").Value;
        }

        private void Void(object sender, ItemClickEventArgs e)
        {
            var model = CurrentModel as ShipmentModel;
            if (model == null) return;
            if (!model.Voided && model.TrackingStatusId == (int) EnumTrackingStatus.FranchiseDataEntry)
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

        private void AutoPopulateCustomerDetail(object sender, EventArgs e)
        {
            if (lkpCustomer.Value != null)
            {
                var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)lkpCustomer.Value, "id", EnumSqlOperator.Equals));
                CustomerDiscount = 0;
                if (customer != null)
                {
                    tbxName.Text = customer.Name;
                    tbxAddress.Text = customer.Address;
                    tbxPhone.Text = customer.Phone;

                    CustomerDiscount = customer.Discount;
                    tbxDiscount.Value = CustomerDiscount;
                }
            }
        }

        //public decimal MaximumBranchDiscount { get; set; }
        public decimal CustomerDiscount { get; set; }

        public int LastCustomerId { get; set; }

        private void TxtTotalWeightOnTextChanged(object sender, EventArgs eventArgs)
        {
            if (_isPopulatingForm) return;
            decimal ceiled = 0;

            if (MinWeight > 0 && tbxTtlGrossWeight.Value < MinWeight) tbxTtlGrossWeight.Value = MinWeight;

            if (CurrentModel == null) return;

            if (tbxTtlGrossWeight.Value > 0)
            {
                var number = Math.Floor(tbxTtlGrossWeight.Value);
                var decPoint = tbxTtlGrossWeight.Value - Convert.ToDecimal(number);

                if (decPoint < (decimal)0.4) ceiled = Convert.ToDecimal(number);
                else ceiled = Convert.ToDecimal(number) + 1;
            }

            //ceiled = Math.Ceiling(tbxTtlGrossWeight.Value * 2) / 2;

            if (ceiled > 999999) MessageBox.Show(@"Chargeable maximal 999,999 kg");

            tbxTtlChargeable.Value = ceiled;

            RefreshGrandTotal();
        }

        protected override void PopulateForm(ShipmentModel model)
        {
            ClearForm();
            _isPopulatingForm = true;
            LastCustomerId = model.CustomerId ?? 0;

            cbxRa.Checked = model.NeedRa;

            tbxDate.DateTime = model.DateProcess;
            tbxSearch_Code.Text = model.Code;

            if (model.CustomerId > 0)
            {
                var customer =
                    new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int) model.CustomerId, "id"));
                lkpCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default(customer.Id, "id") };
            }

            lkpDestination.DefaultValue = new IListParameter[] {WhereTerm.Default(model.DestCityId, "id")};

            tbxName.Text = model.ShipperName;
            tbxAddress.Text = model.ShipperAddress;
            tbxPhone.Text = model.ShipperPhone;
            tbxRef.Text = model.RefNumber;

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
            tbxHandlingFee.Value = model.HandlingFeeTotal;
            tbxTtlTariff.Value = model.TariffTotal;
            tbxDiscount.Value = model.DiscountPercent;
            tbxTtlDiscount.Value = model.DiscountTotal;
            tbxTariffNet.Value = model.TariffNet;

            tbxOther.Value = model.OtherFee;
            tbxGoodsValue.Value = model.GoodsValue;
            tbxInsurance.Value = model.InsuranceFee;

            MinWeight = 0;

            if (((ShipmentModel)CurrentModel).PricingPlanId == PRICING_PLAN_DOMESTIC)
            {
                CustomerTariffModel customerTariffModel = null;
                if (lkpCustomer.Value != null)
                {
                    customerTariffModel = new CustomerTariffDataManager().GetTariff(
                        BaseControl.CityId,
                        (int)lkpDestination.Value,
                        lkpService.Value ?? 0,
                        lkpPackage.Value ?? 0,
                        (int)lkpCustomer.Value,
                        tbxTtlChargeable.Value
                        );
                }

                if (customerTariffModel == null)
                {
                    var tariffModel = new TariffDataManager().GetTariff(
                        BaseControl.CityId,
                        (int)lkpDestination.Value,
                        lkpService.Value ?? 0,
                        lkpPackage.Value ?? 0,
                        tbxTtlChargeable.Value
                    );

                    if (tariffModel != null)
                    {
                        MinWeight = tariffModel.MinWeight;
                        if (MinWeight > 0 && tbxTtlGrossWeight.Value < MinWeight) tbxTtlGrossWeight.Value = MinWeight;
                    }
                }
                else
                {
                    MinWeight = customerTariffModel.MinWeight;
                    if (MinWeight > 0 && tbxTtlGrossWeight.Value < MinWeight) tbxTtlGrossWeight.Value = MinWeight;
                }
            }

            tbxDiscount.Enabled = !lkpService.Text.ToUpper().Equals("CITY COURIER");

            tbxGlobalTotal.Value = model.Total;

            tbxTtlDiscount.Value = model.DiscountTotal;

            btnSave.Enabled = false;
            rbData_Save.Enabled = false;
            EnabledForm(false);

            rbPod_Void.Enabled = true;

            if (model.Voided)
            {
                MessageBox.Show(@"POD sudah di-VOID!");

                btnSave.Enabled = false;
                rbPod_Void.Enabled = false;
                EnabledForm(false);

                tbxDiscount.Enabled = false;
            }

            if (model.TrackingStatusId != (int)EnumTrackingStatus.FranchiseDataEntry) rbPod_Void.Enabled = false;
            if ((DateTime.Now - model.DateProcess).TotalDays > 1) rbPod_Void.Enabled = false;

            promoId = null;
            if (model.PromoId != null)
            {
                promoId = model.PromoId;
                tbxPromo.Text = model.PromoCode;
            }

            tbxEmailPoint.Enabled = false;
            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(model.Id, "shipment_id"));
            if (expand != null)
            {
                if (!string.IsNullOrEmpty(expand.EmailPoint))
                {
                    cbxMobilePoint.Checked = true;
                    tbxEmailPoint.Enabled = true;
                    tbxEmailPoint.Text = expand.EmailPoint;
                }
            }

            _isPopulatingForm = false;
            rbLayout_Pdf.Enabled = true;
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
            model.DestCity = lkpDestination.Text;
            model.DestCityId = (int) lkpDestination.Value;

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

            model.ShipperName = tbxName.Text;
            model.ShipperAddress = tbxAddress.Text;
            model.ShipperPhone = tbxPhone.Text;
            model.RefNumber = tbxRef.Text;

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

            model.SalesTypeId = 5;

            if (CurrentModel.Id == 0)
            {
                model.CreatedPc = Environment.MachineName;
            }

            model.FranchiseId = BaseControl.FranchiseId;
            if (model.Id == 0)
            {
                model.Code = new ShipmentDataManager().GenerateFranchisePODCode(model);
                model.TrackingStatusId = (int) EnumTrackingStatus.FranchiseDataEntry;
            }
            model.PODStatus = (int)EnumPodStatus.None;

            if (promoId != null) model.PromoId = promoId;
            model.PromoCode = tbxPromo.Text;

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
            if (lkpDestination.Value == null)
            {
                MessageBox.Show(@"Please enter the destination city!");
                lkpDestination.SelectAll();
                lkpDestination.Focus();
                return false;
            }
            if (tbxName.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter the shipper name!");
                tbxName.SelectAll();
                tbxName.Focus();
                return false;
            }
            if (tbxAddress.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter the shipper address!");
                tbxAddress.SelectAll();
                tbxAddress.Focus();
                return false;
            }
            if (tbxPhone.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter the shipper phone number!");
                tbxPhone.SelectAll();
                tbxPhone.Focus();
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
            lkpPayment.DefaultValue = new IListParameter[] { WhereTerm.Default("CASH", "name") };

            btnSave.Enabled = true;
            lkpDestination.Focus();

            rbData_Delete.Enabled = false;
            rbData_Save.Enabled = true;
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
            tbxEmailPoint.Enabled = false;

            lkpPayment.DefaultValue = new IListParameter[] { WhereTerm.Default("CASH", "name") };
            rbPod_Void.Enabled = false;

            MinWeight = 0;
            tbxPromo.Enabled = false;
            promoId = null;
            rbLayout_Pdf.Enabled = false;
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
                var upperLimit = Math.Max(CustomerDiscount, 15);
                if (lkpService.Text.Equals("DARAT") || promoId > 0)
                {
                    upperLimit = 5;
                }
                else if (lkpService.Text.Equals("SUPER ECONOMI"))
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
                if (lkpDestination.Value != null && lkpCustomer.Value != null)
                {
                    var customerTariffModel = customerTariffDataManager.GetTariff(
                        BaseControl.CityId,
                        (int)lkpDestination.Value,
                        lkpService.Value ?? 0,
                        lkpPackage.Value ?? 0,
                        (int) lkpCustomer.Value,
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

            CheckPromo();
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
            if (_isPopulatingForm) return;
            if (CurrentModel == null) return;
            var cityDataManager = new CityServices();
            var countryDataManager = new CountryServices();

            var cityModel = cityDataManager.GetFirst<CityModel>(WhereTerm.Default(lkpDestination.Value ?? 0, "Id"));

            if (cityModel != null)
            {
                var countryModel = countryDataManager.GetFirst<CountryModel>(WhereTerm.Default(cityModel.CountryId, "Id"));

                if (countryModel != null)
                {
                    ((ShipmentModel)CurrentModel).PricingPlanId = countryModel.PricingPlanId;
                }
            }

            RefreshTariff();
        }

        private void lkpPackageType_EditValueChanged(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;
            RefreshTariff();
            NoServiceMessage();
        }

        private void lkpServiceType_EditValueChanged(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;
            RefreshTariff();
            NoServiceMessage();
        }

        private void txtOtherFee_EditValueChanged(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;
            RefreshGrandTotal();
        }

        private void txtGoodsValue_EditValueChanged(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;

            var goodsvalue = tbxGoodsValue.Value;
            if (goodsvalue == 0) tbxInsurance.Value = 0;
            //else tbxInsurance.Value = Math.Round((goodsvalue*BaseControl.GoodValuesInsurance) + BaseControl.GoodValuesAdministration, 0, MidpointRounding.AwayFromZero);
            else
            {
                var insurance = Math.Round(goodsvalue * (Convert.ToDecimal(_lookup.Value) / 100));

                if (Convert.ToDecimal(_minInsurance) > insurance) tbxInsurance.Value = Convert.ToDecimal(_minInsurance);
                else tbxInsurance.Value = insurance;

                tbxInsurance.Value = tbxInsurance.Value + Convert.ToDecimal(_adminInsurance);
            }

            RefreshGrandTotal();
        }

        private void txtTotalPiece_EditValueChanged(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;
            RefreshGrandTotal();
        }

        private void txtTotalWeight_EditValueChanged(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;
            RefreshGrandTotal();
        }

        private void txtChargeable_EditValueChanged(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;
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
            CheckPromo();
        }

        private bool SetPromo(PromoModel promo)
        {
            promoId = null;
            tbxPromo.Text = string.Empty;

            if (promo.CityOrigId != null) if (promo.CityOrigId != BaseControl.CityId) return false;
            if (promo.CityDestId != null) if (promo.CityDestId != lkpDestination.Value) return false;
            if (promo.PackageTypeId != null) if (promo.PackageTypeId != lkpPackage.Value) return false;
            if (promo.ServiceTypeId != null) if (promo.ServiceTypeId != lkpService.Value) return false;

            if (promo.MinWeight != null && tbxTtlGrossWeight.Value < promo.MinWeight)
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
                    WhereTerm.Default(true, "active")
                }).ToList();

            if (promoes.Count() > 0)
            {
                // check promo based on origin city
                var origbase = promoes.Where(p => p.CityOrigId == BaseControl.CityId).ToList();
                if (origbase.Count() > 0)
                {
                    if (origbase.Count() == 1)
                    {
                        if (SetPromo(origbase.FirstOrDefault())) return;
                        else origbase = promoes.Where(p => p.CityOrigId != BaseControl.CityId).ToList();
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
                var packbase = destbase.Where(p => p.PackageTypeId == lkpPackage.Value).ToList();
                if (packbase.Count() > 0)
                {
                    if (packbase.Count() == 1)
                    {
                        if (SetPromo(packbase.FirstOrDefault())) return;
                        else packbase = destbase.Where(p => p.PackageTypeId != lkpPackage.Value).ToList();
                    }

                    promoes = packbase;
                }
                else
                {
                    promoes = promoes.Where(p => p.PackageTypeId == null).ToList();
                    packbase = promoes;
                }

                //based on service type
                var servbase = packbase.Where(p => p.ServiceTypeId == lkpService.Value).ToList();

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

        private void tbxDiscount_EditValueChanged(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;
            if (tbxDiscount.Value > 20) tbxDiscount.Value = 20;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        public override void Save()
        {
            if (tbxGlobalTotal.Value > 0) base.Save();
            else NoServiceMessage();
        }

        private void lkpDestination_Leave(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;
            RefreshTariff();
            NoServiceMessage();
        }

        private void NoServiceMessage()
        {
            if (tbxTariff.Value == 0 && lkpDestination.Value > 0) MessageBox.Show("Tidak ada layanan pengiriman untuk tujuan atau service tersebut.");
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

            var expandModel = new ShipmentExpandModel
            {
                ShipmentId = CurrentModel.Id,
                VolumeL = 1,
                VolumeW = 1,
                VolumeH = 1,
                UsePacking = false,
                IsCod = false,
                TotalCod = 0,
                Printed = 0,
                EmailPoint = tbxEmailPoint.Text
            };
            SaveExpand(expandModel);

            new FranchiseCommissionDataManager().CalculateCommission(model, BaseControl.FranchiseId, BaseControl.UserLogin);
            tbxSearch_Code.Text = model.Code;
            DataManager = new ShipmentDataManager();
            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                WhereTerm.Default(5,"sales_type_id", EnumSqlOperator.Equals),
                WhereTerm.Default(BaseControl.FranchiseId, "franchise_id", EnumSqlOperator.Equals)
            };
            PerformFind();
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            btnSave.Enabled = true;
            if (TotalPage > 0)
            {
                rbLayout_Print.Enabled = true;
                rbLayout_PrintPreview.Enabled = false;
            }

            var model = CurrentModel as ShipmentModel;

            if (model != null)
            {
                if (model.Id > 0)
                {
                    rbData_Delete.Enabled = false;

                    rbData_Save.Enabled = false;
                    btnSave.Enabled = false;

                    EnabledForm(false);
                }
            }

            if (model != null && (model.Voided || model.Posted || model.Invoiced == 1) && model.PODStatus > 0)
            {
                rbData_New.Enabled = true;
                rbData_Delete.Enabled = false;

                rbData_Save.Enabled = false;
                btnSave.Enabled = false;
                rbLayout_Print.Enabled = false;
                rbLayout_PrintPreview.Enabled = false;

                EnabledForm(false);
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
    }
}