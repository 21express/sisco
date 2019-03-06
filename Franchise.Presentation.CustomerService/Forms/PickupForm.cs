using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using Franchise.Presentation.Common;
using Franchise.Presentation.Common.Component;
using Franchise.Presentation.Common.Forms;
using Franchise.Presentation.Common.Properties;
using Franchise.Presentation.CustomerService.Reports;
using Franchise.Presentation.MasterData.Popup;
using SISCO.App.Franchise;
using SISCO.App.MasterData;
using SISCO.Models;
using Franchise.Presentation.CustomerService.Popup;
using SISCO.LocalStorage;

namespace Franchise.Presentation.CustomerService.Forms
{
    public partial class PickupForm : BaseCrudForm<FranchisePickupModel, FranchisePickupDataManager>//BaseToolbarForm//
    {
        private bool FocusPod { get; set; }
        private decimal TtlSales { get; set; }
        private decimal TtlPpn { get; set; }
        private decimal TtlCommission { get; set; }
        private decimal TtlPph { get; set; }
        private decimal TtlNetCommission { get; set; }
        private decimal Balance { get; set; }

        public PickupForm()
        {
            InitializeComponent();
            form = this;

            Shown += PickupFormShown;
            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.FranchiseId, "franchise_id", EnumSqlOperator.Equals)
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
            ClearForm();
            PodView.CustomColumnDisplayText += NumberGrid;
            PodView.CellValueChanged += Changed;
            PodView.CellValueChanging += Changing;

            SearchPopup = new PickupPopup();

