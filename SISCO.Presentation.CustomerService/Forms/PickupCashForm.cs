using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Views.Grid;
using SISCO.App.CustomerService;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
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
    public partial class PickupCashForm : BaseCrudForm<PickupOrderModel, PickupOrderDataManager>//BaseToolbarForm//
    {
        public PickupCashForm()
        {
            InitializeComponent();

            form = this;
            Load += LoadPickupCash;
            btnFilter.Click += FilterList;

            PickupOrderView.CustomColumnDisplayText += NumberGrid;
            PickupOrderView.RowStyle += ChangeColor;
            PickupOrderGrid.DoubleClick += GenerateFormData;

            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id"), WhereTerm.Default(1, "payment_method_id") };
        }

        private void FilterList(object sender, EventArgs e)
        {
            var param = new List<WhereTerm>();
            param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            param.Add(WhereTerm.Default(false, "cancelled"));

            if (tbxFilterDateFrom.DateTime > new DateTime(1900, 1, 1, 0, 0, 0))
            {
                var from = tbxFilterDateFrom.DateTime;
                param.Add(WhereTerm.Default(new DateTime(from.Year, from.Month, from.Day, 0, 0, 0), "date_process", EnumSqlOperator.GreatThanEqual));
            }

            if (tbxFilterDateTo.DateTime > new DateTime(1900, 1, 1, 23, 59, 59))
            {
                var to = tbxFilterDateTo.DateTime;
                param.Add(WhereTerm.Default(new DateTime(to.Year, to.Month, to.Day, 23, 59, 59), "date_process", EnumSqlOperator.LesThanEqual));
            }

            param.Add(WhereTerm.Default(cbxReceived.Checked, "received_cash"));

            var objModel = new PickupOrderDataManager().GridCash(param.ToArray());
            PickupOrderGrid.DataSource = objModel;
        }

        private void GenerateFormData(object sender, EventArgs e)
        {
            var rows = PickupOrderView.GetSelectedRows();

            if (rows.Count() > 0) OpenData(PickupOrderView.GetRowCellValue(rows[0], "Id").ToString());
        }

        private void ChangeColor(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                if ((bool)view.GetRowCellValue(e.RowHandle, view.Columns["ReceivedCash"]))
                {
                    e.Appearance.ForeColor = Color.Green;
                }
                else
                {
                    e.Appearance.ForeColor = Color.Red;
                }
            }
        }

        private void LoadPickupCash(object sender, EventArgs e)
        {
            ucConfirmed.Icon = false;
            ucPickup.Icon = false;

            _SetControlEnableState(pnlSearch, true);
            cbxReceived.Checked = false;

            var objModel = new PickupOrderDataManager().GridCash(new IListParameter[]{
                WhereTerm.Default(BaseControl.BranchId, "branch_id"),
                WhereTerm.Default(false, "cancelled"),
                WhereTerm.Default(false, "received_cash")
            });
            PickupOrderGrid.DataSource = objModel;
        }

        protected override bool ValidateForm()
        {
            if (tbxCash.Value > 0) return true;
            return false;
        }

        protected override void PopulateForm(PickupOrderModel model)
        {
            _ClearForm(pnlBlue);
            _ClearForm(pnlGreen);
            _ClearForm(pnlPink);

            if (model == null) return;

            ToolbarCode = model.Id.ToString();
            tbxDate.Text = model.DateProcess.ToString("dd-MM-yyyy");
            tbxPickupDate.Text = model.PickupDate.ToString("dd-MM-yyyy");
            tbxPickupTime.Text = model.PickupDate.ToString("HH:mm");

            if (model.NewCustomer) tbxCustomer.Text = model.CustomerName;
            else if (model.CustomerId != null)
            {
                var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)model.CustomerId, "id"));
                tbxCustomer.Text = customer.Name;
            }

            tbxAddress.Text = model.CustomerAddress;
            tbxPhone.Text = model.CustomerPhone;
            tbxContact.Text = model.CustomerContact;
            tbxNote.Text = model.Note;

            var vehicle = new VehicleTypeDataManager().GetFirst<VehicleTypeModel>(WhereTerm.Default(model.VehicleTypeId, "id", EnumSqlOperator.Equals));
            tbxVehicle.Text = vehicle.Name;
            
            if (model.MessengerId > 0)
            {
                var messenger = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default(model.MessengerId, "id", EnumSqlOperator.Equals));
                tbxMessenger.Text = messenger != null ? messenger.Name : string.Empty;
            }

            var package = new PackageTypeDataManager().GetFirst<PackageTypeModel>(WhereTerm.Default(model.PackageTypeId, "id", EnumSqlOperator.Equals));
            tbxPackage.Text = package.Name;

            var service = new ServiceDataManager().GetFirst<ServiceTypeModel>(WhereTerm.Default(model.ServiceTypeId, "id", EnumSqlOperator.Equals));
            tbxServiceType.Text = service.Name;

            var payment = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default(model.PaymentMethodId, "id", EnumSqlOperator.Equals));
            tbxPayment.Text = payment.Name;

            tbxPiece.SetValue(model.TtlPiece.ToString());
            tbxWeight.SetValue(model.TtlGrossWeight.ToString());
            tbxDimensi.Text = model.Dimension;
            tbxGoods.Text = model.NatureOfGoods;
            tbxTotal.SetValue(model.Total.ToString(BaseControl.culture));
            tbxCash.SetValue(model.TotalCash > 0 ? (decimal) model.TotalCash : 0);

            ucConfirmed.Icon = model.Confirmed;
            ucPickup.Icon = model.PickedUp;

            tbxCash.Focus();
        }

        protected override PickupOrderModel PopulateModel(PickupOrderModel model)
        {
            model.TotalCash = tbxCash.Value;
            model.ReceivedCash = true;

            model.Modifieddate = DateTime.Now;
            model.Modifiedby = BaseControl.UserLogin;
            model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override PickupOrderModel Find(string searchTerm)
        {
            int value;
            int.TryParse(tsBaseTxt_Code.Text, out value);
            var param = new IListParameter[]
                {
                    WhereTerm.Default(value, "id", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<PickupOrderModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as PickupOrderModel;

            info.CreatedPc = model.CreatedPc;
            info.ModifiedPc = model.ModifiedPc;

            base.Info();
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            var model = CurrentModel as PickupOrderModel;
            if (model != null && model.Id > 0)
            {
                _SetControlEnableState(pnlBlue, false);
                _SetControlEnableState(pnlGreen, false);
                _SetControlEnableState(pnlPink, false);

                if (model.ReceivedCash != null && (bool) model.ReceivedCash)
                {
                    tsBaseBtn_Save.Enabled = false;
                }
                else
                {
                    tbxCash.Enabled = true;
                }
            }
        }
    }
}
