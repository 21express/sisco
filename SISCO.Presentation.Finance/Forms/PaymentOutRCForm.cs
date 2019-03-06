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

namespace SISCO.Presentation.Finance.Forms
{
    // ReSharper disable once InconsistentNaming
    public partial class PaymentOutRCForm : BaseCrudForm<PaymentRcModel, PaymentRcDataManager>
    {
        private PaymentRcDetailDataManager _detailDm = new PaymentRcDetailDataManager();
        private bool DeleteOld { get; set; }
        private string Code { get; set; }

        public PaymentOutRCForm()
        {
            InitializeComponent();

            form = this;
            Load += PaymentRcLoad;
            tbxCustomer.Leave += GetInvoice;
            RcView.CustomColumnDisplayText += NumberGrid;
            RcView.CellValueChanged += Changed;
            RcView.CellValueChanging += Changing;
            tbxAdjustment.Leave += CalculateTotal;

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
            var print = new RcPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = GridRc.DataSource;

                print.RequestParameters = false;
                var model = CurrentModel as PaymentRcModel;
                if (model == null) return;

                print.Parameters.Add(new Parameter
                {
                    Name = "Date",
                    Value = model.DateProcess,
                    Visible = false
                });

                var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default(model.CustomerId, "id", EnumSqlOperator.Equals));
                if (customer != null)
                {
                    print.Parameters.Add(new Parameter
                    {
                        Name = "CustomerName",
                        Value = customer.Name,
                        Visible = false
                    });
                }

                print.Parameters.Add(new Parameter
                {
                    Name = "Amount",
                    Value = model.Total,
                    Visible = false
                });

                if (model.PaymentTypeId != null)
                {
                    var paymenttype = new PaymentTypeDataManager().GetFirst<PaymentTypeModel>(WhereTerm.Default((int)model.PaymentTypeId, "id", EnumSqlOperator.Equals));
                    if (paymenttype != null)
                    {
                        print.Parameters.Add(new Parameter
                        {
                            Name = "PaymentType",
                            Value = paymenttype.Name,
                            Visible = false
                        });
                    }
                }

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

