using System;
using System.Collections.Generic;
using System.Globalization;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.Finance.Popup;
using SISCO.Presentation.Finance.Report;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Finance.Reports;
using Devenlab.Common.Helpers;

namespace SISCO.Presentation.Finance.Forms
{
    // ReSharper disable once InconsistentNaming
    public partial class PaymentOutMCForm : BaseCrudForm<PaymentMcModel, PaymentMcDataManager>//BaseToolbarForm//
    {
        private PaymentMcDetailDataManager _detailDm = new PaymentMcDetailDataManager();
        private bool DeleteOld { get; set; }
        private string Code { get; set; }

        public PaymentOutMCForm()
        {
            InitializeComponent();

            form = this;
            Load += PaymentMcLoad;
            tbxMarketing.Leave += GetInvoice;
            McView.CustomColumnDisplayText += NumberGrid;
            McView.CellValueChanged += Changed;
            McView.CellValueChanging += Changing;
            tbxAdjusment.Leave += CalculateTotal;

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
            };

            btnTambah.Click += (sender, args) => Add();

            tsBaseBtn_Print.Click += Print;
            tsBaseBtn_PrintPreview.Click += PrintPreview;
        }

        private void PrintPreview(object sender, EventArgs e)
        {
            var print = new McPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = GridMc.DataSource;

                print.RequestParameters = false;

                var model = CurrentModel as PaymentMcModel;
                if (model == null) return;

                print.Parameters.Add(new Parameter
                {
                    Name = "Date",
                    Value = model.DateProcess,
                    Visible = false
                });

                var marketing = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default(model.MarketingId, "id", EnumSqlOperator.Equals));
                if (marketing != null)
                {
                    print.Parameters.Add(new Parameter
                    {
                        Name = "MarketingName",
                        Value = marketing.Name,
                        Visible = false
                    });
                }

                print.Parameters.Add(new Parameter
                {
                    Name = "Amount",
                    Value = model.Total,
                    Visible = false
                });

                var paymenttype = new PaymentTypeDataManager().GetFirst<PaymentTypeModel>(WhereTerm.Default(model.PaymentTypeId, "id", EnumSqlOperator.Equals));
                if (paymenttype != null)
                {
                    print.Parameters.Add(new Parameter
                    {
                        Name = "PaymentType",
                        Value = paymenttype.Name,
                        Visible = false
                    });
                }

                print.Parameters.Add(new Parameter
                {
                    Name = "Description",
                    Value = model.Description,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "TotalInvoice",
                    Value = model.TotalInvoice,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Adjustment",
                    Value = model.Adjustment,
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
            var print = new McPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = GridMc.DataSource;

                print.RequestParameters = false;
                var model = CurrentModel as PaymentMcModel;
                if (model == null) return;

                print.Parameters.Add(new Parameter
                {
                    Name = "Date",
                    Value = model.DateProcess,
                    Visible = false
                });

                var marketing = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default(model.MarketingId, "id", EnumSqlOperator.Equals));
                if (marketing != null)
                {
                    print.Parameters.Add(new Parameter
                    {
                        Name = "MarketingName",
                        Value = marketing.Name,
                        Visible = false
                    });
                }

                print.Parameters.Add(new Parameter
                {
                    Name = "Amount",
                    Value = model.Total,
                    Visible = false
                });

                var paymenttype = new PaymentTypeDataManager().GetFirst<PaymentTypeModel>(WhereTerm.Default(model.PaymentTypeId, "id", EnumSqlOperator.Equals));
                if (paymenttype != null)
                {
                    print.Parameters.Add(new Parameter
                    {
                        Name = "PaymentType",
                        Value = paymenttype.Name,
                        Visible = false
                    });
                }

                print.CreateDocument();
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                };

                print.Parameters.Add(new Parameter
                {
                    Name = "Description",
                    Value = model.Description,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "TotalInvoice",
                    Value = model.TotalInvoice,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Adjustment",
                    Value = model.Adjustment,
                    Visible = false
                });

