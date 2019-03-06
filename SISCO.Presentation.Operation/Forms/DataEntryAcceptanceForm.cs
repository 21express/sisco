using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using SISCO.App.Administration;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.Common.Reports;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Operation.Popup;
using SISCO.Presentation.Common.Component;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class DataEntryAcceptanceForm : BaseCrudForm<ShipmentModel, ShipmentDataManager>//BaseToolbarForm//
    {
        private bool EditCustomer { get; set; }

        public DataEntryAcceptanceForm()
        {
            InitializeComponent();
            form = this;
            
            tbxName.CharacterCasing = CharacterCasing.Upper;
            tbxAlamat.CharacterCasing = CharacterCasing.Upper;
            tbxTelp.CharacterCasing = CharacterCasing.Upper;
            tbxConName.CharacterCasing = CharacterCasing.Upper;
            tbxConAddress.CharacterCasing = CharacterCasing.Upper;
            tbxConTelp.CharacterCasing = CharacterCasing.Upper;
            tbxReff.CharacterCasing = CharacterCasing.Upper;
            tbxNote.CharacterCasing = CharacterCasing.Upper;
            tbxNature.CharacterCasing = CharacterCasing.Upper;

            Load += DataEntryAcceptanceLoad;
            btnSave.Click += (sender, args) => Save();
            tbxWeight.Leave += Calculate;

            EditCustomer = false;
            tbxOrigin.Leave += (sender, args) => CheckRa(null, null);
            tbxDestination.Leave += (sender, args) =>
            {
                if (tbxDestination.Value != null)
                {
                    var city = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default((int)tbxDestination.Value, "id"));
                    cbxCod.Enabled = city != null && city.Cod;
                    cbxCod.Checked = city != null && !city.Cod ? false : cbxCod.Checked;
                    tbxCod.SetValue(city != null && !city.Cod ? 0 : tbxCod.Value);

                    CheckRa(null, null);
                }
            };
            tbxService.Leave += (sender, args) => CheckRa(null, null, false);
            tbxPackage.Leave += (sender, args) => CheckRa(null, null, false);
            tbxCustomer.Leave += AutopopulateShipper;
            tbxCustomer.TextChanged += (sender, args) =>
            {
                EditCustomer = true;
            };

            tbxNo.Leave += (sender, args) => CheckCn();
            tbxDate.KeyDown += CursorBarcode;
            tsBaseTxt_Code.KeyDown += SearchBarcodeCursor;

            btnSave.PreviewKeyDown += (sender, args) =>
            {
                if (args.KeyCode == Keys.Up)
                    tbxPacking.Focus();
                if (args.KeyCode == Keys.Down)
                    tsBaseTxt_Code.Focus();
            };

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                WhereTerm.Default(0,"sales_type_id", EnumSqlOperator.Equals)
            };
        }

        private void SearchBarcodeCursor(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                case Keys.Up:
                    btnSave.Focus();
                    break;
                case Keys.Left:
                case Keys.Down:
                    tbxDate.Focus();
                    break;
            }
        }

        private void CursorBarcode(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                case Keys.Up:
                    tsBaseTxt_Code.Focus();
                    break;
            }
        }

        private void AutopopulateShipper(object sender, EventArgs e)
        {
            if (EditCustomer)
            {
                if (tbxCustomer.Value != null)
                {
                    var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int) tbxCustomer.Value, "id", EnumSqlOperator.Equals));

                    if (customer != null)
                    {
                        tbxName.Text = customer.Name;
                        tbxAlamat.Text = customer.Address;
                        tbxTelp.Text = customer.Phone;
                    }
                }

                EditCustomer = false;
            }

            CheckRa(null, null);
        }

        private void CheckRa(int? origBranchId, int? destBranchId, bool checkService = true)
        {
            ucRA.Icon = false;
            var orig = new CityModel();
            var dest = new CityModel();
            if (origBranchId != null && destBranchId != null)
            {
                orig = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default((int)origBranchId, "id", EnumSqlOperator.Equals));
                dest =
                        new CityDataManager().GetFirst<CityModel>(WhereTerm.Default((int)destBranchId, "id", EnumSqlOperator.Equals));
            }
            else
            {
                if (tbxOrigin.Value != null && tbxDestination.Value != null)
                {
                    orig = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default((int)tbxOrigin.Value, "id", EnumSqlOperator.Equals));
                    dest =
                            new CityDataManager().GetFirst<CityModel>(WhereTerm.Default((int)tbxDestination.Value, "id",
                                EnumSqlOperator.Equals));
                }
            }

            if (tbxDestination.Value == null || tbxOrigin.Value == null) return;
            var cityCourier = new BranchCityListDataManager().GetFirst<BranchCityListModel>(new IListParameter[]
            {
                WhereTerm.Default(orig.BranchId, "branch_id", EnumSqlOperator.Equals),
                WhereTerm.Default(dest.Id, "city_id", EnumSqlOperator.Equals)
            });

            if (cityCourier != null && checkService)
            {
                tbxService.DefaultValue = new IListParameter[] { WhereTerm.Default("CITY COURIER", "name", EnumSqlOperator.Equals) };
            }

            if (tbxPackage.Value == null || tbxService.Value == null) return;
            if (tbxCustomer.Value != null)
            {
                var cust = new CustomerTariffDataManager().GetTariff(orig.Id, dest.Id, (int) tbxService.Value,
                    (int) tbxPackage.Value, (int) tbxCustomer.Value, tbxCharge.Value);

                if (cust != null)
                {
                    ucRA.Icon = cust.Ra??false;
                    return;
                }
            }

            var tarif = new TariffDataManager().GetTariff(orig.Id, dest.Id,
                    (int)tbxService.Value, (int)tbxPackage.Value, tbxCharge.Value);

            if (tarif != null) ucRA.Icon = tarif.Ra??false;
        }

        private void DataEntryAcceptanceLoad(object sender, EventArgs e)
        {
            ucRA.Label = @"RA";
            ucRA.Icon = false;

            VisibleBtnNew = false;
            VisibleBtnSave = false;
            VisibleBtnPrint = false;
            VisibleBtnPrintPreview = false;
            EnableBtnSearch = true;

            SearchPopup = new DataEntryAcceptanceFilterPopup();

            tbxOrigin.LookupPopup = new CityPopup();
            tbxOrigin.AutoCompleteDataManager = new CityDataManager();
            tbxOrigin.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            tbxOrigin.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            tbxDestination.LookupPopup = new CityPopup();
            tbxDestination.AutoCompleteDataManager = new CityDataManager();
            tbxDestination.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            tbxDestination.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            tbxCustomer.LookupPopup = new CustomerPopup(new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) });
            tbxCustomer.AutoCompleteDataManager = new CustomerDataManager();
            //tbxCustomer.AutoCompleteText = model => ((CustomerModel)model).Name;
            tbxCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            tbxCustomer.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0) AND branch_id = @1", s, BaseControl.BranchId);

            tbxMessenger.LookupPopup = new MessengerPopup();
            tbxMessenger.AutoCompleteDataManager = new EmployeeDataManager();
            tbxMessenger.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            tbxMessenger.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_messenger AND branch_id = @1", s, BaseControl.BranchId);

            tbxMessenger2.LookupPopup = new MessengerPopup();
            tbxMessenger2.AutoCompleteDataManager = new EmployeeDataManager();
            tbxMessenger2.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            tbxMessenger2.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_messenger AND branch_id = @1", s, BaseControl.BranchId);

            tbxPackage.LookupPopup = new PackagePopup();
            tbxPackage.AutoCompleteDataManager = new PackageDataManager();
            tbxPackage.AutoCompleteDisplayFormater = model => ((PackageTypeModel)model).Name;
            tbxPackage.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            tbxService.LookupPopup = new ServicePopup();
            tbxService.AutoCompleteDataManager = new ServiceDataManager();
            tbxService.AutoCompleteDisplayFormater = model => ((ServiceTypeModel)model).Name;
            tbxService.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            tbxPayment.LookupPopup = new PaymentMethodPopup(new IListParameter[] { WhereTerm.Default("CASH", "name", EnumSqlOperator.NotEqual) });
            tbxPayment.AutoCompleteDataManager = new PaymentMethodDataManager();
            tbxPayment.AutoCompleteDisplayFormater = model => ((PaymentMethodModel)model).Name;
            tbxPayment.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith),
                WhereTerm.Default("CASH", "name", EnumSqlOperator.NotEqual)
            };

            tbxPieces.IsNumber = true;
            tbxPacking.IsNumber = true;

            tbxL.EditValueChanged += (s, o) => VolumeCalculation(tbxL.Value, tbxW.Value, tbxH.Value, tbxService.Text, tbxWeight.Value, tbxCharge);
            tbxW.EditValueChanged += (s, o) => VolumeCalculation(tbxL.Value, tbxW.Value, tbxH.Value, tbxService.Text, tbxWeight.Value, tbxCharge);
            tbxH.EditValueChanged += (s, o) => VolumeCalculation(tbxL.Value, tbxW.Value, tbxH.Value, tbxService.Text, tbxWeight.Value, tbxCharge);

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
                if (cbxPacking.Checked) tbxPacking.Value = PackingCalculation(tbxL.Value, tbxW.Value, tbxH.Value);
                else tbxPacking.Value = 0;
            };
        }

        private bool CheckCn()
        {
            if (tbxNo.Text != "")
            {
                if (tbxNo.Text.Length != 12)
                {
                    MessageBox.Show(Resources.cn_less_12, Resources.information, MessageBoxButtons.OK);
                    tbxNo.Text = string.Empty;
                    tbxNo.Focus();
                    return false;
                }

                if (((ShipmentModel) CurrentModel).Code != tbxNo.Text)
                {
                    var ship = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxNo.Text, "code", EnumSqlOperator.Equals));
                    if (ship != null)
                    {
                        if (ship.Id != CurrentModel.Id)
                        {
                            MessageBox.Show(Resources.cn_exists, Resources.information, MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }

                if (!((ShipmentDataManager)DataManager).CheckPrefixBranchShipment(BaseControl.BranchId, tbxNo.Text))
                {
                    MessageBox.Show(Resources.invalid_stt, Resources.invalid_stt_title, MessageBoxButtons.OK);
                    tbxNo.Focus();
                    return false;
                }
            }

            return true;
        }

        private void Calculate(object sender, EventArgs e)
        {
            base.OnLeave(e);
            var isDomestic = true;

            if (tbxDestination.Value != null)
            {
                var city = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default((int)tbxDestination.Value, "id", EnumSqlOperator.Equals));
                var country =
                    new CountryDataManager().GetFirst<CountryModel>(WhereTerm.Default(city.CountryId, "id",
                        EnumSqlOperator.Equals));
                if (country.PricingPlanId != null)
                {
                    var zone = new PricingPlanDataManager().GetFirst<PricingPlanModel>(WhereTerm.Default((int)country.PricingPlanId, "id", EnumSqlOperator.Equals));
                    if (zone.Zone != "DOMESTIK") isDomestic = false;
                }
            }

            RoundedUp(tbxWeight.Value, tbxCharge, isDomestic);
            VolumeCalculation(tbxL.Value, tbxW.Value, tbxH.Value, tbxService.Text, tbxWeight.Value, tbxCharge);
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();
            ClearForm();
            tbxPacking.Enabled = false;
            tbxCod.Enabled = false;
        }

        public override void Save()
        {
            if (!CheckCn()) return;

            if (((ShipmentModel)CurrentModel).Invoiced == 1)
            {
                MessageBox.Show(Resources.invoiced, Resources.information, MessageBoxButtons.OK);
                return;
            }

            /*var acceptance = CurrentModel as ShipmentModel;
            Debug.Assert(acceptance != null, "acceptance != null");
            if (acceptance.Id > 0 && acceptance.TrackingStatusId != (int)EnumTrackingStatus.Acceptance)
            {
                MessageBox.Show(Resources.status_invalid, Resources.information, MessageBoxButtons.OK);
                return;
            }*/

            var ship = DataManager.GetFirst<ShipmentModel>(WhereTerm.Default(tbxNo.Text, "code", EnumSqlOperator.Equals));
            if (ship != null)
            {
                if (ship.Id != CurrentModel.Id)
                {
                    MessageBox.Show(Resources.cn_exists, Resources.information, MessageBoxButtons.OK);
                    tbxNo.Focus();
                    return;
                }
            }

            base.Save();
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
                Fulfilment = tbxFulfilment.Text
            };
            SaveExpand(expandModel);

            var dataSource = GetPrintDataSource();

            if (cbxPrint.Checked)
            {
                if (cbxContinous.Checked)
                {
                    var printout = new ConsignmentNoteContinuous
                    {
                        DataSource = dataSource
                    };

                    if (printout.Print()) new ShipmentExpandDataManager().Printing(CurrentModel.Id);
                }
                else
                {
                    var printout = new ConsignmentNote
                    {
                        DataSource = dataSource
                    };

                    if (printout.Print()) new ShipmentExpandDataManager().Printing(CurrentModel.Id);
                }
            }

            var cprinter = cbxPrint.Checked;
            var ccontinous = cbxContinous.Checked;

            EditCustomer = false;
            //OpenData(tbxNo.Text);
            //StateChange = EnumStateChange.Select;
            //tbxCustomer.Focus();

            ClearForm();
            EnabledForm(false);

            tsBaseTxt_Code.Focus();

            cbxPrint.Checked = cprinter;
            cbxContinous.Checked = ccontinous;
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

            using (var packageTypeDm = new PackageTypeDataManager())
            {
                var packageType = packageTypeDm.GetFirst<PackageTypeModel>(WhereTerm.Default(model.PackageTypeId, "id"));
                if (packageType != null)
                {
                    model.PackageType = packageType.Name;
                }
            }

            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(CurrentModel.Id, "shipment_id"));
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

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "" && tbxNo.Text != "" && tbxOrigin.Text != "" && tbxDestination.Text != "" &&
                tbxCustomer.Text != "" && tbxName.Text != "" && tbxAlamat.Text != "" && tbxTelp.Text != "" &&
                tbxConName.Text != "" && tbxConAddress.Text != "" && tbxConTelp.Text != "" &&
                tbxPackage.Text != "" && tbxService.Text != "" && tbxPayment.Text != "" && tbxMessenger.Text != "" && tbxCod.Value > 0)
                return true;

            if (tbxCod.Value == 0 && cbxCod.Checked)
            {
                tbxCod.Focus();
                return false;
            }

            return true;
        }

        protected override void PopulateForm(ShipmentModel model)
        {
            var cprinter = cbxPrint.Checked;
            var ccontinous = cbxContinous.Checked;

            ClearForm();
            if (model == null) return;
            tbxPacking.Enabled = false;
            tbxCod.Enabled = false;

            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(model.Id, "shipment_id"));
            var branch =
                    new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(model.BranchId, "id",
                        EnumSqlOperator.Equals));

            tbxBranch.Text = branch.Code;

            ToolbarCode = model.Code;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = model.DateProcess.ToString();
            tbxNo.Text = model.Code;
            tbxOrigin.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CityId, "id", EnumSqlOperator.Equals) };

            tbxDestination.DefaultValue = new IListParameter[] { WhereTerm.Default(model.DestCityId, "id", EnumSqlOperator.Equals) };
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            //CheckRa(tbxOrigin.GetFieldModel(s => ((CityModel)s).BranchId), tbxDestination.GetFieldModel(s => ((CityModel)s).BranchId));
            ucRA.Icon = model.NeedRa;

            tbxCustomer.Enabled = true;
            tbxCustomer.Properties.Buttons[0].Enabled = true;
            tbxCustomer.BackColor = Color.AntiqueWhite;
            if (model.CustomerId != null)
            {
                tbxCustomer.DefaultValue = new IListParameter[]
                {WhereTerm.Default((int) model.CustomerId, "id", EnumSqlOperator.Equals)};

                try
                {
                    var allocation =
                        new ShipmentNumberAllocationDataManager().GetAllocationByCustomer(Convert.ToInt64(model.Code),
                            model.BranchId);
                    if (allocation != null)
                    {
                        tbxCustomer.Enabled = false;
                        tbxCustomer.Properties.Buttons[0].Enabled = false;
                    }
                }
                catch{};
            }

            tbxName.Text = model.ShipperName;
            tbxAlamat.Text = model.ShipperAddress;
            tbxTelp.Text = model.ShipperPhone;
            tbxReff.Text = model.RefNumber;
            tbxConName.Text = model.ConsigneeName;
            tbxConAddress.Text = model.ConsigneeAddress;
            tbxConTelp.Text = model.ConsigneePhone;
            tbxPackage.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PackageTypeId, "id", EnumSqlOperator.Equals) };
            tbxService.DefaultValue = new IListParameter[] { WhereTerm.Default(model.ServiceTypeId, "id", EnumSqlOperator.Equals) };
            tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PaymentMethodId, "id", EnumSqlOperator.Equals) };
            if (model.MessengerId != null)
            {
                tbxMessenger.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.MessengerId, "id", EnumSqlOperator.Equals) };
            }
            if (model.MessengerId2 != null)
            {
                tbxMessenger2.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.MessengerId2, "id") };
            }
            tbxNature.Text = model.NatureOfGoods;
            tbxNote.Text = model.Note;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxPieces.SetValue(model.TtlPiece.ToString());
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxWeight.SetValue(model.TtlGrossWeight.ToString());
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxCharge.SetValue(model.TtlChargeableWeight.ToString());
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxPacking.SetValue(model.PackingFee.ToString());

            cbxPrint.Checked = cprinter;
            cbxContinous.Checked = ccontinous;

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
            }
            else
            {
                tbxL.SetValue(Resources.default_number);
                tbxW.SetValue(Resources.default_number);
                tbxH.SetValue(Resources.default_number);
                tbxCod.SetValue((decimal)0);
            }

            if (model.Voided)
            {
                MessageForm.Info(form, Resources.information, @"Nomor CN sudah divoid");
                EnabledForm(false);
            }
            else EnabledForm(true);

            if (model.Paid) EnableBtnSave = false;
            tbxCustomer.Focus();

            tbxPayment.Enabled = false;
            tbxPayment.Properties.Buttons[0].Enabled = false;
            tbxNo.ReadOnly = true;

            var destCity = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(model.DestCityId, "id"));
            cbxCod.Enabled = destCity != null & destCity.Cod;
            tbxCod.Enabled = !cbxCod.Enabled ? false : cbxCod.Checked;

            btnSave.Enabled = true;
        }

        protected override ShipmentModel PopulateModel(ShipmentModel model)
        {
            model.DateProcess = tbxDate.Value;
            model.Code = tbxNo.Text;

            if (tbxOrigin.Value != null) model.CityId = (int)tbxOrigin.Value;

            var city = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(model.CityId, "id", EnumSqlOperator.Equals));

            model.CityName = city.Name;
            model.BranchId = BaseControl.BranchId;
                
            if (tbxDestination.Value != null) model.DestCityId = (int) tbxDestination.Value;

            city = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(model.DestCityId, "id", EnumSqlOperator.Equals));

            model.DestCity = city.Name;
            model.CustomerId = tbxCustomer.Value;

            if (model.CustomerId != null)
            {
                var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int) model.CustomerId, "id", EnumSqlOperator.Equals));
                model.CustomerName = customer.Name;
            }

            if (model.Id == 0)
            {
                model.TrackingStatusId = (int)EnumTrackingStatus.Acceptance;
                model.CreatedPc = Environment.MachineName;
            }
            else
            {
                model.ModifiedPc = Environment.MachineName;
                if (string.IsNullOrEmpty(model.ConsigneeName)) model.DataEntryEmployee = BaseControl.EmployeeCode;
            }

            model.ShipperName = tbxName.Text;
            model.ShipperAddress = tbxAlamat.Text;
            model.ShipperPhone = tbxTelp.Text;
            model.RefNumber = tbxReff.Text;
            model.ConsigneeName = tbxConName.Text;
            model.ConsigneeAddress = tbxConAddress.Text;
            model.ConsigneePhone = tbxConTelp.Text;

            model.DestCountryId = BaseControl.CountryId;
            model.DestCountry = BaseControl.CountryName;

            var destCity =
                new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(model.DestCityId, "id",
                    EnumSqlOperator.Equals));
            var destBranch =
                new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(destCity.BranchId, "id",
                    EnumSqlOperator.Equals));

            model.DestBranchId = destBranch.Id;
            model.DestBranchName = destBranch.Name;

            if (tbxPackage.Value != null) model.PackageTypeId = (int) tbxPackage.Value;
            if (tbxService.Value != null) model.ServiceTypeId = (int) tbxService.Value;
            if (tbxPayment.Value != null) model.PaymentMethodId = (int) tbxPayment.Value;
            model.MessengerId = tbxMessenger.Value;
            model.MessengerId2 = tbxMessenger2.Value;

            if (model.MessengerId != null)
            {
                var messenger = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int) model.MessengerId, "id", EnumSqlOperator.Equals));
                model.MessengerName = messenger.Name;
            }

            if (model.MessengerId2 != null)
            {
                var messenger2 = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)model.MessengerId2, "id"));
                model.MessengerName2 = messenger2.Name;
            }

            model.NatureOfGoods = tbxNature.Text;
            model.Note = tbxNote.Text;

            model.TtlPiece = (short) tbxPieces.Value;
            model.TtlGrossWeight = tbxWeight.Value;
            model.TtlChargeableWeight = tbxCharge.Value;
            model.PackingFee = (int) tbxPacking.Value;

            model = new ShipmentDataManager().GetTariff(model, BaseControl.CountryId);

            return model;
        }

        protected override ShipmentModel Find(string searchTerm)
        {
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<ShipmentModel>(param);
            //PopulateForm(obj);

            tbxCustomer.Focus();

            return obj;
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();
            EditCustomer = false;

            var model = CurrentModel as ShipmentModel;
            if (model != null && (model.Voided || model.Posted || model.Invoiced == 1 || (DateTime.Now - model.DateProcess).TotalDays > 3))
            {
                EnabledForm(false);
                btnSave.Enabled = false;
                tsBaseBtn_Save.Enabled = false;
                NavigationMenu.SaveStrip.Enabled = false;
                tsBaseBtn_Delete.Enabled = false;
                NavigationMenu.DeleteStrip.Enabled = false;
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

        protected override void VolumeCalculation(decimal L, decimal W, decimal H, string serviceType, decimal Gw, dTextBoxNumber chargeable)
        {
            base.VolumeCalculation(L, W, H, serviceType, Gw, chargeable);
            if (cbxPacking.Checked) tbxPacking.SetValue(PackingCalculation(L, W, H));
        }
    }
}