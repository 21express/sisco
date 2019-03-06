using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Interfaces;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.Finance.Popup;
using SISCO.Presentation.Finance.Report;
using SISCO.Presentation.MasterData.Popup;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using System.Text.RegularExpressions;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class CostForm : BaseCrudForm<CostModel, CostDataManager>, IGridChildForm//BaseToolbarForm//
    {
        public String Code { get; set; }
        private List<int> DeletedRows { get; set; }
        private List<int> DeleteAccount { get; set; }
        private decimal MaxAmount { get; set; }
        private TransactionalAccountPopup transactionPopup;

        public CostForm()
        {
            InitializeComponent();

            form = this;
            Load += CostLoad;

            TransactionalView.CustomColumnDisplayText += NumberGrid;
            CostView.CustomColumnDisplayText += NumberGrid;
            CostView.CellValueChanged += Changed;
            CostView.LostFocus += (sender, args) =>
            {
                CostView.PostEditor();
            };
            btnExport.Click += (sender, args) => ExportExcelNew(GridCost);
            btnNew.Click += (sender, args) => DetailNew();

            tbxDescription.KeyPress += FocusDescription;

            tsBaseBtn_Print.Click += Print;
            tsBaseBtn_PrintPreview.Click += PrintPreview;
            tsBaseBtn_PrintPreview.Enabled = false;

            btnImport.Click += ImportCost;

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
            };
        }

        private void ImportCost(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Directory.GetCurrentDirectory();
                dialog.Filter = @"Microsoft Excel 2007 files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (!File.Exists(dialog.FileName)) return;

                    var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; data source={0}; Extended Properties=\"Excel 12.0 Xml;HDR=YES\"", dialog.FileName);
                    using (var conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        using (var cmd = new OleDbCommand("SELECT * FROM [Sheet$]", conn))
                        {
                            var reader = cmd.ExecuteReader();
                            var typerepo = new CostTypeDataManager();

                            var ds = GridCost.DataSource as List<CostDetailModel>;
                            if (ds == null) ds = new List<CostDetailModel>();

                            while (reader != null && reader.Read())
                            {
                                var cost = new CostDetailModel();
                                var colType = reader[1].ToString();
                                var costtype = typerepo.GetFirst<CostTypeModel>(WhereTerm.Default(colType, "name", EnumSqlOperator.Equals));
                                if (costtype != null)
                                {
                                    cost.CostTypeId = costtype.Id;
                                    cost.CostType = costtype.Name;
                                    cost.Description = reader[2].ToString();
                                    cost.Amount = reader[3] != null ? Convert.ToInt64(reader[3].ToString()) : 0;
                                    cost.StateChange2 = EnumStateChange.Insert.ToString();

                                    ds.Add(cost);
                                }
                                else
                                {
                                    if (colType != "")
                                        MessageForm.Info(form, Resources.information, string.Format("Cost type '{0}' tidak terdaftar di database",colType));
                                }
                            }

                            GridCost.DataSource = ds;
                        }

                        conn.Close();
                    }
                }
            }
        }

        private void PrintPreview(object sender, EventArgs e)
        {
            var print = new CostPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                //print.DataSource = GridTransactional.DataSource;
                var transactional = print.Bands["DetailReport"] as DetailReportBand;
                transactional.DataSource = GridTransactional.DataSource;
                var cost = print.Bands["DetailReport1"] as DetailReportBand;
                cost.DataSource = GridCost.DataSource;
                var cash = print.Bands["DetailReport2"] as DetailReportBand;
                cash.DataSource = GridCash.DataSource;

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "From",
                    Value = tbxDate.Value,
                    Visible = false
                });

                var branch = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id", EnumSqlOperator.Equals));

                print.Parameters.Add(new Parameter
                {
                    Name = "Branch",
                    Value = branch.Code + " - " + branch.Name,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "HardCash",
                    Value = tbxHardCash.Value,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "BankAccount",
                    Value = lkpAccount.Text,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "TransactionalAccount",
                    Value = lkpTransactional.Text,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Total",
                    Value = (GridCost.DataSource as List<CostDetailModel>).Sum(p => p.Amount),
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "CashOnHand",
                    Value = tbxCashOnHand.Value,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Balance",
                    Value = tbxBalance.Value,
                    Visible = false
                });

                print.CreateDocument();
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                };

                printTool.ShowPreviewDialog();
            }
        }

        private void Print(object sender, EventArgs e)
        {
            var print = new CostPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                //print.DataSource = GridTransactional.DataSource;
                var transactional = print.Bands["DetailReport"] as DetailReportBand;
                transactional.DataSource = GridTransactional.DataSource;
                var cost = print.Bands["DetailReport1"] as DetailReportBand;
                cost.DataSource = GridCost.DataSource;
                var cash = print.Bands["DetailReport2"] as DetailReportBand;
                cash.DataSource = GridCash.DataSource;

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "From",
                    Value = tbxDate.Value,
                    Visible = false
                });

                var branch = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id", EnumSqlOperator.Equals));

                print.Parameters.Add(new Parameter
                {
                    Name = "Branch",
                    Value = branch.Code + " - " + branch.Name,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "HardCash",
                    Value = tbxHardCash.Value,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "BankAccount",
                    Value = lkpAccount.Text,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "TransactionalAccount",
                    Value = lkpTransactional.Text,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Total",
                    Value = (GridCost.DataSource as List<CostDetailModel>).Sum(p => p.Amount),
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "CashOnHand",
                    Value = tbxCashOnHand.Value,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Balance",
                    Value = tbxBalance.Value,
                    Visible = false
                });
                
                print.CreateDocument();
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                };

                printTool.Print();

                ((CostModel)CurrentModel).Printed = true;
                new CostDataManager().Update<CostModel>(CurrentModel);

                EnabledForm(false);
                CostView.OptionsBehavior.ReadOnly = true;
                CostView.OptionsBehavior.Editable = false;
            }
        }

        public void ExportExcelNew(GridControl grid)
        {
            CostDate.Visible = true;
            CostDate.VisibleIndex = 4;

            ExportExcel(grid);

            CostDate.Visible = false;
        }

        private void FocusDescription(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) tbxDescription.Focus();
        }

        private void Changed(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "clState")
            {
                var id = CostView.GetRowCellValue(CostView.FocusedRowHandle, CostView.Columns["Id"]) != null ?CostView.GetRowCellValue(CostView.FocusedRowHandle, CostView.Columns["Id"]).ToString() : "";
                id = id == "0" ? "" : id;
                CostView.SetRowCellValue(CostView.FocusedRowHandle, CostView.Columns["StateChange2"],
                    !string.IsNullOrEmpty(id) ? EnumStateChange.Update.ToString() : EnumStateChange.Insert.ToString());
            }

            if (e.Column.FieldName == "Amount")
            {
                //if ((decimal)CostView.GetRowCellValue(CostView.FocusedRowHandle, CostView.Columns["Amount"]) > 0)
                //{
                //    var details = GridCost.DataSource as List<CostDetailModel>;
                //    if (details.Sum(p => p.Amount) > MaxAmount)
                //    {
                //        CostView.SetRowCellValue(CostView.FocusedRowHandle, CostView.Columns["Amount"], 0);
                //        MessageBox.Show("Batas Cost tidak boleh melebihi Rp " + MaxAmount.ToString("#,#"));
                //    }
                //}

                Balance();
            }
        }

        private void CostLoad(object sender, EventArgs e)
        {
            transactionPopup = new TransactionalAccountPopup(lkpAccount, false);

            MaxAmount = 0;
            tbxDescription.CharacterCasing = CharacterCasing.Upper;
            EnableBtnSearch = true;
            SearchPopup = new CostFilterPopup();

            tbxHardCash.Value = 0;

            EnableBtnPrint = true;
            EnableBtnPrintPreview = false;

            clCostType.ButtonClick += (o, args) =>
            {
                var foo = new CostTypePopup();
                foo.ShowDialog();
                
                var view = GridCost.FocusedView as GridView;
                if (view != null)
                {
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["CostTypeId"], foo.SelectedValue);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["CostType"], foo.SelectedText);
                    view.FocusedColumn = view.VisibleColumns[2];
                }
            };

            clCostType.KeyUp += (o, args) =>
            {
                var button = o as DevExpress.XtraEditors.ButtonEdit;
                if (button == null) return;
                var text = button.Text;
                var view = GridCost.FocusedView as GridView;

                if (text == "")
                {
                    if (view != null)
                    {
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns["CostTypeId"], 0);
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns["CostType"], "");
                    }
                    return;
                }

                if (text.Length > 2)
                {
                    var result = new CostTypeDataManager().GetFirst<CostTypeModel>(WhereTerm.Default(text, "name", EnumSqlOperator.BeginWith));

                    if (result != null)
                    {
                        if (view != null)
                        {
                            var id = result.Id;
                            var textValue = result.Name;

                            view.SetRowCellValue(view.FocusedRowHandle, view.Columns["CostTypeId"], id);
                            view.SetRowCellValue(view.FocusedRowHandle, view.Columns["CostType"], textValue);

                            var strtemp = text;
                            var startSel = strtemp.Length;
                            button.SelectionStart = startSel;
                            button.SelectionLength = textValue.Length - startSel;

                            if (args.KeyCode == Keys.Enter)
                            {
                                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["CostType"], textValue);
                            }
                        }
                    }
                }
            };

            clCostType.Leave += (o, args) =>
            {
                var view = GridCost.FocusedView as GridView;
                if (view != null)
                {
                    var id = (int)view.GetRowCellValue(view.FocusedRowHandle, view.Columns["CostTypeId"]);
                    var costtype = new CostTypeDataManager().GetFirst<CostTypeModel>(WhereTerm.Default(id, "id", EnumSqlOperator.Equals));
                    if (costtype != null) view.SetRowCellValue(view.FocusedRowHandle, view.Columns["CostType"], costtype.Name);
                    else view.SetRowCellValue(view.FocusedRowHandle, view.Columns["CostType"], "");

                    view.FocusedColumn = view.VisibleColumns[2];
                }
            };

            txtDescriptionRw.Leave += (o, args) =>
            {
                var view = GridCost.FocusedView as GridView;
                if (view != null) view.FocusedColumn = view.VisibleColumns[3];
            };

            tbxPaymentType.LookupPopup = new PaymentTypePopup();
            tbxPaymentType.AutoCompleteDataManager = new PaymentTypeDataManager();
            tbxPaymentType.AutoCompleteDisplayFormater = model => ((PaymentTypeModel)model).Name;
            tbxPaymentType.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            lkpAccount.LookupPopup = new BankAccountPopup();
            lkpAccount.AutoCompleteDataManager = new BankAccountDataManager();
            lkpAccount.AutoCompleteDisplayFormater = model => ((BankAccountModel)model).AccountNo + " " + ((BankAccountModel)model).BankName;
            lkpAccount.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("account_no.StartsWith(@0) and branch_id = @1", s, BaseControl.BranchId);

            lkpAccount.TextChanged += (s, ar) =>
            {
                lkpTransactional.Value = null;
                lkpTransactional.Text = string.Empty;
            };

            lkpTransactional.LookupPopup = transactionPopup;
            lkpTransactional.AutoCompleteDataManager = new TransactionalAccountDataManager();
            lkpTransactional.AutoCompleteDisplayFormater = model => ((TransactionalAccountModel)model).Description + " Rp " + ((TransactionalAccountModel)model).CreditTotalAmount.ToString("#,#");
            lkpTransactional.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression(string.Format("(description.StartsWith(@0){0}) and credit_total_amount = 0 and closed_date = null", Regex.IsMatch(s, "^[0-9]+$") ? " or debit_total_amount = " + s : ""), s);

            btnNew.Enabled = false;
            btnImport.Enabled = false;
            btnExport.Enabled = false;

            tbxDate.TextChanged += (s, a) =>
            {
                GridCash.DataSource = new PettyCashJournalDataManager().GetSummary(BaseControl.BranchId, tbxDate.DateTime);
                CashView.RefreshData();
            };

            CashView.CustomColumnDisplayText += NumberGrid;
            GridCash.DoubleClick += (s, a) => OpenRelatedForm(CashView, new PettyCashForm());

            btnAdd.Click += btnAdd_Click;
            btnRemove.Click += btnRemove_Click;

            tbxHardCash.Leave += (s, sd) => Balance();

            tbxDate.EditValueChanged += tbxDate_EditValueChanged;
        }

        void tbxDate_EditValueChanged(object sender, EventArgs e)
        {
            transactionPopup.paymentDate = tbxDate.DateTime;
        }

        void btnRemove_Click(object sender, EventArgs e)
        {
            var row = TransactionalView.FocusedRowHandle;
            if ((int)TransactionalView.GetRowCellValue(row, TransactionalView.Columns["Id"]) > 0) DeleteAccount.Add((int)TransactionalView.GetRowCellValue(row, TransactionalView.Columns["Id"]));
            TransactionalView.DeleteSelectedRows();

            var transactional = GridTransactional.DataSource as List<CostTransactionalAccount>;
            MaxAmount = transactional.Sum(p => p.Amount);
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            if (lkpAccount.Value == null)
            {
                lkpAccount.Focus();
                return;
            }

            if (lkpTransactional.Value == null)
            {
                lkpTransactional.Focus();
                return;
            }

            var transactional = GridTransactional.DataSource as List<CostTransactionalAccount>;
            if (transactional.Where(p => p.TransactionalAccountId == (int)lkpTransactional.Value).FirstOrDefault() == null)
            {
                var t = new TransactionalAccountDataManager().GetTransactionAccountAgaintsCostTransaction((int)lkpTransactional.Value);
                if (t != null)
                {
                    transactional.Add(new CostTransactionalAccount
                    {
                        Id = 0,
                        AccountNumber = lkpAccount.Text,
                        TransactionalAccountId = (int)lkpTransactional.Value,
                        Description = t.Description,
                        Amount = t.DebitTotalAmount
                    });

                    GridTransactional.DataSource = transactional;
                    TransactionalView.RefreshData();

                    MaxAmount = transactional.Sum(p => p.Amount);
                }
                else MessageBox.Show("Transaksi sudah digunakan pada pengeluaran lain.");
            }

            lkpTransactional.Value = null;
            lkpTransactional.Text = string.Empty;

            lkpTransactional.Focus();
            Balance();
        }

        void Balance()
        {
            tbxBalance.Value = 0;
            tbxCashOnHand.Value = 0;

            var balance = new TransactionalAccountDataManager().GetWithdrawAgaintsCost(BaseControl.BranchId, tbxDate.DateTime, CurrentModel.Id == 0 ? null : (int?)CurrentModel.Id);
            var transactions = GridTransactional.DataSource as List<CostTransactionalAccount>;

            balance += transactions.Sum(p => p.Amount);
            balance += tbxHardCash.Value;
            var details = GridCost.DataSource as List<CostDetailModel>;
            if (details != null)
            {
                var cash = GridCash.DataSource as List<PettyCashSummary>;
                tbxBalance.Value = balance - details.Sum(p => p.Amount);
                tbxCashOnHand.Value = tbxBalance.Value - cash.Sum(p => p.Balance);
            }
        }

        public override void New()
        {
            base.New();

            ClearForm();
            btnNew.Enabled = true;
            btnImport.Enabled = true;
            btnExport.Enabled = false;
            DeletedRows = new List<int>();
            DeleteAccount = new List<int>();

            tbxDate.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            tbxDate.Enabled = true;
            tbxDate.Properties.Buttons[0].Enabled = true;

            tbxPaymentType.Focus();

            GridTransactional.DataSource = new List<CostTransactionalAccount>();
            TransactionalView.RefreshData();

            GridCost.DataSource = new List<CostDetailModel>();
            CostView.RefreshData();

            MaxAmount = 0;

            GridCash.DataSource = new PettyCashJournalDataManager().GetSummary(BaseControl.BranchId, tbxDate.DateTime);
            CashView.RefreshData();

            CostView.OptionsBehavior.ReadOnly = false;
            CostView.OptionsBehavior.Editable = true;
            NavigationMenu.DeleteStrip.Enabled = true;
            NavigationMenu.DetailDeleteStrip.Enabled = true;
        }

        public override void Save()
        {
            if (CostView.RowCount == 0)
            {
                //MessageBox.Show(Resources.stt_detail_empty, Resources.title_save_changes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageForm.Info(form, Resources.title_save_changes, Resources.data_empty);
                return;
            }

            var x = GridCost.DataSource as List<CostDetailModel>;
            if (x != null && x.Where(p => p.CostTypeId.ToString(CultureInfo.InvariantCulture) == "").ToList().Count > 0)
            {
                MessageForm.Info(form, Resources.information, @"Cost type dan amount tidak boleh kosong");
                CostView.Focus();
                return;
            }

            if (x != null && x.Where(p => p.Amount == 0).ToList().Count > 0)
            {
                MessageForm.Info(form, Resources.information, @"Cost type dan amount tidak boleh kosong");
                CostView.Focus();
                return;
            }

            //if (TransactionalView.RowCount == 0)
            //{
            //    MessageBox.Show("Silakan masukkan data rekening.");
            //    lkpAccount.Focus();
            //    return;
            //}

            //if (x.Sum(p => p.Amount) > MaxAmount)
            //{
            //    MessageBox.Show("Batas Cost tidak boleh melebihi Rp " + MaxAmount.ToString("#,#"));
            //    return;
            //}

            Code = CurrentModel.Id > 0 ? ((CostModel)CurrentModel).Code : (tbxDate.Text != "" ? GetCode("cost", tbxDate.Value) : "");
            if (string.IsNullOrEmpty(Code)) return;
            base.Save();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            var detailDm = new CostDetailDataManager();
            for (var i = 0; i < CostView.RowCount; i++)
            {
                var model = new CostDetailModel();
                var state = CostView.GetRowCellValue(i, CostView.Columns["StateChange2"]).ToString();
                if (state == EnumStateChange.Insert.ToString())
                {
                    model.Rowstatus = true;
                    model.Rowversion = DateTime.Now;
                    model.DateProcess = DateTime.Now;
                    model.CostId = CurrentModel.Id;
                    model.CostTypeId = (int) CostView.GetRowCellValue(i, CostView.Columns["CostTypeId"]);
                    model.Description = CostView.GetRowCellValue(i, CostView.Columns["Description"]) != null ? CostView.GetRowCellValue(i, CostView.Columns["Description"]).ToString() : "";
                    model.Amount = (Decimal) CostView.GetRowCellValue(i, CostView.Columns["Amount"]);
                    model.Createdby = BaseControl.UserLogin;
                    model.Createddate = DateTime.Now;

                    detailDm.Save<CostDetailModel>(model);
                }

                if (state == EnumStateChange.Update.ToString())
                {
                    model = detailDm.GetFirst<CostDetailModel>(WhereTerm.Default((int)CostView.GetRowCellValue(i, CostView.Columns["Id"]), "id", EnumSqlOperator.Equals));
                    model.CostTypeId = (int)CostView.GetRowCellValue(i, CostView.Columns["CostTypeId"]);
                    model.Description = CostView.GetRowCellValue(i, CostView.Columns["Description"]) != null ? CostView.GetRowCellValue(i, CostView.Columns["Description"]).ToString() : "";
                    model.Amount = (Decimal)CostView.GetRowCellValue(i, CostView.Columns["Amount"]);
                    model.Modifiedby = BaseControl.UserLogin;
                    model.Modifieddate = DateTime.Now;

                    detailDm.Update<CostDetailModel>(model);
                }
            }

            for (var i = 0; i < TransactionalView.RowCount; i++)
            {
                if ((int)TransactionalView.GetRowCellValue(i, TransactionalView.Columns["Id"]) == 0)
                {
                    var m = new CostTransactionalAccountModel();
                    m.Rowstatus = true;
                    m.Rowversion = DateTime.Now;
                    m.CostId = CurrentModel.Id;
                    m.TransactionalAccountId = (int)TransactionalView.GetRowCellValue(i, TransactionalView.Columns["TransactionalAccountId"]);
                    m.Createdby = BaseControl.UserLogin;
                    m.Createddate = DateTime.Now;

                    new CostTransactionalAccountDataManager().Save<CostTransactionalAccountModel>(m);
                }
            }

            if (DeletedRows.Count > 0)
            {
                foreach (int o in DeletedRows)
                {
                    if (o > 0) detailDm.DeActive(o, BaseControl.UserLogin, DateTime.Now);
                }
            }

           if (DeleteAccount.Count > 0)
           {
               foreach (int d in DeleteAccount)
                   new CostTransactionalAccountDataManager().DeActive(d, BaseControl.UserLogin, DateTime.Now);
           }
        }

        protected override void AfterSave()
        {
            OpenData(Code);
        }

        public override void AfterDelete()
        {
            var repo = new CostDetailDataManager();
            var detailCost =
                repo.Get<CostDetailModel>(WhereTerm.Default(CurrentModel.Id, "cost_id", EnumSqlOperator.Equals));
            if (detailCost != null)
            {
                foreach (CostDetailModel obj in detailCost)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                }    
            }

            var costTransactionals = new CostTransactionalAccountDataManager().Get<CostTransactionalAccountModel>(WhereTerm.Default(CurrentModel.Id, "cost_id"));
            if (costTransactionals != null)
            {
                foreach (var c in costTransactionals) new CostTransactionalAccountDataManager().DeActive(c.Id, BaseControl.UserLogin, DateTime.Now);
            }

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "" && tbxPaymentType.Value != null) return true;

            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return false;
            }

            if (tbxPaymentType.Value == null)
            {
                tbxPaymentType.Focus();
                return false;
            }

            return false;
        }

        protected override void PopulateForm(CostModel model)
        {
            ClearForm();
            if (model == null) return;

            NavigationMenu.DeleteStrip.Enabled = true;
            NavigationMenu.DetailDeleteStrip.Enabled = true;

            btnNew.Enabled = true;
            btnImport.Enabled = true;
            btnExport.Enabled = true;
            DeletedRows = new List<int>();
            DeleteAccount = new List<int>();

            tbxDate.Text = model.DateProcess.ToString(CultureInfo.InvariantCulture);
            if (model.PaymentTypeId != null)
                tbxPaymentType.DefaultValue = new IListParameter[] { WhereTerm.Default((int) model.PaymentTypeId, "id", EnumSqlOperator.Equals) };

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            ToolbarCode = model.Code;
            tbxDescription.Text = model.Description;

            tbxHardCash.Value = model.HardCash == null ? 0 : (decimal)model.HardCash;

            var detail =
                new CostDetailDataManager().Get<CostDetailModel>(WhereTerm.Default(model.Id, "cost_id",
                    EnumSqlOperator.Equals));

            detail.ToList().ForEach(x => x.CostDate = model.DateProcess.Date);

            GridCost.DataSource = detail;
            CostView.RefreshData();
            tsBaseBtn_PrintPreview.Enabled = false;

            EnabledForm(!model.Printed);
            CostView.OptionsBehavior.ReadOnly = model.Printed;
            CostView.OptionsBehavior.Editable = !model.Printed;

            GridCash.DataSource = new PettyCashJournalDataManager().GetSummary(BaseControl.BranchId, tbxDate.DateTime);
            CashView.RefreshData();

            GridTransactional.DataSource = new CostTransactionalAccountDataManager().GetTransactions(model.Id);
            TransactionalView.RefreshData();

            Balance();
        }

        protected override CostModel PopulateModel(CostModel model)
        {
            model.Code = Code;
            model.DateProcess = tbxDate.Value;
            model.BranchId = BaseControl.BranchId;
            model.PaymentTypeId = tbxPaymentType.Value;
            model.Description = tbxDescription.Text;
            model.HardCash = tbxHardCash.Value;

            var x = GridCost.DataSource as List<CostDetailModel>;
            if (x != null)
            {
                model.Total = x.Sum(p => p.Amount);
            }

            if (model.Id == 0) model.Createdpc = Environment.MachineName;
            else model.Modifiedpc = Environment.MachineName;

            return model;
        }

        protected override CostModel Find(string searchTerm)
        {
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            CurrentModel = DataManager.GetFirst<CostModel>(param);
            PopulateForm(CurrentModel as CostModel);

            return CurrentModel as CostModel;
        }

        public override void Info()
        {
            var model = CurrentModel as CostModel;

            if (model != null)
            {
                info.CreatedPc = model.Createdpc;
                info.ModifiedPc = model.Modifiedpc;
            }

            base.Info();
        }

        public void DetailNew()
        {
            //if (TransactionalView.RowCount == 0)
            //{
            //    lkpAccount.Focus();
            //    return;
            //}

            if (((CostModel)CurrentModel).Printed)
            {
                MessageBox.Show("Data sudah di print tidak bisa dilakukan perubahan data.");
                return;
            }

            var grid = GridCost.DataSource as List<CostDetailModel>;
            if (grid == null) grid = new List<CostDetailModel>();

            grid.Add(new CostDetailModel());
            GridCost.DataSource = grid;

            CostView.RefreshData();
            CostView.FocusedRowHandle = grid.Count - 1;
            CostView.SelectRow(grid.Count-1);
            CostView.FocusedColumn = CostView.VisibleColumns[1];

            CostView.Focus();
        }

        public void DetailDelete()
        {
            if (((CostModel)CurrentModel).Printed)
            {
                MessageBox.Show("Data sudah di print tidak bisa dilakukan perubahan data.");
                return;
            }

            var rowHandle = CostView.FocusedRowHandle;
            if (CostView.GetRowCellValue(rowHandle, CostView.Columns["Id"]) != null) DeletedRows.Add((int)CostView.GetRowCellValue(rowHandle, CostView.Columns["Id"]));
            
            CostView.DeleteSelectedRows();
        }
    }
}