                print.CreateDocument();
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                };

                printTool.Print();
            }
        }

        private void Changing(object sender, CellValueChangedEventArgs e)
        {
            var due = Convert.ToInt32(McView.GetRowCellValue(e.RowHandle, McView.Columns["InvoiceBalance"]));

            if (e.Column.Name == "clChecked")
            {
                if (!(bool)McView.GetRowCellValue(e.RowHandle, McView.Columns["Checked"]))
                {
                    McView.SetRowCellValue(e.RowHandle, McView.Columns["Balance"], 0);
                    McView.SetRowCellValue(e.RowHandle, McView.Columns["Payment"], due);
                    McView.SetRowCellValue(e.RowHandle, McView.Columns["Checked"], true);
                }
                else
                {
                    McView.SetRowCellValue(e.RowHandle, McView.Columns["Balance"], due);
                    McView.SetRowCellValue(e.RowHandle, McView.Columns["Payment"], 0);
                    McView.SetRowCellValue(e.RowHandle, McView.Columns["Checked"], false);
                }
            }
        }

        private void Add()
        {
            if (tbxCn.Text == "")
            {
                tbxCn.Focus();
                return;
            }

            var kwitansi =
                new PaymentInDetailDataManager().GetKwitansi(WhereTerm.Default(tbxCn.Text,
                    "invoice_ref_number", EnumSqlOperator.Equals));

            foreach (PaymentInDetailModel o in kwitansi)
            {
                for (var i = 0; i < McView.RowCount; i++)
                {
                    var code = McView.GetRowCellValue(i, McView.Columns["InvoiceCode"]).ToString();
                    if (code == o.PaymentInCode)
                    {
                        var balance = McView.GetRowCellValue(i, McView.Columns["InvoiceBalance"]);
                        McView.SetRowCellValue(i, McView.Columns["Payment"], balance);
                        McView.SetRowCellValue(i, McView.Columns["Checked"], true);
                        McView.SetRowCellValue(i, McView.Columns["Balance"], 0);
                    }
                }
            }
            
            var total = 0;
            for (var i = 0; i < McView.RowCount; i++)
            {
                total += Convert.ToInt32(McView.GetRowCellValue(i, McView.Columns["Payment"]));
            }

            tbxTotalInvoice.SetValue(total.ToString(CultureInfo.InvariantCulture));
            tbxTotal.SetValue(((Int64)tbxTotalInvoice.Value - (Int64)tbxAdjusment.Value).ToString(CultureInfo.InvariantCulture));

            tbxCn.Clear();
            tbxCn.Focus();
        }

        private void Changed(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "clState" && e.Column.Name != "clBalance")
            {
                var due = Convert.ToInt32(McView.GetRowCellValue(e.RowHandle, McView.Columns["InvoiceBalance"]));

                if (e.Column.Name == "clChecked")
                {
                    if ((bool)McView.GetRowCellValue(e.RowHandle, McView.Columns["Checked"]))
                    {
                        McView.SetRowCellValue(e.RowHandle, McView.Columns["Balance"], 0);
                        McView.SetRowCellValue(e.RowHandle, McView.Columns["Payment"], due);
                    }
                    else
                    {
                        McView.SetRowCellValue(e.RowHandle, McView.Columns["Balance"], due);
                        McView.SetRowCellValue(e.RowHandle, McView.Columns["Payment"], 0);
                    }
                }

                if (e.Column.Name == "clPayment")
                {
                    var payment = Convert.ToInt32(McView.GetRowCellValue(e.RowHandle, McView.Columns["Payment"]));
                    McView.SetRowCellValue(e.RowHandle, McView.Columns["Balance"], (due - payment));
                }

                var total = 0;
                for (var i = 0; i < McView.RowCount; i++)
                {
                    total += Convert.ToInt32(McView.GetRowCellValue(i, McView.Columns["Payment"]));
                }

                tbxTotalInvoice.SetValue(total.ToString(CultureInfo.InvariantCulture));
                tbxTotal.SetValue(((Int64)tbxTotalInvoice.Value - (Int64)tbxAdjusment.Value).ToString(CultureInfo.InvariantCulture));

                if (McView.GetRowCellValue(e.RowHandle, McView.Columns["StateChange2"]).ToString() ==
                    EnumStateChange.Select.ToString())
                {
                    McView.SetRowCellValue(e.RowHandle, McView.Columns["StateChange2"], EnumStateChange.Update);
                }

                if (McView.GetRowCellValue(e.RowHandle, McView.Columns["StateChange2"]).ToString() ==
                    EnumStateChange.Idle.ToString())
                {
                    McView.SetRowCellValue(e.RowHandle, McView.Columns["StateChange2"], EnumStateChange.Insert);
                }
            }
        }

        private void CalculateTotal(object sender, EventArgs e)
        {
            tbxTotal.SetValue(((Int64)tbxTotalInvoice.Value - (Int64)tbxAdjusment.Value).ToString(CultureInfo.InvariantCulture));
        }

        private void GetInvoice(object sender, EventArgs e)
        {
            base.OnLeave(e);

            GridMc.DataSource = null;
            McView.RefreshData();

            if (tbxMarketing.Value != null)
            {
                //var invoices = new PaymentInDataManager().Get<PaymentInModel>(new IListParameter[]
                //{
                //    WhereTerm.Default((int)tbxMarketing.Value, "marketing_id", EnumSqlOperator.Equals),
                //    WhereTerm.Default(0, "mc_total", EnumSqlOperator.GreatThan)
                //});

                var invoices = new PaymentInDataManager().GetInvoiceMarketing((int)tbxMarketing.Value);
                var ds = new List<PaymentMcDetailModel>();
                
                foreach (PaymentInModel invoice in invoices)
                {
                    var payment = _detailDm.GetPaymentMc(invoice.Id);
                    var balance = invoice.McTotal - payment;

                    if (balance > 1)
                    {
                        ds.Add(new PaymentMcDetailModel
                        {
                            InvoiceId = invoice.Id,
                            InvoiceCode = invoice.Code,
                            InvoiceDate = invoice.DateProcess,
                            InvoiceTotal = invoice.McTotal,
                            InvoiceBalance = balance,
                            Payment = 0,
                            Balance = balance,
                            Checked = false,
                            StateChange2 = EnumStateChange.Idle.ToString()
                        });
                    }
                }

                GridMc.DataSource = ds;
                McView.RefreshData();
            }
        }

        private void PaymentMcLoad(object sender, EventArgs e)
        {
            ClearForm();

            EnableBtnSearch = true;
            SearchPopup = new PaymentMcFilterPopup();

            EnableBtnPrint = true;
            EnableBtnPrintPreview = true;

            tbxMarketing.LookupPopup = new EmployeePopup(EmployeeModel.EmployeeType.Marketing);
            tbxMarketing.AutoCompleteDataManager = new EmployeeDataManager();
            tbxMarketing.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            tbxMarketing.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1 AND as_marketing", s, BaseControl.BranchId);

            tbxPayment.LookupPopup = new PaymentTypePopup();
            tbxPayment.AutoCompleteDataManager = new PaymentTypeDataManager();
            tbxPayment.AutoCompleteDisplayFormater = model => ((PaymentTypeModel)model).Name;
            tbxPayment.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            tbxAmount.IsNumber = true;
            tbxTotal.IsNumber = true;
            tbxAdjusment.IsNumber = true;
            tbxTotalInvoice.IsNumber = true;

            btnPrint.Click += btnPrint_Click;
        }

        void btnPrint_Click(object sender, EventArgs e)
        {
            var print = new McInvoicePrint();
            using (var printTool = new ReportPrintTool(print))
            {
                var model = CurrentModel as PaymentMcModel;
                print.DataSource = new List<McInvoice>
                {
                    new McInvoice
                    {
                        DateProcess = model.DateProcess,
                        InvoiceNo = model.Code,
                        InWords = InWordsHelper.Spell(model.Total).ToUpper(),
                        Description = string.Format("{0} {1}", model.Description, tbxMarketing.Text),
                        Total = model.Total,
                        CityName = BaseControl.CityName
                    }
                };

                print.CreateDocument();
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                };

                print.Print();
            }
        }

        public override void New()
        {
            base.New();

            ClearForm();
            ToolbarCode = string.Empty;
            tbxDate.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            tbxMarketing.Focus();
            GridMc.DataSource = null;
            McView.RefreshData();

            tbxTotal.ReadOnly = true;
            tbxTotalInvoice.ReadOnly = true;

            btnPrint.Visible = false;
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
                if (((PaymentMcModel) CurrentModel).MarketingId != tbxMarketing.Value) DeleteOld = true;
                Code = ((PaymentMcModel) CurrentModel).Code;
            }
            else
            {
                if (tbxDate.Text != "") 
                    Code = GetCode("mc", tbxDate.Value);
            }

            base.Save();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            Enabled = false;
            if (DeleteOld)
            {
                new PaymentMcDetailDataManager().DeActiveRows(new IListParameter[]
                {
                    WhereTerm.Default(CurrentModel.Id, "payment_mc_id", EnumSqlOperator.Equals)
                }, BaseControl.UserLogin);
            }

            var detailRepo = new PaymentMcDetailDataManager();
            var paymentRepo = new PaymentInDataManager();
            for (int i = 0; i < McView.RowCount; i++)
            {
                var state = McView.GetRowCellValue(i, McView.Columns["StateChange2"]);

                var detail = new PaymentMcDetailModel();

                if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                {
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.DateProcess = DateTime.Now;
                    detail.PaymentMcId = CurrentModel.Id;
                    detail.InvoiceId =
                            (int)McView.GetRowCellValue(i, McView.Columns["InvoiceId"]);
                    detail.InvoiceDate =
                            (DateTime)McView.GetRowCellValue(i, McView.Columns["InvoiceDate"]);
                    detail.InvoiceCode =
                            McView.GetRowCellValue(i, McView.Columns["InvoiceCode"]).ToString();
                    detail.InvoiceTotal =
                            (decimal)McView.GetRowCellValue(i, McView.Columns["InvoiceTotal"]);
                    detail.InvoiceBalance =
                            (decimal)McView.GetRowCellValue(i, McView.Columns["InvoiceBalance"]);
                    detail.Payment =
                            (decimal)McView.GetRowCellValue(i, McView.Columns["Payment"]);
                    detail.Balance =
                            (decimal)McView.GetRowCellValue(i, McView.Columns["Balance"]);
                    detail.Checked =
                            (bool)McView.GetRowCellValue(i, McView.Columns["Checked"]);

                    detail.Createdby = BaseControl.UserLogin;
                    detail.Createddate = DateTime.Now;

                    detailRepo.Save<PaymentMcDetailModel>(detail);
                }

                if (state.ToString().Equals(EnumStateChange.Update.ToString()))
                {
                    detail = detailRepo.GetFirst<PaymentMcDetailModel>(WhereTerm.Default((int)McView.GetRowCellValue(i, McView.Columns["Id"]), "id", EnumSqlOperator.Equals));
                    detail.Payment =
                            (decimal)McView.GetRowCellValue(i, McView.Columns["Payment"]);
                    detail.Balance =
                            (decimal)McView.GetRowCellValue(i, McView.Columns["Balance"]);
                    detail.Checked =
                            (bool)McView.GetRowCellValue(i, McView.Columns["Checked"]);
                    detail.Modifiedby = BaseControl.UserLogin;
                    detail.Modifieddate = DateTime.Now;

                    if (detail.Payment == 0)
                        detailRepo.DeActive(detail.Id, BaseControl.UserLogin, DateTime.Now);
                    else detailRepo.Update<PaymentMcDetailModel>(detail);
                }

                var payment = paymentRepo.GetFirst<PaymentInModel>(WhereTerm.Default(detail.InvoiceId, "id", EnumSqlOperator.Equals));
                if (payment != null)
                {
                    payment.TotalPaymentMc = _detailDm.GetPaymentMc(payment.Id);
                    payment.PaidMc = payment.TotalPaymentMc == payment.McTotal;

                    paymentRepo.Update<PaymentInModel>(payment);
                }
            }

            Enabled = true;
        }

        protected override void AfterSave()
        {
            ToolbarCode = ((PaymentMcModel)CurrentModel).Code;
            OpenData(ToolbarCode);
        }

        public override void AfterDelete()
        {
            var detail = new PaymentMcDetailDataManager().Get<PaymentMcDetailModel>(WhereTerm.Default(CurrentModel.Id, "payment_mc_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new PaymentMcDetailDataManager();
                foreach (PaymentMcDetailModel obj in detail)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                }
            }

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "" && tbxMarketing.Text != "" && tbxPayment.Text != "") return true;

            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return false;
            }

            if (tbxMarketing.Text == "")
            {
                tbxMarketing.Focus();
                return false;
            }

            if (tbxPayment.Text == "")
            {
                tbxPayment.Focus();
                return false;
            }

            return false;
        }

        protected override void PopulateForm(PaymentMcModel model)
        {
            ClearForm();
            if (model == null)
            {
                GridMc.DataSource = null;
                McView.RefreshData();

                EnabledForm(false);
                return;
            }

            tbxDate.Text = model.DateProcess.ToString(CultureInfo.InvariantCulture);
            tbxMarketing.DefaultValue = new IListParameter[] { WhereTerm.Default(model.MarketingId, "id", EnumSqlOperator.Equals) };
            tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PaymentTypeId, "id", EnumSqlOperator.Equals) };

            tbxAmount.SetValue(model.Amount.ToString(CultureInfo.InvariantCulture));
            tbxDescription.Text = model.Description;

            tbxTotalInvoice.SetValue(model.TotalInvoice.ToString(CultureInfo.InvariantCulture));
            tbxAdjusment.SetValue(model.Adjustment.ToString(CultureInfo.InvariantCulture));
            tbxTotal.SetValue(model.Total.ToString(CultureInfo.InvariantCulture));

            ToolbarCode = model.Code;

            var detail = new PaymentMcDetailDataManager().Get<PaymentMcDetailModel>(WhereTerm.Default(model.Id, "payment_mc_id", EnumSqlOperator.Equals));
            GridMc.DataSource = detail;
            McView.RefreshData();

            tbxTotal.ReadOnly = true;
            tbxTotalInvoice.ReadOnly = true;

            btnPrint.Visible = true;
        }

        protected override PaymentMcModel PopulateModel(PaymentMcModel model)
        {
            model.Code = Code;
            model.DateProcess = tbxDate.Value;
            if (tbxMarketing.Value != null) model.MarketingId = (int) tbxMarketing.Value;
            model.BranchId = BaseControl.BranchId;
            if (tbxPayment.Value != null) model.PaymentTypeId = (int) tbxPayment.Value;

            model.Description = tbxDescription.Text;
            model.Amount = tbxAmount.Value;
            model.TotalInvoice = tbxTotalInvoice.Value;
            model.Total = tbxTotal.Value;
            model.Adjustment = tbxAdjusment.Value;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override PaymentMcModel Find(string searchTerm)
        {
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<PaymentMcModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as PaymentMcModel;
            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }
    }
}
