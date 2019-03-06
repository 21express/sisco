using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.LocalStorage;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.CustomerService.Reports;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.CustomerService.Forms
{
    public partial class PODReturnForm : BaseForm
    {
        private int _id { get; set; }
        private int? _customerId { get; set; }
        private int? _pricingPlanId { get; set; }
        private int? _paymentMethodId { get; set; }
        private int? _packageTypeId { get; set; }
        private int? _serviceTypeId { get; set; }
        private decimal _deliveryTariffMin { get; set; }
        private decimal _deliveryFee { get; set; }
        private int? _currencyId { get; set; }
        private string _currency { get; set; }
        private decimal _currencyRate { get; set; }
        private bool _ra { get; set; }
        private decimal _minWeight { get; set; }

        public PODReturnForm()
        {
            InitializeComponent();
            form = this;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            tbxNo.Leave += CheckPod;
            lkpDestination.LookupPopup = new CityPopup();
            lkpDestination.AutoCompleteDataManager = new CityServices();
            lkpDestination.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpDestination.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            lkpDestination.EditValueChanged += ChangeDestination;
            btnRetur.Click += PodRetur;
            btnPrint.Click += Print;
            tbxReturAwb.Leave += (s, a) => CheckCn();
            tbxGrossWeight.EditValueChanged += TxtTotalWeightOnTextChanged;
        }

        private void TxtTotalWeightOnTextChanged(object sender, EventArgs eventArgs)
        {
            decimal ceiled;

            if (_minWeight > 0 && tbxGrossWeight.Value < _minWeight) tbxGrossWeight.Value = _minWeight;

            if (_pricingPlanId == 1)
            {
                ceiled = Math.Ceiling(tbxGrossWeight.Value);
            }
            else
            {
                ceiled = Math.Ceiling(tbxGrossWeight.Value * 2) / 2;
            }

            if (ceiled > 999999) MessageBox.Show(@"Chargeable maximal 999,999 kg");

            tbxChargeable.Value = ceiled;
            RefreshTariff();
        }

        private void Print(object sender, EventArgs e)
        {
            var printout = new EConnotePrintout
            {
                DataSource = GetPrintDataSource()
            };

            printout.Print();
        }

        private IEnumerable<ShipmentModel.ShipmentReportRow> GetPrintDataSource()
        {
            var currExpand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(_id, "shipment_id"));
            var currModel = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(currExpand.ReturnAWB, "code"));
            var model = ConvertModel<ShipmentModel, ShipmentModel.ShipmentReportRow>(currModel as ShipmentModel);

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

            using (var packageTypeDm = new PackageTypeDataManager())
            {
                var packageType = packageTypeDm.GetFirst<PackageTypeModel>(WhereTerm.Default(model.PackageTypeId, "id"));
                if (packageType != null)
                {
                    model.PackageType = packageType.Name;
                }
            }

            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(_id, "shipment_id"));
            model.IsCod = expand == null ? false : expand.IsCod;
            model.TotalCod = expand == null ? 0 : expand.TotalCod;
            model.Printed = expand == null ? (short)0 : expand.Printed;
            model.VolumeL = expand == null ? 1 : expand.VolumeL;
            model.VolumeW = expand == null ? 1 : expand.VolumeW;
            model.VolumeH = expand == null ? 1 : expand.VolumeH;
            model.Fulfilment = expand == null ? string.Empty : expand.Fulfilment;

            return new List<ShipmentModel.ShipmentReportRow>
            {
                model
            };
        }

        private void PodRetur(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;
            if (tbxTariffNet.Value == 0)
            {
                MessageBox.Show("Tidak ada layanan pengiriman untuk tujuan atau service tersebut.");
                return;
            }

            UseWaitCursor = true;

            var model = new ShipmentModel();
            var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxReturAwb.Text, "code", EnumSqlOperator.Equals));
            if (shipment == null)
            {
                model = PopulateModel();
                new ShipmentDataManager().Save<ShipmentModel>(model);
                var expandModel = new ShipmentExpandModel
                {
                    ShipmentId = model.Id,
                    VolumeL = tbxVolumeL.Value,
                    VolumeW = tbxVolumeW.Value,
                    VolumeH = tbxVolumeH.Value,
                    UsePacking = false,
                    IsCod = false,
                    TotalCod = 0,
                    Printed = 0
                };
                new ShipmentExpandDataManager().Save<ShipmentExpandModel>(expandModel);

                PodStatusModel.ShipmentId = model.Id;
                PodStatusModel.PositionStatusId = BaseControl.BranchId;
                PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();
                PodStatusModel.Reference = string.Empty;
                PodStatusModel.StatusNote = string.Empty;
                PodStatusModel.TrackingStatusId = (int)EnumTrackingStatus.Acceptance;
                PodStatusModel.StatusBy = BaseControl.UserLogin;
                PodStatusModel.Rowstatus = true;
                PodStatusModel.Rowversion = DateTime.Now;
                PodStatusModel.DateProcess = DateTime.Now;
                PodStatusModel.BranchId = BaseControl.BranchId;
                PodStatusModel.EmployeeId = BaseControl.EmployeeId;
                PodStatusModel.Createddate = DateTime.Now;
                PodStatusModel.Createdby = BaseControl.UserLogin;
                new ShipmentStatusDataManager().Save<ShipmentStatusModel>(PodStatusModel);
            }
            else
            {
                shipment.TtlPiece = (short)tbxPcs.Value;
                shipment.TtlGrossWeight = (decimal)tbxGrossWeight.Value;
                shipment.TtlChargeableWeight = (decimal)tbxChargeable.Value;
                shipment.Modifieddate = DateTime.Now;
                shipment.ModifiedPc = Environment.MachineName;
                shipment.Modifiedby = BaseControl.UserLogin;

                new ShipmentDataManager().Update<ShipmentModel>(shipment);

                model = shipment;
            }

            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(_id, "shipment_id"));
            expand.ReturnAWB = model.Code;
            new ShipmentExpandDataManager().Update<ShipmentExpandModel>(expand);

            PodStatusModel.ShipmentId = _id;
            PodStatusModel.PositionStatusId = BaseControl.BranchId;
            PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();
            PodStatusModel.TrackingStatusId = (int)EnumTrackingStatus.Returned;
            FormTrackingStatus = EnumTrackingStatus.Returned;
            PodStatusModel.StatusNote = tbxReason.Text;
            PodStatusModel.Reference = model.Code;

            InsertTracking = true;

            ShipmentStatusUpdate();

            UseWaitCursor = false;

            AutoClosingMessageBox.Show(@"Resi sudah di retur", Resources.information);
            CheckPod(sender, e);
        }

        private bool ValidateForm()
        {
            if (lkpDestination.Value == null)
            {
                lkpDestination.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbxConsigneeName.Text))
            {
                tbxConsigneeName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbxConsigneeAddress.Text))
            {
                tbxConsigneeAddress.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbxConsigneePhone.Text))
            {
                tbxConsigneePhone.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbxReason.Text))
            {
                tbxReason.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbxReturAwb.Text))
            {
                tbxReturAwb.Focus();
                return false;
            }

            return true;
        }

        private bool CheckCn()
        {
            if (string.IsNullOrEmpty(tbxNo.Text))
            {
                tbxNo.Focus();
                tbxReturAwb.Clear();
                return false;
            }

            if (!tbxReturAwb.Enabled) return false;

            tbxReturAwb.Enabled = true;
            tbxReturAwb.BackColor = Color.AntiqueWhite;
            lkpDestination.Enabled = true;
            lkpDestination.Properties.Buttons[0].Enabled = true;
            lkpDestination.BackColor = Color.AntiqueWhite;
            tbxConsigneeName.Enabled = true;
            tbxConsigneeName.BackColor = Color.AntiqueWhite;
            tbxConsigneeAddress.Enabled = true;
            tbxConsigneeAddress.BackColor = Color.AntiqueWhite;
            tbxConsigneePhone.Enabled = true;
            tbxConsigneePhone.BackColor = Color.AntiqueWhite;
            tbxPcs.Enabled = true;
            tbxPcs.BackColor = Color.AntiqueWhite;
            tbxGrossWeight.Enabled = true;
            tbxGrossWeight.BackColor = Color.AntiqueWhite;
            tbxReason.Enabled = true;
            tbxReason.BackColor = Color.AntiqueWhite;

            if (tbxReturAwb.Text != "")
            {
                if (tbxReturAwb.Text.Length != 12)
                {
                    MessageBox.Show(Resources.cn_less_12, Resources.information, MessageBoxButtons.OK);
                    tbxReturAwb.Clear();
                    tbxReturAwb.Focus();
                    return false;
                }

                var ship2 =
                        new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxReturAwb.Text, "code", EnumSqlOperator.Equals));
                if (ship2 != null)
                {
                    if (ship2.TrackingStatusId == (int)EnumTrackingStatus.Acceptance && ship2.CustomerId == _customerId)
                    {
                        lkpDestination.Enabled = false;
                        lkpDestination.Properties.Buttons[0].Enabled = false;
                        tbxConsigneeName.Enabled = false;
                        tbxConsigneePhone.Enabled = false;
                        tbxConsigneeAddress.Enabled = false;
                        tbxReason.Enabled = true;
                        tbxReason.BackColor = Color.AntiqueWhite;
                        tbxReason.Clear();

                        PopulateShipment(ship2.Code);
                    }
                    else
                    {
                        MessageBox.Show(Resources.cn_exists, Resources.information, MessageBoxButtons.OK);
                        tbxReturAwb.Clear();
                        tbxReturAwb.Focus();
                        return false;
                    }
                }
                else
                {
                    lkpDestination.Value = null;
                    lkpDestination.Text = string.Empty;
                    tbxPcs.SetValue((decimal)1);
                    tbxGrossWeight.SetValue((decimal)1);
                    tbxTariff.SetValue((decimal)0);
                    tbxHandlingFee.SetValue((decimal)0);
                    tbxTariffNet.SetValue((decimal)0);
                    tbxTariffTotal.SetValue((decimal)0);
                    tbxDiscount.SetValue((decimal)0);
                    tbxDiscountTotal.SetValue((decimal)0);
                    tbxGrandTotal.SetValue((decimal)0);
                }

                if (!new ShipmentDataManager().CheckPrefixBranchShipment(BaseControl.BranchId, tbxReturAwb.Text))
                {
                    MessageBox.Show(Resources.invalid_stt, Resources.invalid_stt_title, MessageBoxButtons.OK);
                    tbxReturAwb.Clear();
                    tbxReturAwb.Focus();
                    return false;
                }
            }

            return true;
        }

        private ShipmentModel PopulateModel()
        {
            var model = new ShipmentModel();

            model.DateProcess = DateTime.Now;
            model.Rowstatus = true;
            model.Rowversion = DateTime.Now;
            model.BranchId = BaseControl.BranchId;

            model.AutoNumber = false;
            model.NeedRa = _ra;
            model.Code = tbxReturAwb.Text;
            
            model.CityId = BaseControl.CityId;
            model.CityName = BaseControl.CityName;

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

            model.CustomerId = _customerId;
            using (var dm = new CustomerDataManager())
            {
                var customer = dm.GetFirst<CustomerModel>(WhereTerm.Default(_customerId ?? 0, "id"));
                model.CustomerName = customer != null ? customer.Name : string.Empty;
            }

            model.ShipperName = tbxShipperName.Text;
            model.ShipperAddress = tbxShipperAddress.Text;
            model.ShipperPhone = string.Empty;
            model.RefNumber = tbxNo.Text;

            model.ConsigneeName = tbxConsigneeName.Text;
            model.ConsigneeAddress = tbxConsigneeAddress.Text;
            model.ConsigneePhone = tbxConsigneePhone.Text;

            model.PackageTypeId = (int)_packageTypeId;
            model.PackageType = lkpPackageType.Text;

            model.ServiceTypeId = (int)_serviceTypeId;

            model.PaymentMethodId = (int)_paymentMethodId;
            model.PaymentMethod = lkpPayment.Text;

            model.MessengerName = BaseControl.UserLogin;
            model.MessengerId = BaseControl.UserId;

            model.NatureOfGoods = tbxNatureGoods.Text;

            model.TtlPiece = Convert.ToInt16(tbxTtlPiece.Value);
            model.TtlGrossWeight = tbxGw.Value;
            model.TtlChargeableWeight = tbxCw.Value;

            model.Tariff = tbxTariff.Value;
            model.HandlingFeeTotal = tbxHandlingFee.Value;
            model.TariffTotal = tbxTariffTotal.Value;
            model.DiscountPercent = tbxDiscount.Value;
            model.DiscountTotal = tbxDiscountTotal.Value;
            model.TariffNet = tbxTariffNet.Value;

            model.PackingFee = 0;
            model.OtherFee = 0;
            model.GoodsValue = 0;
            model.InsuranceFee = 0;

            model.TrackingStatusId = (int)EnumTrackingStatus.Acceptance;
            model.Total = tbxGrandTotal.Value;

            model.SalesTypeId = 0;

            model.CreatedPc = Environment.MachineName;
            model.Createdby = BaseControl.UserLogin;
            model.Createddate = DateTime.Now;

            model.PricingPlanId = _pricingPlanId;
            model.DeliveryFee = _deliveryFee;
            model.CurrencyId = _currencyId;
            model.Currency = _currency;
            model.CurrencyRate = _currencyRate;

            return model;
        }
         
        private void ClearFormLocal()
        {
            _id = 0;
            _customerId = null;
            _pricingPlanId = null;
            _paymentMethodId = null;
            _packageTypeId = null;
            _serviceTypeId = null;
            _deliveryTariffMin = 0;
            _currencyId = 0;
            _currency = string.Empty;
            _currencyRate = 0;
            _ra = false;
            _minWeight = 0;

            _ClearForm(panel1);
            _ClearForm(panel3);
            _ClearForm(panel4);
            tbxReturAwb.Enabled = true;
            tbxReturAwb.BackColor = Color.AntiqueWhite;
            lkpDestination.Enabled = true;
            lkpDestination.Properties.Buttons[0].Enabled = true;
            lkpDestination.BackColor = Color.AntiqueWhite;
            tbxConsigneeName.Enabled = true;
            tbxConsigneeName.BackColor = Color.AntiqueWhite;
            tbxConsigneeAddress.Enabled = true;
            tbxConsigneeAddress.BackColor = Color.AntiqueWhite;
            tbxConsigneePhone.Enabled = true;
            tbxConsigneePhone.BackColor = Color.AntiqueWhite;
            tbxPcs.Enabled = true;
            tbxPcs.BackColor = Color.AntiqueWhite;
            tbxGrossWeight.Enabled = true;
            tbxGrossWeight.BackColor = Color.AntiqueWhite;
            tbxReason.Enabled = true;
            tbxReason.BackColor = Color.AntiqueWhite;
            btnRetur.Enabled = true;
            btnPrint.Enabled = false;
        }

        private void DisableForm()
        {
            tbxReturAwb.Enabled = false;
            lkpDestination.Enabled = false;
            lkpDestination.Properties.Buttons[0].Enabled = false;
            tbxConsigneeName.Enabled = false;
            tbxConsigneeAddress.Enabled = false;
            tbxConsigneePhone.Enabled = false;
            tbxReason.Enabled = false;
            btnRetur.Enabled = false;
            tbxPcs.Enabled = false;
            tbxGrossWeight.Enabled = false;
        }

        private void ChangeDestination(object sender, EventArgs e)
        {
            if (lkpDestination.Value == null) return;

            var cityDataManager = new CityDataManager();
            var countryDataManager = new CountryDataManager();

            var cityModel = cityDataManager.GetFirst<CityModel>(WhereTerm.Default(lkpDestination.Value ?? 0, "Id"));

            if (cityModel != null)
            {
                var countryModel = countryDataManager.GetFirst<CountryModel>(WhereTerm.Default(cityModel.CountryId, "Id"));

                if (countryModel != null)
                {
                    _pricingPlanId = countryModel.PricingPlanId;
                }
            }

            cityDataManager.Dispose();
            countryDataManager.Dispose();

            RefreshTariff();
        }

        private void RefreshTariff()
        {
            if (lkpDestination.Value == null) return;
            using (var dm = new DeliveryTariffDataManager())
            {
                DeliveryTariffModel dlvTariff = null;
                if (_packageTypeId != null)
                {
                    dlvTariff = dm.GetByPackageTypeAndWeight((int)_packageTypeId, (int)lkpDestination.Value, tbxGrossWeight.Value);
                }

                if (dlvTariff != null)
                {
                    _deliveryFee = dlvTariff.Tariff;
                    _deliveryTariffMin = dlvTariff.MinWeight;
                }
                else
                {
                    _deliveryFee = 0;
                    _deliveryTariffMin = 0;
                }
            }

            if (_pricingPlanId != 1)
            {
                using (var tariffInternationalDataManager = new TariffInternationalDataManager())
                {
                    var tariffIntModel = tariffInternationalDataManager.GetTariff(
                        _pricingPlanId ?? 0,
                        _packageTypeId ?? 0,
                        tbxChargeable.Value
                        );

                    if (tariffIntModel != null)
                    {
                        tbxTariff.Value = 0;
                        tbxTariffTotal.Value = tariffIntModel.Tariff;

                        tbxHandlingFee.Value = tariffIntModel.HandlingFee ?? 0;
                        _currencyId = tariffIntModel.CurrencyId;

                        using (var currencyDm = new CurrencyDataManager())
                        {
                            var currencyModel =
                                currencyDm.GetFirst<CurrencyModel>(WhereTerm.Default(tariffIntModel.CurrencyId, "id"));

                            if (currencyModel != null)
                            {
                                _currency = currencyModel.Name;
                                _currencyRate = currencyModel.Rate;
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
                        currencyDm.GetFirst<CurrencyModel>(WhereTerm.Default("IDR", "code"));

                    if (currencyModel != null)
                    {
                        _currencyId = currencyModel.Id;
                        _currency = currencyModel.Name;
                        _currencyRate = currencyModel.Rate;
                    }
                }
            }

            if (_customerId != null)
            {
                using (var customerTariffDataManager = new CustomerTariffDataManager())
                {
                    var customerTariffModel = customerTariffDataManager.GetTariff(
                        BaseControl.CityId,
                        (int)lkpDestination.Value,
                        _serviceTypeId ?? 0,
                        _packageTypeId ?? 0,
                        _customerId ?? 0,
                        tbxChargeable.Value
                        );
                    if (customerTariffModel != null)
                    {
                        tbxTariff.Value = customerTariffModel.Tariff;
                        tbxHandlingFee.Value = customerTariffModel.HandlingFee;

                        _ra = customerTariffModel.Ra ?? false;
                        _minWeight = customerTariffModel.MinWeight;
                        if (_minWeight > 0 && tbxGw.Value < _minWeight) tbxGw.Value = _minWeight;
                        RefreshGrandTotal();
                        return;
                    }
                }
            }

            using (var tariffDataManager = new TariffDataManager())
            {
                var tariffModel = tariffDataManager.GetTariff(
                    BaseControl.CityId,
                    (int)lkpDestination.Value,
                    _serviceTypeId ?? 0,
                    _packageTypeId ?? 0,
                    tbxChargeable.Value
                    );
                if (tariffModel != null)
                {
                    tbxTariff.Value = tariffModel.Tariff;
                    tbxHandlingFee.Value = tariffModel.HandlingFee;

                    _ra = tariffModel.Ra ?? false;
                    _minWeight = tariffModel.MinWeight;
                    if (_minWeight > 0 && tbxGw.Value < _minWeight) tbxGrossWeight.Value = _minWeight;
                    RefreshGrandTotal();
                    return;
                }
            }

            tbxTariff.Text = @"0";
            tbxHandlingFee.Text = @"0";

            _minWeight = 0;
            RefreshGrandTotal();
        }

        private void RefreshGrandTotal()
        {
            if (_pricingPlanId == 1)
            {
                tbxTariffTotal.Value = (tbxTariff.Value * tbxChargeable.Value) + tbxHandlingFee.Value;
            }

            tbxDiscountTotal.Value = (tbxDiscount.Value / 100) * tbxTariffTotal.Value;
            tbxTariffNet.Value = tbxTariffTotal.Value - tbxDiscountTotal.Value;

            var grandTotal = tbxTariffNet.Value;
            if (_currencyId != null)
            {
                grandTotal *= _currencyRate;
            }

            tbxGrandTotal.Value = grandTotal;
        }

        private void CheckPod(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxNo.Text)) return;
            var resi = tbxNo.Text;
            ClearFormLocal();
            tbxNo.Text = resi;
            var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxNo.Text, "code"));
            if (shipment == null)
            {
                MessageBox.Show(@"Nomor resi tidak dikenali", @"Error!");
                return;
            }

            _id = shipment.Id;
            if (shipment.DestBranchId != BaseControl.BranchId)
            {
                MessageBox.Show(@"Nomor resi bukan tujuan cabang ini.", @"Error!");
                return;
            }

            if (shipment.CustomerId == null)
            {
                MessageBox.Show("Resi bukan untuk customer corporate.");
                return;
            }

            var status = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
            {
                WhereTerm.Default(_id, "shipment_id"),
                WhereTerm.Default((int) EnumTrackingStatus.Received, "tracking_status_id")
            });

            if (status != null)
            {
                MessageBox.Show("Resi sudah diterima, tidak dapat di retur.");
                return;
            }

            var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)shipment.CustomerId, "id", EnumSqlOperator.Equals));
            if (customer == null)
            {
                MessageBox.Show("Nama customer tidak dikenali untuk resi ini.");
                return;
            }

            if (shipment.PaymentMethodId != 3)
            {
                MessageBox.Show("Metode pembayaran harus kredit.");
                return;
            }

            var package = new PackageDataManager().GetFirst<PackageTypeModel>(WhereTerm.Default(shipment.PackageTypeId, "id"));
            //var service = new ServiceTypeDataManager().GetFirst<ServiceTypeModel>(WhereTerm.Default(shipment.ServiceTypeId, "id"));
            var service = new ServiceDataManager().GetFirst<ServiceTypeModel>(WhereTerm.Default("ECO", "name"));
            var payment = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default(shipment.PaymentMethodId, "id"));

            _customerId = customer.Id;
            lkpCustomer.Text = string.Format("{0} - {1}", customer.Code, customer.Name);
            
            lkpPackageType.Text = package.Name;
            _packageTypeId = package.Id;

            _serviceTypeId = service.Id;

            lkpPayment.Text = payment.Name;
            _paymentMethodId = payment.Id;

            tbxNatureGoods.Text = shipment.NatureOfGoods;
            tbxTtlPiece.SetValue((decimal)shipment.TtlPiece);
            tbxGw.SetValue((decimal)shipment.TtlGrossWeight);
            tbxCw.SetValue((decimal)shipment.TtlChargeableWeight);

            var exists = false;
            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(shipment.Id, "shipment_id"));
            if (expand != null)
            {
                tbxVolumeL.SetValue(expand.VolumeL);
                tbxVolumeH.SetValue(expand.VolumeH);
                tbxVolumeW.SetValue(expand.VolumeW);

                exists = !string.IsNullOrEmpty(expand.ReturnAWB);
            }

            if (!exists)
            {
                lkpOrigin.Text = BaseControl.CityName;
                tbxShipperAddress.Text = BaseControl.CityName;
                tbxShipperName.Text = string.Format("CS {0}", BaseControl.BranchCode);
                tbxPcs.SetValue((decimal)1);
                tbxGrossWeight.SetValue((decimal)1.0);

                tbxConsigneeName.Text = customer.Name;
                tbxConsigneeAddress.Text = customer.Address;
                tbxConsigneePhone.Text = customer.Phone;
                btnPrint.Enabled = false;
            }
            else
            {
                PopulateShipment(expand.ReturnAWB);

                DisableForm();
                btnPrint.Enabled = true;
            }
        }

        private void PopulateShipment(string awb)
        {
            var newShipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(awb, "code"));
            tbxReturAwb.Text = awb;
            lkpOrigin.Text = newShipment.CityName;
            lkpDestination.DefaultValue = new IListParameter[] { WhereTerm.Default(newShipment.DestCityId, "id") };
            tbxShipperAddress.Text = newShipment.ShipperAddress;
            tbxShipperName.Text = newShipment.ShipperName;
            tbxConsigneeName.Text = newShipment.ConsigneeName;
            tbxConsigneeAddress.Text = newShipment.ConsigneeAddress;
            tbxConsigneePhone.Text = newShipment.ConsigneePhone;

            _pricingPlanId = newShipment.PricingPlanId;
            tbxPcs.SetValue((decimal)newShipment.TtlPiece);
            tbxGrossWeight.SetValue(newShipment.TtlGrossWeight);
            tbxChargeable.SetValue(newShipment.TtlChargeableWeight);
            tbxTariff.SetValue(newShipment.Tariff);
            tbxTariffNet.SetValue(newShipment.TariffNet);
            tbxTariffTotal.SetValue(newShipment.TariffTotal);
            tbxDiscount.SetValue(newShipment.DiscountPercent);
            tbxDiscountTotal.SetValue(newShipment.DiscountTotal);
            tbxHandlingFee.SetValue(newShipment.HandlingFee);
            tbxGrandTotal.SetValue(newShipment.Total);

            var status = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                {
                    WhereTerm.Default(_id, "shipment_id"),
                    WhereTerm.Default((int) EnumTrackingStatus.Returned, "tracking_status_id")
                });

            if (status != null) tbxReason.Text = status.StatusNote;
        }
    }
}