using System;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using SISCO.App.CustomerService;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Operation.Reports;
using System.Collections.Generic;
using System.Drawing;
using SISCO.Presentation.CustomerService.Forms;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class PickupArrangementForm : BaseForm
    {
        private EmployeeRolesModel _messengerRole = new EmployeeRolesModel();
        public PickupArrangementForm()
        {
            InitializeComponent();

            DataManager = new PickupOrderDataManager();
            Load += PickupArrangementLoad;

            btnSelectAll.Click += SelectAll;
            btnDeselectAll.Click += DeselectAll;
            btnRefresh.Click += PickupArrangementLoad;

            arrangementView.ShowingEditor += Editor;
            arrangementView.CellValueChanged += Changed;
            arrangementView.RowCellStyle += ChangeColor;

            arrangementView.CustomColumnDisplayText += NumberGrid;
            gridArrangement.DoubleClick += (sa, a) => OpenRelatedForm(arrangementView, new PickupOrderForm(), "Id");

            lkpPayment.LookupPopup = new PaymentMethodPopup();
            lkpPayment.AutoCompleteDataManager = new PaymentMethodDataManager();
            lkpPayment.AutoCompleteDisplayFormater = model => ((PaymentMethodModel)model).Name;
            lkpPayment.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            btnFilter.Click += PickupArrangementLoad;

            msgLookup.ButtonClick += (sender, args) =>
            {
                var foo = BaseControl.OpenPopup(new MessengerPopup());

                var view = gridArrangement.FocusedView as GridView;
                if (view != null)
                {
                    if (string.IsNullOrEmpty(foo.Text)) return;

                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["MessengerName"], foo.Text);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["MessengerId"], foo.Value);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["StateChange2"], EnumStateChange.Update);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Confirmed"], true);
                }
            };

            msgLookup.KeyUp += (sender, args) =>
            {
                var button = sender as DevExpress.XtraEditors.ButtonEdit;
                // ReSharper disable once PossibleNullReferenceException
                var text = button.Text;
                var view = gridArrangement.FocusedView as GridView;

                if (text == "")
                {
                    if (view != null)
                    {
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns["MessengerName"], string.Empty);
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns["MessengerId"], 0);
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns["StateChange2"],
                            EnumStateChange.Update);
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Confirmed"], false);
                    }
                    return;
                }

                if (text.Length > 2)
                {
                    int count;
                    var result = new EmployeeDataManager().Get<EmployeeModel>(Paging.Instance(0,1), out count, new IListParameter[]
                    {
                        WhereTerm.Default(text, "name", EnumSqlOperator.BeginWith),
                        WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                        WhereTerm.Default(true, "as_messenger")
                    }).ToList();

                    if (result.Any())
                    {
                        if (view != null)
                        {
                            var id = result[0].Id;
                            var textValue = result[0].Name;

                            view.SetRowCellValue(view.FocusedRowHandle, view.Columns["MessengerName"], textValue);
                            view.SetRowCellValue(view.FocusedRowHandle, view.Columns["MessengerId"], id);
                            view.SetRowCellValue(view.FocusedRowHandle, view.Columns["StateChange2"],
                                EnumStateChange.Update);
                            view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Confirmed"], true);

                            var strtemp = text;
                            var startSel = strtemp.Length;
                            button.SelectionStart = startSel;
                            button.SelectionLength = textValue.Length - startSel;

                            if (args.KeyCode == Keys.Enter) view.SetRowCellValue(view.FocusedRowHandle, view.Columns["MessengerName"], result[0].Code + " - " + result[0].Name);
                        }
                    }
                }
            };

            msgLookup.Leave += (sender, args) =>
            {
                var view = gridArrangement.FocusedView as GridView;
                if (view != null)
                {
                    var id = (int)view.GetRowCellValue(view.FocusedRowHandle, view.Columns["MessengerId"]);
                    var messenger = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default(id, "id", EnumSqlOperator.Equals));
                    if (messenger != null) view.SetRowCellValue(view.FocusedRowHandle, view.Columns["MessengerName"], messenger.Code + " - " + messenger.Name);
                    else view.SetRowCellValue(view.FocusedRowHandle, view.Columns["MessengerName"], "");
                }
            };

            NavigationMenu.EnableButtons(false);
            NavigationMenu.SaveStrip.Enabled = true;

            btnSave.Click += Save;
            btnPrint.Click += Print;
            btnPrintPreview.Click += PrintPreview;
        }

        private void PrintPreview(object sender, EventArgs e)
        {
            var print = new PickupOrderPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = new PickupOrderDataManager().Get<PickupOrderModel>(new IListParameter[]
                {
                    WhereTerm.Default(false, "confirmed"),
                    WhereTerm.Default(false, "cancelled"),
                    WhereTerm.Default(false, "picked_up")
                });

                print.CreateDocument();
                printTool.ShowPreviewDialog();
            }
        }

        private void Print(object sender, EventArgs e)
        {
            var print = new PickupOrderPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = new PickupOrderDataManager().Get<PickupOrderModel>(new IListParameter[]
                {
                    WhereTerm.Default(false, "confirmed"),
                    WhereTerm.Default(false, "cancelled"),
                    WhereTerm.Default(false, "picked_up")
                });

                print.CreateDocument();
                printTool.Print();
            }
        }

        private void Changed(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "clState")
            {
                if ((int) arrangementView.GetRowCellValue(e.RowHandle, arrangementView.Columns["MessengerId"]) > 0)
                    arrangementView.SetRowCellValue(e.RowHandle, arrangementView.Columns["StateChange2"], EnumStateChange.Update);
                else
                    arrangementView.SetRowCellValue(e.RowHandle, arrangementView.Columns["StateChange2"], EnumStateChange.Select);
            }
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

        private void Editor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (arrangementView.FocusedColumn.Name == "clConfirm" && Convert.ToInt32(arrangementView.GetFocusedRowCellValue(arrangementView.Columns["MessengerId"])) == 0)
            {
                e.Cancel = true;
            }
        }

        private void SelectAll(object sender, EventArgs e)
        {
            for (int i = 0; i < arrangementView.RowCount; i++)
            {
                if (Convert.ToInt32(arrangementView.GetRowCellValue(i, "MessengerId")) > 0 && arrangementView.GetRowCellValue(i, "MessengerName").ToString() != "")
                    arrangementView.SetRowCellValue(i, arrangementView.Columns["Confirmed"], true);
            }
        }

        private void DeselectAll(object sender, EventArgs e)
        {
            for (int i = 0; i < arrangementView.RowCount; i++)
            {
                arrangementView.SetRowCellValue(i, arrangementView.Columns["Confirmed"], false);
            }
        }

        public void Save(object sender, EventArgs e)
        {
            if (arrangementView.RowCount > 0)
            {
                for (int i = 0; i < arrangementView.RowCount; i++)
                {
                    if (arrangementView.GetRowCellValue(i, "StateChange2").ToString() == EnumStateChange.Update.ToString())
                    {
                        var param = new IListParameter[]
                        {
                            WhereTerm.Default(Convert.ToInt32(arrangementView.GetRowCellValue(i, "Id")), "id", EnumSqlOperator.Equals)
                        };

                        var pickupOrder = DataManager.GetFirst<PickupOrderModel>(param);
                        pickupOrder.MessengerId = Convert.ToInt32(arrangementView.GetRowCellValue(i, "MessengerId"));
                        pickupOrder.MessengerName = arrangementView.GetRowCellValue(i, "MessengerName").ToString();
                        pickupOrder.Confirmed = Convert.ToBoolean(arrangementView.GetRowCellValue(i, "Confirmed"));
                        pickupOrder.Modifiedby = BaseControl.UserLogin;
                        pickupOrder.Modifieddate = DateTime.Now;

                        new PickupOrderDataManager().Update<PickupOrderModel>(pickupOrder);
                    }
                }

                MessageBox.Show(Resources.save_success, Resources.save_confirmation, MessageBoxButtons.OK);
            }

            PickupArrangementLoad(sender, e);
        }

        private void PickupArrangementLoad(object sender, EventArgs e)
        {
            var param = new List<WhereTerm>();
            param.Add(WhereTerm.Default(false, "confirmed"));
            param.Add(WhereTerm.Default(false, "cancelled"));
            param.Add(WhereTerm.Default(false, "picked_up"));
            param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));

            if (lkpPayment.Value != null) param.Add(WhereTerm.Default((int)lkpPayment.Value, "payment_method_id", EnumSqlOperator.Equals));
            
            var objModel = new PickupOrderDataManager().Arrangement(param.ToArray());

            // ReSharper disable once PossibleMultipleEnumeration

            gridArrangement.DataSource = objModel;

            if (objModel.Any())
            {
                btnSelectAll.Enabled = true;
                btnDeselectAll.Enabled = true;
                btnSave.Enabled = true;

                btnPrint.Enabled = true;
                btnPrintPreview.Enabled = true;

                btnSave.Enabled = true;
                NavigationMenu.SaveStrip.Enabled = true;
            }
            else
            {
                btnSelectAll.Enabled = false;
                btnDeselectAll.Enabled = false;
                btnSave.Enabled = false;

                btnPrint.Enabled = false;
                btnPrintPreview.Enabled = false;

                btnSave.Enabled = false;
                NavigationMenu.SaveStrip.Enabled = false;
            }

            gridArrangement.Focus();

            _messengerRole =
                new EmployeeRoleDataManager().GetFirst<EmployeeRolesModel>(new IListParameter[]
                {
                    new WhereTerm
                    {
                        Value = "MESSENGER",
                        TableName = "",
                        ColumnName = "role",
                        Operator = EnumSqlOperator.Equals,
                        ParamDataType = EnumParameterDataTypes.Character
                    }
                });
        }
    }
}