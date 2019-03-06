using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Columns;
using SISCO.App.CustomerService;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.MasterData.Popup;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using SISCO.Presentation.CustomerService.Forms;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class PickupResultForm : BaseForm
    {
        public PickupResultForm()
        {
            InitializeComponent();

            DataManager = new PickupOrderDataManager();
            Load += PickupResultLoad;

            btnSelectAll.Click += SelectAll;
            btnDeselectAll.Click += DeselectAll;
            btnRefresh.Click += PickupResultLoad;

            NavigationMenu.EnableButtons(false);
            NavigationMenu.SaveStrip.Enabled = true;

            btnSave.Click += Save;
            btnFilter.Click += PickupResultLoad;

            resultView.CellValueChanged += Changed;
            resultView.RowCellStyle += ChangeColor;
            resultView.CustomColumnDisplayText += NumberGrid;

            lkpPayment.LookupPopup = new PaymentMethodPopup();
            lkpPayment.AutoCompleteDataManager = new PaymentMethodDataManager();
            lkpPayment.AutoCompleteDisplayFormater = model => ((PaymentMethodModel)model).Name;
            lkpPayment.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            gridResult.DoubleClick += (sa, a) => OpenRelatedForm(resultView, new PickupOrderForm(), "Id");
        }

        private void Changed(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "clState") resultView.SetRowCellValue(e.RowHandle, resultView.Columns["StateChange2"], EnumStateChange.Update);
        }

        private void PickupResultLoad(object sender, EventArgs e)
        {
            var p = new List<WhereTerm>();
            p.Add(WhereTerm.Default(true, "confirmed"));
            p.Add(WhereTerm.Default(false, "cancelled"));
            p.Add(WhereTerm.Default(false, "picked_up"));
            p.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));

            if (tbxFilterMessenger.Value > 0)
            {
                p.Add(WhereTerm.Default(Convert.ToInt32(tbxFilterMessenger.Value), "messenger_id", EnumSqlOperator.Equals));
            }

            if (lkpPayment.Value != null)
            {
                p.Add(WhereTerm.Default((int)lkpPayment.Value, "payment_method_id", EnumSqlOperator.Equals));
            }

            // ReSharper disable once CoVariantArrayConversion
            IListParameter[] param = p.ToArray();
            var objModel = new PickupOrderDataManager().Arrangement(param);

            gridResult.DataSource = objModel;

            if (objModel.Any())
            {
                btnSelectAll.Enabled = true;
                btnDeselectAll.Enabled = true;
                btnRefresh.Enabled = true;
                btnSave.Enabled = true;

                btnSave.Enabled = true;
                NavigationMenu.SaveStrip.Enabled = true;
            }
            else
            {
                btnSelectAll.Enabled = false;
                btnDeselectAll.Enabled = false;
                btnRefresh.Enabled = false;
                btnSave.Enabled = false;

                btnSave.Enabled = false;
                NavigationMenu.SaveStrip.Enabled = false;
            }

            var msg = new EmployeeRoleDataManager().GetFirst<EmployeeRolesModel>(new IListParameter[] { new WhereTerm { Value = "MESSENGER", TableName = "", ColumnName = "role", Operator = EnumSqlOperator.Equals, ParamDataType = EnumParameterDataTypes.Character } });
            tbxFilterMessenger.LookupPopup = new MessengerPopup();
            tbxFilterMessenger.AutoCompleteDataManager = new EmployeeDataManager();
            tbxFilterMessenger.AutoCompleteText = model => ((EmployeeModel) model).Name;
            tbxFilterMessenger.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            tbxFilterMessenger.AutoCompleteWheretermFormater = s => new IListParameter[]
                {
                    WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith),
                    WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                    WhereTerm.Default(true, "as_messenger")
                };
        }

        private void ChangeColor(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                if (view != null && view.GetRowCellValue(e.RowHandle, view.Columns["PaymentMethodName"]).Equals("CASH"))
                {
                    e.Appearance.ForeColor = Color.Red;
                }
            }
        }

        private void SelectAll(object sender, EventArgs e)
        {
            // ReSharper disable once UnusedVariable
            foreach (GridColumn column in resultView.Columns)
                for (int i = 0; i < resultView.RowCount; i++)
                {
                    resultView.SetRowCellValue(i, resultView.Columns["PickedUp"], true);
                }
        }

        private void DeselectAll(object sender, EventArgs e)
        {
            for (int i = 0; i < resultView.RowCount; i++)
            {
                resultView.SetRowCellValue(i, resultView.Columns["PickedUp"], false);
            }
        }

        public void Save(object sender, EventArgs e)
        {
            if (resultView.RowCount > 0)
            {
                for (int i = 0; i < resultView.RowCount; i++)
                {
                    if (resultView.GetRowCellValue(i, "StateChange2").ToString() == EnumStateChange.Update.ToString())
                    {
                        var param = new IListParameter[]
                        {
                            WhereTerm.Default(Convert.ToInt32(resultView.GetRowCellValue(i, "Id")), "id", EnumSqlOperator.Equals)
                        };

                        var pickupOrder = DataManager.GetFirst<PickupOrderModel>(param);
                        pickupOrder.PickedUp = Convert.ToBoolean(resultView.GetRowCellValue(i, "PickedUp"));
                        pickupOrder.PickupNote = resultView.GetRowCellValue(i, "PickupNote").ToString();
                        pickupOrder.TtlPiece = (sbyte)resultView.GetRowCellValue(i, "TtlPiece");
                        pickupOrder.TtlGrossWeight = (decimal)resultView.GetRowCellValue(i, "TtlGrossWeight");
                        pickupOrder.Modifiedby = BaseControl.UserLogin;
                        pickupOrder.Modifieddate = DateTime.Now;
                        pickupOrder.StatusId = (int) EnumTrackingStatus.Pickup;

                        new PickupOrderDataManager().Update<PickupOrderModel>(pickupOrder);
                    }
                }

                MessageBox.Show(Resources.save_success, Resources.save_confirmation, MessageBoxButtons.OK);
            }

            PickupResultLoad(sender, e);
        }
    }
}
