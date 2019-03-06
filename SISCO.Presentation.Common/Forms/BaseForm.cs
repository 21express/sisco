using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common.Component;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.Presentation.Common.Interfaces;
using SISCO.Presentation.Common.Properties;
using System.Transactions;

namespace SISCO.Presentation.Common.Forms
{
    public class BaseForm : Form, IBaseForm
    {
    
        protected string ObjectName { get; set; }
        protected int TotalRecord { get; set; }
        protected int TotalPage { get; set; }
        protected int PageLimit { get; set; }
        protected int CurrentIndexPage { get; set; }
        protected string NavigationState { get; set; }
        protected IDataManager DataManager { get; set; }
        protected EnumStateChange CrudState { get; set; }

        protected Paging PagingForm { get; set; }

        protected bool InsertTracking { get; set; }
        protected EnumTrackingStatus FormTrackingStatus { get; set; }
        protected ShipmentStatusModel PodStatusModel { get; set; }

        protected IBusinessProcessManager ProcessManager { get; set; }
        // ReSharper disable once InconsistentNaming
        protected Form form { get; set; }
        protected bool Dirty { get; set; }

        public Type CallingCommand { get; set; }
        public bool AllowAccess { get; set; }
        public bool AllowView { get; set; }
        public bool AllowViewAll { get; set; }
        public bool AllowCreate { get; set; }
        public bool AllowEdit { get; set; }
        public bool AllowDelete { get; set; }
        public bool AllowPrint { get; set; }

        public BaseForm()
        {
            PageLimit = 1;
            PodStatusModel = new ShipmentStatusModel();
            StartPosition = FormStartPosition.CenterScreen;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            AutoScaleMode = AutoScaleMode.None;
            //AutoScaleDimensions = CurrentAutoScaleDimensions;
        }

        private string PrefixCode(string prefix, string type, int number, DateTime currTgl)
        {
            switch (type)
            {
                case "consolidation":
                    return string.Format(prefix, BaseControl.BranchCode, currTgl.ToString("yyyyMMdd"), number.ToString("000"));
                case "insurance":
                case "manifest":
                case "manifest-vendor":
                case "inbound":
                case "booking":
                case "acceptance":
                    return string.Format(prefix, BaseControl.BranchCode, currTgl.ToString("yyyy"), currTgl.ToString("MM"), currTgl.ToString("dd"), number.ToString("000"));
                case "pettycash":
                case "consol":
                    return string.Format(prefix, BaseControl.BranchCode, currTgl.Year, number.ToString("000000"));
                case "invoice-acceptance":
                case "refundpph23":
                case "invoicein":
                case "invoiceout":
                case "otherinvoice":
                case "rc":
                case "mc":
                case "deliveryout":
                case "paymentout":
                case "collectout":
                case "collectin":
                case "counter":
                case "franchise-invoice":
                case "franchisepayment":
                case "fundtransferverification":
                case "codfundtransferverification":
                case "codfundtransfer":
                case "codpayment":
                case "fundtransfer":
                case "payment":
                case "pickup-document":
                case "delivery":
                case "cost":
                case "titip-acceptance":
                    return string.Format(prefix, BaseControl.BranchCode, currTgl.ToString("yyyy"), currTgl.ToString("MM"), number.ToString("00000"));
                case "booking_pod":
                    return string.Format(prefix, BaseControl.BranchId.ToString("000"), number.ToString("0000"), currTgl.ToString("MM"), currTgl.ToString("yy"));
            }

            return string.Empty;
        }

