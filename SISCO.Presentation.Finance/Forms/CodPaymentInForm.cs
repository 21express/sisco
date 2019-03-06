using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.CustomerService.Forms;
using SISCO.Presentation.Finance.Popup;
using SISCO.Presentation.Finance.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class CodPaymentInForm : BaseCrudForm<CodPaymentInModel, CodPaymentInDataManager>//BaseToolbarForm//
    {
        private bool FocusBarcode { get; set; }

        public CodPaymentInForm()
        {
            InitializeComponent();
            form = this;

            CodView.CustomColumnDisplayText += NumberGrid;
            CodView.CellValueChanging += Changing;
            CodView.CellValueChanged += Changed;

            btnAdd.Click += AddPaid;
            tbxPod.KeyDown += (sender, args) =>
            {
                FocusBarcode = false;
                switch (args.KeyCode)
                {
                    case Keys.Enter:
                        if (!args.Shift)
                        {
                            FocusBarcode = true;
                        }
                        break;
                }

                base.OnKeyDown(args);
            };

            btnAdd.GotFocus += (sender, args) =>
            {
                if (FocusBarcode)
                {
                    FocusBarcode = false;
                    AddPaid(sender, args);
                }
            };

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
            };

            EnableBtnSearch = true;
            SearchPopup = new CodPaymentInFilterPopup();
            EnableBtnPrint = true;
            EnableBtnPrintPreview = true;

            tsBaseBtn_Print.Click += Print;
            tsBaseBtn_PrintPreview.Click += PrintPreview;

            GridCod.DoubleClick += (sender, args) => OpenRelatedForm(CodView, new TrackingViewForm(), "ShipmentCode");
        }

        private void PrintPreview(object sender, EventArgs e)
        {
            var print = new CodPaymentPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = GridCod.DataSource as List<CodPaymentInDetailModel>;

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "DateProcess",
                    Value = ((CodPaymentInModel)CurrentModel).DateProcess,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Code",
                    Value = ((CodPaymentInModel)CurrentModel).Code,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Description",
                    Value = ((CodPaymentInModel)CurrentModel).Description,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "TotalCash",
                    Value = ((CodPaymentInModel)CurrentModel).TotalCash,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "TotalSales",
                    Value = ((CodPaymentInModel)CurrentModel).Total,
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
            var print = new CodPaymentPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = GridCod.DataSource as List<CodPaymentInDetailModel>;

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "DateProcess",
                    Value = ((CodPaymentInModel)CurrentModel).DateProcess,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Code",
                    Value = ((CodPaymentInModel)CurrentModel).Code,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Description",
                    Value = ((CodPaymentInModel)CurrentModel).Description,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "TotalCash",
                    Value = ((CodPaymentInModel)CurrentModel).TotalCash,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "TotalSales",
                    Value = ((CodPaymentInModel)CurrentModel).Total,
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

        private void AddPaid(object sender, EventArgs e)
        {
            if (tbxPod.Text == "")
            {
                tbxPod.Focus();
                return;
            }

            var d = new CodPaymentInDetailDataManager().GetFirst<CodPaymentInDetailModel>(new IListParameter[]
                {
                    WhereTerm.Default(tbxPod.Text, "shipment_code", EnumSqlOperator.Equals),
                    WhereTerm.Default(0, "actual_paid", EnumSqlOperator.GreatThan)
                });
            if (d != null)
            {
                var x = new CodPaymentInDataManager().GetFirst<CodPaymentInModel>(WhereTerm.Default(d.CodPaymentInId, "id"));
                if (x != null)
                {
                    MessageBox.Show("Pod ini sudah ada pembayaran dengan code pembayaran " + x.Code);
                    tbxPod.Clear();
                    tbxPod.Focus();
                    return;
                }
            }
            
            var data = GridCod.DataSource as List<CodPaymentInDetailModel>;
            if (data == null) 
            {
                data = new List<CodPaymentInDetailModel>();
                var shipment = new CodPaymentInDetailDataManager().GetUpaidShipment(BaseControl.BranchId, tbxPod.Text);
                if (shipment != null)
                {
                    var shipmentDeliveryExists = new CodPaymentInDetailDataManager().GetFirst<CodPaymentInDetailModel>(
                        new IListParameter[]
                        {
                            WhereTerm.Default(shipment.ShipmentCode, "shipment_code", EnumSqlOperator.Equals),
                            WhereTerm.Default(shipment.DeliveryCode, "delivery_code", EnumSqlOperator.Equals)
                        });
                    if (shipmentDeliveryExists == null)
                    {
                        var deliveryOrder = new DeliveryOrderDataManager().GetFirst<DeliveryOrderModel>(WhereTerm.Default(shipment.DeliveryCode, "code", EnumSqlOperator.Equals));
                        if (deliveryOrder != null)
                        {
                            var deliveryDetail = new DeliveryOrderDetailDataManager().Get<DeliveryOrderDetailModel>(WhereTerm.Default(deliveryOrder.Id, "delivery_order_id")).ToList();
                            if (deliveryDetail.Count > 0)
                            {
                                var cods = deliveryDetail.Where(p => p.TotalCod > 0).ToList();
                                if (cods.Count > 0)
                                {
                                    foreach (var c in cods)
                                    {
                                        var x = new CodPaymentInDetailModel
                                        {
                                            Id = 0,
                                            ShipmentDate = (DateTime)c.ShipmentDate,
                                            ShipmentId = c.ShipmentId,
                                            ShipmentCode = c.ShipmentCode,
                                            TotalCod = (decimal)c.TotalCod,
                                            ActualPaid = (decimal)c.TotalCod,
                                            DeliveryCode = deliveryOrder.Code,
                                            Checked = false,
                                            StateChange = EnumStateChange.Insert
                                        };

                                        if (c.ShipmentCode == tbxPod.Text)
                                        {
                                            x.Checked = true;
                                            tbxTotalSales.Value = x.TotalCod;
                                        }

                                        data.Add(x);
                                    }

                                    GridCod.DataSource = data;
                                    CodView.RefreshData();
                                }
                                else
                                    MessageBox.Show("Tidak ada pengiriman COD.");
                            }
                        }
                        else
                            MessageBox.Show("Tidak ada DO untuk POD tersebut.");

                    }
                    else
                        MessageBox.Show("Tidak bisa memasukkan data dengan delivery code dan POD yang sama. Silakan lakukan delivery order baru untuk POD ini.");
                }
                else
                {
                    MessageBox.Show("POD tidak dikenali");
                }
            }
            else
            {
                if (data.Where(p => p.ShipmentCode == tbxPod.Text).ToList().Count > 0)
                {
                    for (var i = 0; i < CodView.RowCount; i++)
                    {
                        if (CodView.GetRowCellValue(i, CodView.Columns["ShipmentCode"]).ToString() == tbxPod.Text)
                        {
                            CodView.FocusedRowHandle = i;
                            CodView.SelectRow(i);
                            CodView.SetRowCellValue(i, CodView.Columns["Checked"], true);
                        }
                    }
                }
                else 
                    MessageBox.Show("POD bukan dari DO ini.");
            }

            tbxPod.Clear();
            tbxPod.Focus();
        }

        private void Changing(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "clChecked")
            {
                if (!(bool)CodView.GetRowCellValue(e.RowHandle, CodView.Columns["Checked"]))
                {
                    var d = new CodPaymentInDetailDataManager().GetFirst<CodPaymentInDetailModel>(new IListParameter[]
                    {
                        WhereTerm.Default(CodView.GetRowCellValue(e.RowHandle, CodView.Columns["ShipmentCode"]).ToString(), "shipment_code", EnumSqlOperator.Equals),
                        WhereTerm.Default(0, "actual_paid", EnumSqlOperator.GreatThan)
                    });
                    if (d != null)
                    {
                        var x = new CodPaymentInDataManager().GetFirst<CodPaymentInModel>(WhereTerm.Default(d.CodPaymentInId, "id"));
                        if (x != null)
                        {
                            if (CurrentModel.Id > 0)
                            {
                                if (((CodPaymentInModel)CurrentModel).Code != x.Code)
                                {
                                    MessageBox.Show("Pod ini sudah ada pembayaran dengan code pembayaran " + x.Code);
                                    CodView.CancelUpdateCurrentRow();
                                    CodView.SetRowCellValue(e.RowHandle, CodView.Columns["Checked"], false);
                                    CodView.SetRowCellValue(e.RowHandle, CodView.Columns["ActualPaid"], 0);
                                    return;
                                }
                            }
                        }
                    }

                    CodView.SetRowCellValue(e.RowHandle, CodView.Columns["Checked"], true);
                    if (CodView.GetRowCellValue(e.RowHandle, CodView.Columns["ActualPaid"]) == null || Convert.ToInt32(CodView.GetRowCellValue(e.RowHandle, CodView.Columns["ActualPaid"])) == 0)
                        CodView.SetRowCellValue(e.RowHandle, CodView.Columns["ActualPaid"], CodView.GetRowCellValue(e.RowHandle, CodView.Columns["TotalCod"]));
                }
                else
                {
                    CodView.SetRowCellValue(e.RowHandle, CodView.Columns["Checked"], false);
                    CodView.SetRowCellValue(e.RowHandle, CodView.Columns["ActualPaid"], 0);
                }
            }
        }

        private void Changed(object sender, CellValueChangedEventArgs e)
        {
            //if (e.Column.Name != "clState")
            //{
            //    if (CodView.GetRowCellValue(e.RowHandle, CodView.Columns["StateChange2"]).ToString() != EnumStateChange.Insert.ToString())
            //        CodView.SetRowCellValue(e.RowHandle, CodView.Columns["StateChange2"], EnumStateChange.Update);

                var total = 0;

                for (var i = 0; i < CodView.RowCount; i++)
                {
                    if (Convert.ToBoolean(CodView.GetRowCellValue(i, CodView.Columns["Checked"]).ToString()))
                        total += Convert.ToInt32(CodView.GetRowCellValue(i, CodView.Columns["TotalCod"]));
                }

                tbxTotalSales.SetValue(total.ToString(CultureInfo.InvariantCulture));
            //}
        }

        protected override void BeforeNew()
        {
            tbxDate.DateTime = DateTime.Now;
            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            GridCod.DataSource = null;// new CodPaymentInDetailDataManager().GetUpaidShipment(BaseControl.BranchId);
            CodView.RefreshData();

            tbxDescription.Focus();
            tbxTotalCash.SetValue((decimal)0);
            tbxTotalSales.SetValue((decimal)0);
        }

        public override void Save()
        {
            if (CodView.RowCount == 0)
            {
                MessageBox.Show("Tidak ada Transaksi COD");
                return;
            }

            if (((List<CodPaymentInDetailModel>)GridCod.DataSource).Where(w => w.Checked.Equals(true)).ToList().Count == 0)
            {
                MessageBox.Show("Silakan pilih POD yang sudah terima Pembayarannya.");
                return;
            }

            if (tbxTotalSales.Value > tbxTotalCash.Value)
            {
                MessageBox.Show("Jumlah COD tidak boleh lebih dari jumlah uang cash yang diterima");
                return;
            }

            base.Save();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            var detailDm = new CodPaymentInDetailDataManager();
            var expandDm = new ShipmentExpandDataManager();

            for (var i = 0; i < CodView.RowCount; i++)
            {
                //var state = CodView.GetRowCellValue(i, CodView.Columns["StateChange2"]).ToString();
                var detail = new CodPaymentInDetailModel();

                if ((int)CodView.GetRowCellValue(i, CodView.Columns["Id"]) == 0)
                {
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.CodPaymentInId = CurrentModel.Id;
                    detail.DateProcess = DateTime.Now;
                    detail.ShipmentId = (int)CodView.GetRowCellValue(i, CodView.Columns["ShipmentId"]);
                    detail.ShipmentDate = (DateTime)CodView.GetRowCellValue(i, CodView.Columns["ShipmentDate"]);
                    detail.ShipmentCode = CodView.GetRowCellValue(i, CodView.Columns["ShipmentCode"]).ToString();
                    detail.TotalCod = (decimal)CodView.GetRowCellValue(i, CodView.Columns["TotalCod"]);
                    detail.ActualPaid =  Convert.ToBoolean(CodView.GetRowCellValue(i, CodView.Columns["Checked"])) ? detail.TotalCod : 0;
                    detail.DeliveryCode = CodView.GetRowCellValue(i, CodView.Columns["DeliveryCode"]).ToString();

                    detail.Createdby = BaseControl.UserLogin;
                    detail.Createddate = DateTime.Now;

                    detailDm.Save<CodPaymentInDetailModel>(detail);

                    if (Convert.ToBoolean(CodView.GetRowCellValue(i, CodView.Columns["Checked"])))
                    {
                        var expand = expandDm.GetFirst<ShipmentExpandModel>(WhereTerm.Default((int)CodView.GetRowCellValue(i, CodView.Columns["ShipmentId"]), "shipment_id", EnumSqlOperator.Equals));
                        if (expand != null)
                        {
                            expand.PaidCod = true;
                            expandDm.Update<ShipmentExpandModel>(expand);
                        }
                    }
                }

                if ((int)CodView.GetRowCellValue(i, CodView.Columns["Id"]) > 0)
                {
                    var id = (int)CodView.GetRowCellValue(i, CodView.Columns["Id"]);
                    var detailChanged = new CodPaymentInDetailDataManager().GetFirst<CodPaymentInDetailModel>(WhereTerm.Default(id, "id"));
                    if (Convert.ToBoolean(CodView.GetRowCellValue(i, CodView.Columns["Checked"])))
                        detailChanged.ActualPaid = (decimal)CodView.GetRowCellValue(i, CodView.Columns["TotalCod"]);
                    else detailChanged.ActualPaid = 0;
                    if (CodView.GetRowCellValue(i, CodView.Columns["DeliveryCode"])!= null)
                        detailChanged.DeliveryCode = CodView.GetRowCellValue(i, CodView.Columns["DeliveryCode"]).ToString();
                    detailChanged.Modifiedby = BaseControl.UserLogin;
                    detailChanged.Modifieddate = DateTime.Now;

                    detailDm.Update<CodPaymentInDetailModel>(detailChanged);

                    var expand = expandDm.GetFirst<ShipmentExpandModel>(WhereTerm.Default((int)CodView.GetRowCellValue(i, CodView.Columns["ShipmentId"]), "shipment_id", EnumSqlOperator.Equals));
                    if (expand != null)
                    {
                        expand.PaidCod = Convert.ToBoolean(CodView.GetRowCellValue(i, CodView.Columns["Checked"]));
                        expandDm.Update<ShipmentExpandModel>(expand);
                    }
                }
            }
        }

        protected override void AfterSave()
        {
            base.AfterSave();

            tsBaseTxt_Code.Text = ((CodPaymentInModel)CurrentModel).Code;
            PerformFind();
        }

        public override void AfterDelete()
        {
            var details = new CodPaymentInDetailDataManager().Get<CodPaymentInDetailModel>(WhereTerm.Default(CurrentModel.Id, "cod_payment_in_id", EnumSqlOperator.Equals));
            if (details != null)
            {
                var detailDm = new CodPaymentInDetailDataManager();
                var expandDm = new ShipmentExpandDataManager();
                foreach (CodPaymentInDetailModel obj in details)
                {
                    var expand = expandDm.GetFirst<ShipmentExpandModel>(WhereTerm.Default((int)obj.ShipmentId, "shipment_id", EnumSqlOperator.Equals));
                    expand.PaidCod = false;
                    expandDm.Update<ShipmentExpandModel>(expand);

                    detailDm.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                }
            }

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "")
                return true;

            if (tbxTotalCash.Value <= 1)
            {
                tbxTotalCash.Focus();
                return false;
            }

            return false;
        }

        protected override void PopulateForm(CodPaymentInModel model)
        {
            ClearForm();
            GridCod.DataSource = null;

            if (model == null) return;
            EnabledForm(true);

            tsBaseTxt_Code.Text = model.Code;

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;
            tbxDate.DateTime = model.DateProcess;
            tbxDescription.Text = model.Description;

            tbxTotalSales.SetValue(model.Total);
            tbxTotalSales.Enabled = false;

            tbxTotalCash.SetValue(model.TotalCash);
            tbxTotalCash.Enabled = true;

            var data = new CodPaymentInDetailDataManager().Get<CodPaymentInDetailModel>(WhereTerm.Default(model.Id, "cod_payment_in_id"));
            data.ToList().ForEach(p =>
            {
                p.Checked = p.ActualPaid > 0;
            });
            GridCod.DataSource = data;
            CodView.RefreshData();
        }

        protected override CodPaymentInModel PopulateModel(CodPaymentInModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.BranchId = BaseControl.BranchId;
            model.Description = tbxDescription.Text;
            model.Total = tbxTotalSales.Value;
            model.TotalCash = tbxTotalCash.Value;

            if (model.Id == 0)
            {
                model.CreatedPc = Environment.MachineName;
                model.Code = GetCode("codpayment", tbxDate.DateTime);
            }
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override CodPaymentInModel Find(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm)) tsBaseTxt_Code.Text = searchTerm;
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<CodPaymentInModel>(param);
            PopulateForm(obj);

            return obj;
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            var model = CurrentModel as CodPaymentInModel;
            if ((model != null && model.Id > 0 && (DateTime.Now - model.DateProcess).TotalHours > 2)/* && BaseControl.RoleId != 2*/)
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