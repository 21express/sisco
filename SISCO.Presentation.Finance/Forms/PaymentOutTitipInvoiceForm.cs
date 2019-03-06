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
    public partial class PaymentOutTitipInvoiceForm : BaseCrudForm<OtherInvoicePaymentOutModel, OtherInvoicePaymentOutDataManager>//BaseToolbarForm//
    {
        private OtherInvoicePaymentOutDetailDataManager _detailDm = new OtherInvoicePaymentOutDetailDataManager();
        private string Code { get; set; }

        public PaymentOutTitipInvoiceForm()
        {
            InitializeComponent();

            form = this;
            Load += InvoiceOutLoad;

            InvoiceOutView.CustomColumnDisplayText += NumberGrid;
            InvoiceOutView.CellValueChanged += Changed;
            InvoiceOutView.CellValueChanging += Changing;
            tbxAdjustment.Leave += CalculateTotal;

            btnAdd.Click += Pay;

            tbxBranch.Leave += GetInvoice;
            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "owner_branch_id", EnumSqlOperator.Equals)
            };
        }

        private void Pay(object sender, EventArgs e)
        {
            if (tbxCode.Text == "")
            {
                tbxCode.Focus();
                return;
            }

            var total = 0;
            decimal pph = 0;
            for (var i = 0; i < InvoiceOutView.RowCount; i++)
            {
                if (InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["InvoiceRefNumber"]).ToString() == tbxCode.Text)
                {
                    var balance =
                        (decimal)InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["InvoiceBalance"]);

                    InvoiceOutView.SetRowCellValue(i, InvoiceOutView.Columns["Payment"], balance);
                    InvoiceOutView.SetRowCellValue(i, InvoiceOutView.Columns["Balance"], 0);
                    InvoiceOutView.SetRowCellValue(i, InvoiceOutView.Columns["Paid"], true);
                    InvoiceOutView.SetRowCellValue(i, InvoiceOutView.Columns["Checked"], true);
                }

                total += Convert.ToInt32(InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["Payment"]));
                if (Convert.ToInt32(InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["Payment"])) > 0)
                    pph += Convert.ToDecimal(InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["TotalPph"]));
            }

            tbxCode.Clear();
            tbxCode.Focus();

            tbxTotalInvoice.SetValue(total.ToString(CultureInfo.InvariantCulture));
            tbxTotalPph.SetValue(pph.ToString());
            //tbxTotal.SetValue(((Int64)tbxTotalInvoice.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));

            CalculateTotal(sender, e);
        }

        private void Changing(object sender, CellValueChangedEventArgs e)
        {
            var due = Convert.ToInt32(InvoiceOutView.GetRowCellValue(e.RowHandle, InvoiceOutView.Columns["InvoiceBalance"]));

            if (e.Column.Name == "clChecked")
            {
                if (!(bool)InvoiceOutView.GetRowCellValue(e.RowHandle, InvoiceOutView.Columns["Checked"]))
                {
                    InvoiceOutView.SetRowCellValue(e.RowHandle, InvoiceOutView.Columns["Balance"], 0);
                    InvoiceOutView.SetRowCellValue(e.RowHandle, InvoiceOutView.Columns["Payment"], due);
                    InvoiceOutView.SetRowCellValue(e.RowHandle, InvoiceOutView.Columns["Checked"], true);
                }
                else
                {
                    InvoiceOutView.SetRowCellValue(e.RowHandle, InvoiceOutView.Columns["Balance"], due);
                    InvoiceOutView.SetRowCellValue(e.RowHandle, InvoiceOutView.Columns["Payment"], 0);
                    InvoiceOutView.SetRowCellValue(e.RowHandle, InvoiceOutView.Columns["Checked"], false);
                }
            }
        }

        private void GetInvoice(object sender, EventArgs e)
        {
            GridInvoiceOut.DataSource = null;
            InvoiceOutView.RefreshData();

            if (tbxBranch.Value == null) return;

            var ds = _detailDm.GetPaymentInvoice((int)tbxBranch.Value, BaseControl.BranchId);
            GridInvoiceOut.DataSource = null;
            InvoiceOutView.RefreshData();

            GridInvoiceOut.DataSource = ds;
            InvoiceOutView.RefreshData();
        }

        private void CalculateTotal(object sender, EventArgs e)
        {
            tbxTotal.SetValue(((decimal)tbxTotalInvoice.Value - (decimal)tbxTotalPph.Value - (decimal)tbxAdjustment.Value).ToString());
        }

        private void Changed(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "clState" && e.Column.Name != "clBalance")
            {
                var due = Convert.ToInt32(InvoiceOutView.GetRowCellValue(e.RowHandle, InvoiceOutView.Columns["InvoiceBalance"]));
                var invTotal = Convert.ToInt32(InvoiceOutView.GetRowCellValue(e.RowHandle, InvoiceOutView.Columns["InvoiceTotal"]));

                if (e.Column.Name == "clChecked")
                {
                    if ((bool)InvoiceOutView.GetRowCellValue(e.RowHandle, InvoiceOutView.Columns["Checked"]))
                    {
                        InvoiceOutView.SetRowCellValue(e.RowHandle, InvoiceOutView.Columns["Balance"], 0);
                        InvoiceOutView.SetRowCellValue(e.RowHandle, InvoiceOutView.Columns["Payment"], due);
                    }
                    else
                    {
                        InvoiceOutView.SetRowCellValue(e.RowHandle, InvoiceOutView.Columns["Balance"], invTotal);
                        InvoiceOutView.SetRowCellValue(e.RowHandle, InvoiceOutView.Columns["Payment"], 0);
                    }
                }

                var payment = Convert.ToInt32(InvoiceOutView.GetRowCellValue(e.RowHandle, InvoiceOutView.Columns["Payment"]));

                if (e.Column.Name == "clPayment")
                {
                    InvoiceOutView.SetRowCellValue(e.RowHandle, InvoiceOutView.Columns["Balance"], (invTotal - payment));
                }

                var total = 0;
                decimal pph = 0;
                for (var i = 0; i < InvoiceOutView.RowCount; i++)
                {
                    total += Convert.ToInt32(InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["Payment"]));
                    if (Convert.ToInt32(InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["Payment"])) > 0)
                        pph += Convert.ToDecimal(InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["TotalPph"]));
                }

                tbxTotalInvoice.SetValue(total.ToString(CultureInfo.InvariantCulture));
                tbxTotalPph.SetValue(pph.ToString());
                tbxTotal.SetValue(((Int64)tbxTotalInvoice.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));

                CalculateTotal(sender, e);

                if (InvoiceOutView.GetRowCellValue(e.RowHandle, InvoiceOutView.Columns["StateChange2"]).ToString() ==
                    EnumStateChange.Select.ToString())
                {
                    InvoiceOutView.SetRowCellValue(e.RowHandle, InvoiceOutView.Columns["StateChange2"], EnumStateChange.Update);
                }

                if (InvoiceOutView.GetRowCellValue(e.RowHandle, InvoiceOutView.Columns["StateChange2"]).ToString() ==
                    EnumStateChange.Idle.ToString())
                {
                    InvoiceOutView.SetRowCellValue(e.RowHandle, InvoiceOutView.Columns["StateChange2"], EnumStateChange.Insert);
                }
            }
        }

        private void InvoiceOutLoad(object sender, EventArgs e)
        {
            ClearForm();

            EnableBtnSearch = true;
            SearchPopup = new PaymentOutTitipInvoiceFilterPopup();

            tbxBranch.LookupPopup = new BranchPopup();
            tbxBranch.AutoCompleteDataManager = new BranchDataManager();
            tbxBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            tbxBranch.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            tbxPayment.LookupPopup = new PaymentTypePopup();
            tbxPayment.AutoCompleteDataManager = new PaymentTypeDataManager();
            tbxPayment.AutoCompleteDisplayFormater = model => ((PaymentTypeModel)model).Name;
            tbxPayment.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            //tbxAmount.IsNumber = true;
            //tbxTotal.IsNumber = true;
            //tbxTotalPph.IsNumber = true;
            //tbxTotalInvoice.IsNumber = true;
            //tbxAdjustment.IsNumber = true;

            tsBaseBtn_PrintPreview.Click += PrintPreview;
            tsBaseBtn_Print.Click += Print;
        }

        private void Print(object sender, EventArgs e)
        {
            var print = new PaymentOutTitipInvoicePrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = new OtherInvoicePaymentOutDetailDataManager().Get<OtherInvoicePaymentOutDetailModel>(WhereTerm.Default(CurrentModel.Id, "other_invoice_payment_out_id", EnumSqlOperator.Equals));

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "Code",
                    Value = ((OtherInvoicePaymentOutModel)CurrentModel).Code,
                    Visible = false
                });

                var branch = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id"));
                print.Parameters.Add(new Parameter
                {
                    Name = "OrigBranchName",
                    Value = string.Format("{0} - {1}", branch.Code, branch.Name),
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "DestBranchName",
                    Value = tbxBranch.Text,
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
                    Name = "Total",
                    Value = ((OtherInvoicePaymentOutModel)CurrentModel).Total,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Adjustment",
                    Value = ((OtherInvoicePaymentOutModel)CurrentModel).Adjustment,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "TotalPph",
                    Value = ((OtherInvoicePaymentOutModel)CurrentModel).TotalPph,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Note",
                    Value = ((OtherInvoicePaymentOutModel)CurrentModel).Description,
                    Visible = false
                });

                print.CreateDocument();
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                };
                printTool.PrintDialog();
            }
        }

        private void PrintPreview(object sender, EventArgs e)
        {
            var print = new PaymentOutTitipInvoicePrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = new OtherInvoicePaymentOutDetailDataManager().Get<OtherInvoicePaymentOutDetailModel>(WhereTerm.Default(CurrentModel.Id, "other_invoice_payment_out_id", EnumSqlOperator.Equals));

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "Code",
                    Value = ((OtherInvoicePaymentOutModel)CurrentModel).Code,
                    Visible = false
                });

                var branch = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id"));
                print.Parameters.Add(new Parameter
                {
                    Name = "OrigBranchName",
                    Value = string.Format("{0} - {1}", branch.Code, branch.Name),
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "DestBranchName",
                    Value = tbxBranch.Text,
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
                    Name = "Total",
                    Value = ((OtherInvoicePaymentOutModel)CurrentModel).Total,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "TotalPph",
                    Value = ((OtherInvoicePaymentOutModel)CurrentModel).TotalPph,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Adjustment",
                    Value = ((OtherInvoicePaymentOutModel)CurrentModel).Adjustment,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Note",
                    Value = ((OtherInvoicePaymentOutModel)CurrentModel).Description,
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
            tbxDate.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            tbxDate.Focus();
            GridInvoiceOut.DataSource = null;
            InvoiceOutView.RefreshData();

            tbxTotal.ReadOnly = true;
            tbxTotalPph.ReadOnly = true;
            tbxTotalInvoice.ReadOnly = true;

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

            base.Save();
        }

        protected override void  SaveDetail(bool isUpdate = false)
        {
            Enabled = false;

            
            var detailRepo = new OtherInvoicePaymentOutDetailDataManager();
            for (int i = 0; i < InvoiceOutView.RowCount; i++)
            {
                var state = InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["StateChange2"]);

                var detail = new OtherInvoicePaymentOutDetailModel();

                if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                {
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.DateProcess = DateTime.Now;
                    detail.OtherInvoicePaymentOutId = CurrentModel.Id;
                    detail.InvoiceId =
                            (int)InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["InvoiceId"]);
                    detail.InvoiceDate =
                            (DateTime)InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["InvoiceDate"]);
                    detail.InvoiceCode =
                            InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["InvoiceCode"]).ToString();
                    detail.InvoiceTotal =
                            (decimal)InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["InvoiceTotal"]);
                    detail.InvoiceBalance =
                            (decimal)InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["InvoiceBalance"]);
                    detail.Payment =
                            (decimal)InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["Payment"]);
                    detail.Balance =
                            (decimal)InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["Balance"]);
                    detail.TotalPph =
                        (decimal)InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["TotalPph"]);
                    detail.Checked =
                            (bool)InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["Checked"]);

                    if (InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["InvoiceRefNumber"]) != null)
                        detail.InvoiceRefNumber =
                            InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["InvoiceRefNumber"]).ToString();

                    if (InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["Note"]) != null)
                        detail.Note = InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["Note"]).ToString();

                    detail.Createdby = BaseControl.UserLogin;
                    detail.Createddate = DateTime.Now;

                    detailRepo.Save<OtherInvoicePaymentOutDetailModel>(detail);
                }

                if (state.ToString().Equals(EnumStateChange.Update.ToString()))
                {
                    detail = detailRepo.GetFirst<OtherInvoicePaymentOutDetailModel>(WhereTerm.Default((int)InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["Id"]), "id", EnumSqlOperator.Equals));
                    detail.Payment =
                            (decimal)InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["Payment"]);
                    detail.Balance =
                            (decimal)InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["Balance"]);
                    detail.Checked =
                            (bool)InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["Checked"]);
                    detail.Modifiedby = BaseControl.UserLogin;
                    detail.Modifieddate = DateTime.Now;

                    if (detail.Payment == 0)
                        detailRepo.DeActive(detail.Id, BaseControl.UserLogin, DateTime.Now);
                    else detailRepo.Update<OtherInvoicePaymentOutDetailModel>(detail);
                }

                var refNumber = InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["InvoiceRefNumber"]).ToString();
                var invoiceId = (int) InvoiceOutView.GetRowCellValue(i, InvoiceOutView.Columns["InvoiceId"]);
                var otherInvoice =
                    new OtherInvoiceDataManager().GetFirst<OtherInvoiceModel>(WhereTerm.Default(refNumber, "ref_number",
                        EnumSqlOperator.Equals));

                if (otherInvoice != null)
                {
                    var payment = _detailDm.GetTotalPayment(otherInvoice.Id);
                    otherInvoice.OutTotalPayment = payment;
                    if (payment == otherInvoice.Total) otherInvoice.OutPaid = true;
                    otherInvoice.Modifiedby = BaseControl.UserLogin;
                    otherInvoice.Modifieddate = DateTime.Now;

                    new OtherInvoiceDataManager().Update<OtherInvoiceModel>(otherInvoice);
                }
            }

            Enabled = true;
        }

        protected override void AfterSave()
        {
            ToolbarCode = ((OtherInvoicePaymentOutModel)CurrentModel).Code;
            OpenData(ToolbarCode);
        }

        public override void AfterDelete()
        {
            var detail = new OtherInvoicePaymentOutDetailDataManager().Get<OtherInvoicePaymentOutDetailModel>(WhereTerm.Default(CurrentModel.Id, "other_invoice_payment_out_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new OtherInvoicePaymentOutDetailDataManager();
                foreach (OtherInvoicePaymentOutDetailModel obj in detail)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                }
            }

            ClearForm();
            GridInvoiceOut.DataSource = null;
            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "" && tbxPayment.Value != null)
            {
                if (CurrentModel.Id > 0) Code = ((OtherInvoicePaymentOutModel) CurrentModel).Code;
                else
                {
                    if (tbxDate.Text != "") 
                        Code = GetCode("invoiceout", tbxDate.Value);
                }
                return true;
            }

            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return false;
            }

            if (tbxPayment.Value == null)
            {
                tbxPayment.Focus();
                return false;
            }

            return false;
        }

        protected override void PopulateForm(OtherInvoicePaymentOutModel model)
        {
            tbxDate.Text = model.DateProcess.ToString(CultureInfo.InvariantCulture);
            tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default(model.PaymentTypeId, "id", EnumSqlOperator.Equals) };
            
            tbxAmount.SetValue(model.Amount.ToString(CultureInfo.InvariantCulture));
            tbxDescription.Text = model.Description;

            tbxBranch.DefaultValue = new IListParameter[] {WhereTerm.Default(model.BranchId, "id", EnumSqlOperator.Equals)};

            
            tbxTotalInvoice.SetValue(model.TotalInvoice.ToString(CultureInfo.InvariantCulture));
            tbxTotalPph.SetValue(model.TotalPph.ToString());
            
            tbxAdjustment.SetValue(model.Adjustment.ToString(CultureInfo.InvariantCulture));
            
            tbxTotal.SetValue(model.Total.ToString(CultureInfo.InvariantCulture));

            ToolbarCode = model.Code;

            var detail = new OtherInvoicePaymentOutDetailDataManager().Get<OtherInvoicePaymentOutDetailModel>(WhereTerm.Default(model.Id, "other_invoice_payment_out_id", EnumSqlOperator.Equals));
            detail.ToList().ForEach(d =>
            {
                d.StateChange2 = EnumStateChange.Select.ToString();
            });
            GridInvoiceOut.DataSource = detail;
            InvoiceOutView.RefreshData();

            tbxTotal.ReadOnly = true;
            tbxTotalPph.ReadOnly = true;
            tbxTotalInvoice.ReadOnly = true;

            EnableBtnPrint = true;
            EnableBtnPrintPreview = true;
        }

        protected override OtherInvoicePaymentOutModel PopulateModel(OtherInvoicePaymentOutModel model)
        {
            model.Code = Code;
            model.DateProcess = tbxDate.Value;
            if (tbxBranch.Value != null) model.BranchId = (int)tbxBranch.Value;
            model.OwnerBranchId = BaseControl.BranchId;
            if (tbxPayment.Value != null) model.PaymentTypeId = (int)tbxPayment.Value;
            model.Description = tbxDescription.Text;
            model.Amount = tbxAmount.Value;
            model.TotalInvoice = tbxTotalInvoice.Value;
            model.Total = tbxTotal.Value;
            model.TotalPph = tbxTotalPph.Value;
            model.Adjustment = tbxAdjustment.Value;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override OtherInvoicePaymentOutModel Find(string searchTerm)
        {
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<OtherInvoicePaymentOutModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as OtherInvoicePaymentOutModel;
            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }
    }
}