        public void ExportExcel(GridControl grid)
        {
            var saveXls = new SaveFileDialog
            {
                Filter = @"xls files (*.xls)|*.xls|xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (saveXls.ShowDialog() == DialogResult.OK)
            {
                if (saveXls.FileName != "")
                {
                    var format = saveXls.FileName.Substring(saveXls.FileName.Length - 1);
                    if (format == "s") grid.ExportToXls(saveXls.FileName);
                    if (format == "x") grid.ExportToXlsx(saveXls.FileName);
                    if (format == "s" || format == "x") System.Diagnostics.Process.Start(saveXls.FileName);
                }
            }
        }

        public void RoundedUp(decimal value, dTextBoxNumber objChargeable, bool isDomestic)
        {
            if (isDomestic)
            {
                // ReSharper disable once SpecifyACultureInStringConversionExplicitly
                objChargeable.SetValue(((int)Math.Ceiling(value)).ToString());
            }
            else
            {
                // ReSharper disable once SpecifyACultureInStringConversionExplicitly
                objChargeable.SetValue((Math.Ceiling(value / new decimal(0.5)) * new decimal(0.5)).ToString());
            }
        }

        protected string GetCode(string tableName, DateTime currTgl, int bookingCount = 0)
        {
            try
            {
                var code = string.Empty;

                using (var dataMan = new PrefixCodeDataManager())
                {
                    // ReSharper disable once TooWideLocalVariableScope
                    int urut = 0;
                    var prefixs = dataMan.Get<PrefixCodeModel>(WhereTerm.Default(tableName, "table", EnumSqlOperator.Equals));
                    // ReSharper disable once PossibleMultipleEnumeration
                    var codeModels = prefixs as PrefixCodeModel[] ?? prefixs.ToArray();
                    var prefixCodeModels = prefixs as IList<PrefixCodeModel> ?? codeModels.ToList();
                    if (!prefixCodeModels.Any())
                    {
                        MessageBox.Show(
                            @"Kode modul belum tersedia. Silakan menghubungi administrator"
                            , Resources.information
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Information);
                    }
                    else
                    {
                        // ReSharper disable once PossibleMultipleEnumeration
                        var tgl = tableName == "manifest" || tableName == "inbound" || tableName == "consolidation" || tableName == "acceptance" ? (sbyte)currTgl.Day : (sbyte)0;
                        var bulan = (sbyte)currTgl.Month;
                        var tahun = (short)currTgl.Year;
                        var prefix = string.Empty;

                        switch (tableName)
                        {
                            case "insurance":
                            case "manifest":
                            case "manifest-vendor":
                            case "inbound":
                            case "acceptance":
                            case "booking":
                            case "consolidation":
                                urut = new SISCO.App.DataManager().PrefixCodeGenerator(tableName, BaseControl.BranchId, tgl, bulan, tahun, ref prefix);
                                break;
                            case "invoice-acceptance":
                            case "refundpph23":
                            case "invoicein":
                            case "invoiceout":
                            case "otherinvoice":
                            case "rc":
                            case "mc":
                            case "deliveryout":
                            case "paymentout":
                            case "collectout":
                            case "collectin":
                            case "counter":
                            case "franchisepayment":
                            case "fundtransferverification":
                            case "codfundtransferverification":
                            case "codpayment":
                            case "franchise-invoice":
                            case "fundtransfer":
                            case "codfundtransfer":
                            case "payment":
                            case "delivery":
                            case "pickup-document":
                            case "cost":
                            case "titip-acceptance":
                                urut = new SISCO.App.DataManager().PrefixCodeGenerator(tableName, BaseControl.BranchId, 0, bulan, tahun, ref prefix);
                                break;
                            case "pettycash":
                            case "consol":
                                urut = new SISCO.App.DataManager().PrefixCodeGenerator(tableName, BaseControl.BranchId, 0, 0, tahun, ref prefix);
                                break;
                            case "booking_pod":
                                urut = new SISCO.App.DataManager().GenerateBookingPod(bookingCount, BaseControl.BranchId, 0, bulan, tahun, ref prefix);
                                break;
                        }

                        code = PrefixCode(prefix, tableName, urut, currTgl);
                    }
                }

                return code;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected string DateTimeToString(DateTime? dt)
        {
            string str = string.Empty;
            if (!string.IsNullOrEmpty(dt.ToString())) str = Convert.ToDateTime(dt.ToString()).ToString("dd MMM YYYY");

            return str;
        }

        public virtual void ClearForm()
        {
            _ClearForm(form);
        }

        public void _ClearForm(Control container)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl is TextEdit || ctrl is TextBox) ctrl.Text = "";
                if (ctrl is dCalendar) ctrl.Text = null;
                if (ctrl is RichTextBox) ctrl.Text = null;
                if (ctrl is dLookup)
                {
                    var s = ctrl as dLookup;
                    s.Text = "";
                    s.Value = null;
                }

                if (ctrl is dTextBoxNumber)
                {
                    var d = ctrl as dTextBoxNumber;
                    d.SetValue("");
                }

                var box = ctrl as CheckBox;
                if (box != null) box.Checked = false;

                if (ctrl.Controls.Count > 0) _ClearForm(ctrl);
            }
        }