                print.Parameters.Add(new Parameter
                {
                    Name = "Description",
                    Value = model.Description,
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
            var print = new RcPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = GridRc.DataSource;

                print.RequestParameters = false;
                var model = CurrentModel as PaymentRcModel;
                if (model == null) return;

                print.Parameters.Add(new Parameter
                {
                    Name = "Date",
                    Value = model.DateProcess,
                    Visible = false
                });

                var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default(model.CustomerId, "id", EnumSqlOperator.Equals));
                if (customer != null)
                {
                    print.Parameters.Add(new Parameter
                    {
                        Name = "CustomerName",
                        Value = customer.Name,
                        Visible = false
                    });
                }

                print.Parameters.Add(new Parameter
                {
                    Name = "Amount",
                    Value = model.Total,
                    Visible = false
                });

                if (model.PaymentTypeId != null)
                {
                    var paymenttype = new PaymentTypeDataManager().GetFirst<PaymentTypeModel>(WhereTerm.Default((int) model.PaymentTypeId, "id", EnumSqlOperator.Equals));
                    if (paymenttype != null)
                    {
                        print.Parameters.Add(new Parameter
                        {
                            Name = "PaymentType",
                            Value = paymenttype.Name,
                            Visible = false
                        });
                    }
                }

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

                print.Parameters.Add(new Parameter
                {
                    Name = "Description",
                    Value = model.Description,
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

        private void Add()
        {
            if (tbxBarcode.Text == "")
            {
                tbxBarcode.Focus();
                return;
            }

            var kwitansi =
                new PaymentInDetailDataManager().GetKwitansi(WhereTerm.Default(tbxBarcode.Text,
                    "invoice_ref_number", EnumSqlOperator.Equals));

            foreach (PaymentInDetailModel o in kwitansi)
            {
                for (var i = 0; i < RcView.RowCount; i++)
                {
                    var code = RcView.GetRowCellValue(i, RcView.Columns["InvoiceCode"]).ToString();
                    if (code == o.PaymentInCode)
                    {
                        var balance = RcView.GetRowCellValue(i, RcView.Columns["InvoiceBalance"]);
                        RcView.SetRowCellValue(i, RcView.Columns["Payment"], balance);
                        RcView.SetRowCellValue(i, RcView.Columns["Checked"], true);
                        RcView.SetRowCellValue(i, RcView.Columns["Balance"], 0);
                    }
                }
            }

            var total = 0;
            for (var i = 0; i < RcView.RowCount; i++)
            {
                total += Convert.ToInt32(RcView.GetRowCellValue(i, RcView.Columns["Payment"]));
            }

            tbxTotalInvoice.SetValue(total.ToString(CultureInfo.InvariantCulture));
            tbxTotal.SetValue(((Int64)tbxTotalInvoice.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));

            tbxBarcode.Clear();
            tbxBarcode.Focus();
        }

        private void Changed(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "clState" && e.Column.Name != "clBalance")
            {
                var due = Convert.ToInt32(RcView.GetRowCellValue(e.RowHandle, RcView.Columns["InvoiceBalance"]));

                if (e.Column.Name == "clChecked")
                {
                    if ((bool)RcView.GetRowCellValue(e.RowHandle, RcView.Columns["Checked"]))
                    {
                        RcView.SetRowCellValue(e.RowHandle, RcView.Columns["Balance"], 0);
                        RcView.SetRowCellValue(e.RowHandle, RcView.Columns["Payment"], due);
                    }
                    else
                    {
                        RcView.SetRowCellValue(e.RowHandle, RcView.Columns["Balance"], due);
                        RcView.SetRowCellValue(e.RowHandle, RcView.Columns["Payment"], 0);
                    }
                }

                if (e.Column.Name == "clPayment")
                {
                    var payment = Convert.ToInt32(RcView.GetRowCellValue(e.RowHandle, RcView.Columns["Payment"]));
                    RcView.SetRowCellValue(e.RowHandle, RcView.Columns["Balance"], (due - payment));
                }

                var total = 0;
                for (var i = 0; i < RcView.RowCount; i++)
                {
                    total += Convert.ToInt32(RcView.GetRowCellValue(i, RcView.Columns["Payment"]));
                }

                tbxTotalInvoice.SetValue(total.ToString(CultureInfo.InvariantCulture));
                tbxTotal.SetValue(((Int64)tbxTotalInvoice.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));

                if (RcView.GetRowCellValue(e.RowHandle, RcView.Columns["StateChange2"]).ToString() ==
                    EnumStateChange.Select.ToString())
                {
                    RcView.SetRowCellValue(e.RowHandle, RcView.Columns["StateChange2"], EnumStateChange.Update);
                }

                if (RcView.GetRowCellValue(e.RowHandle, RcView.Columns["StateChange2"]).ToString() ==
                    EnumStateChange.Idle.ToString())
                {
                    RcView.SetRowCellValue(e.RowHandle, RcView.Columns["StateChange2"], EnumStateChange.Insert);
                }
            }
        }

        private void CalculateTotal(object sender, EventArgs e)
        {
            tbxTotal.SetValue(((Int64)tbxTotalInvoice.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));
        }

        private void GetInvoice(object sender, EventArgs e)
        {
            base.OnLeave(e);

            GridRc.DataSource = null;
            RcView.RefreshData();

            if (tbxCustomer.Value != null)
            {
                var invoices = new PaymentInDataManager().Get<PaymentInModel>(new IListParameter[]
                {
                    WhereTerm.Default((int)tbxCustomer.Value, "customer_id", EnumSqlOperator.Equals),
                    WhereTerm.Default(0, "rc_total", EnumSqlOperator.GreatThan)
                });

                var ds = new List<PaymentRcDetailModel>();
                foreach (PaymentInModel invoice in invoices)
                {
                    var payment = _detailDm.GetPaymentRc(invoice.Id);
                    var balance = invoice.RcTotal - payment;

                    if (balance > 0)
                    {
                        ds.Add(new PaymentRcDetailModel
                        {
                            InvoiceId = invoice.Id,
                            InvoiceCode = invoice.Code,
                            InvoiceDate = invoice.DateProcess,
                            InvoiceTotal = invoice.RcTotal,
                            InvoiceBalance = balance,
                            Payment = 0,
                            Balance = balance,
                            Checked = false,
                            StateChange2 = EnumStateChange.Insert.ToString()
                        });
                    }
                }

                GridRc.DataSource = ds;
                RcView.RefreshData();
            }
        }

        private void PaymentRcLoad(object sender, EventArgs e)
        {
            ClearForm();

            EnableBtnSearch = true;
            SearchPopup = new PaymentRcFilterPopup();

            EnableBtnPrint = true;
            EnableBtnPrintPreview = true;

            tbxCustomer.LookupPopup = new CustomerPopup();
            tbxCustomer.AutoCompleteDataManager = new CustomerDataManager();
            tbxCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            tbxCustomer.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);

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
            tbxTotalInvoice.IsNumber = true;
        }

        public override void New()
        {
            base.New();
            ClearForm();
            ToolbarCode = string.Empty;
            tbxDate.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            tbxCustomer.Focus();
            GridRc.DataSource = null;
            RcView.RefreshData();

            tbxTotal.ReadOnly = true;
            tbxTotalInvoice.ReadOnly = true;
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
                if (((PaymentRcModel) CurrentModel).CustomerId != tbxCustomer.Value) DeleteOld = true;
                Code = ((PaymentRcModel) CurrentModel).Code;
            }
            else
            {
                if (tbxDate.Text != "") 
                    Code = GetCode("rc", tbxDate.Value);
            }

            base.Save();
        }

