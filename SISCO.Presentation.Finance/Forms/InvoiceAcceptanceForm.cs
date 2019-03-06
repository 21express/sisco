using Devenlab.Common;
using SISCO.App.Finance;
using SISCO.App.Billing;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.MasterData.Popup;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using Devenlab.Common.WinControl.MessageBox;
using SISCO.Presentation.Common;
using Devenlab.Common.Interfaces;
using System;
using SISCO.Presentation.Finance.Popup;
using SISCO.Presentation.Finance.Report;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class InvoiceAcceptanceForm : BaseCrudForm<SalesInvoiceAcceptanceModel, SalesInvoiceAcceptanceDataManager>//BaseToolbarForm//
    {
        private List<int> DeletedRows { get; set; }
        private string Code { get; set; }

        public InvoiceAcceptanceForm()
        {
            InitializeComponent();
            form = this;

            EnableBtnPrint = false;
            EnableBtnPrintPreview = false;

            Load += InvoiceAcceptanceLoad;
            btnTambah.Click += (sender, e) => AddRow();
            btnRowDelete.ButtonClick += DeleteRow;

            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };
            GridInvoice.DoubleClick += UpdateAcceptance;

            Shown += InvoiceAcceptanceForm_Shown;
        }

        void InvoiceAcceptanceForm_Shown(object sender, EventArgs e)
        {
 	        GridUnaccepted.DataSource = new SalesInvoiceAcceptanceDetailDataManager().GetUnaccepted(BaseControl.BranchId);
            UnacceptedView.RefreshData();
        }

        private void UpdateAcceptance(object sender, EventArgs e)
        {
            var rows = InvoiceView.GetSelectedRows();
            lkpKurir.Value = null;
            lkpKurir.Text = string.Empty;
            tbxKwitansi.Text = InvoiceView.GetRowCellValue(rows[0], "RefNumber").ToString();
            if (InvoiceView.GetRowCellValue(rows[0], "CollectorId") != null)
                lkpKurir.DefaultValue = new IListParameter[] { WhereTerm.Default((int)InvoiceView.GetRowCellValue(rows[0], "CollectorId"), "id", EnumSqlOperator.Equals) };
        }

        private void DeleteRow(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var dialog = MessageForm.Ask(form, Resources.delete_confirm, Resources.delete_confirm_msg);
            if (dialog == DialogResult.Yes)
            {
                var rowHandle = InvoiceView.FocusedRowHandle;
                if (InvoiceView.GetRowCellValue(rowHandle, InvoiceView.Columns["Id"]) != null) DeletedRows.Add((int)InvoiceView.GetRowCellValue(rowHandle, InvoiceView.Columns["Id"]));
                InvoiceView.DeleteSelectedRows();
            }
        }

        private void AddRow()
        {
            if (tbxKwitansi.Text == string.Empty)
            {
                tbxKwitansi.Focus();
                return;
            }

            var invoice = new SalesInvoiceDataManager().GetFirst<SalesInvoiceModel>(WhereTerm.Default(tbxKwitansi.Text, "ref_number", EnumSqlOperator.Equals));
            if (invoice == null)
            {
                MessageBox.Show(@"No Kwitansi tidak dikenali", Resources.information,
                            MessageBoxButtons.OK);
            }
            else
            {
                if (invoice.Cancelled) MessageBox.Show("No kwitansi sudah dibatalkan.");
                else if (!invoice.Printed) MessageBox.Show("No kwitansi belum dicetak");
                else
                {
                    if (!new InvoiceToFinanceDetailDataManager().IsRefSent(tbxKwitansi.Text)) MessageBox.Show("No Kwitansi ini belum pernah dikirim oleh billing.");
                    Detail(invoice);
                }
                
            }

            tbxKwitansi.Clear();
            lkpKurir.Value = null;
            lkpKurir.Text = "";
            tbxKwitansi.Focus();
        }

        private void PrintPreview(object sender, EventArgs e)
        {
            var print = new AcceptancePrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = GridInvoice.DataSource;

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "From",
                    Value = tbxDate.Value,
                    Visible = false
                });

                var salesAcceptance = new SalesInvoiceAcceptanceDataManager().GetFirst<SalesInvoiceAcceptanceModel>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));

                print.Parameters.Add(new Parameter
                {
                    Name = "Code",
                    Value = salesAcceptance.Code,
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
            var print = new AcceptancePrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = GridInvoice.DataSource;

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "From",
                    Value = tbxDate.Value,
                    Visible = false
                });

                var salesAcceptance = new SalesInvoiceAcceptanceDataManager().GetFirst<SalesInvoiceAcceptanceModel>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));

                print.Parameters.Add(new Parameter
                {
                    Name = "Code",
                    Value = salesAcceptance.Code,
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

        private void Detail(SalesInvoiceModel invoice)
        {
            
            var details = GridInvoice.DataSource as List<InvoiceAcceptanceDetailModel>;
            if (details.Where(p => p.RefNumber == invoice.RefNumber).FirstOrDefault() == null)
            {
                if (!new SalesInvoiceAcceptanceDetailDataManager().IsAccepted(invoice.RefNumber))
                {
                    details.Add(new InvoiceAcceptanceDetailModel
                    {
                        Id = 0,
                        SalesInvoiceId = invoice.Id,
                        RefNumber = invoice.RefNumber,
                        CustomerName = invoice.CompanyInvoicedTo,
                        Period = invoice.Period,
                        Total = invoice.Total,
                        CollectorId = lkpKurir.Value,
                        CollectorName = lkpKurir.Text,
                        StateChange = EnumStateChange.Insert.ToString()
                    });

                    GridInvoice.DataSource = details;
                    InvoiceView.RefreshData();

                    InvoiceView.FocusedRowHandle = InvoiceView.RowCount - 1;
                }
                else MessageBox.Show("No Kwitansi sudah diterima.");
            }
            else
            {
                for (int i = 0; i < InvoiceView.RowCount; i++)
                {
                    if (InvoiceView.GetRowCellValue(i, InvoiceView.Columns["RefNumber"]).ToString().Equals(tbxKwitansi.Text))
                    {
                        InvoiceView.SetRowCellValue(i, InvoiceView.Columns["CollectorId"], lkpKurir.Value);
                        InvoiceView.SetRowCellValue(i, InvoiceView.Columns["CollectorName"], lkpKurir.Text);
                        InvoiceView.SetRowCellValue(i, InvoiceView.Columns["StateChange"], EnumStateChange.Update.ToString());
                    }
                }
            }
        }

        private void InvoiceAcceptanceLoad(object sender, System.EventArgs e)
        {
            EnableBtnSearch = true;
            SearchPopup = new InvoiceAcceptanceFilterPopup();

            UnacceptedView.CustomColumnDisplayText += NumberGrid;
            InvoiceView.CustomColumnDisplayText += NumberGrid;

            EnableBtnSearch = true;
            btnTambah.Enabled = false;

            lkpKurir.LookupPopup = new CollectorPopup();
            lkpKurir.AutoCompleteDataManager = new EmployeeDataManager();
            lkpKurir.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " " + ((EmployeeModel)model).Name;
            lkpKurir.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("(code = @0 or name.StartsWith(@0)) and branch_id = @1 and as_collector", s, BaseControl.BranchId);

            tsBaseBtn_Print.Click += Print;
            tsBaseBtn_PrintPreview.Click += PrintPreview;
        }

        public override void New()
        {
            base.New();

            ClearForm();
            ToolbarCode = string.Empty;
            StateChange = EnumStateChange.Insert;
            GridInvoice.DataSource = null;
            InvoiceView.RefreshData();

            EnableBtnPrint = false;
            EnableBtnPrintPreview = false;

            DeletedRows = new List<int>();

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;
            btnTambah.Enabled = true;

            tbxDate.Value = DateTime.Now;
            tbxKwitansi.Focus();

            GridUnaccepted.DataSource = new SalesInvoiceAcceptanceDetailDataManager().GetUnaccepted(BaseControl.BranchId);
            UnacceptedView.RefreshData();

            GridInvoice.DataSource = new List<InvoiceAcceptanceDetailModel>();
            InvoiceView.RefreshData();
        }

        public override void Save()
        {
            if (InvoiceView.RowCount == 0)
            {
                MessageForm.Info(form, Resources.title_save_changes, Resources.stt_detail_empty);
                tbxKwitansi.Focus();
                tbxKwitansi.Clear();
                return;
            }

            // ReSharper disable once RedundantAssignment
            var invoice = CurrentModel as SalesInvoiceAcceptanceModel;
            if (CurrentModel.Id == 0)
            {
                if (tbxDate.Text != "")
                    Code = GetCode("invoice-acceptance", tbxDate.Value);
            }
            else
            {
                invoice = new SalesInvoiceAcceptanceDataManager().GetFirst<SalesInvoiceAcceptanceModel>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));
                Code = invoice.Code;
            }

            base.Save();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            form.Enabled = false;
            var invoice = new SalesInvoiceAcceptanceDataManager().GetFirst<SalesInvoiceAcceptanceModel>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));
            Code = invoice.Code;

            StateChange = EnumStateChange.Select;
            for (int i = 0; i < InvoiceView.RowCount; i++)
            {
                int rowHandle = InvoiceView.GetVisibleRowHandle(i);
                if (InvoiceView.IsDataRow(rowHandle))
                {
                    var state = InvoiceView.GetRowCellValue(rowHandle, InvoiceView.Columns["StateChange"]);
                    if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                    {
                        var detail = new SalesInvoiceAcceptanceDetailModel();
                        detail.Rowstatus = true;
                        detail.Rowversion = DateTime.Now;
                        detail.SalesInvoiceAcceptanceId = CurrentModel.Id;
                        detail.SalesInvoiceId = (int)InvoiceView.GetRowCellValue(rowHandle, InvoiceView.Columns["SalesInvoiceId"]);

                        if (InvoiceView.GetRowCellValue(rowHandle, InvoiceView.Columns["CollectorId"]) != null)
                            detail.CollectorId = (int)InvoiceView.GetRowCellValue(rowHandle, InvoiceView.Columns["CollectorId"]);

                        detail.Createddate = DateTime.Now;
                        detail.Createdby = BaseControl.UserLogin;

                        new SalesInvoiceAcceptanceDetailDataManager().Save<SalesInvoiceAcceptanceDetailModel>(detail);
                    }

                    if (state.ToString().Equals(EnumStateChange.Update.ToString()))
                    {
                        var rec = new SalesInvoiceAcceptanceDetailDataManager().GetFirst<SalesInvoiceAcceptanceDetailModel>(WhereTerm.Default((int)InvoiceView.GetRowCellValue(rowHandle, InvoiceView.Columns["Id"]), "id", EnumSqlOperator.Equals));
                        if(rec != null)
                        {
                            if (InvoiceView.GetRowCellValue(rowHandle, InvoiceView.Columns["CollectorId"]) != null)
                                rec.CollectorId = (int)InvoiceView.GetRowCellValue(rowHandle, InvoiceView.Columns["CollectorId"]);
                            else rec.CollectorId = null;

                            rec.Modifieddate = DateTime.Now;
                            new SalesInvoiceAcceptanceDetailDataManager().Update<SalesInvoiceAcceptanceDetailModel>(rec);
                        }
                    }
                }
            }
            
            invoice.Modifiedby = BaseControl.UserLogin;
            invoice.Modifieddate = DateTime.Now;
            invoice.ModifiedPc = Environment.MachineName;

            new SalesInvoiceAcceptanceDataManager().Update<SalesInvoiceAcceptanceModel>(invoice);

            foreach (int o in DeletedRows)
            {
                var data = new SalesInvoiceAcceptanceDetailDataManager().GetFirst<SalesInvoiceAcceptanceDetailModel>(WhereTerm.Default(o, "id", EnumSqlOperator.Equals));
                if (data != null)
                {
                    new SalesInvoiceAcceptanceDetailDataManager().DeActive(o, BaseControl.UserLogin, DateTime.Now);
                }
            }

            Enabled = true;
            ToolbarCode = invoice.Code;
        }

        protected override void AfterSave()
        {
            OpenData(ToolbarCode);
            tsBaseTxt_Code.Focus();
        }

        public override void AfterDelete()
        {
            var detail = new SalesInvoiceAcceptanceDetailDataManager().Get<SalesInvoiceAcceptanceDetailModel>(WhereTerm.Default(CurrentModel.Id, "sales_invoice_acceptance_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new SalesInvoiceAcceptanceDetailDataManager();
                foreach (SalesInvoiceAcceptanceDetailModel obj in detail)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                }
            }

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (InvoiceView.RowCount == 0)
            {
                tbxKwitansi.Focus();
                return false;
            }

            return true;
        }

        protected override void PopulateForm(SalesInvoiceAcceptanceModel model)
        {
            ClearForm();
            EnableBtnPrint = false;
            EnableBtnPrintPreview = false;
            btnTambah.Enabled = false;
            if (model == null) return;

            EnableBtnPrint = true;
            EnableBtnPrintPreview = true;
            btnTambah.Enabled = true;

            DeletedRows = new List<int>();

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            ToolbarCode = model.Code;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = model.DateProcess.ToString();

            var details = new SalesInvoiceAcceptanceDetailDataManager().GetDetails(model.Id);

            GridUnaccepted.DataSource = new SalesInvoiceAcceptanceDetailDataManager().GetUnaccepted(BaseControl.BranchId);
            UnacceptedView.RefreshData();

            GridInvoice.DataSource = details;
            tsBaseTxt_Code.Focus();
        }

        protected override SalesInvoiceAcceptanceModel PopulateModel(SalesInvoiceAcceptanceModel model)
        {
            model.DateProcess = tbxDate.Value;
            model.Code = Code;
            model.BranchId = BaseControl.BranchId;

            if (model.Id == 0)
            {
                model.CreatedPc = Environment.MachineName;
            }
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override SalesInvoiceAcceptanceModel Find(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm)) tsBaseTxt_Code.Text = searchTerm;
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<SalesInvoiceAcceptanceModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as SalesInvoiceAcceptanceModel;

            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }
    }
}