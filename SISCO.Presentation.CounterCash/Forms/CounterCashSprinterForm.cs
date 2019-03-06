using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.App;
using SISCO.App.Administration;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.LocalStorage;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Operation.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.CounterCash.Forms
{
    public partial class CounterCashSprinterForm : BaseCrudForm<ShipmentModel, ShipmentDataManager>//BaseToolbarForm//
    {
        const string CURRENCY_IDR = "IDR";
        const string SERVICE_TYPE_CITY_COURIER = "CITY COURIER";
        const int PRICING_PLAN_DOMESTIC = 1;
        // ReSharper restore InconsistentNaming

        public decimal DeliveryTariffMinimumWeight { get; set; }
        public bool IsInternationalShipment { get; set; }
        private decimal MinWeight { get; set; }
        private int _sprinterId { get; set; }

        private LookupModel _lookup { get; set; }
        private string _minInsurance { get; set; }
        private string _adminInsurance { get; set; }
        private bool _print = true;

        public CounterCashSprinterForm()
        {
            InitializeComponent();
            form = this;

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                WhereTerm.Default(1,"sales_type_id", EnumSqlOperator.Equals)
            };

            txtTotalWeight.TextChanged += TxtTotalWeightOnTextChanged;
            tbxBookingNo.Leave += CheckBookingNo;

            lkpPackageType.TextChanged += VolumeChanged;
            lkpDestinationCity.TextChanged += (o, args) => RefreshTariff();
            lkpServiceType.TextChanged += (o, args) => RefreshTariff();
            txtChargeable.TextChanged += (o, args) => RefreshTariff();
            tbxL.EditValueChanged += (s, o) => VolumeCalculation(tbxL.Value, tbxW.Value, tbxH.Value, lkpServiceType.Text, txtTotalWeight.Value, txtChargeable);
            tbxW.EditValueChanged += (s, o) => VolumeCalculation(tbxL.Value, tbxW.Value, tbxH.Value, lkpServiceType.Text, txtTotalWeight.Value, txtChargeable);
            tbxH.EditValueChanged += (s, o) => VolumeCalculation(tbxL.Value, tbxW.Value, tbxH.Value, lkpServiceType.Text, txtTotalWeight.Value, txtChargeable);
            txtGoodsValue.TextChanged += GoodsValueChanged;

            cbxPacking.Click += (s, o) =>
            {
                if (cbxPacking.Checked) txtPackingFee.Value = PackingCalculation(tbxL.Value, tbxW.Value, tbxH.Value);
                else txtPackingFee.Value = 0;

                RefreshGrandTotal();
            };

            _lookup = new LookupDataManager().Get("FixCashInsurance");
            _minInsurance = new LookupDataManager().Get("MinInsurance").Value;
            _adminInsurance = new LookupDataManager().Get("AdminInsurance").Value;
        }

        private void GoodsValueChanged(object sender, EventArgs e)
        {
            if (_isPopulatingForm) return;

            var goodsvalue = txtGoodsValue.Value;
            if (goodsvalue == 0) txtInsuranceFee.Value = 0;
            else
            {
                var insurance = Math.Round(goodsvalue * (Convert.ToDecimal(_lookup.Value) / 100));

                if (Convert.ToDecimal(_minInsurance) > insurance) txtInsuranceFee.Value = Convert.ToDecimal(_minInsurance);
                else txtInsuranceFee.Value = insurance;

                txtInsuranceFee.Value = txtInsuranceFee.Value + Convert.ToDecimal(_adminInsurance);
            }

            RefreshGrandTotal();
        }

        private void VolumeChanged(object sender, EventArgs e)
        {
            if (lkpPackageType.Value != null)
            {
                switch ((int)lkpPackageType.Value)
                {
                    case 1 :
                        tbxH.Value = 1;
                        tbxW.Value = 1;
                        tbxL.Value = 1;

                        tbxL.ReadOnly = true;
                        tbxW.ReadOnly = true;
                        tbxH.ReadOnly = true;
                        break;
                    case 2:
                        tbxH.Value = 0;
                        tbxW.Value = 0;
                        tbxL.Value = 0;

                        tbxL.ReadOnly = false;
                        tbxW.ReadOnly = false;
                        tbxH.ReadOnly = false;
                        break;
                }
            }
            else
            {
                tbxH.Value = 0;
                tbxL.Value = 0;
                tbxH.Value = 0;

                tbxL.ReadOnly = true;
                tbxW.ReadOnly = true;
                tbxH.ReadOnly = true;
            }
        }

        private void CheckBookingNo(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxBookingNo.Text) && !_isPopulatingForm)
            {
                var booking = new BookingPodDataManager().GetFirst<BookingPodModel>(new IListParameter[] {
                    WhereTerm.Default(tbxBookingNo.Text, "booking_start", EnumSqlOperator.LesThanEqual),
                    WhereTerm.Default(tbxBookingNo.Text, "booking_end", EnumSqlOperator.GreatThanEqual),
                    WhereTerm.Default(BaseControl.BranchId, "branch_id"),
                });
                if (booking != null)
                {
                    var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(tbxBookingNo.Text, "fulfilment", EnumSqlOperator.Equals));
                    if (expand != null)
                    {
                        tbxBookingNo.Clear();
                        lblSprinter.Text = "-";
                        MessageBox.Show("Nomor booking sudah digunakan.");
                        tbxBookingNo.Focus();
                    }

                    var sprinter = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)booking.SprintId, "id"));
                    if (sprinter != null)
                    {
                        lblSprinter.Text = sprinter.Name;
                        lblOrigin.Text = BaseControl.BranchCode;

                        tbxPickupDate.Focus();
                        _sprinterId = sprinter.Id;
                    }
                }
                else
                {
                    tbxBookingNo.Clear();
                    lblSprinter.Text = "-";
                    MessageBox.Show("Nomor booking tidak dikenali");
                    tbxBookingNo.Focus();
                }
            }
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            EnableBtnPrint = true;

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

            tbxBookingNo.FieldLabel = "Booking Number";
            tbxBookingNo.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

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

            txtPackingFee.EditMask = "##,###,##0.00";
            txtGoodsValue.EditMask = "##,###,###,##0.00";
            txtInsuranceFee.EditMask = "##,###,###,##0.00";

            txtShipperName.CharacterCasing = CharacterCasing.Upper;
            txtShipperAddress.CharacterCasing = CharacterCasing.Upper;
            txtShipperPhone.CharacterCasing = CharacterCasing.Upper;
            txtConsigneeName.CharacterCasing = CharacterCasing.Upper;
            txtConsigneeAddress.CharacterCasing = CharacterCasing.Upper;
            txtConsigneePhone.CharacterCasing = CharacterCasing.Upper;
            txtShipperMail.CharacterCasing = CharacterCasing.Upper;
            txtNote.CharacterCasing = CharacterCasing.Upper;
            txtNatureOfGoods.CharacterCasing = CharacterCasing.Upper;

            txtShipperName.MaxLength = 100;
            txtShipperAddress.MaxLength = 254;
            txtShipperPhone.MaxLength = 50;
            txtConsigneeName.MaxLength = 100;
            txtConsigneeAddress.MaxLength = 254;
            txtConsigneePhone.MaxLength = 50;
            txtShipperMail.MaxLength = 50;
            txtNote.MaxLength = 100;
            txtNatureOfGoods.MaxLength = 50;

            FormTrackingStatus = EnumTrackingStatus.Acceptance;
            tsBaseBtn_Print.Click += (o, args) => PrintPOD();
        }

        private void TxtTotalWeightOnTextChanged(object sender, EventArgs eventArgs)
        {
            decimal ceiled;

            if (MinWeight > 0 && txtTotalWeight.Value < MinWeight) txtTotalWeight.Value = MinWeight;

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
        }

        protected override void BeforeNew()
        {
            ClearForm();

            txtTotalPiece.Value = 1;
            txtTotalWeight.Value = 1;
            txtChargeable.Value = 1;

            txtTariffPerKg.Value = 0;
            txtHandlingFee.Value = 0;
            txtTariffTotal.Value = 0;

            txtPackingFee.Value = 0;
            txtGoodsValue.Value = 0;
            txtInsuranceFee.Value = 0;

            tbxL.Value = 1;
            tbxW.Value = 1;
            tbxH.Value = 1;

            txtGrandTotal.Value = 0;

            tbxPickupDate.Text = string.Empty;

            lkpPackageType.DefaultValue = new IListParameter[] { WhereTerm.Default("PARCEL", "name") };
            lkpServiceType.DefaultValue = new IListParameter[] { WhereTerm.Default("ECO", "name") };

            lkpDestinationCity.Focus();
            txtPackingFee.Enabled = false;
            _sprinterId = 0;

            tbxPickupDate.Enabled = true;
            tbxPickupDate.Properties.Buttons[0].Enabled = true;

            lblOrigin.Text = "-";
            lblSprinter.Text = "-";

            tbxBookingNo.Focus();
            tbxBookingNo.ReadOnly = false;

            txtTariffTotal.ReadOnly = true;
            txtGrandTotal.ReadOnly = true;
            txtTariffPerKg.ReadOnly = true;
            txtHandlingFee.ReadOnly = true;

            cbxPrint.Checked = _print;
            EnableBtnPrint = false;
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            if (string.IsNullOrEmpty(tbxPickupDate.Text))
            {
                MessageBox.Show("Please enter the pickup date");
                tbxPickupDate.Focus();
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

            return true;
        }

        protected override void PopulateForm(ShipmentModel model)
        {
            _isPopulatingForm = true;
            ClearForm();

            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(model.Id, "shipment_id"));
            var status = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[] {
                WhereTerm.Default(model.Id, "shipment_id"),
                WhereTerm.Default((int)EnumTrackingStatus.Pickup, "tracking_status_id")
            });

            tbxPickupDate.DateTime = status.DateProcess;
            tbxPickupDate.Enabled = false;
            tbxPickupDate.Properties.Buttons[0].Enabled = false;
            tsBaseTxt_Code.Text = model.Code;

            lblOrigin.Text = model.CityName;
            lkpDestinationCity.DefaultValue = new IListParameter[] { WhereTerm.Default(model.DestCityId, "id") };

            txtShipperName.Text = model.ShipperName;
            txtShipperAddress.Text = model.ShipperAddress;
            txtShipperPhone.Text = model.ShipperPhone;

            txtConsigneeName.Text = model.ConsigneeName;
            txtConsigneeAddress.Text = model.ConsigneeAddress;
            txtConsigneePhone.Text = model.ConsigneePhone;

            lkpPackageType.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PackageTypeId, "id") };
            lkpServiceType.DefaultValue = new IListParameter[] { WhereTerm.Default(model.ServiceTypeId, "id") };

            txtNatureOfGoods.Text = model.NatureOfGoods;
            txtNote.Text = model.Note;

            txtTotalPiece.Value = model.TtlPiece;
            txtTotalWeight.Value = model.TtlGrossWeight;
            txtChargeable.Value = model.TtlChargeableWeight;

            txtTariffPerKg.Value = model.Tariff;
            txtHandlingFee.Value = model.HandlingFee;
            txtTariffTotal.Value = model.TariffTotal;

            txtPackingFee.Value = model.PackingFee;
            txtPackingFee.Enabled = false;
            txtGoodsValue.Value = model.GoodsValue;
            txtInsuranceFee.Value = model.InsuranceFee;

            MinWeight = 0;

            if (((ShipmentModel)CurrentModel).PricingPlanId == PRICING_PLAN_DOMESTIC)
            {
                var tariffModel = new TariffDataManager().GetTariff(
                    BaseControl.BranchId,
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

            txtGrandTotal.Value = model.Total;

            if (model.Posted)
            {
                MessageBox.Show(@"POD sudah divalidasi di billing dan tidak bisa dikoreksi");

                EnabledForm(false);
            }
            else if (model.Voided)
            {
                MessageBox.Show(@"POD sudah di-VOID!");
                EnabledForm(false);
            }
            else
            {
                chkRA.Enabled = false;

                txtTariffPerKg.Enabled = false;
                txtHandlingFee.Enabled = false;
                txtTariffTotal.Enabled = false;
                txtGrandTotal.Enabled = false;
                txtInsuranceFee.Enabled = true;
            }

            if (expand != null)
            {
                tbxL.SetValue(expand.VolumeL);
                tbxW.SetValue(expand.VolumeW);
                tbxH.SetValue(expand.VolumeH);
                cbxPacking.Checked = expand.UsePacking;
                txtShipperMail.Text = expand.ShipperEmail;
                _sprinterId = expand.SprinterId == null ? 0 : (int)expand.SprinterId;
                tbxBookingNo.Text = expand.Fulfilment;
            }

            ActiveControl = tsBaseTxt_Code.Control;
            txtInsuranceFee.Enabled = false;
            lblSprinter.Text = model.MessengerName;
            lblOrigin.Text = model.CityName;

            tbxBookingNo.ReadOnly = true;

            EnableBtnPrint = true;
            _isPopulatingForm = false;

            txtTariffTotal.ReadOnly = true;
            txtGrandTotal.ReadOnly = true;
            txtTariffPerKg.ReadOnly = true;
            txtHandlingFee.ReadOnly = true;
            cbxPrint.Checked = _print;
        }

        protected override ShipmentModel PopulateModel(ShipmentModel model)
        {
            if (model.Id == 0) model.DateProcess = DateTime.Now;
            model.BranchId = BaseControl.BranchId;

            model.Code = string.Empty;
            model.AutoNumber = true;

            model.NeedRa = chkRA.Checked;
            model.CityId = BaseControl.CityId;
            model.CityName = BaseControl.CityName;

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

            model.ShipperName = txtShipperName.Text;
            model.ShipperAddress = txtShipperAddress.Text;
            model.ShipperPhone = txtShipperPhone.Text;

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

            model.PaymentMethodId = 1;
            model.PaymentMethod = "CASH";

            model.MessengerName = lblSprinter.Text;
            model.MessengerId = _sprinterId;

            model.NatureOfGoods = txtNatureOfGoods.Text;
            model.Note = txtNote.Text;

            model.TtlPiece = Convert.ToInt16(txtTotalPiece.Value);
            model.TtlGrossWeight = txtTotalWeight.Value;
            model.TtlChargeableWeight = txtChargeable.Value;

            model.Tariff = txtTariffPerKg.Value;
            model.HandlingFeeTotal = txtHandlingFee.Value;
            model.TariffTotal = txtTariffTotal.Value;
            model.DiscountPercent = 0;
            model.DiscountTotal = 0;
            model.TariffNet = txtTariffTotal.Value;

            model.PackingFee = txtPackingFee.Value;
            model.OtherFee = 0;
            model.GoodsValue = txtGoodsValue.Value;
            model.InsuranceFee = txtInsuranceFee.Value;

            model.TrackingStatusId = (int)EnumTrackingStatus.Acceptance;

            model.Total = txtGrandTotal.Value;

            model.DiscountTotal = 0;

            model.SalesTypeId = 1;

            if (CurrentModel.Id == 0)
            {
                model.CreatedPc = Environment.MachineName;
            }

            return model;
        }

        public override void Save()
        {
            base.Save();
        }

        protected override void AfterSave()
        {
            //base.AfterSave();
            tsBaseTxt_Code.Focus();

            PodStatusModel.ShipmentId = CurrentModel.Id;
            PodStatusModel.PositionStatusId = BaseControl.BranchId;
            PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();

            ShipmentStatusUpdate(tbxPickupDate.DateTime);

            ActiveControl = tsBaseTxt_Code.Control;

            tsBaseTxt_Code.Text = ((ShipmentModel)CurrentModel).Code;

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
                ShipperEmail = txtShipperMail.Text,
                Fulfilment = tbxBookingNo.Text,
                SprinterId = _sprinterId
            };
            SaveExpand(expandModel);

            if (cbxPrint.Checked) PrintPOD();
            _print = cbxPrint.Checked;

            tsBaseBtn_New.PerformClick();
        }

        protected override ShipmentModel Find(string searchTerm)
        {
            return DataManager.GetFirst<ShipmentModel>(
                WhereTerm.Default(searchTerm, "code"),
                WhereTerm.Default(1, "sales_type_id"));
        }
        
        protected override T LoadModel<T>(params IListParameter[] listParameters)
        {
            if (DataManager == null)
                throw new Exception("Data Manager Is Not Instansiated");
            int count;
            PageLimit = 1;

            if (CurrentIndexPage > TotalPage + 1)
            {
                CurrentIndexPage = TotalPage + 1;
            }
            if (CurrentIndexPage < 1)
            {
                CurrentIndexPage = 1;
            }

            var model =
                ((ShipmentDataManager)DataManager).GetBooking<T>(Paging.Instance(CurrentIndexPage - 1, PageLimit), out count, listParameters)
                    .FirstOrDefault();
            TotalRecord = count;

            Dirty = false;
            return model;
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

        private void PrintPOD()
        {
            var dataSource = GetPrintDataSource();
            var printout = new EConnotePrintout
            {
                DataSource = dataSource
            };

            printout.Print();
            new ShipmentExpandDataManager().Printing(CurrentModel.Id);
        }

        private void RefreshTariff()
        {
            if (_isPopulatingForm) return;
            if (lkpDestinationCity.Value == null) return;
            if (((ShipmentModel)CurrentModel).Posted || ((ShipmentModel)CurrentModel).Voided) return;

            txtTariffPerKg.Value = 0;
            txtHandlingFee.Value = 0;
            chkRA.Checked = false;

            using (var dm = new DeliveryTariffDataManager())
            {
                DeliveryTariffModel dlvTariff = null;
                if (lkpPackageType.Value != null)
                {
                    dlvTariff = dm.GetByPackageTypeAndWeight((int)lkpPackageType.Value, (int)lkpDestinationCity.Value, txtTotalWeight.Value);
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
                        txtChargeable.Value
                        );

                    if (tariffIntModel != null)
                    {
                        txtTariffPerKg.Value = 0;
                        txtTariffTotal.Value = tariffIntModel.Tariff;

                        txtHandlingFee.Value = tariffIntModel.HandlingFee ?? 0;
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
                var tariffModel = tariffDataManager.GetTariff(
                    (int)BaseControl.CityId,
                    (int)lkpDestinationCity.Value,
                    lkpServiceType.Value ?? 0,
                    lkpPackageType.Value ?? 0,
                    txtChargeable.Value
                    );
                if (tariffModel != null)
                {
                    txtTariffPerKg.Value = tariffModel.Tariff;
                    txtHandlingFee.Value = tariffModel.HandlingFee;

                    txtTariffTotal.Value = (txtTariffPerKg.Value * txtChargeable.Value) + txtHandlingFee.Value;

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

        private void RefreshGrandTotal()
        {
            if (_isPopulatingForm) return;

            if (string.IsNullOrEmpty(txtTariffTotal.Text) ||
                string.IsNullOrEmpty(txtInsuranceFee.Text) || string.IsNullOrEmpty(txtPackingFee.Text) ||
                string.IsNullOrEmpty(txtInsuranceFee.Text)) return;

            if (((ShipmentModel)CurrentModel).PricingPlanId == PRICING_PLAN_DOMESTIC)
            {
                txtTariffTotal.Value = (txtTariffPerKg.Value * txtChargeable.Value) + txtHandlingFee.Value;
            }

            //txtInsuranceFee.Value = txtGoodsValue.Value * ((float) _fixedShippingInsuranceRate);

            var grandTotal = txtTariffTotal.Value + txtPackingFee.Value + txtInsuranceFee.Value;

            if (((ShipmentModel)CurrentModel).CurrencyId != null)
            {
                grandTotal *= ((ShipmentModel)CurrentModel).CurrencyRate;
            }

            txtGrandTotal.Value = grandTotal;
        }
    }
}