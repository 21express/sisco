using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
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
using System.Text.RegularExpressions;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class PaymentInCollectInForm : BaseCrudForm<PaymentInCollectInModel, PaymentInCollectInDataManager>//BaseToolbarForm//
    {
        private string Code { get; set; }
        private PaymentMethodModel Payment { get; set; }

        public PaymentInCollectInForm()
        {
            InitializeComponent();

            form = this;
            Load += InCollectInLoad;

            CashView.CustomColumnDisplayText += NumberGrid;
            CreditView.CustomColumnDisplayText += NumberGrid;

            Payment = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default("COLLECT", "name", EnumSqlOperator.Equals));
            btnTambahCash.Click += AddCash;
            btnTambahCredit.Click += AddCredit;

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
            };

            tsBaseBtn_Print.Click += Print;
            tsBaseBtn_PrintPreview.Click += PrintPreview;

            tbxCnCash.KeyDown += (sender, args) =>
            {
                base.OnKeyDown(args);

                if (args.KeyCode == Keys.Enter)
                {
                    btnTambahCash.PerformClick();
                }
            };

            tbxCnCredit.KeyDown += (sender, args) =>
            {
                base.OnKeyDown(args);

                if (args.KeyCode == Keys.Enter)
                {
                    btnTambahCredit.PerformClick();
                }
            };
        }

        private void PrintPreview(object sender, EventArgs e)
        {
            var print = new PaymentInCollectInPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = new PaymentInCollectInDetailDataManager().Get<PaymentInCollectInDetailModel>(WhereTerm.Default(CurrentModel.Id, "payment_in_collect_in_id", EnumSqlOperator.Equals));

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "Code",
                    Value = ((PaymentInCollectInModel)CurrentModel).Code,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "DateProcess",
                    Value = ((PaymentInCollectInModel)CurrentModel).DateProcess,
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
            var print = new PaymentInCollectInPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = new PaymentInCollectInDetailDataManager().Get<PaymentInCollectInDetailModel>(WhereTerm.Default(CurrentModel.Id, "payment_in_collect_in_id", EnumSqlOperator.Equals));
                
                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "Code",
                    Value = ((PaymentInCollectInModel)CurrentModel).Code,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "DateProcess",
                    Value = ((PaymentInCollectInModel)CurrentModel).DateProcess,
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

        private bool CheckShipment(string code)
        {
            var detail = new PaymentInCollectInDetailDataManager().GetFirst<PaymentInCollectInDetailModel>(WhereTerm.Default(code, "invoice_code", EnumSqlOperator.Equals));
            if (detail == null)
            {
                var gcash = GridCash.DataSource as List<PaymentInCollectInDetailModel>;
                if (gcash != null)
                {
                    if (gcash.FirstOrDefault(p => p.InvoiceCode == code) != null)
                    {
                        MessageForm.Info(this, Resources.information, Resources.cn_exists);
                        return false;
                    }
                }

                var gcredit = GridCredit.DataSource as List<PaymentInCollectInDetailModel>;
                if (gcredit != null)
                {
                    if (gcredit.FirstOrDefault(p => p.InvoiceCode == code) != null)
                    {
                        MessageForm.Info(this, Resources.information, Resources.cn_exists);
                        return false;
                    }
                }
            }
            else
            {
                MessageForm.Info(this, Resources.information, Resources.cn_exists);
                return false;
            }

            return true;
        }

        private void AddCredit(object sender, EventArgs e)
        {
            if (tbxCnCredit.Text != "")
            {
                if (!CheckShipment(tbxCnCredit.Text)) return;
                if (tbxCustomer.Value == null)
                {
                    tbxCustomer.Focus();
                    return;
                }

                var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxCnCredit.Text, "code", EnumSqlOperator.Equals));
                if (shipment != null)
                {
                    if (shipment.DestBranchId != BaseControl.BranchId)
                    {
                        MessageForm.Info(this, Resources.information, string.Format(Resources.check_destination, tbxCnCredit.Text));
                        tbxCnCredit.Clear();
                        tbxCnCredit.Focus();

                        return;
                    }

                    if (shipment.PaymentMethodId == Payment.Id)
                    {
                        var obj = GridCredit.DataSource as List<PaymentInCollectInDetailModel> ?? new List<PaymentInCollectInDetailModel>();
                        obj.Add(new PaymentInCollectInDetailModel
                        {
                            BranchId = shipment.BranchId,
                            InvoiceId = shipment.Id,
                            InvoiceCode = shipment.Code,
                            InvoiceDate = shipment.DateProcess,
                            InvoiceTotal = shipment.Total,
                            InvoiceBalance = shipment.Total,
                            Payment = 0,
                            Balance = shipment.Total,
                            Checked = true,
                            Paid = false,
                            CollectPaymentMethod = "CREDIT",
                            CollectCustomerId = tbxCustomer.Value,
                            CollectCustomerName = tbxCustomer.Text,
                            StateChange2 = EnumStateChange.Insert.ToString()
                        });

                        GridCredit.DataSource = obj;
                        CreditView.RefreshData();
                    }
                    else
                    {
                        MessageForm.Error(this, Resources.information, Resources.not_collect);
                    }
                }
            }

            //tbxCustomer.Value = null;
            //tbxCustomer.Text = string.Empty;
            tbxCnCredit.Clear();
            tbxCnCredit.Focus();
        }

        private void AddCash(object sender, EventArgs e)
        {
            if (tbxCnCash.Text != "")
            {
                if (!CheckShipment(tbxCnCash.Text)) return;
                var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxCnCash.Text, "code", EnumSqlOperator.Equals));
                if (shipment != null)
                {
                    if (shipment.DestBranchId != BaseControl.BranchId)
                    {
                        MessageForm.Info(this, Resources.information, string.Format(Resources.check_destination, tbxCnCash.Text));
                        tbxCnCash.Clear();
                        tbxCnCash.Focus();

                        return;
                    }

                    if (shipment.PaymentMethodId == Payment.Id)
                    {
                        var obj = GridCash.DataSource as List<PaymentInCollectInDetailModel> ?? new List<PaymentInCollectInDetailModel>();

                        decimal totalCash = obj.Sum(p => p.Payment) + shipment.Total;

                        obj.Add(new PaymentInCollectInDetailModel
                        {
                            BranchId = shipment.BranchId,
                            InvoiceId = shipment.Id,
                            InvoiceCode = shipment.Code,
                            InvoiceDate = shipment.DateProcess,
                            InvoiceTotal = shipment.Total,
                            InvoiceBalance = 0,
                            Payment = shipment.Total,
                            Balance = 0,
                            Checked = true,
                            Paid = true,
                            CollectPaymentMethod = "CASH",
                            StateChange2 = EnumStateChange.Insert.ToString()
                        });

                        GridCash.DataSource = obj;
                        CashView.RefreshData();
                    }
                    else
                    {
                        MessageForm.Error(this, Resources.information, Resources.not_collect);
                    }
                }
            }

            tbxCnCash.Clear();
            tbxCnCash.Focus();
        }

        private void InCollectInLoad(object sender, EventArgs e)
        {
            ClearForm();
            EnabledForm(false);

            EnableBtnPrint = false;
            EnableBtnPrintPreview = false;

            EnableBtnSearch = true;
            SearchPopup = new PaymentInCollectInFilterPopup();

            tbxCustomer.LookupPopup = new CustomerPopup(new IListParameter[] {WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)});
            tbxCustomer.AutoCompleteDataManager = new CustomerDataManager();
            tbxCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            tbxCustomer.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) and branch_id = @1", s, BaseControl.BranchId);
        }
        
        public override void New()
        {
            base.New();

            ClearForm();
            EnabledForm(true);

            tbxDate.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            GridCash.DataSource = null;
            CashView.RefreshData();

            GridCredit.DataSource = null;
            CreditView.RefreshData();

            tbxDate.Focus();
        }

        public override void Save()
        {
            var oCash = GridCash.DataSource as List<PaymentInCollectInDetailModel>;
            var oCredit = GridCredit.DataSource as List<PaymentInCollectInDetailModel>;

            if (oCash == null && oCredit == null)
            {
                MessageForm.Info(this, Resources.information, Resources.data_empty);
                return;
            }

            Code = CurrentModel.Id == 0 ? (tbxDate.Text != "" ? GetCode("collectin", tbxDate.Value) : "") : ((PaymentInCollectInModel)CurrentModel).Code;

            base.Save();
        }

        protected override void  SaveDetail(bool isUpdate = false)
        {
            Enabled = false;

            decimal totalInvoice = 0;
            decimal totalCash = 0;
            decimal totalCredit = 0;

            var dm = new PaymentInCollectInDetailDataManager();
            for (var i = 0; i < CashView.RowCount; i++)
            {
                var state = CashView.GetRowCellValue(i, CashView.Columns["StateChange2"]).ToString();

                if (state == EnumStateChange.Insert.ToString())
                {
                    var detail = new PaymentInCollectInDetailModel();

                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.PaymentInCollectInId = CurrentModel.Id;
                    detail.DateProcess = DateTime.Now;
                    detail.BranchId = (int)CashView.GetRowCellValue(i, CashView.Columns["BranchId"]);
                    detail.InvoiceId = (int)CashView.GetRowCellValue(i, CashView.Columns["InvoiceId"]);
                    detail.InvoiceDate = (DateTime?)CashView.GetRowCellValue(i, CashView.Columns["InvoiceDate"]);
                    detail.InvoiceCode = CashView.GetRowCellValue(i, CashView.Columns["InvoiceCode"]).ToString();
                    detail.InvoiceTotal = (decimal)CashView.GetRowCellValue(i, CashView.Columns["InvoiceTotal"]);
                    detail.InvoiceBalance = (decimal)CashView.GetRowCellValue(i, CashView.Columns["InvoiceBalance"]);
                    detail.Payment = (decimal)CashView.GetRowCellValue(i, CashView.Columns["Payment"]);
                    detail.Balance = (decimal)CashView.GetRowCellValue(i, CashView.Columns["Balance"]);
                    detail.Checked = (bool)CashView.GetRowCellValue(i, CashView.Columns["Checked"]);
                    detail.Paid = (bool)CashView.GetRowCellValue(i, CashView.Columns["Paid"]);
                    detail.CollectPaymentMethod = "CASH";

                    detail.Createdby = BaseControl.UserLogin;
                    detail.Createddate = DateTime.Now;

                    totalInvoice += detail.InvoiceTotal;
                    totalCash += detail.InvoiceTotal;

                    dm.Save<PaymentInCollectInDetailModel>(detail);

                    var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default((int) detail.InvoiceId, "id", EnumSqlOperator.Equals));
                    shipment.CollectPaymentMethod = "CASH";
                    shipment.TotalPaymentColl = detail.Payment;
                    shipment.PaidColl = true;

                    new ShipmentDataManager().Update<ShipmentModel>(shipment);
                }
            }

            for (var i = 0; i < CreditView.RowCount; i++)
            {
                var state = CreditView.GetRowCellValue(i, CreditView.Columns["StateChange2"]).ToString();

                if (state == EnumStateChange.Insert.ToString())
                {
                    var detail = new PaymentInCollectInDetailModel();

                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.PaymentInCollectInId = CurrentModel.Id;
                    detail.DateProcess = DateTime.Now;
                    detail.BranchId = (int)CreditView.GetRowCellValue(i, CreditView.Columns["BranchId"]);
                    detail.InvoiceId = (int)CreditView.GetRowCellValue(i, CreditView.Columns["InvoiceId"]);
                    detail.InvoiceDate = (DateTime?)CreditView.GetRowCellValue(i, CreditView.Columns["InvoiceDate"]);
                    detail.InvoiceCode = CreditView.GetRowCellValue(i, CreditView.Columns["InvoiceCode"]).ToString();
                    detail.InvoiceTotal = (decimal)CreditView.GetRowCellValue(i, CreditView.Columns["InvoiceTotal"]);
                    detail.InvoiceBalance = (decimal)CreditView.GetRowCellValue(i, CreditView.Columns["InvoiceBalance"]);
                    detail.Payment = 0;
                    detail.Balance = (decimal)CreditView.GetRowCellValue(i, CreditView.Columns["Balance"]);
                    detail.Checked = (bool)CreditView.GetRowCellValue(i, CreditView.Columns["Checked"]);
                    detail.Paid = (bool)CreditView.GetRowCellValue(i, CreditView.Columns["Paid"]);
                    detail.CollectPaymentMethod = "CREDIT";

                    detail.CollectCustomerId = (int) CreditView.GetRowCellValue(i, CreditView.Columns["CollectCustomerId"]);
                    detail.CollectCustomerName = CreditView.GetRowCellValue(i, CreditView.Columns["CollectCustomerName"]).ToString();

                    detail.Createdby = BaseControl.UserLogin;
                    detail.Createddate = DateTime.Now;

                    totalInvoice += detail.InvoiceTotal;
                    totalCredit += detail.InvoiceTotal;

                    dm.Save<PaymentInCollectInDetailModel>(detail);

                    var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default((int)detail.InvoiceId, "id", EnumSqlOperator.Equals));
                    shipment.CollectCustomerId = detail.CollectCustomerId;
                    shipment.CollectCustomerName = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int) detail.CollectCustomerId, "id", EnumSqlOperator.Equals)).Name;
                    shipment.CollectPaymentMethod = "CREDIT";

                    new ShipmentDataManager().Update<ShipmentModel>(shipment);
                }
            }

            var master = CurrentModel as PaymentInCollectInModel;
            if (master != null)
            {
                master.TotalInvoice = totalInvoice;
                master.Total = totalCash;
                master.TotalCredit = totalCredit;
    
                new PaymentInCollectInDataManager().Update<PaymentInCollectInModel>(master);

                ToolbarCode = master.Code;
            }
            
            Enabled = true;
        }

        protected override void AfterSave()
        {
            OpenData(ToolbarCode);
        }

        public override void AfterDelete()
        {
            var detail = new PaymentInCollectInDetailDataManager().Get<PaymentInCollectInDetailModel>(WhereTerm.Default(CurrentModel.Id, "payment_in_collect_in_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new PaymentInCollectInDetailDataManager();
                foreach (PaymentInCollectInDetailModel obj in detail)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                }
            }

            GridCash.DataSource = null;
            CashView.RefreshData();

            GridCredit.DataSource = null;
            CreditView.RefreshData();

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return false;
            }

            return true;
        }

        protected override void PopulateForm(PaymentInCollectInModel model)
        {
            ClearForm();
            if (model == null)
            {
                GridCash.DataSource = null;
                CashView.RefreshData();

                GridCredit.DataSource = null;
                CreditView.RefreshData();

                return;
            }

            EnableBtnPrint = true;
            EnableBtnPrintPreview = true;

            tbxDate.Text = model.DateProcess.ToString(CultureInfo.InvariantCulture);
            ToolbarCode = model.Code;

            var detail = new PaymentInCollectInDetailDataManager().Get<PaymentInCollectInDetailModel>(new IListParameter[]
            {
                WhereTerm.Default(model.Id, "payment_in_collect_in_id", EnumSqlOperator.Equals)
            }).ToList();

            var cash = detail.Where(p => p.CollectPaymentMethod == "CASH").ToList();
            var credit = detail.Where(p => p.CollectPaymentMethod == "CREDIT").ToList();

            GridCash.DataSource = cash;
            CashView.RefreshData();

            GridCredit.DataSource = credit;
            CreditView.RefreshData();
        }

        protected override PaymentInCollectInModel PopulateModel(PaymentInCollectInModel model)
        {
            model.Code = Code;
            model.DateProcess = tbxDate.Value;
            model.BranchId = BaseControl.BranchId;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override PaymentInCollectInModel Find(string searchTerm)
        {
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<PaymentInCollectInModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as PaymentInCollectInModel;
            if (model == null) return;

            info.CreatedPc = model.CreatedPc;
            info.ModifiedPc = model.ModifiedPc;

            base.Info();
        }
    }
}
