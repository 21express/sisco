using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraGrid.Views.Base;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.Finance.Popup;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Finance.Report;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class PaymentOutCollectInForm : BaseCrudForm<PaymentOutCollectInModel, PaymentOutCollectInDataManager>//BaseToolbarForm//
    {
        private PaymentOutCollectInDetailDataManager _detailDm = new PaymentOutCollectInDetailDataManager();
        private bool DeleteOld { get; set; }
        private string Code { get; set; }

        public PaymentOutCollectInForm()
        {
            InitializeComponent();

            form = this;
            Load += PaymentOutCollectInLoad;
            CollectOutView.CustomColumnDisplayText += NumberGrid;
            tbxOrigin.Leave += GetInvoice;

            CollectOutView.CellValueChanged += Changed;
            CollectOutView.CellValueChanging += Changing;
            tbxAdjustment.Leave += CalculateTotal;

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "owner_branch_id", EnumSqlOperator.Equals)
            };

            btnTambah.Click += (sender, args) => Add();
        }

        private void Changing(object sender, CellValueChangedEventArgs e)
        {
            var due = Convert.ToInt32(CollectOutView.GetRowCellValue(e.RowHandle, CollectOutView.Columns["InvoiceBalance"]));

            if (e.Column.Name == "clChecked")
            {
                if (!(bool)CollectOutView.GetRowCellValue(e.RowHandle, CollectOutView.Columns["Checked"]))
                {
                    CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Balance"], 0);
                    CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Payment"], due);
                    CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Checked"], true);
                }
                else
                {
                    CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Balance"], due);
                    CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Payment"], 0);
                    CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Checked"], false);
                }
            }
        }

        private void Add()
        {
            if (tbxBarcode.Text == "")
            {
                tbxBarcode.Focus();
                return;
            }

            for (var i = 0; i < CollectOutView.RowCount; i++)
            {
                var code = CollectOutView.GetRowCellValue(i, CollectOutView.Columns["InvoiceCode"]).ToString();
                if (code == tbxBarcode.Text)
                {
                    var balance = CollectOutView.GetRowCellValue(i, CollectOutView.Columns["InvoiceBalance"]);
                    CollectOutView.SetRowCellValue(i, CollectOutView.Columns["Payment"], balance);
                    CollectOutView.SetRowCellValue(i, CollectOutView.Columns["Checked"], true);
                    CollectOutView.SetRowCellValue(i, CollectOutView.Columns["Balance"], 0);
                }
            }

            SetTotal();

            tbxBarcode.Clear();
            tbxBarcode.Focus();
        }

        private void CalculateTotal(object sender, EventArgs e)
        {
            tbxTotal.SetValue(((Int64)tbxTotalSales.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));
        }

        private void Changed(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "clState" && e.Column.Name != "clBal")
            {
                var due = Convert.ToInt32(CollectOutView.GetRowCellValue(e.RowHandle, CollectOutView.Columns["InvoiceBalance"]));

                if (e.Column.Name == "clChecked")
                {
                    if ((bool)CollectOutView.GetRowCellValue(e.RowHandle, CollectOutView.Columns["Checked"]))
                    {
                        CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Balance"], 0);
                        CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Payment"], due);
                    }
                    else
                    {
                        CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Balance"], due);
                        CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Payment"], 0);
                    }
                }

                if (e.Column.Name == "clPayment")
                {
                    var payment = Convert.ToInt32(CollectOutView.GetRowCellValue(e.RowHandle, CollectOutView.Columns["Payment"]));
                    CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["Balance"], (due - payment));
                }

                SetTotal();

                if (CollectOutView.GetRowCellValue(e.RowHandle, CollectOutView.Columns["StateChange2"]).ToString() ==
                    EnumStateChange.Select.ToString())
                {
                    CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["StateChange2"], EnumStateChange.Update);
                }

                if (CollectOutView.GetRowCellValue(e.RowHandle, CollectOutView.Columns["StateChange2"]).ToString() ==
                    EnumStateChange.Idle.ToString())
                {
                    CollectOutView.SetRowCellValue(e.RowHandle, CollectOutView.Columns["StateChange2"], EnumStateChange.Insert);
                }
            }
        }

        private void SetTotal()
        {
            var total = 0;
            for (var i = 0; i < CollectOutView.RowCount; i++)
            {
                total += Convert.ToInt32(CollectOutView.GetRowCellValue(i, CollectOutView.Columns["Payment"]));
            }

            tbxTotalSales.SetValue(total.ToString(CultureInfo.InvariantCulture));
            tbxTotal.SetValue(((Int64)tbxTotalSales.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));
        }

        private void GetInvoice(object sender, EventArgs e)
        {
            base.OnLeave(e);

            if (tbxOrigin.Value != null)
            {
                //var invoices =
                //    new PaymentInCollectInDetailDataManager().Get<PaymentInCollectInDetailModel>(new IListParameter[]
                //    {
                //        WhereTerm.Default((int) tbxOrigin.Value, "branch_id", EnumSqlOperator.Equals),
                //        WhereTerm.Default("CASH", "collect_payment_method", EnumSqlOperator.Equals)
                //    });
                GridCollectOut.DataSource = null;
                CollectOutView.RefreshData();

                //var ds = (from invoice in invoices
                //          where invoice.InvoiceId != null
                //          let payment = _detailDm.GetPaymentOutCollectIn((int)invoice.InvoiceId)
                //          let balance = invoice.InvoiceTotal - payment
                //          where balance > 0
                //          select new PaymentOutCollectInDetailModel
                //          {
                //              PaymentInCollectInCode = invoice.PaymentInCollectInCode,
                //              InvoiceId = (int)invoice.InvoiceId,
                //              InvoiceCode = invoice.InvoiceCode,
                //              InvoiceDate = invoice.InvoiceDate != null ? (DateTime)invoice.InvoiceDate : DateTime.Now,
                //              InvoiceTotal = invoice.InvoiceTotal,
                //              InvoiceBalance = balance,
                //              Payment = 0,
                //              Balance = balance,
                //              Checked = false,
                //              Paid = false,
                //              CollectPaymentMethod = invoice.CollectPaymentMethod,
                //              StateChange2 = EnumStateChange.Idle.ToString()
                //          }).ToList();

                var ds = new PaymentOutCollectInDetailDataManager().GetPaidCollectIn((int)tbxOrigin.Value, "CASH", BaseControl.BranchId);

                GridCollectOut.DataSource = ds;
                CollectOutView.RefreshData();
            }
            else
            {
                GridCollectOut.DataSource = null;
                CollectOutView.RefreshData();
            }
        }

        private void PaymentOutCollectInLoad(object sender, EventArgs e)
        {
            ClearForm();
            EnabledForm(false);

            EnableBtnSearch = true;
            SearchPopup = new PaymentOutCollectInFilterPopup();

            tbxOrigin.LookupPopup = new BranchPopup();
            tbxOrigin.AutoCompleteDataManager = new BranchDataManager();
            tbxOrigin.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            tbxOrigin.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0))", s);

            tbxPayment.LookupPopup = new PaymentTypePopup();
            tbxPayment.AutoCompleteDataManager = new PaymentTypeDataManager();
            tbxPayment.AutoCompleteDisplayFormater = model => ((PaymentTypeModel)model).Name;
            tbxPayment.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            tbxAmount.IsNumber = true;
            tbxTotal.IsNumber = true;
            tbxAdjustment.IsNumber = true;
            tbxTotalSales.IsNumber = true;

            tsBaseBtn_PrintPreview.Click += PrintPreview;
        }

        private void PrintPreview(object sender, EventArgs e)
        {
            var print = new PaymentOutCollectInPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = new PaymentOutCollectInDetailDataManager().Get<PaymentOutCollectInDetailModel>(WhereTerm.Default(CurrentModel.Id, "payment_out_collect_in_id", EnumSqlOperator.Equals));

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "Code",
                    Value = ((PaymentOutCollectInModel)CurrentModel).Code,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "OrigBranchName",
                    Value = tbxOrigin.Text,
                    Visible = false
                });

                var branch = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id"));
                print.Parameters.Add(new Parameter
                {
                    Name = "DestBranchName",
                    Value = string.Format("{0} - {1}", branch.Code, branch.Name),
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Amount",
                    Value = tbxAmount.Value,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "PaymentType",
                    Value = tbxPayment.Text,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "OrigBranchName",
                    Value = string.Format("{0} - {1}", branch.Code, branch.Name),
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Total",
                    Value = ((PaymentOutCollectInModel)CurrentModel).Total,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Adjustment",
                    Value = ((PaymentOutCollectInModel)CurrentModel).Adjustment,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Note",
                    Value = ((PaymentOutCollectInModel)CurrentModel).Description,
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

        public override void New()
        {
            base.New();
            ClearForm();
            ToolbarCode = string.Empty;
            
            tbxDate.Focus();
            GridCollectOut.DataSource = null;
            CollectOutView.RefreshData();

            tbxTotal.ReadOnly = true;
            tbxTotalSales.ReadOnly = true;

            EnableBtnPrint = false;
            EnableBtnPrintPreview = false;
        }

        public override void Save()
        {
            if (tbxAmount.Value != tbxTotal.Value)
            {
                MessageForm.Info(this, Resources.information, Resources.total_invoice);
                tbxAmount.Focus();
                return;
            }

            DeleteOld = false;

            if (CurrentModel.Id > 0)
            {
                if (((PaymentOutCollectInModel) CurrentModel).BranchId != tbxOrigin.Value) DeleteOld = true;
                Code = ((PaymentOutCollectInModel) CurrentModel).Code;
            }
            else
            {
                if (tbxDate.Text != "") 
                    Code = GetCode("collectout", tbxDate.Value);
            }

            base.Save();
        }

        protected override void  SaveDetail(bool isUpdate = false)
        {
            Enabled = false;
            if (DeleteOld)
            {
                new PaymentOutCollectInDetailDataManager().DeActiveRows(new IListParameter[]
                {
                    WhereTerm.Default(CurrentModel.Id, "payment_out_collect_id_id", EnumSqlOperator.Equals)
                }, BaseControl.UserLogin);
            }

            for (int i = 0; i < CollectOutView.RowCount; i++)
            {
                var state = CollectOutView.GetRowCellValue(i, CollectOutView.Columns["StateChange2"]);

                var detail = new PaymentOutCollectInDetailModel();

                if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                {
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.DateProcess = DateTime.Now;
                    detail.PaymentOutCollectInId = CurrentModel.Id;
                    detail.PaymentInCollectInCode = CollectOutView.GetRowCellValue(i, CollectOutView.Columns["PaymentInCollectInCode"]).ToString();
                    detail.InvoiceId =
                            (int)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["InvoiceId"]);
                    detail.InvoiceDate =
                            (DateTime)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["InvoiceDate"]);
                    detail.InvoiceCode =
                            CollectOutView.GetRowCellValue(i, CollectOutView.Columns["InvoiceCode"]).ToString();
                    detail.InvoiceTotal =
                            (decimal)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["InvoiceTotal"]);
                    detail.InvoiceBalance =
                            (decimal)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["InvoiceBalance"]);
                    detail.Payment =
                            (decimal)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["Payment"]);
                    detail.Balance =
                            (decimal)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["Balance"]);
                    detail.Checked =
                            (bool)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["Checked"]);
                    detail.Paid = false;
                    detail.CollectPaymentMethod = CollectOutView.GetRowCellValue(i, CollectOutView.Columns["CollectPaymentMethod"]).ToString();

                    detail.Createdby = BaseControl.UserLogin;
                    detail.Createddate = DateTime.Now;

                    if (detail.Payment > 0) _detailDm.Save<PaymentOutCollectInDetailModel>(detail);
                }

                if (state.ToString().Equals(EnumStateChange.Update.ToString()))
                {
                    detail = _detailDm.GetFirst<PaymentOutCollectInDetailModel>(WhereTerm.Default((int)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["Id"]), "id", EnumSqlOperator.Equals));
                    detail.Payment =
                            (decimal)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["Payment"]);
                    detail.Balance =
                            (decimal)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["Balance"]);
                    detail.Checked =
                            (bool)CollectOutView.GetRowCellValue(i, CollectOutView.Columns["Checked"]);
                    detail.Modifiedby = BaseControl.UserLogin;
                    detail.Modifieddate = DateTime.Now;

                    if (detail.Payment == 0)
                        _detailDm.DeActive(detail.Id, BaseControl.UserLogin, DateTime.Now);
                    else
                        _detailDm.Update<PaymentOutCollectInDetailModel>(detail);
                }
            }

            Enabled = true;
        }

        protected override void AfterSave()
        {
            ToolbarCode = ((PaymentOutCollectInModel)CurrentModel).Code;
            OpenData(ToolbarCode);
        }

        public override void AfterDelete()
        {
            var detail = new PaymentOutCollectInDetailDataManager().Get<PaymentOutCollectInDetailModel>(WhereTerm.Default(CurrentModel.Id, "payment_out_collect_in_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new PaymentOutCollectInDetailDataManager();
                foreach (PaymentOutCollectInDetailModel obj in detail)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                }
            }

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "" && tbxOrigin.Text != "" && tbxPayment.Text != "") return true;
            return false;
        }

        protected override void PopulateForm(PaymentOutCollectInModel model)
        {
            if (model == null) return;

            tbxDate.Text = model.DateProcess.ToString(CultureInfo.InvariantCulture);
            ToolbarCode = model.Code;
            tbxOrigin.DefaultValue = new IListParameter[] { WhereTerm.Default(model.BranchId, "id", EnumSqlOperator.Equals) };
            tbxAmount.SetValue(model.Amount.ToString(CultureInfo.InvariantCulture));
            tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PaymentTypeId, "id", EnumSqlOperator.Equals) };
            tbxDescription.Text = model.Description;

            tbxTotalSales.SetValue(model.TotalInvoice);
            tbxAdjustment.SetValue(model.Adjustment);
            tbxTotal.SetValue(model.Total);

            var detail = new PaymentOutCollectInDetailDataManager().Get<PaymentOutCollectInDetailModel>(WhereTerm.Default(model.Id, "payment_out_collect_in_id", EnumSqlOperator.Equals));
            GridCollectOut.DataSource = detail;
            CollectOutView.RefreshData();

            tbxTotal.ReadOnly = true;
            tbxTotalSales.ReadOnly = true;

            EnableBtnPrint = true;
            EnableBtnPrintPreview = true;
        }

        protected override PaymentOutCollectInModel PopulateModel(PaymentOutCollectInModel model)
        {
            model.Code = Code;
            model.DateProcess = tbxDate.Value;
            if (tbxOrigin.Value != null) model.BranchId = (int) tbxOrigin.Value;
            model.OwnerBranchId = BaseControl.BranchId;
            model.Amount = tbxAmount.Value;
            if (tbxPayment.Value != null) model.PaymentTypeId = (int) tbxPayment.Value;
            model.Description = tbxDescription.Text;

            model.TotalInvoice = tbxTotalSales.Value;
            model.Adjustment = tbxAdjustment.Value;
            model.Total = tbxTotal.Value;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override PaymentOutCollectInModel Find(string searchTerm)
        {
            var param = new IListParameter[]
            {
                WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
            };
            var obj = DataManager.GetFirst<PaymentOutCollectInModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as PaymentOutCollectInModel;
            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            var model = CurrentModel as PaymentOutCollectInModel;
            if (model != null && model.Id > 0 && model.Verified)
            {
                EnabledForm(false);
                tsBaseBtn_Delete.Enabled = false;
                tsBaseBtn_Save.Enabled = false;

                AutoClosingMessageBox.Show("Pembayaran sudah di verifikasi Audit");
            }
        }
    }
}
