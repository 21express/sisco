using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Finance.Popup;
using SISCO.Presentation.Finance.Report;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class SendTitipInvoiceForm : BaseCrudForm<OtherInvoiceSendModel, OtherInvoiceSendDataManager>//BaseToolbarForm//
    {
        public SendTitipInvoiceForm()
        {
            InitializeComponent();
            form = this;
            btnGet.Click += (s, e) => GetData();

            SearchPopup = new SendInvoiceFilterPopup();

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
            };

            tsBaseBtn_Print.Click += Print;
        }

        private void Print(object sender, EventArgs e)
        {
            var print = new KirimTitipInvoicePrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = GridSend.DataSource;

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "Code",
                    Value = tbxNomor.Text,
                    Visible = false
                });

                var branch = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id"));
                print.Parameters.Add(new Parameter
                {
                    Name = "OriginBranch",
                    Value = branch.Name,
                    Visible = false
                });

                branch = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default((int) lkpDestBranch.Value, "id"));

                print.Parameters.Add(new Parameter
                {
                    Name = "DestBranch",
                    Value = branch.Name,
                    Visible = false
                });

                print.CreateDocument();

                #if(DEBUG)
                printTool.ShowPreviewDialog();
                #else
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                };
                printTool.Print();
                #endif
            }
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);
            EnableBtnSearch = true;

            lkpDestBranch.LookupPopup = new BranchPopup();
            lkpDestBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpDestBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            lkpDestBranch.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0))", s);
        }

        private void GetData()
        {
            if (lkpDestBranch.Value == null)
            {
                lkpDestBranch.Focus();
                return;
            }

            var start = tbxStart.DateTime;
            start = new DateTime(start.Year, start.Month, start.Day, 0, 0, 0);
            var end = tbxEnd.DateTime;
            end = new DateTime(end.Year, end.Month, end.Day, 23, 59, 59);

            var others = new OtherInvoiceDataManager().GetUnsendInvoice(BaseControl.BranchId, (int)lkpDestBranch.Value, start, end);

            GridSend.DataSource = others;
            SendView.RefreshData();
        }

        protected override void BeforeNew()
        {
            ClearForm();
            EnabledForm(true);

            tbxDate.DateTime = DateTime.Now;
            tbxStart.DateTime = DateTime.Now;
            tbxEnd.DateTime = DateTime.Now;

            gbCreate.Enabled = true;
            GridSend.DataSource = null;
            SendView.RefreshData();

            EnableBtnPrint = false;
        }

        protected override bool ValidateForm()
        {
            if (lkpDestBranch.Value == null)
            {
                lkpDestBranch.Focus();
                return false;
            }

            if (tbxStart.DateTime == null)
            {
                tbxStart.Focus();
                return false;
            }

            if (tbxEnd.DateTime == null)
            {
                tbxEnd.Focus();
                return false;
            }

            var others = GridSend.DataSource as List<SendInvoice>;
            if (others.Where(p => p.Checked).ToList().Count == 0)
            {
                return false;
            }

            return true;
        }

        protected override void PopulateForm(OtherInvoiceSendModel model)
        {
            ClearForm();
            EnabledForm(false);
            gbCreate.Enabled = false;

            ToolbarCode = model.Id.ToString();

            tbxDate.DateTime = model.DateProcess;
            lkpDestBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(model.DestBranchId, "id", EnumSqlOperator.Equals) };
            tbxNomor.Text = model.Code;
            tbxStart.DateTime = model.FromDate;
            tbxEnd.DateTime = model.ToDate;

            var details = new OtherInvoiceSendDetailDataManager().GetDetailsInvoice(CurrentModel.Id);
            GridSend.DataSource = details;
            SendView.RefreshData();

            EnableBtnPrint = true;
        }

        protected override OtherInvoiceSendModel PopulateModel(OtherInvoiceSendModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.Code = tbxNomor.Text;
            model.DestBranchId = (int) lkpDestBranch.Value;
            model.FromDate = tbxStart.DateTime;
            model.ToDate = tbxEnd.DateTime;
            model.BranchId = BaseControl.BranchId;

            return model;
        }

        protected override OtherInvoiceSendModel Find(string searchTerm)
        {
            var param = new IListParameter[]
                {
                    WhereTerm.Default(Convert.ToInt32(tsBaseTxt_Code.Text), "id", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<OtherInvoiceSendModel>(param);

            return obj;
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            var DetailRepo = new OtherInvoiceSendDetailDataManager();
            for (int i = 0; i < SendView.RowCount; i++)
            {
                if ((bool)SendView.GetRowCellValue(i, SendView.Columns["Checked"]))
                {
                    var detail = new OtherInvoiceSendDetailModel();

                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.OtherInvoiceSendId = CurrentModel.Id;
                    detail.OtherInvoiceId =
                            (int)SendView.GetRowCellValue(i, SendView.Columns["Id"]);

                    detail.Createdby = BaseControl.UserLogin;
                    detail.Createddate = DateTime.Now;

                    DetailRepo.Save<OtherInvoiceSendDetailModel>(detail);
                }
            }
        }

        protected override void AfterSave()
        {
            ToolbarCode = CurrentModel.Id.ToString();
            OpenData(ToolbarCode);
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            if (TotalPage > 0)
            {
                tsBaseBtn_Print.Enabled = true;
                tsBaseBtn_PrintPreview.Enabled = false;
            }

            var model = CurrentModel as ShipmentModel;
            if (model != null && model.Id > 0)
            {
                EnabledForm(false);
                tsBaseBtn_Save.Enabled = false;
                NavigationMenu.SaveStrip.Enabled = false;
                tsBaseBtn_Delete.Enabled = false;
                NavigationMenu.DeleteStrip.Enabled = false;
            }
        }
    }
}