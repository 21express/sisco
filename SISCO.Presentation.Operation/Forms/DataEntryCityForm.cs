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
using SISCO.Presentation.Operation.Command;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class DataEntryCityForm : BaseCrudForm<ShipmentModel, ShipmentDataManager>//BaseToolbarForm//
    {
        private bool EditCustomer { get; set; }

        public DataEntryCityForm()
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

            Load += DataEntryCityLoad;
            tbxWeight.Leave += Calculate;
            btnSave.Click += (sender, args) => Save();
            tbxCustomer.Leave += (sender, args) => AutopopulateShipper();
            tbxCustomer.TextChanged += (sender, args) =>
            {
                EditCustomer = true;
            };

            tbxNo.Leave += (sender, args) =>
            {
                if (CheckCn() && !string.IsNullOrEmpty(tbxNo.Text))
                {
                    var model = new ShipmentNumberAllocationDataManager().GetFirst<ShipmentAllocationModel>(
                        WhereTerm.Default(Convert.ToInt64(tbxNo.Text), "shipment_code_start", EnumSqlOperator.LesThanEqual),
                        WhereTerm.Default(Convert.ToInt64(tbxNo.Text), "shipment_code_end", EnumSqlOperator.GreatThanEqual)
                    );

                    if (model != null)
                    {
                        if (model.FranchiseId != null)
                        {
                            var code = tbxNo.Text;

                            New();

                            var dataEntryForm = new DataEntryFranchiseForm();
                            BaseControl.OpenDataEntryFranchiseForm(dataEntryForm, code, new DataEntryFranchiseCommand().GetType(), "Operation");
                            return;
                        }
                    }
                }
                else return;

                if (CurrentModel.Id == 0 && tbxNo.Text != "")
                {
                    try
                    {
                        var allocation =
                            new ShipmentNumberAllocationDataManager().GetAllocationByCustomer(
                                Convert.ToInt64(tbxNo.Text), BaseControl.BranchId);
                        if (allocation != null)
                        {
                            if (allocation.DropPointId != null)
                            {
                                var code = tbxNo.Text;

                                New();

                                MessageForm.Warning(form, "POD Cash", string.Format("POD {0} sudah dialokasi untuk transaksi Cash. Silakan info ke Counter Cash.", code));
                                return;
                            }

                            tbxCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default((int)allocation.CustomerId, "id", EnumSqlOperator.Equals) };
                            EditCustomer = true;
                            tbxCustomer.Enabled = false;
                            tbxCustomer.Properties.Buttons[0].Enabled = false;

                            AutopopulateShipper();
                        }
                        else
                        {
                            tbxCustomer.Enabled = true;
                            tbxCustomer.Properties.Buttons[0].Enabled = true;
                            tbxCustomer.BackColor = Color.AntiqueWhite;
                        }
                    }
                    catch
                    {
                        tbxCustomer.Enabled = true;
                        tbxCustomer.Properties.Buttons[0].Enabled = true;
                        tbxCustomer.BackColor = Color.AntiqueWhite;
                    }
                }
            };

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                //WhereTerm.Default(BaseControl.BranchId, "dest_branch_id", EnumSqlOperator.Equals),
                WhereTerm.Default(2,"sales_type_id", EnumSqlOperator.Equals)
            };

            //Shown += (sender, args) => Top();
            FormTrackingStatus = EnumTrackingStatus.Acceptance;

            SearchPopup = new DataEntryCityFilterPopup();
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
            tbxService.Leave += (sender, args) => CheckRa(null, null);
            tbxPackage.Leave += (sender, args) => CheckRa(null, null);

            tbxDate.KeyDown += CursorBarcode;
            tsBaseTxt_Code.KeyDown += SearchBarcodeCursor;

            btnSave.PreviewKeyDown += (sender, args) =>
            {
                if (args.KeyCode == Keys.Up)
                    tbxCharge.Focus();
                if (args.KeyCode == Keys.Down)
                    tsBaseTxt_Code.Focus();
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

        private void CheckRa(int? origBranchId, int? destBranchId)
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

            if (tbxPackage.Value == null || tbxService.Value == null) return;
            if (tbxCustomer.Value != null)
            {
                var cust = new CustomerTariffDataManager().GetTariff(orig.Id, dest.Id, (int)tbxService.Value,
                    (int)tbxPackage.Value, (int)tbxCustomer.Value, tbxCharge.Value);

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

        private void AutopopulateShipper()
        {
            if (EditCustomer)
            {
                if (tbxCustomer.Value != null)
                {
                    var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)tbxCustomer.Value, "id", EnumSqlOperator.Equals));

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

        private void DataEntryCityLoad(object sender, EventArgs e)
        {
            ucRA.Label = @"RA";
            ucRA.Icon = false;

            EnableBtnSearch = true;
            
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

            tbxCustomer.LookupPopup =
                new CustomerPopup(new IListParameter[]
                {
                    WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                    WhereTerm.Default("0", "disabled", EnumSqlOperator.Equals)
                });
            tbxCustomer.AutoCompleteDataManager = new CustomerDataManager();
            tbxCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            tbxCustomer.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1 AND disabled = @2", s, BaseControl.BranchId, "0");

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
        }

        public override void New()
        {
            var messenger = tbxMessenger.Value;
            var messenger2 = tbxMessenger2.Value;

            btnSave.Enabled = true;
            base.New();

            _ClearForm(pnlTop);
            _ClearForm(pnlTop2);
            _ClearForm(pnlMiddle);
            _ClearForm(pnlBottom);
            _ClearForm(pnlRight);
            tbxFulfilment.Clear();

            ToolbarCode = string.Empty;

            var branch =
                    new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id",
                        EnumSqlOperator.Equals));

            tbxBranch.Text = branch.Name;

            tbxOrigin.DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.CityId, "id", EnumSqlOperator.Equals) };
            tbxDestination.DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.CityId, "id", EnumSqlOperator.Equals) };

            tbxPackage.DefaultValue = new IListParameter[] { WhereTerm.Default("DOCUMENT", "name", EnumSqlOperator.Equals) };
            tbxService.DefaultValue = new IListParameter[] { WhereTerm.Default("CITY COURIER", "name", EnumSqlOperator.Equals) };
            tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default("CREDIT", "name", EnumSqlOperator.Equals) };

            if (messenger != null)
            {
                tbxMessenger.DefaultValue = new IListParameter[]
                {WhereTerm.Default((int) messenger, "id", EnumSqlOperator.Equals)};
            }
            else
            {
                var employee =
                    new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default(BaseControl.EmployeeId, "id",
                        EnumSqlOperator.Equals));

                if (employee != null && employee.AsMessenger)
                {
                    tbxMessenger.DefaultValue = new IListParameter[]
                    {WhereTerm.Default(employee.Id, "id", EnumSqlOperator.Equals)};
                }
            }

            if (messenger2 != null)
            {
                tbxMessenger2.DefaultValue = new IListParameter[] { WhereTerm.Default((int)messenger2, "id") };
            }

            tbxPieces.SetValue(Resources.default_number);
            tbxWeight.SetValue(Resources.default_number);
            tbxCharge.SetValue(Resources.default_number);
            tbxL.SetValue(Resources.default_number);
            tbxW.SetValue(Resources.default_number);
            tbxH.SetValue(Resources.default_number);
            tbxCod.SetValue((decimal)0);
            tbxCod.Enabled = false;

            tbxDate.Enabled = false;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = DateTime.Now.ToString();
            tbxDate.Properties.Buttons[0].Enabled = false;

            tbxNo.Focus();
            tbxNo.ReadOnly = false;
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

                if (CurrentModel.Id > 0)
                {
                    var ship2 =
                        new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxNo.Text, "code", EnumSqlOperator.Equals));
                    if (ship2 != null)
                    {
                        if (ship2.Id != CurrentModel.Id)
                        {
                            MessageBox.Show(Resources.cn_exists, Resources.information, MessageBoxButtons.OK);
                            tbxNo.Text = string.Empty;
                            tbxNo.Focus();
                            return false;
                        }
                    }
                }

                if (!((ShipmentDataManager)DataManager).CheckPrefixBranchShipment(BaseControl.BranchId, tbxNo.Text))
                {
                    MessageBox.Show(Resources.invalid_stt, Resources.invalid_stt_title, MessageBoxButtons.OK);
                    tbxNo.Text = string.Empty;
                    tbxNo.Focus();
                    return false;
                }

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
            }

            return true;
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

            base.Save();
        }

        protected override void AfterSave()
        {
            PodStatusModel.ShipmentId = CurrentModel.Id;
            PodStatusModel.PositionStatusId = BaseControl.BranchId;
            PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();
            PodStatusModel.StatusBy = BaseControl.UserLogin;

            ShipmentStatusUpdate();
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

            var shipmentNo = "";
            var auto = false;
            try
            {
                // ReSharper disable once SpecifyACultureInStringConversionExplicitly
                shipmentNo = (Convert.ToInt64(tbxNo.Text) + 1).ToString();
                auto = cbxAutoIncrement.Checked;
            }
            catch {}

            var customerId = tbxCustomer.Value;

            New();

            if (auto)
            {
                tbxNo.Text = shipmentNo;
                cbxAutoIncrement.Checked = true;
                tbxDestination.Focus();
            }

            if (customerId != null)
            {
                tbxCustomer.DefaultValue = new IListParameter[]
                {WhereTerm.Default((int) customerId, "id", EnumSqlOperator.Equals)};

                AutopopulateShipper();
            }

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
                tbxPackage.Text != "" && tbxService.Text != "" && tbxPayment.Text != "" && tbxMessenger.Text != "" &&
                tbxPieces.Text != "" && tbxWeight.Text != "" && tbxCharge.Text != "")
                return true;

            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return false;
            }

            if (tbxNo.Text == "")
            {
                tbxNo.Focus();
                return false;
            }

            if (tbxOrigin.Text == "")
            {
                tbxOrigin.Focus();
                return false;
            }

            if (tbxDestination.Text == "")
            {
                tbxDestination.Focus();
                return false;
            }

            if (tbxCustomer.Text == "")
            {
                tbxCustomer.Focus();
                return false;
            }

            if (tbxName.Text == "")
            {
                tbxName.Focus();
                return false;
            }

            if (tbxAlamat.Text == "")
            {
                tbxAlamat.Focus();
                return false;
            }

            if (tbxTelp.Text == "")
            {
                tbxTelp.Focus();
                return false;
            }

            if (tbxConName.Text == "")
            {
                tbxConName.Focus();
                return false;
            }

            if (tbxConAddress.Text == "")
            {
                tbxConAddress.Focus();
                return false;
            }

            if (tbxConTelp.Text == "")
            {
                tbxConTelp.Focus();
                return false;
            }

            if (tbxPackage.Text == "")
            {
                tbxPackage.Focus();
                return false;
            }

            if (tbxService.Text == "")
            {
                tbxService.Focus();
                return false;
            }

            if (tbxPayment.Text == "")
            {
                tbxPayment.Focus();
                return false;
            }

            if (tbxMessenger.Text == "")
            {
                tbxMessenger.Focus();
                return false;
            }

            if (tbxPieces.Text == "")
            {
                tbxPieces.Focus();
                return false;
            }

            if (tbxWeight.Text == "")
            {
                tbxWeight.Focus();
                return false;
            }

            if (tbxCharge.Text == "")
            {
                tbxCharge.Focus();
                return false;
            }

            return false;
        }

        protected override void PopulateForm(ShipmentModel model)
        {
            var cprinter = cbxPrint.Checked;
            var ccontinous = cbxContinous.Checked;

            _ClearForm(pnlTop);
            _ClearForm(pnlTop2);
            _ClearForm(pnlMiddle);
            _ClearForm(pnlBottom);
            _ClearForm(pnlRight);
            EnabledForm(true);
            tbxFulfilment.Clear();

            if (model == null) return;

            var branch = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id",
                    EnumSqlOperator.Equals));

            tbxBranch.Text = branch.Code;

            ToolbarCode = model.Code;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = model.DateProcess.ToString();
            tbxNo.Text = model.Code;
            tbxNo.Enabled = false;
            tbxOrigin.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CityId, "id", EnumSqlOperator.Equals) };
            tbxDestination.DefaultValue = new IListParameter[] { WhereTerm.Default(model.DestCityId, "id", EnumSqlOperator.Equals) };
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            ucRA.Icon = model.NeedRa;

            tbxCustomer.Enabled = true;
            tbxCustomer.Properties.Buttons[0].Enabled = true;
            tbxCustomer.BackColor = Color.AntiqueWhite;
            if (model.CustomerId != null)
            {
                tbxCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.CustomerId, "id", EnumSqlOperator.Equals) };
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
                catch{}
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

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            cbxPrint.Checked = cprinter;
            cbxContinous.Checked = ccontinous;

            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(model.Id, "shipment_id"));
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
            model.CityName =
                new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(model.CityId, "id", EnumSqlOperator.Equals)).Name;
            model.BranchId = BaseControl.BranchId;
            
            if (tbxDestination.Value != null) model.DestCityId = (int)tbxDestination.Value;
            model.DestCity = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(model.DestCityId, "id", EnumSqlOperator.Equals)).Name;
            model.SalesTypeId = 2;

            if (tbxCustomer.Value != null)
            {
                model.CustomerId = tbxCustomer.Value;
                model.CustomerName =
                    new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int) model.CustomerId, "id",
                        EnumSqlOperator.Equals)).Name;
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

            if (tbxPackage.Value != null) model.PackageTypeId = (int)tbxPackage.Value;
            if (tbxService.Value != null) model.ServiceTypeId = (int)tbxService.Value;
            if (tbxPayment.Value != null) model.PaymentMethodId = (int) tbxPayment.Value;

            if (tbxMessenger.Value != null)
            {
                model.MessengerId = tbxMessenger.Value;
                model.MessengerName =
                    new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int) model.MessengerId, "id",
                        EnumSqlOperator.Equals)).Name;
            }

            model.MessengerId2 = tbxMessenger2.Value;
            if (tbxMessenger2.Value != null)
            {
                model.MessengerName2 = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int) model.MessengerId2, "id")).Name;
            }

            model.NatureOfGoods = tbxNature.Text;
            model.Note = tbxNote.Text;

            model.TtlPiece = (short)tbxPieces.Value;
            model.TtlGrossWeight = tbxWeight.Value;
            model.TtlChargeableWeight = tbxCharge.Value;

            if (cbxPacking.Checked) model.PackingFee = PackingCalculation(tbxL.Value, tbxW.Value, tbxH.Value);
            else model.PackingFee = 0;

            model = new ShipmentDataManager().GetTariff(model, BaseControl.CountryId);

            if (model.Id == 0)
            {
                model.TrackingStatusId = (int)EnumTrackingStatus.Acceptance;
                model.CreatedPc = Environment.MachineName;
                model.DataEntryEmployee = BaseControl.EmployeeCode;
            }
            else model.ModifiedPc = Environment.MachineName;

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

            tbxNo.Focus();
            return obj;
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();
            EditCustomer = false;

            var model = CurrentModel as ShipmentModel;
            if (model != null && model.Id > 0 && (model.Paid || model.Voided || model.Posted || model.Invoiced == 1 || (DateTime.Now - model.DateProcess).TotalDays > 3))
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

        private void cbxAutoIncrement_CheckedChanged(object sender, EventArgs e)
        {
            tbxNo.Focus();
        }
    }
}