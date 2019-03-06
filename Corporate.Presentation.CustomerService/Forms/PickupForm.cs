using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using Corporate.Presentation.Common;
using Corporate.Presentation.Common.Component;
using Corporate.Presentation.Common.Forms;
using Corporate.Presentation.Common.Properties;
using Corporate.Presentation.CustomerService.Reports;
using Corporate.Presentation.MasterData.Popup;
using SISCO.App.Corporate;
using SISCO.App.MasterData;
using SISCO.Models;
using Corporate.Presentation.CustomerService.Popup;

namespace Corporate.Presentation.CustomerService.Forms
{
    public partial class PickupForm : BaseCrudForm<CorporatePickupModel, CorporatePickupDataManager>//BaseToolbarForm//
    {
        private bool FocusPod { get; set; }
        private decimal TtlSales { get; set; }
        private decimal TtlPpn { get; set; }
        private decimal TtlCommission { get; set; }
        private decimal TtlPph { get; set; }
        private decimal TtlNetCommission { get; set; }

        public PickupForm()
        {
            InitializeComponent();
            form = this;

            Shown += PickupFormShown;
            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.CorporateId, "corporate_id", EnumSqlOperator.Equals)
            };

            PodGrid.DoubleClick += (o, args) =>
            {
                var rows = PodView.GetSelectedRows();

                if (rows.Count() > 0)
                {
                    BaseControl.OpenRelatedForm(new TrackingViewForm(), PodView.GetRowCellValue(rows[0], "ShipmentCode").ToString(), CallingCommand);
                }
            };
        }

        private void PickupFormShown(object sender, EventArgs e)
        {
            TtlSales = 0;
            TtlPpn = 0;
            TtlCommission = 0;
            TtlPph = 0;
            TtlNetCommission = 0;

            EnabledForm(false);

            EnableBtnSearch = true;
            SearchPopup = new PickupPopup();

            ClearForm();
            PodView.CustomColumnDisplayText += NumberGrid;
            PodView.CellValueChanged += Changed;

            tbxMessenger.LookupPopup = new MessengerPopup();
            tbxMessenger.AutoCompleteDataManager = new EmployeeDataManager();
            tbxMessenger.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            tbxMessenger.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_messenger AND branch_id = @1", s, BaseControl.BranchId);

            btnAdd.Click += AddRow;
            tbxPod.KeyDown += (x, args) =>
            {
                FocusPod = false;
                switch (args.KeyCode)
                {
                    case Keys.Enter:
                        if (!args.Shift)
                        {
                            FocusPod = true;
                        }
                        break;
                }

                base.OnKeyDown(args);
            };

            btnAdd.GotFocus += (x, args) =>
            {
                if (FocusPod)
                {
                    FocusPod = false;
                    AddRow(x, args);
                }
            };

            tbxDate.FieldLabel = "Date Process";
            tbxDate.ValidationRules = new[] {new ComponentValidationRule(EnumComponentValidationRule.Mandatory)};

            rbLayout_Print.ItemClick += Print;
            rbLayout_PrintPreview.ItemClick += PrintPreview;
        }

        private void PrintPreview(object sender, ItemClickEventArgs e)
        {
            var print = new PickupPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                var ds = new CorporatePickupDetailDataManager().GetPickupDetailPrint((CurrentModel.Id));
                print.DataSource = ds;
                var model = CurrentModel as CorporatePickupModel;
                var curModel = new CorporatePickupDataManager().GetFirst<CorporatePickupModel>(WhereTerm.Default(CurrentModel.Id, "id"));
                if (curModel != null)
                {
                    if (!curModel.IsPrint)
                    {
                        foreach (var obj in ds)
                        {
                            InsertTracking = true;
                            PodStatusModel.ShipmentId = obj.ShipmentId;
                            PodStatusModel.TrackingStatusId = (int)EnumTrackingStatus.Pickup;
                            PodStatusModel.EmployeeId = model.MessengerId;
                            FormTrackingStatus = EnumTrackingStatus.Pickup;
                            PodStatusModel.PositionStatusId = BaseControl.BranchId;
                            PodStatusModel.PositionStatus = EnumPositionStatus.Agent.ToString();

                            ShipmentStatusUpdate();
                        }
                    }

                    curModel.IsPrint = true;
                    curModel.ModifiedPc = Environment.MachineName;
                    curModel.Modifiedby = BaseControl.UserLogin;
                    curModel.Modifieddate = DateTime.Now;

                    new CorporatePickupDataManager().Update<CorporatePickupModel>(curModel);
                }

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "Code",
                    Value = ((CorporatePickupModel)CurrentModel).Code,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "DateProcess",
                    Value = ((CorporatePickupModel)CurrentModel).DateProcess,
                    Visible = false
                });

                var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default(BaseControl.CorporateId, "id"));

                print.Parameters.Add(new Parameter
                {
                    Name = "CorporateName",
                    Value = string.Format("{0} {1}", customer.Code, BaseControl.CorporateName),
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Printed",
                    Value = string.Format("{0} {1}", BaseControl.UserLogin, DateTime.Now.ToString("d-MMM-yyyy HH:mm")),
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

        private void Print(object sender, ItemClickEventArgs e)
        {
            var print = new PickupPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                var ds = new CorporatePickupDetailDataManager().GetPickupDetailPrint(CurrentModel.Id);
                print.DataSource = ds;
                var model = CurrentModel as CorporatePickupModel;
                var curModel = new CorporatePickupDataManager().GetFirst<CorporatePickupModel>(WhereTerm.Default(CurrentModel.Id, "id"));
                if (curModel != null)
                {
                    if (!curModel.IsPrint)
                    {
                        foreach (var obj in ds)
                        {
                            InsertTracking = true;
                            PodStatusModel.ShipmentId = obj.ShipmentId;
                            PodStatusModel.TrackingStatusId = (int) EnumTrackingStatus.Pickup;
                            PodStatusModel.EmployeeId = model.MessengerId;
                            FormTrackingStatus = EnumTrackingStatus.Pickup;
                            PodStatusModel.PositionStatusId = BaseControl.BranchId;
                            PodStatusModel.PositionStatus = EnumPositionStatus.Agent.ToString();

                            ShipmentStatusUpdate();
                        }
                    }

                    curModel.IsPrint = true;
                    curModel.ModifiedPc = Environment.MachineName;
                    curModel.Modifiedby = BaseControl.UserLogin;
                    curModel.Modifieddate = DateTime.Now;

                    new CorporatePickupDataManager().Update<CorporatePickupModel>(curModel);
                }

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "Code",
                    Value = ((CorporatePickupModel)CurrentModel).Code,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "DateProcess",
                    Value = ((CorporatePickupModel)CurrentModel).DateProcess,
                    Visible = false
                });

                var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default(BaseControl.CorporateId, "id", EnumSqlOperator.Equals));
                print.Parameters.Add(new Parameter
                {
                    Name = "CorporateName",
                    Value = string.Format("{0} {1}", customer.Code, customer.Name),
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Printed",
                    Value = string.Format("{0} {1}", BaseControl.UserLogin, DateTime.Now.ToString("d-MMM-yyyy HH:mm")),
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

        private void Changed(object sender, CellValueChangedEventArgs e)
        {
            summary();
        }

        private void summary()
        {
            var ds = PodView.DataSource as List<CorporatePickupDetailModel>;
            if (ds != null)
            {
                var checkeds = ds.Where(d => d.Checked.Equals(true)).ToList();

                tbxTtlPod.Value = checkeds.Count();
                tbxTtlPiece.Value = checkeds.Sum(c => c.TtlPiece);
                tbxTtlWeight.Value = checkeds.Sum(c => c.TtlGrossWeight);
                tbxTtlChargeable.Value = checkeds.Sum(c => c.TtlChargeableWeight);
            }
        }

        private void AddRow(object sender, EventArgs e)
        {
            if (tbxPod.Text == string.Empty) return;

            var found = false;
            for (var i = 0; i < PodView.RowCount; i++)
            {
                if (PodView.GetRowCellValue(i, PodView.Columns["ShipmentCode"]).ToString() == tbxPod.Text)
                {
                    if (PodView.GetRowCellValue(i, PodView.Columns["StateChange"]).ToString() == EnumStateChange.Idle.ToString())
                        PodView.SetRowCellValue(i, PodView.Columns["StateChange"], EnumStateChange.Insert);
                    if (PodView.GetRowCellValue(i, PodView.Columns["StateChange"]).ToString() == EnumStateChange.Select.ToString())
                        PodView.SetRowCellValue(i, PodView.Columns["StateChange"], EnumStateChange.Update);

                    PodView.SetRowCellValue(i, PodView.Columns["Checked"], true);
                    found = true;
                }
            }

            if (!found)
            {
                var shipment = new CorporatePickupDetailDataManager().GetShipmentPickup(tbxPod.Text);
                if (shipment != null)
                {
                    var list = PodGrid.DataSource as List<CorporatePickupDetailModel>;

                    if (list == null) list = new List<CorporatePickupDetailModel>();

                    list.Add(shipment);

                    PodGrid.DataSource = list;
                    PodView.RefreshData();
                }
                else MessageBox.Show(Resources.no_found_data, Resources.title_information, MessageBoxButtons.OK);
            }

            tbxPod.Clear();
            tbxPod.Focus();

            summary();
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            tbxDate.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            tbxPod.Focus();
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override void PopulateForm(CorporatePickupModel model)
        {
            tbxSearch_Code.Text = model.Code;
            tbxDate.DateTime = model.DateProcess;
            tbxDate.Enabled = false;
            tbxTtlPod.Value = model.TtlPod;
            tbxTtlPiece.Value = model.TtlPiece;
            tbxTtlWeight.Value = model.TtlGrossWeight;
            tbxTtlChargeable.Value = model.TtlChargeable;

            if (model.MessengerId != null)
            {
                tbxMessenger.DefaultValue = new IListParameter[] { WhereTerm.Default((int) model.MessengerId, "id") };
            }

            if (model.IsPrint)
            {
                rbData_Save.Enabled = false;
                rbData_Delete.Enabled = false;

                EnabledForm(false);
            }

            PodGrid.DataSource = new CorporatePickupDetailDataManager().GetPickupDetail(model.Id);
            PodGrid.Refresh();
        }

        protected override CorporatePickupModel PopulateModel(CorporatePickupModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.CorporateId = BaseControl.CorporateId;
            model.TtlPiece = (short) tbxTtlPiece.Value;
            model.TtlGrossWeight = tbxTtlWeight.Value;
            model.TtlChargeable = tbxTtlChargeable.Value;
            model.TtlPod = (short) tbxTtlPod.Value;
            model.TtlSales = TtlSales;
            model.TtlPpn = TtlPpn;
            model.TtlCommission = TtlCommission;
            model.TtlPph23 = TtlPph;
            model.TtlNetCommission = TtlNetCommission;
            model.MessengerId = tbxMessenger.Value;

            if (model.Id == 0)
            {
                model.Code = new CorporatePickupDataManager().GenerateCode(model.DateProcess);
                model.IsPrint = false;
                model.CreatedPc = Environment.MachineName;
            }
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override CorporatePickupModel Find(string searchTerm)
        {
            return DataManager.GetFirst<CorporatePickupModel>(
                WhereTerm.Default(searchTerm, "code"));
        }

        public override void New()
        {
            base.New();

            ClearForm();
            EnabledForm(true);

            PodGrid.DataSource = null;
            PodGrid.Refresh();

            tbxDate.Focus();
            tbxDate.Enabled = false;
            tbxDate.DateTime = DateTime.Now;
        }

        public override void Save()
        {
            var obj = PodGrid.DataSource as List<CorporatePickupDetailModel>;
            if (obj != null && obj.Where(b => b.Checked).ToList().Count > 0)
            {
                base.Save();
                return;
            }

            MessageBox.Show(Resources.pod_data_empty, Resources.title_information, MessageBoxButtons.OK);
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            var details = PodGrid.DataSource as List<CorporatePickupDetailModel>;
            var manager = new CorporatePickupDetailDataManager();
            var smanager = new ShipmentDataManager();
            foreach (CorporatePickupDetailModel detail in details)
            {
                var pickupDetail = new CorporatePickupDetailModel();
                var shipment = new ShipmentModel();
                if (detail.StateChange == EnumStateChange.Insert && detail.Checked)
                {
                    pickupDetail.Rowstatus = true;
                    pickupDetail.Rowversion = DateTime.Now;
                    pickupDetail.CorporatePickupId = CurrentModel.Id;
                    pickupDetail.ShipmentId = detail.ShipmentId;
                    pickupDetail.CreatedPc = Environment.MachineName;
                    pickupDetail.Createdby = BaseControl.UserLogin;
                    pickupDetail.Createddate = DateTime.Now;

                    manager.Save<CorporatePickupDetailModel>(pickupDetail);
                    shipment = smanager.GetFirst<ShipmentModel>(WhereTerm.Default(detail.ShipmentId, "id"));
                    if (shipment != null)
                    {
                        shipment.PODStatus = (int)EnumPodStatus.PickedUp;
                        shipment.ModifiedPc = Environment.MachineName;
                        shipment.Modifiedby = BaseControl.UserLogin;
                        shipment.Modifieddate = DateTime.Now;

                        smanager.Update<ShipmentModel>(shipment);
                    }
                } else if (detail.StateChange == EnumStateChange.Update && !detail.Checked)
                {
                    manager.DeActive(detail.Id, BaseControl.UserLogin, DateTime.Now);
                    shipment = smanager.GetFirst<ShipmentModel>(WhereTerm.Default(detail.ShipmentId, "id"));
                    if (shipment != null)
                    {
                        shipment.PODStatus = (int)EnumPodStatus.None;
                        shipment.ModifiedPc = Environment.MachineName;
                        shipment.Modifiedby = BaseControl.UserLogin;
                        shipment.Modifieddate = DateTime.Now;

                        smanager.Update<ShipmentModel>(shipment);
                    }
                }
            }
        }

        protected override void AfterSave()
        {
            base.AfterSave();
            tbxSearch_Code.Text = ((CorporatePickupModel)CurrentModel).Code;
            PerformFind();
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            var model = CurrentModel as CorporatePickupModel;
            if (model == null) return;
            clChecked.ColumnEdit.Enabled = true;
            if (model.IsPrint)
            {
                rbData_Save.Enabled = false;
                rbData_Delete.Enabled = false;
                clChecked.ColumnEdit.Enabled = false;
            }
        }
    }
}