            tbxMessenger.LookupPopup = new MessengerPopup();
            tbxMessenger.AutoCompleteDataManager = new MessengerServices();
            tbxMessenger.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            tbxMessenger.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0))", s);

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

        private void Changing(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "clChecked")
            {
                if (!(bool)PodView.GetRowCellValue(e.RowHandle, PodView.Columns["Checked"]))
                {
                    PodView.SetRowCellValue(e.RowHandle, PodView.Columns["Checked"], true);
                }
                else
                {
                    PodView.SetRowCellValue(e.RowHandle, PodView.Columns["Checked"], false);
                }
            }
        }

        private void PrintPreview(object sender, ItemClickEventArgs e)
        {
            var print = new PickupPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                var ds = new FranchisePickupDetailDataManager().GetPickupDetailPrint((CurrentModel.Id));
                print.DataSource = ds;
                var model = CurrentModel as FranchisePickupModel;
                var curModel = new FranchisePickupDataManager().GetFirst<FranchisePickupModel>(WhereTerm.Default(CurrentModel.Id, "id"));
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

                    new FranchisePickupDataManager().Update<FranchisePickupModel>(curModel);
                }

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "Code",
                    Value = ((FranchisePickupModel)CurrentModel).Code,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "DateProcess",
                    Value = ((FranchisePickupModel)CurrentModel).DateProcess,
                    Visible = false
                });

                var franchise = new FranchiseDataManager().GetFirst<FranchiseModel>(WhereTerm.Default(BaseControl.FranchiseId, "id"));

                print.Parameters.Add(new Parameter
                {
                    Name = "FranchiseName",
                    Value = string.Format("{0} {1}", franchise.Code, BaseControl.FranchiseName),
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Setoran",
                    Value = ((FranchisePickupModel)CurrentModel).PaymentTypeAgent == 0 ? "CASH" : "BANK TRANSFER",
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
                var ds = new FranchisePickupDetailDataManager().GetPickupDetailPrint(CurrentModel.Id);
                print.DataSource = ds;
                var model = CurrentModel as FranchisePickupModel;
                var curModel = new FranchisePickupDataManager().GetFirst<FranchisePickupModel>(WhereTerm.Default(CurrentModel.Id, "id"));
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

                    new FranchisePickupDataManager().Update<FranchisePickupModel>(curModel);
                }

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "Code",
                    Value = ((FranchisePickupModel)CurrentModel).Code,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "DateProcess",
                    Value = ((FranchisePickupModel)CurrentModel).DateProcess,
                    Visible = false
                });

                var franchise = new FranchiseDataManager().GetFirst<FranchiseModel>(WhereTerm.Default(BaseControl.FranchiseId, "id"));

                print.Parameters.Add(new Parameter
                {
                    Name = "FranchiseName",
                    Value = string.Format("{0} {1}", franchise.Code, BaseControl.FranchiseName),
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Setoran",
                    Value = ((FranchisePickupModel)CurrentModel).PaymentTypeAgent == 0 ? "CASH" : "BANK TRANSFER",
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
            if (e.Column.Name != "clState")
            {
                if (CurrentModel.Id > 0)
                    PodView.SetRowCellValue(e.RowHandle, PodView.Columns["StateChange"], EnumStateChange.Update);

                if (CurrentModel.Id == 0)
                    PodView.SetRowCellValue(e.RowHandle, PodView.Columns["StateChange"], EnumStateChange.Insert);

                var ds = PodView.DataSource as List<FranchiseCommissionModel>;
                if (ds != null)
                {
                    var checkeds = ds.Where(d => d.Checked.Equals(true)).ToList();
    
                    tbxTtlPod.Value = checkeds.Count();
                    tbxTtlPiece.Value = checkeds.Sum(c => c.TtlPiece);
                    tbxTtlWeight.Value = checkeds.Sum(c => c.TtlGrossWeight);
                    tbxTtlChargeable.Value = checkeds.Sum(c => c.TtlChargeableWeight);

                    TtlSales = checkeds.Sum(c => c.TotalSales);
                    TtlPpn = checkeds.Sum(c => c.PPN);
                    TtlCommission = checkeds.Sum(c => c.Commission);
                    TtlPph = checkeds.Sum(c => c.PPH23);
                    TtlNetCommission = checkeds.Sum(c => c.TotalNetCommission);
                    Balance = checkeds.Sum(c => c.Debs);
                }
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
                var shipment = new FranchisePickupDetailDataManager().GetShipmentPickup(tbxPod.Text);
                if (shipment != null)
                {
                    var list = PodGrid.DataSource as List<FranchiseCommissionModel>;
                    list.Add(shipment);

                    PodGrid.DataSource = list;
                    PodView.RefreshData();
                }
                else MessageBox.Show(Resources.no_found_data, Resources.title_information, MessageBoxButtons.OK);
            }

            tbxPod.Clear();
            tbxPod.Focus();
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

        protected override void PopulateForm(FranchisePickupModel model)
        {
            ClearForm();

            tbxSearch_Code.Text = model.Code;
            tbxDate.DateTime = model.DateProcess;
            tbxTtlPod.Value = model.TtlPod;
            tbxTtlPiece.Value = model.TtlPiece;
            tbxTtlWeight.Value = model.TtlGrossWeight;
            tbxTtlChargeable.Value = model.TtlChargeable;
            Balance = model.Balance;
            cbxSetoran.SelectedIndex = model.PaymentTypeAgent;

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

            PodGrid.DataSource = new FranchisePickupDetailDataManager().GetPickupDetail(model.Id);
            PodGrid.Refresh();
        }

        public override void Delete()
        {
            var model = CurrentModel as FranchisePickupModel;
            if (model.IsPrint) return;
            
            base.Delete();
        }

        public override void AfterDelete()
        {
            var ds = PodView.DataSource as List<FranchiseCommissionModel>;
            foreach(var o in ds)
            {
                var s = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(o.ShipmentId, "id"));
                s.PODStatus = (int)EnumPodStatus.None;
                new ShipmentDataManager().Update<ShipmentModel>(s);
            }

            base.AfterDelete();
        }

        protected override FranchisePickupModel PopulateModel(FranchisePickupModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.FranchiseId = BaseControl.FranchiseId;
            model.TtlPiece = (short) tbxTtlPiece.Value;
            model.TtlGrossWeight = tbxTtlWeight.Value;
            model.TtlChargeable = tbxTtlChargeable.Value;
            model.TtlPod = (short) tbxTtlPod.Value;
            model.TtlSales = TtlSales;
            model.TtlPpn = TtlPpn;
            model.TtlCommission = TtlCommission;
            model.TtlPph23 = TtlPph;
            model.TtlNetCommission = TtlNetCommission;
            model.Balance = Balance;
            model.MessengerId = tbxMessenger.Value;
            model.PaymentTypeAgent = cbxSetoran.SelectedIndex;

            if (model.Id == 0)
            {
                model.Code = new FranchisePickupDataManager().GenerateCode(model.DateProcess);
                model.IsPrint = false;
                model.CreatedPc = Environment.MachineName;
            }
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override FranchisePickupModel Find(string searchTerm)
        {
            return DataManager.GetFirst<FranchisePickupModel>(WhereTerm.Default(searchTerm, "code"));
        }

        public override void New()
        {
            base.New();

            ClearForm();
            EnabledForm(true);

            PodGrid.DataSource =
               new FranchiseCommissionDataManager().GetActiveCommission(BaseControl.FranchiseId);
            PodView.RefreshData();

            cbxSetoran.SelectedIndex = 0;
            tbxDate.Focus();
        }

        public override void Save()
        {
            var obj = PodGrid.DataSource as List<FranchiseCommissionModel>;
            if (obj != null && obj.FirstOrDefault(b => b.Checked) != null)
            {
                base.Save();
                return;
            }

            MessageBox.Show(Resources.pod_data_empty, Resources.title_information, MessageBoxButtons.OK);
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            var details = PodGrid.DataSource as List<FranchiseCommissionModel>;
            var manager = new FranchisePickupDetailDataManager();
            var smanager = new ShipmentDataManager();
            foreach (FranchiseCommissionModel detail in details)
            {
                var pickupDetail = new FranchisePickupDetailModel();
                var shipment = new ShipmentModel();
                if (detail.StateChange == EnumStateChange.Insert && detail.Checked)
                {
                    pickupDetail.Rowstatus = true;
                    pickupDetail.Rowversion = DateTime.Now;
                    pickupDetail.FranchisePickupId = CurrentModel.Id;
                    pickupDetail.ShipmentId = detail.ShipmentId;
                    pickupDetail.CreatedPc = Environment.MachineName;
                    pickupDetail.Createdby = BaseControl.UserLogin;
                    pickupDetail.Createddate = DateTime.Now;

                    manager.Save<FranchisePickupDetailModel>(pickupDetail);
                    shipment = smanager.GetFirst<ShipmentModel>(WhereTerm.Default(detail.ShipmentId, "id"));
                    if (shipment != null)
                    {
                        shipment.PODStatus = (int)EnumPodStatus.PickedUp;
                        shipment.TrackingStatusId = (int) EnumTrackingStatus.Pickup;
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
                        shipment.TrackingStatusId = (int)EnumTrackingStatus.FranchiseDataEntry;
                        shipment.ModifiedPc = Environment.MachineName;
                        shipment.Modifiedby = BaseControl.UserLogin;
                        shipment.Modifieddate = DateTime.Now;

                        smanager.Update<ShipmentModel>(shipment);
                    }
                }
            }

            var voided = new ShipmentDataManager().Get<ShipmentModel>(
                new IListParameter[]
                {
                    WhereTerm.Default(true, "voided"),
                    WhereTerm.Default(5,"sales_type_id", EnumSqlOperator.Equals),
                    WhereTerm.Default(BaseControl.FranchiseId, "franchise_id", EnumSqlOperator.Equals),
                    WhereTerm.Default((int)EnumPodStatus.None, "pod_status")
                }
            );

            foreach (var v in voided)
            {
                var pickupDetail = new FranchisePickupDetailModel();

                pickupDetail.Rowstatus = true;
                pickupDetail.Rowversion = DateTime.Now;
                pickupDetail.FranchisePickupId = CurrentModel.Id;
                pickupDetail.ShipmentId = v.Id;
                pickupDetail.CreatedPc = Environment.MachineName;
                pickupDetail.Createdby = BaseControl.UserLogin;
                pickupDetail.Createddate = DateTime.Now;

                manager.Save<FranchisePickupDetailModel>(pickupDetail);

                v.PODStatus = (int)EnumPodStatus.PickedUp;
                v.ModifiedPc = Environment.MachineName;
                v.Modifiedby = BaseControl.UserLogin;
                v.Modifieddate = DateTime.Now;

                smanager.Update<ShipmentModel>(v);
            }
        }

        protected override void AfterSave()
        {
            base.AfterSave();
            tbxSearch_Code.Text = ((FranchisePickupModel)CurrentModel).Code;
            PerformFind();
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            var model = CurrentModel as FranchisePickupModel;
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