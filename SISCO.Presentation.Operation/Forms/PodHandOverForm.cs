using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.CustomerService.Forms;
using SISCO.Presentation.Operation.Popup;
using SISCO.Presentation.Operation.Reports;
using System;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class PodHandOverForm : BaseCrudForm<PodHandoverModel, PodHandoverDataManager>//BaseToolbarForm//
    {
        public PodHandOverForm()
        {
            InitializeComponent();
            form = this;

            EnableBtnSearch = true;
            SearchPopup = new HandoverFilterPopup();

            tbxCek.Enabled = false;
            tbxPod.Enabled = true;

            HandoverView.CustomColumnDisplayText += NumberGrid;
            rpRemoveRow.ButtonClick += RemoveRow;
            GridHandover.DoubleClick += (sender, args) => OpenRelatedForm(HandoverView, new TrackingViewForm());

            tbxPod.KeyDown += (sender, args) =>
            {
                switch (args.KeyCode)
                {
                    case Keys.Enter:
                        if (!args.Shift)
                        {
                            AddRow();
                        }
                        break;
                }
            };

              HandoverView.DataSourceChanged += (sender, args) =>
                {
                    //var code = tsBaseTxt_Code.Text;
                    if (string.IsNullOrEmpty(tsBaseTxt_Code.Text) == false)
                    {
                        var param = new IListParameter[]
                        {
                            WhereTerm.Default(Convert.ToInt32(tsBaseTxt_Code.Text), "id", EnumSqlOperator.Equals)
                        };
                        var cekprint = DataManager.GetFirst<PodHandoverModel>(param);

                        if (cekprint != null && cekprint.Printed == true)
                        {
                            //if (string.IsNullOrEmpty(code) == true)
                            tbxCek.Enabled = true;
                            tbxPod.Enabled = false;
                            label5.Text = "Created By = " + cekprint.Createdby;
                            label7.Text = "Received By = " + cekprint.ReceivedBy;
                            tbxCek.Focus();

                        }
                        else
                        {
                            tbxCek.Enabled = false;
                            tbxPod.Enabled = true;
                            label5.Text = "Created By = ";
                            label7.Text = "Received By = ";
                            tbxPod.Focus();
                        }
                    }
                };
            
            tbxCek.KeyDown += (sender, args) =>
            {
                switch (args.KeyCode)
                {
                    case Keys.Enter:
                        if (!args.Shift)
                        {
                            ceklist();
                        }
                        break;
                }
            };

            tsBaseBtn_Print.Click += Print;
            HandoverView.RowStyle += ChangeColor;
            // Save ke Excel
            btnSave.Click += (sender, args) => ExportExcel(GridHandover);
        }

        private void ceklist()
        {
            if (string.IsNullOrEmpty(tbxCek.Text))
            {
                tbxCek.Focus();
                return;
            }

            //var code = tsBaseTxt_Code.Text;

            var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxCek.Text, "code", EnumSqlOperator.Equals));
            if (shipment == null)
            {
                MessageBox.Show("Nomor Pod tidak dikenali.");
                tbxCek.Clear();
                tbxCek.Focus();
                return;
            }

            var list = GridHandover.DataSource as List<PodHandoverRowDetail>;
            if (list != null)
            { 
               if (list.FirstOrDefault(p => p.Code == tbxCek.Text) != null)
               {
                   var model = CurrentModel as PodHandoverModel;

                   var detail = new PodHandoverDetailDataManager().GetFirst<PodHandoverDetailModel>(
                       WhereTerm.Default(model.Id, "pod_handover_id", EnumSqlOperator.Equals),
                       WhereTerm.Default((int)shipment.Id, "shipment_id", EnumSqlOperator.Equals)
                       );
                   
                   if (detail != null)
                   {
                       //detail.Rowstatus = true;
                       detail.Cek = true;
                       detail.Rowversion = DateTime.Now;
                       detail.ShipmentId = (int)shipment.Id;
                       detail.PodHandoverId = model.Id;
                       //detail.Createdby = BaseControl.UserLogin;
                       //detail.Createddate = DateTime.Now;
                       detail.Modifiedby = BaseControl.UserLogin;
                       detail.Modifieddate = DateTime.Now;

                       new PodHandoverDetailDataManager().Update<PodHandoverDetailModel>(detail);
                       
                       model.ReceivedBy = BaseControl.UserLogin;
                       model.Modifieddate = DateTime.Now;
                       model.Modifiedby = BaseControl.UserLogin;

                       new PodHandoverDataManager().Update<PodHandoverModel>(model);
                   }
                   // ceklist gridview
                   for (int i = 0; i < HandoverView.RowCount; i++)
                   {
                       if (HandoverView.GetRowCellValue(i, HandoverView.Columns["Code"]).ToString() == tbxCek.Text)
                       {
                           HandoverView.SetRowCellValue(i, HandoverView.Columns["Cek"], true);
                           HandoverView.FocusedRowHandle = i;
                       }
                   }
                   
               } else
               {
                   // jika list kosong
               }

               tbxCek.Clear();
               tbxCek.Focus();
            }

        }

        private void ChangeColor(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;

                if (view == null) return;

                //e.Appearance.ForeColor = Color.Black;
                e.Appearance.BackColor = Color.Transparent;
                e.Appearance.ForeColor = Color.Red;
                if ((bool)view.GetRowCellValue(e.RowHandle, view.Columns["Cek"]))
                {
                    //e.Appearance.BackColor = Color.Green;
                    //e.Appearance.BackColor2 = Color.Transparent;
                    e.Appearance.ForeColor = Color.Blue;
                }
            }
        }

        private void Print(object sender, EventArgs e)
        {
            var print = new HandoverPrint();
            var model = CurrentModel as PodHandoverModel;
            using (var printTool = new ReportPrintTool(print))
            {
                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "DateProcess",
                    Value = model.DateProcess,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Id",
                    Value = model.Id,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Description",
                    Value = model.Description,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "UserLogin",
                    Value = BaseControl.UserLogin,
                    Visible = false
                });

                var branch = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(model.BranchId, "id"));
                if (branch == null) throw new Exception("Cabang tidak dikenali");

                print.Parameters.Add(new Parameter
                {
                    Name = "BranchName",
                    Value = branch.Name,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Total",
                    Value = HandoverView.RowCount,
                    Visible = false
                });

                print.CreateDocument();
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                };

                #if (DEBUG)
                printTool.ShowPreviewDialog();
                #else
                printTool.Print();
                #endif

                model.Printed = true;
                model.Modifiedby = BaseControl.UserLogin;
                model.Modifieddate = DateTime.Now;

                new PodHandoverDataManager().Update<PodHandoverModel>(model);
                Find(tsBaseTxt_Code.Text);
            }
        }

        private void AddRow()
        {
            if (string.IsNullOrEmpty(tbxPod.Text))
            {
                tbxPod.Focus();
                return;
            }

            var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxPod.Text, "code", EnumSqlOperator.Equals));
            if (shipment == null)
            {
                MessageBox.Show("Nomor Pod tidak dikenali.");
                tbxPod.Clear();
                tbxPod.Focus();
                return;
            }

            if (string.IsNullOrEmpty(shipment.ConsigneeName))
            {
                MessageBox.Show("Nama Shipper Pod masih kosong harap diinput terlebih dahulu.");
                tbxPod.Clear();
                tbxPod.Focus();
                return;
            }

            var list = GridHandover.DataSource as List<PodHandoverRowDetail>;

            if (list == null) list = new List<PodHandoverRowDetail>();

            if (list.FirstOrDefault(p => p.Code == tbxPod.Text) == null)
            {
                var data = new PodHandoverRowDetail();
                data.StateChange = EnumStateChange.Insert;
                data.Id = shipment.Id;
                data.Code = shipment.Code;
                data.DateProcess = shipment.DateProcess;
                data.CityName = shipment.CityName;
                data.DestCityName = shipment.DestCity;

                if (shipment.CustomerId > 0)
                {
                    var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)shipment.CustomerId, "id"));
                    if (customer != null) data.CustomerName = string.Format("{0} {1}", customer.Code, customer.Name);
                }

                data.ShipperName = shipment.ShipperName;
                data.ShipperAddress = shipment.ShipperAddress;
                data.ConsigneeName = shipment.ConsigneeName;
                data.ConsigneeAddress = shipment.ConsigneeAddress;
                data.TtlPiece = shipment.TtlPiece;
                data.TtlGrossWeight = shipment.TtlGrossWeight;
                data.TtlChargeableWeight = shipment.TtlChargeableWeight;

                list.Add(data);
                GridHandover.DataSource = list;
                HandoverView.RefreshData();
                
                //set row ke paling bawah
                int value = HandoverView.RowCount - 1;
                HandoverView.TopRowIndex = value;
                HandoverView.FocusedRowHandle = value;             
            }

            tbxPod.Clear();
            tbxPod.Focus();
        }

        private void RemoveRow(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (CurrentModel.Id <= 0)
            {
                var rowHandle = HandoverView.FocusedRowHandle;
                HandoverView.DeleteSelectedRows();
            }
        }

        public override void New()
        {
            base.New();

            ClearForm();
            GridHandover.DataSource = null;
            HandoverView.RefreshData();

            EnableBtnPrint = false;
            tbxDate.DateTime = DateTime.Now;
            tbxDescription.Text = string.Empty ;
            tbxCek.Enabled = false;
            tbxPod.Enabled = true;
            label5.Text = "Created By = ";
            tbxPod.Focus();

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;
        }

        protected override bool ValidateForm()
        {
            if (HandoverView.RowCount == 0)
            {
                return false;
            }

            return true;
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            form.Enabled = false;
            var model = CurrentModel as PodHandoverModel;

            for (int i = 0; i < HandoverView.RowCount; i++)
            {
                int rowHandle = HandoverView.GetVisibleRowHandle(i);
                if (HandoverView.IsDataRow(rowHandle))
                {
                    var state = HandoverView.GetRowCellValue(rowHandle, HandoverView.Columns["StateChange"]);
                    if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                    {
                        var detail = new PodHandoverDetailModel();
                        detail.Rowstatus = true;
                        detail.Rowversion = DateTime.Now;
                        detail.ShipmentId = (int)HandoverView.GetRowCellValue(rowHandle, HandoverView.Columns["Id"]);
                        detail.PodHandoverId = model.Id;
                        detail.Createdby = BaseControl.UserLogin;
                        detail.Createddate = DateTime.Now;

                        new PodHandoverDetailDataManager().Save<PodHandoverDetailModel>(detail);

                        var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(detail.ShipmentId, "shipment_id"));
                        if (expand != null)
                        {
                            expand.Handedover = true;
                            new ShipmentExpandDataManager().Update<ShipmentExpandModel>(expand);
                        }
                    }
                }
            }

            ToolbarCode = model.Id.ToString();
            form.Enabled = true;
        }

        protected override void AfterSave()
        {
            OpenData(ToolbarCode);
            tsBaseTxt_Code.Focus();
        }

        protected override void PopulateForm(PodHandoverModel model)
        {
            if (model == null) return;
            ClearForm();
            EnableBtnPrint = true;
            GridHandover.DataSource = null;
            HandoverView.RefreshData();

            ToolbarCode = model.Id.ToString();
            tbxDate.DateTime = model.DateProcess;
            tbxDescription.Text = model.Description;

            GridHandover.DataSource = new PodHandoverDetailDataManager().GetPodHandovers(model.Id);
            HandoverView.RefreshData();

            rpRemoveRow.Buttons[0].Enabled = false;   
        }

        protected override PodHandoverModel PopulateModel(PodHandoverModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.BranchId = BaseControl.BranchId;
            model.ObjectId = 1;
            model.Description = tbxDescription.Text;

            if (model.Id > 0) model.ReceivedBy = BaseControl.UserLogin;

            return model;
        }

        protected override PodHandoverModel Find(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm)) tsBaseTxt_Code.Text = searchTerm;
            var param = new IListParameter[]
                {
                    WhereTerm.Default(Convert.ToInt32(tsBaseTxt_Code.Text), "id", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<PodHandoverModel>(param);
            PopulateForm(obj);

            return obj;
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            if (CurrentModel != null && CurrentModel.Id != 0)
            {
                if (((PodHandoverModel)CurrentModel).Printed)
                {
                    EnabledForm(false);
                    tsBaseBtn_Save.Enabled = false;
                }
            }
        }
    }
}