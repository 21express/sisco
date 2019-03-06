using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Corporate.Presentation.Common.Component;
using Corporate.Presentation.Common.Properties;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using SISCO.App.Operation;
using SISCO.Models;

namespace Corporate.Presentation.Common.Forms
{
    public partial class BaseForm : Form
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

        protected ShipmentStatusModel PodStatusModel { get; set; }
        protected EnumTrackingStatus FormTrackingStatus { get; set; }
        protected bool Dirty { get; set; }
        protected bool InsertTracking { get; set; }

        protected Form form { get; set; }
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
            InitializeComponent();

            PageLimit = 1;
            PodStatusModel = new ShipmentStatusModel();
            StartPosition = FormStartPosition.CenterScreen;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            AutoScaleMode = AutoScaleMode.Font;
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
                if (ctrl is dLookupC)
                {
                    var s = ctrl as dLookupC;
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

        public virtual void ExportGridToExcel(GridView _gridView, string defaultFileName = "export", bool appendTimestamp = true, string format = "xlsx")
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
                                TextExportMode = TextExportMode.Text,
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

        public virtual void EnabledForm(bool enabled)
        {
            _SetControlEnableState(form, enabled);
        }

        protected void _SetControlEnableState(Control container, bool state)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl.Name != "tbxSearch_Code")
                if (ctrl is dTextBoxNumber) ((dTextBoxNumber)ctrl).Enabled = state;
                else if (ctrl is dTextBox) ((dTextBox)ctrl).Enabled = state;
                else if (ctrl is dCalendar) ((dCalendar)ctrl).Enabled = state;
                else if (ctrl is dLookupC) ((dLookupC)ctrl).Enabled = state;
                else if (ctrl is dComboBox) (ctrl).Enabled = state;
                else if (ctrl is dCheckBox) (ctrl).Enabled = state;
                else if (ctrl is CheckBox) (ctrl).Enabled = state;

                if (ctrl.Controls.Count > 0) _SetControlEnableState(ctrl, state);
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
                   , Resources.title_confirmation
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
                var resultBtn = MessageForm.Ask(this, Resources.title_information, Resources.dirty_form);
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
                var resultBtn = MessageForm.Ask(this, Resources.title_information, Resources.dirty_form);
                if (resultBtn == DialogResult.No) return;
            }
            CurrentModel = LoadModel<T>();
            Dirty = false;
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
                var navigator = ((GridView)sender).GridControl.UseEmbeddedNavigator;
                if (navigator)
                {
                    //e.DisplayText = (e.RowHandle + 1).ToString();
                    var ind = CurrentIndexPage == 0 ? 0 : CurrentIndexPage - 1;
                    e.DisplayText = ((ind * PageLimit) + e.RowHandle + 1).ToString();
                }
                else e.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        protected void ShipmentStatusUpdate()
        {
            var dataManager = new ShipmentStatusDataManager();

            PodStatusModel.Rowstatus = true;
            PodStatusModel.Rowversion = DateTime.Now;
            PodStatusModel.DateProcess = DateTime.Now;
            PodStatusModel.BranchId = BaseControl.BranchId;
            if (PodStatusModel.TrackingStatusId != (int)EnumTrackingStatus.Delivery)
                PodStatusModel.StatusBy = (PodStatusModel.TrackingStatusId != (int)EnumTrackingStatus.Received) ? BaseControl.UserLogin : PodStatusModel.StatusBy;
            
            PodStatusModel.Createddate = DateTime.Now;
            PodStatusModel.Createdby = BaseControl.UserLogin;

            var shipmentStatus = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                WhereTerm.Default(PodStatusModel.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                WhereTerm.Default(PodStatusModel.TrackingStatusId, "tracking_status_id", EnumSqlOperator.Equals)
            });

            if (InsertTracking && shipmentStatus == null)
            {
                switch (FormTrackingStatus)
                {
                    case EnumTrackingStatus.Acceptance:
                        PodStatusModel.TrackingStatusId = (int)EnumTrackingStatus.Pickup;
                        dataManager.Save<ShipmentStatusModel>(PodStatusModel);

                        PodStatusModel.TrackingStatusId = (int)EnumTrackingStatus.Acceptance;
                        PodStatusModel.StatusBy = BaseControl.UserLogin;
                        dataManager.Save<ShipmentStatusModel>(PodStatusModel);
                        break;

                    default:
                        PodStatusModel.TrackingStatusId = (int)FormTrackingStatus;
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
    }
}
