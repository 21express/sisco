using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Operation.Popup;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class DataEntryAgentForm : BaseCrudForm<ShipmentModel, ShipmentDataManager>//BaseToolbarForm//
    {
        private IEnumerable<BranchModel> Agents { get; set; }
        // ReSharper disable once UnusedMember.Local
        // ReSharper disable once InconsistentNaming
        private DataEntryAgentFilterPopup Fpe = new DataEntryAgentFilterPopup();
        public DataEntryAgentForm()
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
            tbxNature.CharacterCasing = CharacterCasing.Upper;

            Load += DataEntryAgentLoad;
            tbxWeight.Leave += Calculate;
            tbxTariff.Leave += Calculate2;
            tbxOther.Leave += Calculate2;
            btnSave.Click += (sender, args) => Save();

            FormTrackingStatus = EnumTrackingStatus.Acceptance;
            Shown += (sender, args) => SetDataManager();

            tbxOrigin.Leave += (sender, args) => CheckCityCourier();
            tbxDestination.Leave += (sender, args) => CheckCityCourier();
            tbxNo.Leave += (sender, args) => CheckCn();

            tbxDate.KeyDown += CursorBarcode;
            tsBaseTxt_Code.KeyDown += SearchBarcodeCursor;
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

        private bool CheckCn()
        {
            if (tbxNo.Text != "")
            {
                var ship = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxNo.Text, "code", EnumSqlOperator.Equals));
                if (ship != null)
                {
                    if (ship.Id != CurrentModel.Id)
                    {
                        MessageBox.Show(Resources.cn_exists, Resources.information, MessageBoxButtons.OK);
                        tbxNo.Focus();
                        tbxNo.Text = "";
                        return false;
                    }
                }

                if (!((ShipmentDataManager)DataManager).CheckPrefixBranchShipment((int) cbxBranch.SelectedValue, tbxNo.Text))
                {
                    MessageBox.Show(Resources.invalid_stt, Resources.invalid_stt_title, MessageBoxButtons.OK);
                    tbxNo.Text = string.Empty;
                    tbxNo.Focus();
                    return false;
                }
            }

            return true;
        }

        private void CheckCityCourier()
        {
            if (tbxDestination.Value == null || tbxOrigin.Value == null) return;
            var orig = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default((int) tbxOrigin.Value, "id", EnumSqlOperator.Equals));
            var cityCourier = new BranchCityListDataManager().GetFirst<BranchCityListModel>(new IListParameter[]
            {
                WhereTerm.Default(orig.BranchId, "branch_id", EnumSqlOperator.Equals),
                WhereTerm.Default((int) tbxDestination.Value, "city_id", EnumSqlOperator.Equals)
            });

            if (cityCourier != null)
            {
                tbxService.DefaultValue = new IListParameter[] { WhereTerm.Default("CITY COURIER", "name", EnumSqlOperator.Equals) };
            }
        }

        private void Calculate2(object sender, EventArgs e)
        {
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxTariffTotal.SetValue((tbxCharge.Value * tbxTariff.Value).ToString());
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxTotal.SetValue((tbxTariffTotal.Value + tbxOther.Value).ToString());
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
        }

        private void SetDataManager()
        {
            if (cbxBranch.SelectedValue != null)
            {
                DataManager.DefaultParameters = new IListParameter[]
                {
                    WhereTerm.Default((int) cbxBranch.SelectedValue, "branch_id", EnumSqlOperator.Equals),
                    WhereTerm.Default(3,"sales_type_id", EnumSqlOperator.Equals)
                };

                Fpe.DefaultParam = new IListParameter[]
                {
                    WhereTerm.Default((int) cbxBranch.SelectedValue, "branch_id", EnumSqlOperator.Equals)
                };

                var s = Agents.Where(b => b.Id == (int)cbxBranch.SelectedValue).Select(a => new BranchModel
                {
                    Code = a.Code
                }).FirstOrDefault();

                tbxBranch.Text = s != null ? s.Code : string.Empty;
            }
            else
            {
                DataManager.DefaultParameters = new IListParameter[]
                {
                    WhereTerm.Default(0, "branch_id", EnumSqlOperator.Equals)
                };

                Fpe.DefaultParam = new IListParameter[]
                {
                    WhereTerm.Default(0, "branch_id", EnumSqlOperator.Equals)
                };
            }

            _ClearForm(pnlTop);
            _ClearForm(pnlTop2);
            _ClearForm(pnlMiddle);
            _ClearForm(pnlBottom);
            _ClearForm(pnlRight);

            tsBaseTxt_Code.Text = "";

            //Top();
        }

        private void DataEntryAgentLoad(object sender, EventArgs e)
        {
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

            tbxPayment.LookupPopup = new PaymentMethodPopup(new IListParameter[] { WhereTerm.Default("CREDIT", "name", EnumSqlOperator.NotEqual) });
            tbxPayment.AutoCompleteDataManager = new PaymentMethodDataManager();
            tbxPayment.AutoCompleteDisplayFormater = model => ((PaymentMethodModel)model).Name;
            tbxPayment.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith),
                WhereTerm.Default("CREDIT", "name", EnumSqlOperator.NotEqual)
            };

            Agents = new BranchDataManager().Get<BranchModel>(
                new IListParameter[]
                {
                    WhereTerm.Default(1, "branch_type_id", EnumSqlOperator.Equals)
                }
            );

            cbxBranch.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxBranch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxBranch.DataSource = Agents;
            cbxBranch.DisplayMember = "Name";
            cbxBranch.ValueMember = "Id";
            //cbxBranch.SelectedValue = 0;
            cbxBranch.SelectedValueChanged += (s, a) => SetDataManager();

            cbxBranch.Enabled = true;

            tbxPieces.IsNumber = true;
            SearchPopup = Fpe;
        }

        public override void New()
        {
            if (cbxBranch.SelectedValue == null)
            {
                MessageBox.Show(Resources.agent_empty, Resources.information, MessageBoxButtons.OK);
                return;
            }

            base.New();
            
            _ClearForm(pnlTop);
            _ClearForm(pnlTop2);
            _ClearForm(pnlMiddle);
            _ClearForm(pnlBottom);
            _ClearForm(pnlRight);
            _ClearForm(pnlRight2);

            ToolbarCode = string.Empty;

            var branch =
                    new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default((int)cbxBranch.SelectedValue, "id",
                        EnumSqlOperator.Equals));

            tbxBranch.Text = branch.Code;

            tbxPackage.DefaultValue = new IListParameter[] { WhereTerm.Default("PARCEL", "name", EnumSqlOperator.Equals) };
            tbxService.DefaultValue = new IListParameter[] { WhereTerm.Default("REGULAR", "name", EnumSqlOperator.Equals) };
            tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default("CASH", "name", EnumSqlOperator.Equals) };

            tbxPieces.SetValue(Resources.default_number);
            tbxWeight.SetValue(Resources.default_number);
            tbxCharge.SetValue(Resources.default_number);

            tbxDate.Focus();
            tbxOrigin.DefaultValue = new IListParameter[] { WhereTerm.Default(branch.CityId, "id", EnumSqlOperator.Equals) };
            tbxDestination.DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.CityId, "id", EnumSqlOperator.Equals) };

            tbxNo.ReadOnly = false;
            btnSave.Enabled = true;
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
            PodStatusModel.ShipmentId = CurrentModel.Id;
            PodStatusModel.PositionStatusId = BaseControl.BranchId;
            PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();
            PodStatusModel.StatusBy = BaseControl.UserLogin;

            ShipmentStatusUpdate();

            OpenData(tbxNo.Text);
            StateChange = EnumStateChange.Select;
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "" && tbxNo.Text != "" && tbxOrigin.Text != "" && tbxDestination.Text != "" &&
                tbxName.Text != "" && tbxAlamat.Text != "" && tbxTelp.Text != "" &&
                tbxConName.Text != "" && tbxConAddress.Text != "" && tbxConTelp.Text != "" &&
                tbxPackage.Text != "" && tbxService.Text != "" && tbxPayment.Text != "" &&
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
            _ClearForm(pnlTop);
            _ClearForm(pnlTop2);
            _ClearForm(pnlMiddle);
            _ClearForm(pnlBottom);
            _ClearForm(pnlRight);
            EnabledForm(true);

            if (model == null) return;

            ToolbarCode = model.Code;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = model.DateProcess.ToString();
            tbxNo.Text = model.Code;
            tbxNo.Enabled = false;
            tbxReffCode.Text = model.RefCode;
            tbxOrigin.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CityId, "id", EnumSqlOperator.Equals) };
            tbxDestination.DefaultValue = new IListParameter[] { WhereTerm.Default(model.DestCityId, "id", EnumSqlOperator.Equals) };

            var branch =
                    new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(model.BranchId, "id",
                        EnumSqlOperator.Equals));

            tbxBranch.Text = branch.Code;

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

            tbxNature.Text = model.NatureOfGoods;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxPieces.SetValue(model.TtlPiece.ToString());
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxWeight.SetValue(model.TtlGrossWeight.ToString());
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxCharge.SetValue(model.TtlChargeableWeight.ToString());
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxTariff.SetValue(model.Tariff.ToString());
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxTariffTotal.SetValue(model.TariffTotal.ToString());
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxOther.SetValue(model.OtherFee.ToString());
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxTotal.SetValue(model.Total.ToString());

            if (model.Voided)
            {
                MessageForm.Info(form, Resources.information, @"Nomor CN sudah divoid");
                EnabledForm(false);
            }

            if (model.Paid) EnableBtnSave = false;
            btnSave.Enabled = true;

            if (model != null && (model.Voided || model.Posted || model.Invoiced == 1))
            {
                EnabledForm(false);
                btnSave.Enabled = false;
                tsBaseBtn_Save.Enabled = false;
                NavigationMenu.SaveStrip.Enabled = false;
                tsBaseBtn_Delete.Enabled = false;
                NavigationMenu.DeleteStrip.Enabled = false;
            }
        }

        protected override ShipmentModel PopulateModel(ShipmentModel model)
        {
            model.DateProcess = tbxDate.Value;
            model.Code = tbxNo.Text;

            if (tbxOrigin.Value !=  null) model.CityId = (int)tbxOrigin.Value;
            model.CityName = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(model.CityId, "id", EnumSqlOperator.Equals)).Name;
            model.BranchId = (int)cbxBranch.SelectedValue;
            
            if (tbxDestination.Value != null) model.DestCityId = (int)tbxDestination.Value;
            model.DestCity = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(model.DestCityId, "id", EnumSqlOperator.Equals)).Name;
            model.SalesTypeId = 3;
            model.CustomerId = 0;
            model.CustomerName = string.Empty;
            model.ShipperName = tbxName.Text;
            model.ShipperAddress = tbxAlamat.Text;
            model.ShipperPhone = tbxTelp.Text;
            model.RefCode = tbxReffCode.Text;
            model.ConsigneeName = tbxConName.Text;
            model.ConsigneeAddress = tbxConAddress.Text;
            model.ConsigneePhone = tbxConTelp.Text;

            var destCity =
                new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(model.DestCityId, "id",
                    EnumSqlOperator.Equals));
            var destBranch =
                new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(destCity.BranchId, "id",
                    EnumSqlOperator.Equals));

            model.DestBranchId = destBranch.Id;
            model.DestBranchName = destBranch.Name;

            if (tbxPackage.Value != null) model.PackageTypeId = (int) tbxPackage.Value;
            if (tbxService.Value != null) model.ServiceTypeId = (int)tbxService.Value;
            if (tbxPayment.Value != null) model.PaymentMethodId = (int)tbxPayment.Value;
            model.NatureOfGoods = tbxNature.Text;
            model.RefNumber = tbxReff.Text;

            model.TtlPiece = (short)tbxPieces.Value;
            model.TtlGrossWeight = tbxWeight.Value;
            model.TtlChargeableWeight = tbxCharge.Value;
            model.Tariff = tbxTariff.Value;
            model.TariffNet = tbxTariffTotal.Value;
            model.TariffTotal = tbxTariffTotal.Value;
            model.OtherFee = tbxOther.Value;
            model.Total = tbxTotal.Value;

            model.PricingPlanId = 0;
            model.NeedRa = false;

            // ReSharper disable once PossibleInvalidOperationException
            var cur =
                new CurrencyDataManager().GetFirst<CurrencyModel>(
                    WhereTerm.Default(1, "id", EnumSqlOperator.Equals));
            model.Currency = cur.Name;
            model.CurrencyRate = cur.Rate;

            model = new ShipmentDataManager().GetDeliveryFee(model);

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