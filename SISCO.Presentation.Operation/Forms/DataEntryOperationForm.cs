using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraReports.UI;
using SISCO.App.Administration;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.Common.Reports;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Operation.Popup;
using SISCO.Presentation.Operation.Reports;
using SISCO.App.Corporate;
using SISCO.Presentation.Operation.Command;
using SISCO.Presentation.Common.Component;
using System.Web.Script.Serialization;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class DataEntryOperationForm : BaseCrudForm<ShipmentModel, ShipmentDataManager>//BaseToolbarForm//
    {
        private bool EditCustomer { get; set; }
        public bool isAwbAvailable { get; set; }
        private bool isBulk { get; set; }

        private class QrMeta
        {
            public string Code { get; set; }
            public string Fulfilment { get; set; }
            public string OrigCity { get; set; }
            public string DestCity { get; set; }
            public decimal GrossWeight { get; set; }
        }

        public DataEntryOperationForm()
        {
            InitializeComponent();
            form = this;

            VisibleBtnQr = true;
            tbxName.CharacterCasing = CharacterCasing.Upper;
            tbxAlamat.CharacterCasing = CharacterCasing.Upper;
            tbxTelp.CharacterCasing = CharacterCasing.Upper;
            tbxConName.CharacterCasing = CharacterCasing.Upper;
            tbxConAddress.CharacterCasing = CharacterCasing.Upper;
            tbxConTelp.CharacterCasing = CharacterCasing.Upper;
            tbxReff.CharacterCasing = CharacterCasing.Upper;
            tbxNote.CharacterCasing = CharacterCasing.Upper;
            tbxNature.CharacterCasing = CharacterCasing.Upper;

            tbxWeight.Leave += Calculate;
            Load += DataEntryOperationLoad;
            btnSave.Click += (sender, args) => Save();
            tbxCustomer.Leave += AutopopulateShipper;
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

                            AutopopulateShipper(sender, args);
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

            //Shown += (sender, args) => Top();

            FormTrackingStatus = EnumTrackingStatus.Acceptance;
            //var cash = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default("CASH", "name", EnumSqlOperator.Equals));
            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                //WhereTerm.Default(cash.Id, "payment_method_id", EnumSqlOperator.NotEqual),
                WhereTerm.Default(0,"sales_type_id", EnumSqlOperator.Equals)
            };
            SearchPopup = new DataEntryAcceptanceFilterPopup();
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

            tbxDate.KeyDown += CursorBarcode;
            tsBaseTxt_Code.KeyDown += SearchBarcodeCursor;
            btnSave.PreviewKeyDown += (sender, args) =>
            {
                if (args.KeyCode == Keys.Up)
                    tbxFulfilment.Focus();
                if (args.KeyCode == Keys.Down)
                    tsBaseTxt_Code.Focus();
            };

            tsBaseBtn_Print.Click += (sender, args) => Print();
            tsBaseBtn_PrintPreview.Click += (sender, args) => PrintPodPreview();
        }

        private void PrintPodPreview()
        {
            var printout = new EConnotePrintout
            {
                DataSource = GetPrintDataSource()
            };

            printout.ShowPreviewDialog();
        }

        public override void Print()
        {
            var printout = new EConnotePrintout
            {
                DataSource = GetPrintDataSource()
            };

            printout.Print();
            new ShipmentExpandDataManager().Printing(CurrentModel.Id);
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

        private void AutopopulateShipper(object sender, EventArgs e)
        {
            if (EditCustomer)
            {
                if (tbxCustomer.Value != null)
                {
                    var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)tbxCustomer.Value, "id", EnumSqlOperator.Equals));

                    if (customer != null)
                    {
                        tbxName.Text = tbxName.Text == string.Empty ? customer.Name : tbxName.Text;
                        tbxAlamat.Text = tbxAlamat.Text == string.Empty ? customer.Address : tbxAlamat.Text;
                        tbxTelp.Text = tbxTelp.Text == string.Empty ? customer.Phone : tbxTelp.Text;

                        if (StateChange == EnumStateChange.Insert)
                        {
                            if (customer.ServiceTypeId != null)
                                tbxService.DefaultValue = new IListParameter[] { WhereTerm.Default((int)customer.ServiceTypeId, "id") };
                        }
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

        private void DataEntryOperationLoad(object sender, EventArgs e)
        {
            ucRA.Label = @"RA";
            ucRA.Icon = false;

            EnableBtnSearch = true;
            EnableBtnPrint = true;
            EnableBtnPrintPreview = false;

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
            tbxCod.IsNumber = true;

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
                if (cbxPacking.Checked)
                {
                    tbxPacking.Value = PackingCalculation(tbxL.Value, tbxW.Value, tbxH.Value);
                    tbxPacking.Enabled = true;
                }
                else
                {
                    tbxPacking.Value = 0;
                    tbxPacking.Enabled = false;
                }
            };

            tsBaseBtn_Qr.Click += (s, args) => PrintLabel();
        }

        public override void New()
        {
            var messenger = tbxMessenger.Value;
            var messenger2 = tbxMessenger2.Value;

            base.New();
            EditCustomer = true;

            _ClearForm(pnlTop);
            _ClearForm(pnlTop2);
            _ClearForm(pnlMiddle);
            _ClearForm(pnlBottom);
            _ClearForm(pnlRight);
            tbxFulfilment.Clear();
            tbxPacking.Enabled = false;

            ToolbarCode = string.Empty;

            var branch =
                    new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id",
                        EnumSqlOperator.Equals));

            tbxBranch.Text = branch.Name;

            tbxPackage.DefaultValue = new IListParameter[] { WhereTerm.Default("PARCEL", "name", EnumSqlOperator.Equals) };
            tbxService.DefaultValue = new IListParameter[] { WhereTerm.Default("REGULAR", "name", EnumSqlOperator.Equals) };
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
                tbxMessenger2.DefaultValue = new IListParameter[]
                {
                    WhereTerm.Default((int)messenger2, "id")
                };
            }

            tbxPieces.SetValue(Resources.default_number);
            tbxWeight.SetValue(Resources.default_number);
            tbxCharge.SetValue(Resources.default_number);
            tbxL.SetValue(Resources.default_number);
            tbxW.SetValue(Resources.default_number);
            tbxH.SetValue(Resources.default_number);
            tbxCod.SetValue((decimal)0);

            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = DateTime.Now.ToString();
            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;
            tbxNo.Focus();
            tbxNo.ReadOnly = false;
            btnSave.Enabled = true;
            tbxCod.Enabled = false;
            isBulk = false;

            tbxOrigin.DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.CityId, "id", EnumSqlOperator.Equals) };
            cbxPrinteconnote.Checked = false;
            cbxPrintLabel.Checked = false;

            EnableBtnQr = false;
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

            if (!ValidateForm())
            {
                MessageBox.Show(Resources.alert_empty_field, @"Warning");
                return;
            }

            if (!ValidateFormWithAlert())
            {
                return;
            }

            CurrentModel = PopulateModel(CurrentModel as ShipmentModel);
            var mdl = CurrentModel as ShipmentModel;
            if (mdl.Tariff == 0)
            {
                MessageBox.Show("Tidak ada layanan pengiriman untuk tujuan atau service tersebut. Silakan menghubungi CS untuk info lebih lanjut.");
                return;
            }

            using (var scope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, new TimeSpan(0, 10, 0)))
            {
                if (CurrentModel.Id == 0)
                {
                    InsertTracking = true;
                    CurrentModel.Rowstatus = true;
                    CurrentModel.Rowversion = DateTime.Now;
                    CurrentModel.Createddate = DateTime.Now;
                    CurrentModel.Createdby = BaseControl.UserLogin;

                    new ShipmentDataManager().Save<ShipmentModel>(CurrentModel);

                    SaveDetail();
                }
                else
                {
                    InsertTracking = false;
                    CurrentModel.Rowversion = DateTime.Now;
                    CurrentModel.Modifieddate = DateTime.Now;
                    CurrentModel.Modifiedby = BaseControl.UserLogin;
                    
                    new ShipmentDataManager().Update<ShipmentModel>(CurrentModel);

                    SaveDetail(true);
                }

                scope.Complete();
            }

            TotalPage = 1;
            StateChange = EnumStateChange.Update;
            CrudState = EnumStateChange.Update;

            RefreshToolbarState();

            Dirty = false;
            AfterSave();
            Buttons();

            form.Activate();
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

            if (cbxPrinteconnote.Checked)
            {
                Print();
            }

            if (cbxPrintLabel.Checked)
            {
                PrintLabel();
            }

            var cprinter = cbxPrint.Checked;
            var ccontinous = cbxContinous.Checked;
            var ceconnote = cbxPrinteconnote.Checked;
            var clabel = cbxPrintLabel.Checked;

            var shipmentNo = "";
            var auto = false;
            try
            {
                // ReSharper disable once SpecifyACultureInStringConversionExplicitly
                shipmentNo = (Convert.ToInt64(tbxNo.Text) + 1).ToString();
                auto = cbxAutoIncrement.Checked;
            }
            catch { }

            var awb = tbxNo.Text;
            var _isbulk = isBulk;
            New();

            if (auto)
            {
                tbxNo.Text = shipmentNo;
                cbxAutoIncrement.Checked = true;
                tbxDestination.Focus();
            }

            cbxPrint.Checked = cprinter;
            cbxContinous.Checked = ccontinous;
            cbxPrinteconnote.Checked = ceconnote;
            cbxPrintLabel.Checked = clabel;

            new ShipmentSyncDataManager().UpdateShipment(awb, BaseControl.UserLogin, Environment.MachineName);
            if (_isbulk) Close();
        }

        private void PrintLabel()
        {

            var model = CurrentModel as ShipmentModel;
            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(model.Id, "shipment_id"));

            var qr = new QrMeta
            {
                Code = model.Code,
                Fulfilment = expand != null ? expand.Fulfilment : string.Empty,
                OrigCity = model.CityName,
                DestCity = model.DestCity,
                GrossWeight = model.TtlChargeableWeight
            };

            var branch = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(model.BranchId, "id"));
            var service = new ServiceTypeDataManager().GetFirst<ServiceTypeModel>(WhereTerm.Default(model.ServiceTypeId, "id"));
            var label = new List<QrCodePrint>
            {
                new QrCodePrint{
                    DateProcess = model.DateProcess,
                    Code = model.Code,
                    OrigBranch = branch.Name,
                    DestBranch = model.DestBranchName,
                    GrossWeight = model.TtlChargeableWeight,
                    COD = expand != null ? expand.TotalCod : 0,
                    ConsigneeName = model.ConsigneeName,
                    ConsigneeAddress = model.ConsigneeAddress,
                    ConsigneePhone = model.ConsigneePhone,
                    ServiceType = service.Name,
                    JsonBarcode = new JavaScriptSerializer().Serialize(qr)
                }
            };

            var a = new CnQrCodeCard();
            a.DataSource = label;
            a.CreateDocument();

            var printTool = new ReportPrintTool(a);
            printTool.PrintingSystem.StartPrint += (o, args) =>
            {
                args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.Barcode;
            };

            printTool.Print();
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
                tbxPieces.Text != "" && tbxWeight.Text != "" && tbxCharge.Text != "" && tbxCod.Value > 0)
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

            if (cbxCod.Checked && tbxCod.Value < 1)
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

            _ClearForm(pnlTop);
            _ClearForm(pnlTop2);
            _ClearForm(pnlMiddle);
            _ClearForm(pnlBottom);
            _ClearForm(pnlRight);
            tbxFulfilment.Clear();
            EnabledForm(true);
            tbxPacking.Enabled = false;

            if (model == null) return;

            EnableBtnQr = true;
            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(model.Id, "shipment_id"));
            var branch =
                    new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id",
                        EnumSqlOperator.Equals));

            tbxBranch.Text = branch.Code;

            ToolbarCode = model.Code;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = model.DateProcess.ToString();
            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;
            tbxNo.Text = model.Code;
            tbxNo.Enabled = false;
            tbxOrigin.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CityId, "id", EnumSqlOperator.Equals) };

            tbxDestination.DefaultValue = new IListParameter[] { WhereTerm.Default(model.DestCityId, "id", EnumSqlOperator.Equals) };
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
            
            // ReSharper disable once PossibleInvalidOperationException
            if (model.MessengerId != null)
            {
                tbxMessenger.DefaultValue = new IListParameter[]
                {WhereTerm.Default((int) model.MessengerId, "id", EnumSqlOperator.Equals)};
            }

            if (model.MessengerId2 != null)
            {
                tbxMessenger2.DefaultValue = new IListParameter[]
                {
                    WhereTerm.Default((int)model.MessengerId2, "id")
                };
            }
            tbxPackage.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PackageTypeId, "id", EnumSqlOperator.Equals) };
            tbxService.DefaultValue = new IListParameter[] { WhereTerm.Default(model.ServiceTypeId, "id", EnumSqlOperator.Equals) };
            tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PaymentMethodId, "id", EnumSqlOperator.Equals) };
            if (model.CustomerId != null)
            {
                // ReSharper disable once PossibleInvalidOperationException
                tbxCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.CustomerId, "id", EnumSqlOperator.Equals) };
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
            tbxPacking.SetValue(model.PackingFee);

            cbxPrint.Checked = cprinter;
            cbxContinous.Checked = ccontinous;
            tbxCod.Enabled = false;

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
            } else
            {
                tbxL.SetValue(Resources.default_number);
                tbxW.SetValue(Resources.default_number);
                tbxH.SetValue(Resources.default_number);
                tbxCod.SetValue((decimal)0);
                tbxPacking.SetValue((decimal)0);
            }

            if (model.Voided)
            {
                MessageForm.Info(form, Resources.information, @"Nomor CN sudah divoid");
                EnabledForm(false);
            }

            var destCity = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(model.DestCityId, "id"));
            cbxCod.Enabled = destCity != null & destCity.Cod;
            tbxCod.Enabled = !cbxCod.Enabled ? false : cbxCod.Checked;

            if (model.Paid) EnableBtnSave = false;
            EditCustomer = false;
            if (model.PackingFee > 0) tbxPacking.Enabled = true;
        }

        protected override ShipmentModel PopulateModel(ShipmentModel model)
        {
            model.DateProcess = tbxDate.Value;
            model.Code = tbxNo.Text;

            if (tbxOrigin.Value != null)
            {
                model.CityId = (int) tbxOrigin.Value;
                model.CityName =
                    new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(model.CityId, "id",
                        EnumSqlOperator.Equals)).Name;
            }
            model.BranchId = BaseControl.BranchId;
            if (tbxDestination.Value != null)
            {
                model.DestCityId = (int) tbxDestination.Value;
                model.DestCity =
                    new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(model.DestCityId, "id",
                        EnumSqlOperator.Equals)).Name;
            }

            if (tbxCustomer.Value != null)
            {
                model.CustomerId = tbxCustomer.Value;
                var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int) model.CustomerId, "id",
                        EnumSqlOperator.Equals));

                model.CustomerName = customer.Name;
                if (customer.Discount > 0) model.DiscountPercent = customer.Discount;
                else model.DiscountPercent = 0;
            }

            if (model.Id == 0)
            {
                model.TrackingStatusId = (int)EnumTrackingStatus.Acceptance;
                model.DataEntryEmployee = BaseControl.EmployeeCode;
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
            model.DiscountFixed = 0;

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
            if (tbxPayment.Value != null) model.PaymentMethodId = (int)tbxPayment.Value;

            if (tbxMessenger.Value != null)
            {
                model.MessengerId = tbxMessenger.Value;
                var messenger =
                    new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int) model.MessengerId, "id",
                        EnumSqlOperator.Equals));
                model.MessengerName = messenger.Name;
            }

            model.MessengerId2 = tbxMessenger2.Value;
            if (tbxMessenger2.Value !=null)
            {
                var messenger2 =
                    new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)model.MessengerId2, "id",
                        EnumSqlOperator.Equals));
                model.MessengerName2 = messenger2.Name;
            }

            model.NatureOfGoods = tbxNature.Text;
            model.Note = tbxNote.Text;

            model.TtlPiece = (short)tbxPieces.Value;
            model.TtlGrossWeight = tbxWeight.Value;
            model.TtlChargeableWeight = tbxCharge.Value;
            model.PricingPlanId = 0;
            model.PackingFee = tbxPacking.Value;

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

            isAwbAvailable = obj != null;

            tbxCustomer.Focus();
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

        public void OpenPopulateForm(ShipmentModel model)
        {
            New();
            
            var cprinter = cbxPrint.Checked;
            var ccontinous = cbxContinous.Checked;

            _ClearForm(pnlTop);
            _ClearForm(pnlTop2);
            _ClearForm(pnlMiddle);
            _ClearForm(pnlBottom);
            _ClearForm(pnlRight);

            var branch =
                    new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id",
                        EnumSqlOperator.Equals));

            tbxBranch.Text = branch.Code;

            ToolbarCode = model.Code;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = model.DateProcess.ToString();
            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;
            tbxNo.Text = model.Code;
            tbxNo.ReadOnly = true;
            tbxOrigin.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CityId, "id", EnumSqlOperator.Equals) };

            tbxDestination.DefaultValue = new IListParameter[] { WhereTerm.Default(model.DestCityId, "id", EnumSqlOperator.Equals) };
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
                catch { }
            }

            tbxName.Text = model.ShipperName;
            tbxAlamat.Text = model.ShipperAddress;
            tbxTelp.Text = model.ShipperPhone;
            tbxReff.Text = model.RefNumber;
            tbxConName.Text = model.ConsigneeName;
            tbxConAddress.Text = model.ConsigneeAddress;
            tbxConTelp.Text = model.ConsigneePhone;

            // ReSharper disable once PossibleInvalidOperationException
            if (model.MessengerId != null)
            {
                tbxMessenger.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.MessengerId, "id", EnumSqlOperator.Equals) };
            }

            if (model.MessengerId2 != null)
            {
                tbxMessenger2.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.MessengerId2, "id", EnumSqlOperator.Equals) };
            }

            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxPieces.SetValue(model.TtlPiece.ToString());
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxWeight.SetValue(model.TtlGrossWeight.ToString());
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxCharge.SetValue(model.TtlChargeableWeight.ToString());
            tbxPackage.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PackageTypeId, "id", EnumSqlOperator.Equals) };
            tbxService.DefaultValue = new IListParameter[] { WhereTerm.Default(model.ServiceTypeId, "id", EnumSqlOperator.Equals) };
            tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PaymentMethodId, "id", EnumSqlOperator.Equals) };
            if (model.CustomerId != null)
            {
                // ReSharper disable once PossibleInvalidOperationException
                tbxCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.CustomerId, "id", EnumSqlOperator.Equals) };
            }
            tbxNature.Text = model.NatureOfGoods;
            tbxNote.Text = model.Note;

            cbxPrint.Checked = cprinter;
            cbxContinous.Checked = ccontinous;
            cbxPrinteconnote.Checked = true;

            if (model.Voided)
            {
                MessageForm.Info(form, Resources.information, @"Nomor CN sudah divoid");
                EnabledForm(false);
            }
            else EnabledForm(true);

            tbxCod.Enabled = false;
            tbxPacking.Enabled = false;
            var expand = model as SISCO.Models.ShipmentModel.ShipmentReportRow;
            if (expand != null)
            {
                cbxCod.Checked = expand.IsCod;
                tbxCod.SetValue(expand.TotalCod);
                tbxCod.Enabled = expand.IsCod;
                tbxFulfilment.Text = expand.Fulfilment;
            }

            tbxWeight.Focus();
            tbxCharge.Focus();
            tbxNo.Focus();
            btnSave.Enabled = true;
            isBulk = true;
        }

        protected override void VolumeCalculation(decimal L, decimal W, decimal H, string serviceType, decimal Gw, dTextBoxNumber chargeable)
        {
            base.VolumeCalculation(L, W, H, serviceType, Gw, chargeable);
            if (cbxPacking.Checked) tbxPacking.SetValue(PackingCalculation(L, W, H));
        }
    }
}