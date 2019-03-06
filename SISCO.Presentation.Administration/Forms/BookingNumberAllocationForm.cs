using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraReports.UI;
using SISCO.App.Administration;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Administration.Reports;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Administration.Forms
{
    public partial class BookingNumberAllocationForm : BaseCrudForm<BookingPodModel, BookingPodDataManager>//BaseToolbarForm//
    {
        public BookingNumberAllocationForm()
        {
            InitializeComponent();
            form = this;

            tbxJml.EditMask = "#0";
            tbxTtlBooking.EditMask = "#0";
            tbxTtlResi.EditMask = "#0";

            lkpSprinter.Leave += CheckHistory;
            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id") };
            BookingView.ShowingEditor += BookingView_ShowingEditor;
            BookingView.CustomColumnDisplayText += NumberGrid;
            BookingView.DataSourceChanged += BookingView_DataSourceChanged;
        }

        private void BookingView_DataSourceChanged(object sender, EventArgs e)
        {
            var detail = GridBooking.DataSource as List<BookingPodDetailModel>;
            tbxTtlBooking.Value = detail.Count;
            tbxTtlResi.Value = detail.Where(p => !string.IsNullOrEmpty(p.ShipmentCode)).ToList().Count();
        }

        private void BookingView_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(BookingView.GetRowCellValue(BookingView.FocusedRowHandle, BookingView.Columns["ShipmentCode"]).ToString()) || CurrentModel.Id > 0)
            {
                e.Cancel = true;
            }
        }

        private void CheckHistory(object sender, EventArgs e)
        {
            if (StateChange != EnumStateChange.Insert) return;
            if (lkpSprinter.Value == null)
            {
                GridBooking.DataSource = null;
                ClearForm();
                return;
            }

            var bookingMaster = new BookingPodDataManager().Get<BookingPodModel>(WhereTerm.Default((int) lkpSprinter.Value, "sprinter_id")).ToList();
            var listBooking = new List<string>();
            if (bookingMaster.Count > 0)
            {
                foreach (var b in bookingMaster)
                {
                    if (b.BookingCount > 1)
                    {
                        var numb = Convert.ToInt16(b.BookingStart.Substring(4, 4));
                        for (var i = numb; i < numb + b.BookingCount; i++)
                        {
                            listBooking.Add(string.Format("{0}{1}{2}", b.BookingStart.Substring(0, 4), i.ToString("0000"), b.BookingStart.Substring(8, 4)));
                        }
                    } else listBooking.Add(b.BookingStart);
                }
            }

            if (listBooking.Count > 0)
            {
                var detail = new BookingPodDetailDataManager().BookingAudit(listBooking);
                var notUsed = listBooking.Where(p => !detail.Select(d => d.BookingNo).Any(p2 => p2 == p)).ToList();
                foreach (var n in notUsed)
                {
                    detail.Add(new BookingPodDetailModel
                    {
                        BookingNo = n,
                        ShipmentCode = string.Empty,
                        IsPodExists = false,
                        ReasonLost = string.Empty,
                        StateChange = EnumStateChange.Insert
                    });
                }

                GridBooking.DataSource = detail;
                BookingView.RefreshData();
            }
            else
            {
                GridBooking.DataSource = new List<BookingPodDetailModel>();
                BookingView.RefreshData();
            }
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            lkpSprinter.LookupPopup = new EmployeePopup(EmployeeModel.EmployeeType.Messenger, new IListParameter[] {WhereTerm.Default(BaseControl.BranchId, "branch_id")});
            lkpSprinter.AutoCompleteDataManager = new EmployeeDataManager();
            lkpSprinter.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            lkpSprinter.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0) AND branch_id = @1)", s, BaseControl.BranchId);

            btnPrint.Click += PrintLabel;
            gbBooking.Visible = false;


            btnSave.Click += (o, args) => Save();
        }

        private void PrintLabel(object sender, EventArgs e)
        {
            var barcode = new List<PrintBarcode>();
            string customerCode = string.Empty;
            string customerName = string.Empty;
            string customerPhone = string.Empty;
            string customerAddress = string.Empty;

            var done = false;
            var nums = Convert.ToInt16(tbxStart.Text.Substring(4, 4));
            while (!done)
            {
                var code = string.Format("{0}{1}{2}", tbxStart.Text.Substring(0, 4), nums.ToString("0000"), tbxStart.Text.Substring(8, 4));
                barcode.Add(new PrintBarcode
                {
                    Code = code,
                    BranchName = BaseControl.BranchCode,
                    CourierName = lkpSprinter.Text
                });

                if (code == tbxEnd.Text) done = true;
                else nums++;
            }

            var a = new BarcodeBooking();
            a.DataSource = barcode;
            a.CreateDocument();

            var printTool = new ReportPrintTool(a);
            printTool.PrintingSystem.StartPrint += (o, args) =>
            {
                args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.Barcode;
            };
            printTool.Print();

            var model = CurrentModel as BookingPodModel;
            model.Print = true;
            model.Modifiedby = BaseControl.UserLogin;
            model.Modifieddate = DateTime.Now;

            new BookingPodDataManager().Update<BookingPodModel>(model);
            DataManager = new BookingPodDataManager();
            OpenData(ToolbarCode);
        }

        protected override bool ValidateForm()
        {
            if (lkpSprinter.Value == null)
            {
                lkpSprinter.Focus();
                return false;
            }

            if (tbxJml.Value == 0)
            {
                tbxJml.Focus();
                return false;
            }

            return true;
        }

        protected override void PopulateForm(BookingPodModel model)
        {
            ClearForm();

            ToolbarCode = model.Code;
            
            lkpSprinter.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.SprintId, "id") };
            tbxJml.SetValue((decimal)model.BookingCount);
            tbxStart.Text = model.BookingStart;
            tbxEnd.Text = model.BookingEnd;

            gbBooking.Visible = true;

            GridBooking.DataSource = new BookingPodDetailDataManager().Get<BookingPodDetailModel>(WhereTerm.Default(model.Id, "booking_pod_id"));
            BookingView.RefreshData();

            EnabledForm(false);

            btnPrint.Enabled = !model.Print;
        }

        protected override BookingPodModel PopulateModel(BookingPodModel model)
        {
            model.DateProcess = DateTime.Now;
            if (model.Id == 0)
            {
                model.Code = GetCode("booking", model.DateProcess);
                model.BookingEnd = GetCode("booking_pod", model.DateProcess, (int) tbxJml.Value);
                if (tbxJml.Value == 1) model.BookingStart = model.BookingEnd;
                else
                {
                    var count = Convert.ToInt16(model.BookingEnd.Substring(4, 4));
                    model.BookingStart = string.Format("{0}{1}{2}", model.BookingEnd.Substring(0, 4), ((count - (int)tbxJml.Value)+1).ToString("0000"), model.BookingEnd.Substring(8, 4));
                }
            }

            model.SprintId = (int)lkpSprinter.Value;
            model.BranchId = BaseControl.BranchId;
            model.BookingCount = (int) tbxJml.Value;

            model.HistoryTtlBooking = (int) tbxTtlBooking.Value;
            model.HistoryTtlPod = (int)tbxTtlResi.Value;

            return model;
        }

        protected override BookingPodModel Find(string searchTerm)
        {
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<BookingPodModel>(param);

            return obj;
        }

        public override void New()
        {
            ClearForm();
            GridBooking.DataSource = null;
            BookingView.RefreshData();

            lkpSprinter.Focus();
            EnabledForm(true);
            btnPrint.Enabled = false;

            gbBooking.Visible = false;

            base.New();
        }

        public override void Save()
        {
            var detail = GridBooking.DataSource as List<BookingPodDetailModel>;
            if (detail.Any(p => string.IsNullOrEmpty(p.ShipmentCode) && (!p.IsPodExists && string.IsNullOrEmpty(p.ReasonLost))))
            {
                MessageBox.Show("Mohon berikan alasan untuk nomor Booking POD yang tidak terlampir Fisiknya.");
                return;
            }

            base.Save();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            for (int i = 0; i < BookingView.RowCount; i++)
            {
                int rowHandle = BookingView.GetVisibleRowHandle(i);
                if (BookingView.IsDataRow(rowHandle))
                {
                    var state = BookingView.GetRowCellValue(rowHandle, BookingView.Columns["StateChange"]);
                    if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                    {
                        var detail = new BookingPodDetailModel();
                        detail.Rowstatus = true;
                        detail.Rowversion = DateTime.Now;
                        detail.BookingPodId = CurrentModel.Id;
                        detail.BookingNo = BookingView.GetRowCellValue(rowHandle, BookingView.Columns["BookingNo"]).ToString();
                        detail.ShipmentCode = BookingView.GetRowCellValue(rowHandle, BookingView.Columns["ShipmentCode"]).ToString();
                        detail.IsPodExists = Convert.ToBoolean(BookingView.GetRowCellValue(rowHandle, BookingView.Columns["IsPodExists"]));
                        detail.ReasonLost = BookingView.GetRowCellValue(rowHandle, BookingView.Columns["ReasonLost"]).ToString();
                        detail.Createddate = DateTime.Now;
                        detail.Createdby = BaseControl.UserLogin;

                        new BookingPodDetailDataManager().Save<BookingPodDetailModel>(detail);
                    }
                }
            }
        }

        protected override void AfterSave()
        {
            ToolbarCode = ((BookingPodModel)CurrentModel).Code;
            OpenData(ToolbarCode);
        }
    }
}