using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using Franchise.Presentation.Common;
using Franchise.Presentation.Common.Component;
using Franchise.Presentation.Common.Forms;
using Franchise.Presentation.DropPoint.Print;
using Franchise.Presentation.MasterData.Popup;
using SISCO.App.Administration;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.LocalStorage;
using SISCO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Franchise.Presentation.DropPoint.Forms
{
    public partial class AcceptanceDropPointForm : BaseForm
    {
        private int? promoId { get; set; }
        private int? dropPointId { get; set; }
        private decimal DeliveryTariffMinimumWeight { get; set; }
        private decimal MinWeight { get; set; }

        public string NoResi { get; set; }

        public AcceptanceDropPointForm()
        {
            InitializeComponent();
            form = this;

            Load += FormLoad;
            CurrentModel = new ShipmentModel();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            lkpDestination.LookupPopup = new CityPopup();
            lkpDestination.AutoCompleteDataManager = new CityServices();
            lkpDestination.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpDestination.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpDestination.FieldLabel = "Destination City";
            lkpDestination.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            lkpDestination.EditValueChanged += lkpDestination_EditValueChanged;

            lkpPackage.LookupPopup = new PackageTypePopup();
            lkpPackage.AutoCompleteDataManager = new PackageTypeServices();
            lkpPackage.AutoCompleteDisplayFormater = model => ((PackageTypeModel)model).Name;
            lkpPackage.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };
            lkpPackage.FieldLabel = "Package Type";
            lkpPackage.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            lkpPackage.EditValueChanged += lkpPackageType_EditValueChanged;

            lkpService.LookupPopup = new ServiceTypePopup("name.Equals(@0) OR name.Equals(@1) OR name.Equals(@2)", "ECO", "ONS", "SUPER ECONOMI");
            lkpService.AutoCompleteDataManager = new ServiceTypeServices();
            lkpService.AutoCompleteDisplayFormater = model => ((ServiceTypeModel)model).Name;
            lkpService.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("name.StartsWith(@0) AND (name.Equals(@1) OR name.Equals(@2) OR name.Equals(@3))", s, "ECO", "ONS", "SUPER ECONOMI");
            lkpService.FieldLabel = "Service Type";
            lkpService.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            lkpService.EditValueChanged += lkpServiceType_EditValueChanged;

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
            tbxTtlChargeable.EditValueChanged += lkpDestination_EditValueChanged;

            tbxDiscount.EditMask = "#0.0%%";

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

            tbxTtlGrossWeight.TextChanged += GrossWeightChange;

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

            btnSave.Click += (s, o) =>
            {
                if (Save())
                {
                    NoResi = tbxResi.Text;
                    form.Close();
                }
            };

            btnSavePrint.Click += (s, o) =>
            {
                if (string.IsNullOrEmpty(BaseControl.PrinterSetting.InkJet))
                {
                    MessageBox.Show("Lakukan setting ulang printer di menu Preference/Printer Preference");
                    return;
                }

                if (Save())
                {
                    NoResi = tbxResi.Text;

                    var printout = new EConnotePrintout
                    {
                        DataSource = GetPrintDataSource()
                    };

                    # if (DEBUG)
                    printout.PrintPreview();
                    # else
                    printout.Print();
                    # endif

                    new ShipmentExpandDataManager().Printing(CurrentModel.Id);
                    form.Close();
                }
            };

            btnCancel.Click += (s, o) => Close();

            tbxL.EditValueChanged += (s, o) => GrossWeightChange(s,o);
            tbxW.EditValueChanged += (s, o) => GrossWeightChange(s, o);
            tbxH.EditValueChanged += (s, o) => GrossWeightChange(s, o);
            cbxPacking.CheckedChanged += GrossWeightChange;
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
            model.Printed = expand != null ? expand.Printed : (short)0;
            model.VolumeL = expand != null ? expand.VolumeL : 1;
            model.VolumeH = expand != null ? expand.VolumeH : 1;
            model.VolumeW = expand != null ? expand.VolumeW : 1;

            return new List<ShipmentModel.ShipmentReportRow>
            {
                model
            };
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ClearForm();

            tbxDate.DateTime = DateTime.Now;
            tbxResi.Text = NoResi;
            NoResi = string.Empty;
            CheckResi();

            lkpDestination.Focus();
            tbxEmailPoint.Enabled = false;

            tbxTtlPiece.SetValue((decimal)1);
            tbxTtlGrossWeight.SetValue((decimal)1);
            tbxTtlChargeable.SetValue((decimal)1);
            tbxL.SetValue((decimal)1);
            tbxW.SetValue((decimal)1);
            tbxH.SetValue((decimal)1);
            tbxTariff.SetValue((decimal)0.00);
            tbxTariffNet.SetValue((decimal)0.00);
            tbxHandlingFee.SetValue((decimal)0.00);
            tbxDiscount.SetValue((decimal)10.00);
            tbxTtlDiscount.SetValue((decimal)0.00);
            tbxTariff.SetValue((decimal)0.00);
            tbxTtlTariff.SetValue((decimal)0.00);
            tbxGlobalTotal.SetValue((decimal)0.00);

            lkpPackage.DefaultValue = new IListParameter[] { WhereTerm.Default("PARCEL", "name") };
            lkpService.DefaultValue = new IListParameter[] { WhereTerm.Default("ECO", "name") };
        }

        private bool Save()
        {
            if (ValidateForm())
            {
                CurrentModel = PopulateModel((ShipmentModel)CurrentModel);

                CurrentModel.Rowstatus = true;
                CurrentModel.Rowversion = DateTime.Now;
                CurrentModel.Createdby = BaseControl.UserLogin;
                CurrentModel.Createddate = DateTime.Now;
                ((ShipmentModel)CurrentModel).CreatedPc = Environment.MachineName;

                new ShipmentDataManager().Save<ShipmentModel>((ShipmentModel)CurrentModel);

                var expandModel = new ShipmentExpandModel
                {
                    ShipmentId = CurrentModel.Id,
                    VolumeL = tbxL.Value,
                    VolumeW = tbxL.Value,
                    VolumeH = tbxL.Value,
                    UsePacking = false,
                    IsCod = false,
                    TotalCod = 0,
                    Printed = 0,
                    EmailPoint = tbxEmailPoint.Text,
                    DropPointId = dropPointId
                };

                new ShipmentExpandDataManager().Save<ShipmentExpandModel>(expandModel);
                var shipmentStatusModel = new ShipmentStatusModel
                {
                    Rowstatus = true,
                    Rowversion = DateTime.Now,
                    DateProcess = DateTime.Now,
                    ShipmentId = CurrentModel.Id,
                    TrackingStatusId = (int)EnumTrackingStatus.FranchiseDataEntry,
                    PositionStatusId = BaseControl.BranchId,
                    PositionStatus = EnumPositionStatus.Franchise.ToString(),
                    BranchId = BaseControl.BranchId,
                    StatusBy = BaseControl.UserLogin,
                    Createddate = DateTime.Now,
                    Createdby = BaseControl.UserLogin
                };

                new ShipmentStatusDataManager().Save<ShipmentStatusModel>(shipmentStatusModel);
                return true;
            }

            return false;
        }

        private void GrossWeightChange(object sender, EventArgs e)
        {
            decimal ceiled = 0;
            if (CurrentModel == null) return;
            decimal gw = tbxTtlGrossWeight.Value;

            if (gw > 0)
            {
                if (cbxPacking.Checked)
                {
                    gw = gw + ((gw * 60) / 100);
                }

                var number = Math.Floor(gw);
                var decPoint = gw - Convert.ToDecimal(number);

                if (decPoint < (decimal)0.4) ceiled = Convert.ToDecimal(number);
                else ceiled = Convert.ToDecimal(number) + 1;
            }

            if (ceiled > 999999) MessageBox.Show(@"Chargeable maximal 999,999 kg");

            VolumeCalculation(tbxL.Value, tbxW.Value, tbxH.Value, lkpService.Text, gw, tbxTtlChargeable);

            if (tbxTtlChargeable.Value > ceiled) ceiled = tbxTtlChargeable.Value;

            tbxTtlChargeable.Value = ceiled;
            RefreshDeliveryTariff();
            RefreshGrandTotal();
        }

        private void RefreshGrandTotal()
        {
            CheckPromo();
            if (string.IsNullOrEmpty(tbxTtlDiscount.Text) || string.IsNullOrEmpty(tbxDiscount.Text) ||
                string.IsNullOrEmpty(tbxTariffNet.Text) || string.IsNullOrEmpty(tbxTtlTariff.Text)) return;

            if (((ShipmentModel)CurrentModel).PricingPlanId == 1)
            {
                tbxTtlTariff.Value = (tbxTariff.Value * tbxTtlChargeable.Value) + tbxHandlingFee.Value;
            }

            tbxTtlDiscount.Value = (tbxDiscount.Value / 100) * tbxTtlTariff.Value;
            tbxTariffNet.Value = tbxTtlTariff.Value - tbxTtlDiscount.Value;

            //txtInsuranceFee.Value = txtGoodsValue.Value * ((float) _fixedShippingInsuranceRate);

            var grandTotal = tbxTariffNet.Value;

            if (((ShipmentModel)CurrentModel).CurrencyId != null)
            {
                grandTotal *= ((ShipmentModel)CurrentModel).CurrencyRate;
            }

            tbxGlobalTotal.Value = grandTotal;
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

        private ShipmentModel PopulateModel(ShipmentModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.Code = tbxResi.Text;
            model.BranchId = BaseControl.BranchId;
            model.AutoNumber = true;

            model.NeedRa = cbxRa.Checked;

            model.CityId = BaseControl.CityId;
            model.CityName = BaseControl.CityName;

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

            model.PaymentMethodId = 1;
            model.PaymentMethod = "CASH";

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

            model.Total = tbxGlobalTotal.Value;

            model.SalesTypeId = 5;

            if (CurrentModel.Id == 0)
            {
                model.CreatedPc = Environment.MachineName;
            }

            if (model.Id == 0)
            {
                model.TrackingStatusId = (int)EnumTrackingStatus.FranchiseDataEntry;
            }
            model.PODStatus = (int)EnumPodStatus.None;

            if (promoId != null) model.PromoId = promoId;
            model.PromoCode = tbxPromo.Text;

            return model;
        }

        private void NoServiceMessage()
        {
            if (tbxTariff.Value == 0 && lkpDestination.Value > 0) MessageBox.Show("Tidak ada layanan pengiriman untuk tujuan atau service tersebut.");
        }

        private bool ValidateForm()
        {
            if (tbxResi.Text == string.Empty)
            {
                MessageBox.Show("Nomor resi harus diisi");
                tbxResi.Focus();
                return false;
            }
            if (cbxMobilePoint.Checked && string.IsNullOrEmpty(tbxEmailPoint.Text))
            {
                tbxEmailPoint.Focus();
                return false;
            }
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

            if (tbxGlobalTotal.Value == 0)
            {
                NoServiceMessage();
                return false;
            }

            if (dropPointId == null)
            {
                MessageBox.Show("Nomor resi bukan untuk drop point");
                return false;
            }

            if (tbxTariff.Value == 0 && lkpDestination.Value > 0)
            {
                MessageBox.Show("Tidak ada layanan pengiriman untuk tujuan atau service tersebut.");
                return false;
            }

            return true;
        }

        private void CheckResi()
        {
            if (string.IsNullOrEmpty(tbxResi.Text)) return;

            if (tbxResi.Text.Length != 12)
            {
                MessageBox.Show(@"Nomor POD harus 12 digit!");
                tbxResi.Clear();
                tbxResi.Focus();
                return;
            }

            if (!tbxResi.Text.All(c => char.IsDigit(c)))
            {
                MessageBox.Show(@"Nomor POD harus berupa angka!");
                tbxResi.Clear();
                tbxResi.Focus();
                return;
            }

            var model = new ShipmentNumberAllocationDataManager().GetFirst<ShipmentAllocationModel>(
                WhereTerm.Default(Convert.ToInt64(tbxResi.Text), "shipment_code_start", EnumSqlOperator.LesThanEqual),
                WhereTerm.Default(Convert.ToInt64(tbxResi.Text), "shipment_code_end", EnumSqlOperator.GreatThanEqual),
                WhereTerm.Default(0, "drop_point_id", EnumSqlOperator.GreatThan)
            );

            dropPointId = null;
            lblDropPoint.Text = string.Empty;
            tbxDiscount.SetValue((float)10);

            if (model != null)
            {
                var dp = new DropPointDataManager().GetFirst<DropPointModel>(WhereTerm.Default((int)model.DropPointId, "id"));
                if (dp != null)
                {
                    dropPointId = model.DropPointId;
                    lblDropPoint.Text = dp.Code;
                    tbxDiscount.SetValue(dp.Commission);
                    tbxDiscount.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Nomor resi bukan untuk drop point.");
                    tbxResi.Clear();
                    tbxResi.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Nomor resi bukan untuk drop point.");
                tbxResi.Clear();
                tbxResi.Focus();
                return;
            }
        }

        private void RefreshDeliveryTariff()
        {
            ((ShipmentModel)CurrentModel).DeliveryFeeTotal = ((ShipmentModel)CurrentModel).DeliveryFee * Math.Max(tbxTtlChargeable.Value, DeliveryTariffMinimumWeight);
        }

        private void RefreshTariff()
        {
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

            if (((ShipmentModel)CurrentModel).PricingPlanId != 1)
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
                        currencyDm.GetFirst<CurrencyModel>(WhereTerm.Default("IDR", "code"));

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

        private void lkpDestination_EditValueChanged(object sender, EventArgs e)
        {
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
            RefreshTariff();
        }

        private void lkpServiceType_EditValueChanged(object sender, EventArgs e)
        {
            RefreshTariff();
        }
    }
}