        protected override void  SaveDetail(bool isUpdate = false)
        {
            Enabled = false;
            if (DeleteOld)
            {
                new PaymentRcDetailDataManager().DeActiveRows(new IListParameter[]
                {
                    WhereTerm.Default(CurrentModel.Id, "payment_rc_id", EnumSqlOperator.Equals)
                }, BaseControl.UserLogin);
            }

            var detailRepo = new PaymentRcDetailDataManager();
            var paymentRepo = new PaymentInDataManager();
            for (int i = 0; i < RcView.RowCount; i++)
            {
                var state = RcView.GetRowCellValue(i, RcView.Columns["StateChange2"]);

                var detail = new PaymentRcDetailModel();

                if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                {
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.DateProcess = DateTime.Now;
                    detail.PaymentRcId = CurrentModel.Id;
                    detail.InvoiceId =
                            (int)RcView.GetRowCellValue(i, RcView.Columns["InvoiceId"]);
                    detail.InvoiceDate =
                            (DateTime)RcView.GetRowCellValue(i, RcView.Columns["InvoiceDate"]);
                    detail.InvoiceCode =
                            RcView.GetRowCellValue(i, RcView.Columns["InvoiceCode"]).ToString();
                    detail.InvoiceTotal =
                            (decimal)RcView.GetRowCellValue(i, RcView.Columns["InvoiceTotal"]);
                    detail.InvoiceBalance =
                            (decimal)RcView.GetRowCellValue(i, RcView.Columns["InvoiceBalance"]);
                    detail.Payment =
                            (decimal)RcView.GetRowCellValue(i, RcView.Columns["Payment"]);
                    detail.Balance =
                            (decimal)RcView.GetRowCellValue(i, RcView.Columns["Balance"]);
                    detail.Checked =
                            (bool)RcView.GetRowCellValue(i, RcView.Columns["Checked"]);

                    detail.Createdby = BaseControl.UserLogin;
                    detail.Createddate = DateTime.Now;

                    if (detail.Payment > 0) detailRepo.Save<PaymentRcDetailModel>(detail);
                }

                if (state.ToString().Equals(EnumStateChange.Update.ToString()))
                {
                    detail = detailRepo.GetFirst<PaymentRcDetailModel>(WhereTerm.Default((int)RcView.GetRowCellValue(i, RcView.Columns["Id"]), "id", EnumSqlOperator.Equals));
                    detail.Payment =
                            (decimal)RcView.GetRowCellValue(i, RcView.Columns["Payment"]);
                    detail.Balance =
                            (decimal)RcView.GetRowCellValue(i, RcView.Columns["Balance"]);
                    detail.Checked =
                            (bool)RcView.GetRowCellValue(i, RcView.Columns["Checked"]);
                    detail.Modifiedby = BaseControl.UserLogin;
                    detail.Modifieddate = DateTime.Now;

                    if (detail.Payment == 0)
                        detailRepo.DeActive(detail.Id, BaseControl.UserLogin, DateTime.Now);
                    else detailRepo.Update<PaymentRcDetailModel>(detail);
                }

                if (detail.InvoiceId != null)
                {
                    var payment = paymentRepo.GetFirst<PaymentInModel>(WhereTerm.Default((int) detail.InvoiceId, "id", EnumSqlOperator.Equals));
                    payment.TotalPaymentRc = _detailDm.GetPaymentRc(payment.Id);
                    if (payment.TotalPaymentRc == payment.RcTotal) payment.PaidRc = true;
                    else payment.PaidRc = false;

                    paymentRepo.Update<PaymentInModel>(payment);
                }
            }

            Enabled = true;
        }