        public virtual void EnabledForm(bool enabled)
        {
            _SetControlEnableState(form, enabled);
        }

        protected void _SetControlEnableState(Control container, bool state)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl is dTextBoxNumber) ((dTextBoxNumber)ctrl).Enabled = state;
                else if (ctrl is dTextBox) ((dTextBox)ctrl).Enabled = state;
                else if (ctrl is dCalendar) ((dCalendar)ctrl).Enabled = state;
                else if (ctrl is dLookup) ((dLookup)ctrl).Enabled = state;
                else if (ctrl is dComboBox) (ctrl).Enabled = state;
                else if (ctrl is dCheckBox) (ctrl).Enabled = state;
                else if (ctrl is CheckBox) (ctrl).Enabled = state;
                //else if (ctrl is TextBox) ctrl.Enabled = state;
                //else if (ctrl is TextEdit) ctrl.Enabled = state;
                //else if (ctrl is ComboBox) ctrl.Enabled = state;

                if (ctrl.Controls.Count > 0) _SetControlEnableState(ctrl, state);
            }
        }

        protected void SetDirtyEvent()
        {
            Dirty = false;
            _SetDirtyEvent(form);
        }

        // ReSharper disable once UnusedParameter.Local
        private void _SetDirtyEvent(Control container)
        {
            /*foreach (Control ctlr in container.Controls)
            {
                if (ctlr is dTextBox) ctlr.KeyPress += DirtyForm;
                if (ctlr is dCalendar) ctlr.KeyPress += DirtyForm;
                if (ctlr is dLookup) ctlr.KeyPress += DirtyForm;
                if (ctlr is dTextBoxNumber) ctlr.KeyPress += DirtyForm;
                if (ctlr is Panel) _SetDirtyEvent(ctlr);
            }*/
        }

        private void DirtyForm(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13 || e.KeyChar != 8)
            {
                Dirty = true;
                CrudState = EnumStateChange.Update;
            }
        }

        protected virtual void SetPagingState()
        {
            TotalPage = TotalRecord / (PageLimit == 0 ? 1 : PageLimit);
            if ((TotalRecord - (TotalPage * PageLimit)) > 0)
                TotalPage++;
            NavigationState = TotalRecord == 0 ?
                string.Format("No Record {0} Displaying", ObjectName) :
                string.Format("Displaying {0} {1} of {2}", ObjectName, CurrentIndexPage, TotalPage);

        }

        protected virtual T LoadModel<T>(params IListParameter[] listParameters) where T : IBaseModel
        {
            if (DataManager == null)
                throw new Exception("Data Manager Is Not Instansiated");
            int count;
            PageLimit = 1;

            if (CurrentIndexPage > TotalPage + 1)
            {
                CurrentIndexPage = TotalPage + 1;
            }
            if (CurrentIndexPage < 1)
            {
                CurrentIndexPage = 1;
            }

            var model =
                DataManager.Get<T>(Paging.Instance(CurrentIndexPage - 1, PageLimit), out count, listParameters)
                    .FirstOrDefault();
            TotalRecord = count;

            Dirty = false;
            return model;
        }

        protected virtual void LoadForm(object sender, EventArgs e)
        {
            CurrentIndexPage = 0;
            SetNewRecordState();
        }

        protected virtual void SaveRecord(object sender, EventArgs e)
        {
        }

        protected virtual void PrintPreviewRecord(object sender, EventArgs e)
        {
        }

        protected virtual void PrintRecord(object sender, EventArgs e)
        {
        }

        protected virtual void GotoPreviousRecord(object sender, EventArgs e)
        {
            CurrentIndexPage--;
            BindDataSource<IBaseModel>();
        }

        protected virtual void GotoNextRecord(object sender, EventArgs e)
        {
            CurrentIndexPage++;
            BindDataSource<IBaseModel>();
        }

        protected virtual void NewRecord(object sender, EventArgs e)
        {
            if (Dirty)
            {
                var result = (MessageBox.Show(
                   Resources.message_save_changes
                   , Resources.title_save_changes
                   , MessageBoxButtons.YesNoCancel
                   , MessageBoxIcon.Question));

                switch (result)
                {
                    case DialogResult.No:
                    case DialogResult.Cancel:
                        return;
                }
            }

            if (Dirty)
            {
                var resultBtn = MessageForm.Ask(this, Resources.information, Resources.dirty_form);
                if (resultBtn == DialogResult.No) return;
            }

            EnabledForm(true);
            CrudState = EnumStateChange.Insert;
            Dirty = false;
        }

        protected virtual void GotoLastRecord(object sender, EventArgs e)
        {
            CurrentIndexPage = TotalPage;
            BindDataSource<IBaseModel>();
        }

        protected virtual void GotoFirstRecord(object sender, EventArgs e)
        {
            CurrentIndexPage = 1;
            BindDataSource<IBaseModel>();
        }

        protected virtual void DeleteRecord(object sender, EventArgs e)
        {
        }

        protected virtual void SetNewRecordState()
        {
            CrudState = EnumStateChange.Insert;
        }

        protected IBaseModel CurrentModel { get; set; }
        protected virtual void BindDataSource<T>() where T : IBaseModel
        {
            if (Dirty)
            {
                var resultBtn = MessageForm.Ask(this, Resources.information, Resources.dirty_form);
                if (resultBtn == DialogResult.No) return;
            }
            CurrentModel = LoadModel<T>();
            Dirty = false;
        }

        public virtual void ExportGridToExcel(GridView _gridView, string defaultFileName = "export", bool appendTimestamp = true, string format = "xlsx", TextExportMode exportMode = TextExportMode.Text)
        {
            string filter;
            switch (format)
            {
                case "xlsx":
                    filter = @"Microsoft Excel 2007 files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    break;
                case "csv":
                    filter = @"CSV (Comma separated values) files (*.csv)|*.xlsx|All files (*.*)|*.*";
                    break;
                default:
                    throw new Exception(string.Format("THe grid cannot be exported because the format {0} requested is not supported", format));
            }

            using (var dialog = new SaveFileDialog())
            {
                dialog.FileName = defaultFileName + (appendTimestamp ? "_" + DateTime.Now.ToString("yyyyMMddHHmm") : "") + "." + format;
                dialog.Filter = filter;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    switch (format)
                    {
                        case "xlsx":
                            _gridView.ExportToXlsx(dialog.FileName, new XlsxExportOptions
                            {
                                TextExportMode = exportMode,
                                ExportMode = XlsxExportMode.SingleFile,
                                ShowGridLines = true
                            });
                            break;
                        case "csv":
                            _gridView.ExportToCsv(dialog.FileName, new CsvExportOptions()
                            {
                                TextExportMode = TextExportMode.Value,
                            });
                            break;
                    }
                    

                    if (File.Exists(dialog.FileName))
                    {
                        System.Diagnostics.Process.Start("explorer.exe", @"/select,""" + dialog.FileName + "\"");
                    }
                }
            }
        }

        public static TDerived ConvertModel<TBase, TDerived>(IBaseModel source)
            where TBase : IBaseModel
            where TDerived : TBase
        {
            var derivedType = typeof(TDerived);
            var instance = Activator.CreateInstance(derivedType);

            PropertyInfo[] properties = typeof(TBase).GetProperties();
            foreach (var property in properties)
            {
                property.SetValue(instance, property.GetValue(source, null), null);
            }

            return (TDerived)instance;
        }

        protected void NumberGrid(object sender, CustomColumnDisplayTextEventArgs e)
        {
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            if (e.Column.FieldName == "")
            {
                var navigator = ((GridView) sender).GridControl.UseEmbeddedNavigator;
                if (navigator)
                {
                    //e.DisplayText = (e.RowHandle + 1).ToString();
                    var ind = CurrentIndexPage == 0 ? 0 : CurrentIndexPage - 1;
                    e.DisplayText = ((ind * PageLimit) + e.RowHandle + 1).ToString();
                }
                else e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        protected void OpenRelatedForm(GridView grid, IChildForm relatedForm, string code = "Code")
        {
            var rows = grid.GetSelectedRows();

            if (rows.Count() > 0)
            {
                BaseControl.OpenRelatedForm(relatedForm, grid.GetRowCellValue(rows[0], code).ToString(), CallingCommand);
            }
        }

        protected void ShipmentStatusUpdate(DateTime? pickupDate = null)
        {
            var dataManager = new ShipmentStatusDataManager();

            PodStatusModel.Rowstatus = true;
            PodStatusModel.Rowversion = DateTime.Now;
            PodStatusModel.DateProcess = DateTime.Now;
            PodStatusModel.BranchId = BaseControl.BranchId;
            if (PodStatusModel.TrackingStatusId != (int) EnumTrackingStatus.Delivery)
                PodStatusModel.StatusBy = (PodStatusModel.TrackingStatusId != (int)EnumTrackingStatus.Received) ? BaseControl.UserLogin : PodStatusModel.StatusBy;
            PodStatusModel.EmployeeId = BaseControl.EmployeeId;
            PodStatusModel.Createddate = DateTime.Now;
            PodStatusModel.Createdby = BaseControl.UserLogin;

            //     
            
            var shipmentStatus = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                WhereTerm.Default(PodStatusModel.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                WhereTerm.Default(PodStatusModel.TrackingStatusId, "tracking_status_id", EnumSqlOperator.Equals)
                       
            });

           // if (FormTrackingStatus == EnumTrackingStatus.Delivery )
            if (FormTrackingStatus == EnumTrackingStatus.Delivery)
            {
                if (shipmentStatus != null)
                {
                    if (shipmentStatus.Reference != PodStatusModel.Reference)
                    {
                        PodStatusModel.TrackingStatusId = (int)FormTrackingStatus;
                        dataManager.Save<ShipmentStatusModel>(PodStatusModel);
                        return;
                    }
                }
            }

            if (FormTrackingStatus == EnumTrackingStatus.Consolidation)
            {
                shipmentStatus = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                {
                    WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                    WhereTerm.Default(PodStatusModel.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                    WhereTerm.Default((int)EnumTrackingStatus.Consolidation, "tracking_status_id", EnumSqlOperator.Equals),
                    WhereTerm.Default(PodStatusModel.Reference, "reference", EnumSqlOperator.Equals)
                });

                if (shipmentStatus == null) InsertTracking = true;
                else
                {
                    InsertTracking = false;
                    if (!string.IsNullOrEmpty(shipmentStatus.StatusNote))
                        PodStatusModel.StatusNote = shipmentStatus.StatusNote + "," + PodStatusModel.StatusNote;
                }
            }

            if (FormTrackingStatus == EnumTrackingStatus.Waybilled)
            {
                shipmentStatus = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                {
                    WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                    WhereTerm.Default(PodStatusModel.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                    WhereTerm.Default((int)EnumTrackingStatus.Waybilled, "tracking_status_id", EnumSqlOperator.Equals),
                    WhereTerm.Default(PodStatusModel.Reference, "reference", EnumSqlOperator.Equals)
                });
                if (shipmentStatus == null) InsertTracking = true;
                else
                {
                    InsertTracking = false;
                    if (!string.IsNullOrEmpty(shipmentStatus.StatusNote))
                        PodStatusModel.StatusNote = shipmentStatus.StatusNote + "," + PodStatusModel.StatusNote;
                }
            }

            if (FormTrackingStatus == EnumTrackingStatus.WaybilledRevised)
            {
                shipmentStatus = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                {
                    WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                    WhereTerm.Default(PodStatusModel.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                    WhereTerm.Default((int)EnumTrackingStatus.WaybilledRevised, "tracking_status_id", EnumSqlOperator.Equals),
                    WhereTerm.Default(PodStatusModel.Reference, "reference", EnumSqlOperator.Equals)
                });
                if (shipmentStatus == null) InsertTracking = true;
                else
                {
                    InsertTracking = false;
                    if (!string.IsNullOrEmpty(shipmentStatus.StatusNote))
                        PodStatusModel.StatusNote = shipmentStatus.StatusNote + "," + PodStatusModel.StatusNote;
                }
            }

            if (InsertTracking && shipmentStatus == null)
            {
                switch (FormTrackingStatus)
                {
                    case EnumTrackingStatus.Acceptance:
                        PodStatusModel.TrackingStatusId = (int) EnumTrackingStatus.Pickup;
                        if (pickupDate != null) PodStatusModel.DateProcess = (DateTime) pickupDate;

                        dataManager.Save<ShipmentStatusModel>(PodStatusModel);

                        PodStatusModel.TrackingStatusId = (int) EnumTrackingStatus.Acceptance;
                        PodStatusModel.StatusBy = BaseControl.UserLogin;
                        if (pickupDate != null) PodStatusModel.DateProcess = DateTime.Now;

                        dataManager.Save<ShipmentStatusModel>(PodStatusModel);
                        break;

                    default:
                        PodStatusModel.TrackingStatusId = (int) FormTrackingStatus;
                        dataManager.Save<ShipmentStatusModel>(PodStatusModel);
                        break;
                }
            }
            else
            {
                if (shipmentStatus != null)
                {
                    shipmentStatus.DateProcess = PodStatusModel.DateProcess;
                    shipmentStatus.BranchId = PodStatusModel.BranchId;
                    shipmentStatus.StatusBy = PodStatusModel.StatusBy;
                    shipmentStatus.StatusNote = PodStatusModel.StatusNote;
                    shipmentStatus.Reference = PodStatusModel.Reference;
                    shipmentStatus.MissDeliveryReason = PodStatusModel.MissDeliveryReason;
                    shipmentStatus.EmployeeId = PodStatusModel.EmployeeId;
                    shipmentStatus.Modifiedby = BaseControl.UserLogin;
                    shipmentStatus.Modifieddate = DateTime.Now;
                    shipmentStatus.ShipmentId = PodStatusModel.ShipmentId;
                    shipmentStatus.PositionStatusId = PodStatusModel.BranchId;
                    shipmentStatus.PositionStatus = PodStatusModel.PositionStatus;

                    new ShipmentStatusDataManager().Update<ShipmentStatusModel>(shipmentStatus);
                }
            }
        }

        public virtual void Print()
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }

        protected virtual void SaveExpand(ShipmentExpandModel expandModel)
        {
            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(CurrentModel.Id, "shipment_id"));
            if (expand != null) new ShipmentExpandDataManager().Update<ShipmentExpandModel>(expandModel);
            else new ShipmentExpandDataManager().Save<ShipmentExpandModel>(expandModel);
        }

        protected virtual void VolumeCalculation(decimal L, decimal W, decimal H, string serviceType, decimal Gw, dTextBoxNumber chargeable)
        {
            var volume = L * W * H;
            if (serviceType == "DARAT" || serviceType == "CITY COURIER" || serviceType == "LAUT") volume = volume / 4000;
            else volume = volume / 6000;

            if (volume > Gw)
            {
                var ceiled = Math.Ceiling(volume);
                if (ceiled > 999999)
                {
                    MessageBox.Show(@"Chargeable maximal 999,999 kg");
                    return;
                }

                chargeable.SetValue(ceiled);
            }
        }

        protected virtual decimal PackingCalculation(decimal L, decimal W, decimal H)
        {
            decimal lwh = L + W + H + 18;
            decimal vol = Math.Round(lwh / 3, MidpointRounding.AwayFromZero);
            return vol * 2000;
        }

        public virtual void AdditionalAction() { }
    }
}