        protected override void AfterSave()
        {
            ToolbarCode = ((PaymentRcModel)CurrentModel).Code;
            OpenData(ToolbarCode);
        }

        public override void AfterDelete()
        {
            var detail = new PaymentRcDetailDataManager().Get<PaymentRcDetailModel>(WhereTerm.Default(CurrentModel.Id, "payment_rc_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new PaymentRcDetailDataManager();
                foreach (PaymentRcDetailModel obj in detail)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                }
            }

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "" && tbxCustomer.Text != "" && tbxPayment.Text != "") return true;

            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return false;
            }

            if (tbxCustomer.Text == "")
            {
                tbxCustomer.Focus();
                return false;
            }

            if (tbxPayment.Text == "")
            {
                tbxPayment.Focus();
                return false;
            }

            return false;
        }

        protected override void PopulateForm(PaymentRcModel model)
        {
            tbxDate.Text = model.DateProcess.ToString(CultureInfo.InvariantCulture);
            tbxCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CustomerId, "id", EnumSqlOperator.Equals) };
            if (model.PaymentTypeId != null)
                tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default((int) model.PaymentTypeId, "id", EnumSqlOperator.Equals) };

            tbxAmount.SetValue(model.Amount.ToString(CultureInfo.InvariantCulture));
            tbxDescription.Text = model.Description;
            tbxTotalInvoice.SetValue(model.TotalInvoice.ToString(CultureInfo.InvariantCulture));
            tbxAdjustment.SetValue(model.Adjustment.ToString(CultureInfo.InvariantCulture));
            tbxTotal.SetValue(model.Total.ToString(CultureInfo.InvariantCulture));

            ToolbarCode = model.Code;

            var detail = new PaymentRcDetailDataManager().Get<PaymentRcDetailModel>(WhereTerm.Default(model.Id, "payment_rc_id", EnumSqlOperator.Equals));
            GridRc.DataSource = detail;
            RcView.RefreshData();

            tbxTotal.ReadOnly = true;
            tbxTotalInvoice.ReadOnly = true;
        }

        protected override PaymentRcModel PopulateModel(PaymentRcModel model)
        {
            model.Code = Code;
            model.DateProcess = tbxDate.Value;
            if (tbxCustomer.Value != null)
            {
                model.CustomerId = (int)tbxCustomer.Value;
                model.CompanyName = tbxCustomer.Text;
            }
            model.BranchId = BaseControl.BranchId;
            if (tbxPayment.Value != null) model.PaymentTypeId = tbxPayment.Value;

            model.Description = tbxDescription.Text;
            model.Amount = tbxAmount.Value;
            model.TotalInvoice = tbxTotalInvoice.Value;
            model.Total = tbxTotal.Value;
            model.Adjustment = tbxAdjustment.Value;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override PaymentRcModel Find(string searchTerm)
        {
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<PaymentRcModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as PaymentRcModel;
            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }

        private void Changing(object sender, CellValueChangedEventArgs e)
        {
            var due = Convert.ToInt32(RcView.GetRowCellValue(e.RowHandle, RcView.Columns["InvoiceBalance"]));

            if (e.Column.Name == "clChecked")
            {
                if (!(bool)RcView.GetRowCellValue(e.RowHandle, RcView.Columns["Checked"]))
                {
                    RcView.SetRowCellValue(e.RowHandle, RcView.Columns["Balance"], 0);
                    RcView.SetRowCellValue(e.RowHandle, RcView.Columns["Payment"], due);
                    RcView.SetRowCellValue(e.RowHandle, RcView.Columns["Checked"], true);
                }
                else
                {
                    RcView.SetRowCellValue(e.RowHandle, RcView.Columns["Balance"], due);
                    RcView.SetRowCellValue(e.RowHandle, RcView.Columns["Payment"], 0);
                    RcView.SetRowCellValue(e.RowHandle, RcView.Columns["Checked"], false);
                }
            }
        }
    }
}