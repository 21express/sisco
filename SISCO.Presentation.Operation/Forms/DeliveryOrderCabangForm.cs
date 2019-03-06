using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Operation.Popup;
using SISCO.Presentation.Operation.Reports;
using Devenlab.Common.WinControl.MessageBox;
using SISCO.Presentation.CustomerService.Forms;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class DeliveryOrderCabangForm : BaseCrudForm<DeliveryOrderModel, DeliveryOrderDataManager>//BaseToolbarForm//
    {
        private IEnumerable<BranchModel> Branches { get; set; }
        private string Code { get; set; }
        private List<int> DeletedRows { get; set; }
        private bool FocusBarcode { get; set; }

        public DeliveryOrderCabangForm()
        {
            InitializeComponent();

            form = this;
            Load += DeliveryOrderCabangLoad;
            Shown += (s, o) => cbxCabang.Enabled = true;
            btnAdd.Click += (sender, e) => AddRow();

            SearchPopup = new DeliveryOrderFilterPopup();
            btnDelete.ButtonClick += DeleteRow;
            DeliveryOrderView.RowStyle += ChangeColor;
            DeliveryOrderView.CustomColumnDisplayText += NumberGrid;
            GridDeliveryOrder.DoubleClick += (sender, args) => OpenRelatedForm(DeliveryOrderView, new TrackingViewForm(), "ShipmentCode");

            FormTrackingStatus = EnumTrackingStatus.Delivery;
            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };

            tsBaseBtn_Print.Click += Print;
            tsBaseBtn_PrintPreview.Click += PrintPreview;

            tbxBarcode.KeyDown += (sender, args) =>
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
                    AddRow();
                }
            };

            btnExcel.Click += (sender, args) => ExportExcel(GridDeliveryOrder);
        }

        private void PrintPreview(object sender, EventArgs e)
        {
            var data = new DeliveryOrderDetailDataManager().Get<DeliveryOrderDetailModel>(WhereTerm.Default(CurrentModel.Id, "delivery_order_id"));
            var payment = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default("COLLECT", "name", EnumSqlOperator.Equals));

            var nonCod = data.Where(p => (p.TotalCod == 0 || p.TotalCod == null) && p.PaymentMethodId != payment.Id).ToList();
            var cod = data.Where(p => p.TotalCod > 0).ToList();
            var collect = data.Where(p => p.PaymentMethodId == payment.Id).ToList();

            if (nonCod.Count > 0)
            {
                var print = new DeliveryNonCODPrint();
                using (var printTool = new ReportPrintTool(print))
                {
                    print.DataSource = nonCod;
                    var curmodel = CurrentModel as DeliveryOrderModel;
                    if (curmodel == null) return;
                    var messenger = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default(curmodel.MessengerId, "id", EnumSqlOperator.Equals));

                    print.RequestParameters = false;
                    print.Parameters.Add(new Parameter
                    {
                        Name = "Messenger",
                        Value = string.Format("{0} - {1}", messenger.Code, messenger.Name),
                        Visible = false
                    });

                    var assistant = string.Empty;
                    if (curmodel.AsstId != null)
                    {
                        var asst = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)curmodel.AsstId, "id", EnumSqlOperator.Equals));
                        assistant = string.Format("{0} - {1}", asst.Code, asst.Name);
                    }

                    print.Parameters.Add(new Parameter
                    {
                        Name = "Assistant",
                        Value = assistant,
                        Visible = false
                    });

                    var fleet = string.Empty;
                    if (curmodel.FleetId != null)
                    {
                        var f = new FleetDataManager().GetFirst<FleetModel>(WhereTerm.Default((int)curmodel.FleetId, "id"));
                        fleet = string.Format("{0} / {1} / {2}", f.PlateNumber, f.Brand, f.Model);
                    }

                    print.Parameters.Add(new Parameter
                    {
                        Name = "Fleet",
                        Value = fleet,
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

            if (cod.Count > 0)
            {
                var printCod = new DeliveryCODPrint();
                using (var printTool = new ReportPrintTool(printCod))
                {
                    printCod.DataSource = cod;
                    var curmodel = CurrentModel as DeliveryOrderModel;
                    if (curmodel == null) return;
                    var messenger = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default(curmodel.MessengerId, "id", EnumSqlOperator.Equals));

                    printCod.RequestParameters = false;
                    printCod.Parameters.Add(new Parameter
                    {
                        Name = "Messenger",
                        Value = string.Format("{0} - {1}", messenger.Code, messenger.Name),
                        Visible = false
                    });

                    var vehicleType = string.Empty;
                    if (tbxKendaraan.Value != null)
                    {
                        var vehicle = new FleetDataManager().GetFirst<FleetModel>(WhereTerm.Default((int)tbxKendaraan.Value, "id"));
                        if (vehicle != null)
                        {
                            var VehicleType = new VehicleTypeDataManager().GetFirst<VehicleTypeModel>(WhereTerm.Default(vehicle.VehicleTypeId, "id"));
                            if (VehicleType != null) vehicleType = VehicleType.Name;
                        }
                    }

                    var assistant = string.Empty;
                    if (curmodel.AsstId != null)
                    {
                        var asst = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)curmodel.AsstId, "id", EnumSqlOperator.Equals));
                        assistant = string.Format("{0} - {1}", asst.Code, asst.Name);
                    }

                    printCod.Parameters.Add(new Parameter
                    {
                        Name = "Assistant",
                        Value = assistant,
                        Visible = false
                    });

                    printCod.Parameters.Add(new Parameter
                    {
                        Name = "VehicleType",
                        Value = vehicleType,
                        Visible = false
                    });

                    var fleet = string.Empty;
                    if (curmodel.FleetId != null)
                    {
                        var f = new FleetDataManager().GetFirst<FleetModel>(WhereTerm.Default((int)curmodel.FleetId, "id"));
                        fleet = string.Format("{0} / {1} / {2}", f.PlateNumber, f.Brand, f.Model);
                    }

                    printCod.Parameters.Add(new Parameter
                    {
                        Name = "Fleet",
                        Value = fleet,
                        Visible = false
                    });

                    printCod.Parameters.Add(new Parameter
                    {
                        Name = "Code",
                        Value = curmodel.Code,
                        Visible = false
                    });

                    printCod.CreateDocument();
                    printTool.PrintingSystem.StartPrint += (o, args) =>
                    {
                        args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                    };
                    printTool.ShowPreviewDialog();
                }
            }

            if (collect.Count > 0)
            {
                var printCollect = new DeliveryCollectPrint();
                using (var printTool = new ReportPrintTool(printCollect))
                {
                    printCollect.DataSource = collect;
                    var curmodel = CurrentModel as DeliveryOrderModel;
                    if (curmodel == null) return;
                    var messenger = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default(curmodel.MessengerId, "id", EnumSqlOperator.Equals));

                    printCollect.RequestParameters = false;
                    printCollect.Parameters.Add(new Parameter
                    {
                        Name = "Messenger",
                        Value = string.Format("{0} - {1}", messenger.Code, messenger.Name),
                        Visible = false
                    });

                    var vehicleType = string.Empty;
                    if (tbxKendaraan.Value != null)
                    {
                        var vehicle = new FleetDataManager().GetFirst<FleetModel>(WhereTerm.Default((int)tbxKendaraan.Value, "id"));
                        if (vehicle != null)
                        {
                            var VehicleType = new VehicleTypeDataManager().GetFirst<VehicleTypeModel>(WhereTerm.Default(vehicle.VehicleTypeId, "id"));
                            if (VehicleType != null) vehicleType = VehicleType.Name;
                        }
                    }

                    var assistant = string.Empty;
                    if (curmodel.AsstId != null)
                    {
                        var asst = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)curmodel.AsstId, "id", EnumSqlOperator.Equals));
                        assistant = string.Format("{0} - {1}", asst.Code, asst.Name);
                    }

                    printCollect.Parameters.Add(new Parameter
                    {
                        Name = "Assistant",
                        Value = assistant,
                        Visible = false
                    });

                    printCollect.Parameters.Add(new Parameter
                    {
                        Name = "VehicleType",
                        Value = vehicleType,
                        Visible = false
                    });

                    var fleet = string.Empty;
                    if (curmodel.FleetId != null)
                    {
                        var f = new FleetDataManager().GetFirst<FleetModel>(WhereTerm.Default((int)curmodel.FleetId, "id"));
                        fleet = string.Format("{0} / {1} / {2}", f.PlateNumber, f.Brand, f.Model);
                    }

                    printCollect.Parameters.Add(new Parameter
                    {
                        Name = "Fleet",
                        Value = fleet,
                        Visible = false
                    });

                    printCollect.Parameters.Add(new Parameter
                    {
                        Name = "Code",
                        Value = curmodel.Code,
                        Visible = false
                    });

                    printCollect.CreateDocument();
                    printTool.PrintingSystem.StartPrint += (o, args) =>
                    {
                        args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                    };
                    printTool.ShowPreviewDialog();
                }
            }
        }

        private void Print(object sender, EventArgs e)
        {
            var data = new DeliveryOrderDetailDataManager().Get<DeliveryOrderDetailModel>(WhereTerm.Default(CurrentModel.Id, "delivery_order_id"));
            var payment = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default("COLLECT", "name", EnumSqlOperator.Equals));

            var nonCod = data.Where(p => (p.TotalCod == 0 || p.TotalCod == null) && p.PaymentMethodId != payment.Id).ToList();
            var cod = data.Where(p => p.TotalCod > 0).ToList();
            var collect = data.Where(p => p.PaymentMethodId == payment.Id).ToList();

            if (nonCod.Count > 0)
            {
                var print = new DeliveryNonCODPrint();
                using (var printTool = new ReportPrintTool(print))
                {
                    print.DataSource = nonCod;
                    var curmodel = CurrentModel as DeliveryOrderModel;
                    if (curmodel == null) return;
                    var messenger = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default(curmodel.MessengerId, "id", EnumSqlOperator.Equals));

                    print.RequestParameters = false;
                    print.Parameters.Add(new Parameter
                    {
                        Name = "Messenger",
                        Value = string.Format("{0} - {1}", messenger.Code, messenger.Name),
                        Visible = false
                    });

                    var assistant = string.Empty;
                    if (curmodel.AsstId != null)
                    {
                        var asst = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)curmodel.AsstId, "id", EnumSqlOperator.Equals));
                        assistant = string.Format("{0} - {1}", asst.Code, asst.Name);
                    }

                    print.Parameters.Add(new Parameter
                    {
                        Name = "Assistant",
                        Value = assistant,
                        Visible = false
                    });

                    var fleet = string.Empty;
                    if (curmodel.FleetId != null)
                    {
                        var f = new FleetDataManager().GetFirst<FleetModel>(WhereTerm.Default((int)curmodel.FleetId, "id"));
                        fleet = string.Format("{0} / {1} / {2}", f.PlateNumber, f.Brand, f.Model);
                    }

                    print.Parameters.Add(new Parameter
                    {
                        Name = "Fleet",
                        Value = fleet,
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

            if (cod.Count > 0)
            {
                var printCod = new DeliveryCODPrint();
                using (var printTool = new ReportPrintTool(printCod))
                {
                    printCod.DataSource = cod;
                    var curmodel = CurrentModel as DeliveryOrderModel;
                    if (curmodel == null) return;
                    var messenger = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default(curmodel.MessengerId, "id", EnumSqlOperator.Equals));

                    printCod.RequestParameters = false;
                    printCod.Parameters.Add(new Parameter
                    {
                        Name = "Messenger",
                        Value = string.Format("{0} - {1}", messenger.Code, messenger.Name),
                        Visible = false
                    });

                    var vehicleType = string.Empty;
                    if (tbxKendaraan.Value != null)
                    {
                        var vehicle = new FleetDataManager().GetFirst<FleetModel>(WhereTerm.Default((int)tbxKendaraan.Value, "id"));
                        if (vehicle != null)
                        {
                            var VehicleType = new VehicleTypeDataManager().GetFirst<VehicleTypeModel>(WhereTerm.Default(vehicle.VehicleTypeId, "id"));
                            if (VehicleType != null) vehicleType = VehicleType.Name;
                        }
                    }

                    var assistant = string.Empty;
                    if (curmodel.AsstId != null)
                    {
                        var asst = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)curmodel.AsstId, "id", EnumSqlOperator.Equals));
                        assistant = string.Format("{0} - {1}", asst.Code, asst.Name);
                    }

                    printCod.Parameters.Add(new Parameter
                    {
                        Name = "Assistant",
                        Value = assistant,
                        Visible = false
                    });

                    printCod.Parameters.Add(new Parameter
                    {
                        Name = "VehicleType",
                        Value = vehicleType,
                        Visible = false
                    });

                    var fleet = string.Empty;
                    if (curmodel.FleetId != null)
                    {
                        var f = new FleetDataManager().GetFirst<FleetModel>(WhereTerm.Default((int)curmodel.FleetId, "id"));
                        fleet = string.Format("{0} / {1} / {2}", f.PlateNumber, f.Brand, f.Model);
                    }

                    printCod.Parameters.Add(new Parameter
                    {
                        Name = "Fleet",
                        Value = fleet,
                        Visible = false
                    });

                    printCod.Parameters.Add(new Parameter
                    {
                        Name = "Code",
                        Value = curmodel.Code,
                        Visible = false
                    });

                    printCod.CreateDocument();
                    printTool.PrintingSystem.StartPrint += (o, args) =>
                    {
                        args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                    };
                    printTool.Print();
                }
            }

            if (collect.Count > 0)
            {
                var printCollect = new DeliveryCollectPrint();
                using (var printTool = new ReportPrintTool(printCollect))
                {
                    printCollect.DataSource = collect;
                    var curmodel = CurrentModel as DeliveryOrderModel;
                    if (curmodel == null) return;
                    var messenger = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default(curmodel.MessengerId, "id", EnumSqlOperator.Equals));

                    printCollect.RequestParameters = false;
                    printCollect.Parameters.Add(new Parameter
                    {
                        Name = "Messenger",
                        Value = string.Format("{0} - {1}", messenger.Code, messenger.Name),
                        Visible = false
                    });

                    var vehicleType = string.Empty;
                    if (tbxKendaraan.Value != null)
                    {
                        var vehicle = new FleetDataManager().GetFirst<FleetModel>(WhereTerm.Default((int)tbxKendaraan.Value, "id"));
                        if (vehicle != null)
                        {
                            var VehicleType = new VehicleTypeDataManager().GetFirst<VehicleTypeModel>(WhereTerm.Default(vehicle.VehicleTypeId, "id"));
                            if (VehicleType != null) vehicleType = VehicleType.Name;
                        }
                    }

                    var assistant = string.Empty;
                    if (curmodel.AsstId != null)
                    {
                        var asst = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)curmodel.AsstId, "id", EnumSqlOperator.Equals));
                        assistant = string.Format("{0} - {1}", asst.Code, asst.Name);
                    }

                    printCollect.Parameters.Add(new Parameter
                    {
                        Name = "Assistant",
                        Value = assistant,
                        Visible = false
                    });

                    printCollect.Parameters.Add(new Parameter
                    {
                        Name = "VehicleType",
                        Value = vehicleType,
                        Visible = false
                    });

                    var fleet = string.Empty;
                    if (curmodel.FleetId != null)
                    {
                        var f = new FleetDataManager().GetFirst<FleetModel>(WhereTerm.Default((int)curmodel.FleetId, "id"));
                        fleet = string.Format("{0} / {1} / {2}", f.PlateNumber, f.Brand, f.Model);
                    }

                    printCollect.Parameters.Add(new Parameter
                    {
                        Name = "Fleet",
                        Value = fleet,
                        Visible = false
                    });

                    printCollect.Parameters.Add(new Parameter
                    {
                        Name = "Code",
                        Value = curmodel.Code,
                        Visible = false
                    });

                    printCollect.CreateDocument();
                    printTool.PrintingSystem.StartPrint += (o, args) =>
                    {
                        args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                    };
                    printTool.Print();
                }
            }
        }

        private void DeleteRow(object sender, ButtonPressedEventArgs e)
        {
            var dialog = MessageBox.Show(Resources.delete_confirm_msg, Resources.delete_confirm, MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                var rowHandle = DeliveryOrderView.FocusedRowHandle;
                if (DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["Id"]) != null) DeletedRows.Add((int)DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["Id"]));

                DeliveryOrderView.DeleteSelectedRows();
            }
        }

        private void ChangeColor(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;

                if (view == null) return;
                if ((int)view.GetRowCellValue(e.RowHandle, view.Columns["ServiceTypeId"]) == 7 || (int)view.GetRowCellValue(e.RowHandle, view.Columns["ServiceTypeId"]) == 9)
                {
                    e.Appearance.ForeColor = Color.Red;
                }

                if ((int)view.GetRowCellValue(e.RowHandle, view.Columns["ServiceTypeId"]) == 8)
                {
                    e.Appearance.ForeColor = Color.Blue;
                }
            }
        }

        private void AddRow()
        {
            if (tbxBarcode.Text == string.Empty) return;

            var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxBarcode.Text, "code", EnumSqlOperator.Equals));
            if (shipment != null)
            {
                if (shipment.DestBranchId != (int)cbxCabang.SelectedValue)
                {
                    if (shipment.BranchId == (int)cbxCabang.SelectedValue)
                    {
                        var status = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                    {
                        WhereTerm.Default(shipment.Id, "shipment_id"),
                        WhereTerm.Default((int) EnumTrackingStatus.Returned, "tracking_status_id")
                    });

                        if (status == null)
                        {
                            MessageForm.Warning(form, "POD Retur", "Untuk POD retur, mohon info ke Customer Service untuk update POD sebagai RETURN agar bisa dilakukan delivery kembali.");
                            tbxBarcode.Focus();
                            tbxBarcode.Clear();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(string.Format(Resources.check_destination, shipment.Code), Resources.information,
                            MessageBoxButtons.OK);
                        return;
                    }
                }

                Detail(shipment);
            }
            else
            {
                //BaseControl.OpenRelatedForm(new DataEntryCabangForm(), string.Empty, CallingCommand);
                //AutoClosingMessageBox.Show(@"No. POD tidak dikenali");
                MessageBox.Show("No. POD tidak diketahui");
            }

            tbxBarcode.Text = string.Empty;
            tbxBarcode.Focus();
        }

        private void Detail(ShipmentModel shipment)
        {
            var payment = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default(shipment.PaymentMethodId, "id", EnumSqlOperator.Equals));
            var service = new ServiceTypeDataManager().GetFirst<ServiceTypeModel>(WhereTerm.Default(shipment.ServiceTypeId, "id", EnumSqlOperator.Equals));
            var package = new PackageDataManager().GetFirst<PackageTypeModel>(WhereTerm.Default(shipment.PackageTypeId, "id", EnumSqlOperator.Equals));

            // ReSharper disable once RedundantAssignment
            var details = new List<DeliveryOrderDetailModel>();
            if (DeliveryOrderView.RowCount > 0)
            {
                details = GridDeliveryOrder.DataSource as List<DeliveryOrderDetailModel>;

                //var s = new DeliveryOrderDetailDataManager().GetFirst<DeliveryOrderDetailModel>(WhereTerm.Default(shipment.Code, "shipment_code", EnumSqlOperator.Equals));
                //if (s != null) return;

                if (details != null && details.FirstOrDefault(b => b.ShipmentCode == shipment.Code) != null)  return;
            }

            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(shipment.Id, "shipment_id"));
            var branch = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(shipment.BranchId, "id", EnumSqlOperator.Equals));
            var detail = new DeliveryOrderDetailModel
            {
                DateProcess = DateTime.Now,
                ShipmentId = shipment.Id,
                ShipmentDate = shipment.DateProcess,
                ShipmentCode = shipment.Code,
                ConsolCode = string.Empty,
                BranchId = shipment.BranchId,
                Branch = branch.Name,
                DestCityId = shipment.DestCityId,
                CustomerId = shipment.CustomerId,
                CustomerName = shipment.CustomerName,
                ShipperName = shipment.ShipperName,
                ConsigneeName = shipment.ConsigneeName,
                ServiceTypeId = shipment.ServiceTypeId,
                ServiceType = service.Name,
                PackageTypeId = shipment.PackageTypeId,
                PackageType = package.Name,
                PaymentMethodId = shipment.PaymentMethodId,
                PaymentMethod = payment.Name,
                TtlPiece = shipment.TtlPiece,
                TtlGrossWeight = shipment.TtlGrossWeight,
                TtlChargeableWeight = shipment.TtlChargeableWeight,
                IsCod = expand == null ? false : expand.IsCod,
                TotalCod = expand == null ? 0 : expand.TotalCod,
                Total = payment.Name == "COLLECT" ? shipment.Total : 0,
                Fulfilment = expand == null ? string.Empty : expand.Fulfilment,
                StateChange2 = EnumStateChange.Insert.ToString()
            };

            if (details != null)
            {
                details.Add(detail);
                GridDeliveryOrder.DataSource = details;
                DeliveryOrderView.RefreshData();

                DeliveryOrderView.FocusedRowHandle = DeliveryOrderView.RowCount - 1;
            }
        }

        private void DeliveryOrderCabangLoad(object sender, EventArgs e)
        {
            EnableBtnSearch = true;
            EnableBtnPrint = false;
            EnableBtnPrintPreview = false;

            tbxCourier.LookupPopup = new MessengerPopup();
            tbxCourier.AutoCompleteDataManager = new EmployeeDataManager();
            tbxCourier.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            tbxCourier.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_messenger AND branch_id = @1", s, BaseControl.BranchId);

            tbxAsstDriver.LookupPopup = new MessengerPopup();
            tbxAsstDriver.AutoCompleteDataManager = new EmployeeDataManager();
            tbxAsstDriver.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            tbxAsstDriver.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_messenger AND branch_id = @1", s, BaseControl.BranchId);

            tbxKendaraan.LookupPopup = new FleetPopup();
            tbxKendaraan.AutoCompleteDataManager = new FleetDataManager();
            tbxKendaraan.AutoCompleteDisplayFormater = model => ((FleetModel)model).PlateNumber + " / " + ((FleetModel)model).Brand + " / " + ((FleetModel)model).Model;
            tbxKendaraan.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "plate_number", EnumSqlOperator.BeginWith),
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.BeginWith)
            };

            var branchType = new BranchTypeDataManager().GetFirst<BranchTypeModel>(WhereTerm.Default("BRANCH", "name", EnumSqlOperator.Equals));
            Branches = new BranchDataManager().Get<BranchModel>(
                new IListParameter[]
                {
                    WhereTerm.Default(branchType.Id, "branch_type_id", EnumSqlOperator.Equals)
                }
            );

            cbxCabang.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxCabang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxCabang.DataSource = Branches;
            cbxCabang.DisplayMember = "Name";
            cbxCabang.ValueMember = "Id";
            cbxCabang.SelectedValueChanged += (s, a) => SetDataManager();
        }

        private void SetDataManager()
        {
            _ClearForm(pnlTop);
            cbxCabang.Enabled = true;

            if (cbxCabang.SelectedValue == null)
            {
                DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(0, "branch_id", EnumSqlOperator.Equals) };
                SearchPopup = new DeliveryOrderFilterPopup();
                return;
            }

            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default((int)cbxCabang.SelectedValue, "branch_id", EnumSqlOperator.Equals) };
            SearchPopup = new DeliveryOrderFilterPopup((int)cbxCabang.SelectedValue);
        }

        public override void New()
        {
            base.New();

            DeletedRows = new List<int>();
            _ClearForm(pnlTop);
            ToolbarCode = string.Empty;
            StateChange = EnumStateChange.Insert;
            GridDeliveryOrder.DataSource = null;
            DeliveryOrderView.RefreshData();

            tbxDate.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            tbxCourier.Focus();
        }

        public override void Save()
        {
            if (DeliveryOrderView.RowCount == 0)
            {
                MessageBox.Show(
                   Resources.stt_detail_empty
                   , Resources.title_save_changes
                   , MessageBoxButtons.OK
                   , MessageBoxIcon.Information);

                return;
            }

            if (CurrentModel.Id == 0)
            {
                if (tbxDate.Text != "")
                    Code = GetCode("delivery", tbxDate.Value);
            }
            else
            {
                var order = new DeliveryOrderDataManager().GetFirst<DeliveryOrderModel>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));
                Code = order.Code;
            }

            base.Save();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            Enabled = false;
            var delivery = new DeliveryOrderDataManager().GetFirst<DeliveryOrderModel>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));
            Code = delivery.Code;

            StateChange = EnumStateChange.Select;
            short totalPiece = 0;
            decimal totalGw = 0;
            decimal totalCw = 0;
            for (int i = 0; i < DeliveryOrderView.RowCount; i++)
            {
                int rowHandle = DeliveryOrderView.GetVisibleRowHandle(i);
                if (DeliveryOrderView.IsDataRow(rowHandle))
                {
                    var state = DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["StateChange2"]);
                    if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                    {
                        var detail = new DeliveryOrderDetailModel();
                        detail.Rowstatus = true;
                        detail.Rowversion = DateTime.Now;
                        detail.DeliveryOrderId = CurrentModel.Id;
                        detail.DateProcess = DateTime.Now;
                        detail.DeliveryOrderCode = Code;
                        detail.ShipmentId =
                            (int)DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["ShipmentId"]);
                        detail.ShipmentDate =
                            (DateTime)
                                DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["ShipmentDate"]);
                        detail.ShipmentCode =
                            DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["ShipmentCode"])
                                .ToString();
                        detail.BranchId =
                            (int)DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["BranchId"]);
                        detail.DestCityId =
                            (int)DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["DestCityId"]);
                        detail.CustomerId =
                            DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["CustomerId"]) != null ?
                            (int)DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["CustomerId"]) : (int?) null;
                        detail.CustomerName =
                            DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["CustomerName"]) != null ?
                            DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["CustomerName"])
                            .ToString() : "";
                        detail.ShipperName =
                            DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["ShipperName"]) != null ?
                            DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["ShipperName"])
                            .ToString() : "";
                        detail.ConsigneeName =
                            DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["ConsigneeName"]) != null ?
                            DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["ConsigneeName"])
                            .ToString() : "";
                        detail.ServiceTypeId =
                            (int)DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["ServiceTypeId"]);
                        detail.PackageTypeId =
                            (int)
                                DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["PackageTypeId"]);
                        detail.PaymentMethodId =
                            (int)
                                DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["PaymentMethodId"]);
                        detail.TtlPiece =
                            (short)DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["TtlPiece"]);
                        detail.TtlGrossWeight =
                            (decimal)
                                DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["TtlGrossWeight"]);
                        detail.TtlChargeableWeight =
                            (decimal)
                                DeliveryOrderView.GetRowCellValue(rowHandle,
                                    DeliveryOrderView.Columns["TtlChargeableWeight"]);
                        detail.IsCod =
                            (bool)
                                DeliveryOrderView.GetRowCellValue(rowHandle,
                                    DeliveryOrderView.Columns["IsCod"]);
                        detail.TotalCod =
                            (decimal)
                                DeliveryOrderView.GetRowCellValue(rowHandle,
                                    DeliveryOrderView.Columns["TotalCod"]);
                        detail.Total = (decimal)
                                DeliveryOrderView.GetRowCellValue(rowHandle,
                                    DeliveryOrderView.Columns["Total"]);
                        detail.Createddate = DateTime.Now;
                        detail.Createdby = BaseControl.UserLogin;

                        new DeliveryOrderDetailDataManager().Save<DeliveryOrderDetailModel>(detail);

                        var ship =
                            new ShipmentDataManager().GetFirst<ShipmentModel>(
                                WhereTerm.Default(detail.ShipmentId, "id", EnumSqlOperator.Equals));
                        if (ship != null)
                        {
                            if (ship.TrackingStatusId != (int)EnumTrackingStatus.Received && ship.TrackingStatusId != (int)EnumTrackingStatus.Claimed && ship.TrackingStatusId != (int)EnumTrackingStatus.Gudang)
                            {
                                ship.TrackingStatusId = (int)EnumTrackingStatus.Delivery;
                                ship.Modifiedby = BaseControl.UserLogin;
                                ship.Modifieddate = DateTime.Now;
                                new ShipmentDataManager().Update<ShipmentModel>(ship);
                            }

                            InsertTracking = true;
                            PodStatusModel.ShipmentId = ship.Id;
                            PodStatusModel.PositionStatusId = BaseControl.BranchId;
                            PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();
                            PodStatusModel.Reference = Code;
                            PodStatusModel.TrackingStatusId = (int) FormTrackingStatus;

                            if (delivery.MessengerId > 0)
                            {
                                var mess = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default(delivery.MessengerId, "id", EnumSqlOperator.Equals));
                                PodStatusModel.StatusBy = mess.Name;
                            }

                            ShipmentStatusUpdate();
                        }
                    }

                    totalPiece +=
                        (short)DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["TtlPiece"]);
                    totalGw +=
                        (decimal)
                            DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["TtlGrossWeight"]);
                    totalCw +=
                        (decimal)
                            DeliveryOrderView.GetRowCellValue(rowHandle, DeliveryOrderView.Columns["TtlChargeableWeight"]);
                }
            }

            delivery.TtlPiece = totalPiece;
            delivery.TtlGrossWeight = totalGw;
            delivery.TtlChargeableWeight = totalCw;

            new DeliveryOrderDataManager().Update<DeliveryOrderModel>(delivery);
            foreach (int o in DeletedRows)
            {
                var data =
                    new DeliveryOrderDetailDataManager().GetFirst<DeliveryOrderDetailModel>(WhereTerm.Default(o, "id",
                        EnumSqlOperator.Equals));
                if (data != null)
                {
                    var shipmentStatus =
                        new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                                        {
                                            WhereTerm.Default(data.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                                            WhereTerm.Default((int) EnumTrackingStatus.Delivery, "tracking_status_id",
                                                EnumSqlOperator.Equals)
                                        });

                    if (shipmentStatus != null)
                    {
                        new ShipmentStatusDataManager().DeActive(shipmentStatus.Id, BaseControl.UserLogin,
                            DateTime.Now);
                    }

                    new DeliveryOrderDetailDataManager().DeActive(o, BaseControl.UserLogin, DateTime.Now);
                }
            }

            Enabled = true;
            ToolbarCode = delivery.Code;
        }

        protected override void AfterSave()
        {
            OpenData(ToolbarCode);
            tsBaseTxt_Code.Focus();
        }

        public override void AfterDelete()
        {
            var repo = new DeliveryOrderDetailDataManager();
            var detail = repo.Get<DeliveryOrderDetailModel>(WhereTerm.Default(CurrentModel.Id, "delivery_order_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var shipRepo = new ShipmentStatusDataManager();
                foreach (DeliveryOrderDetailModel obj in detail)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                    var shipmentStatus = shipRepo.GetFirst<ShipmentStatusModel>(new IListParameter[]
                        {
                            WhereTerm.Default(obj.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                            WhereTerm.Default((int) EnumTrackingStatus.Delivery, "tracking_status_id", EnumSqlOperator.Equals)
                        });
                    if (shipmentStatus != null)
                    {
                        shipRepo.DeActive(shipmentStatus.Id, BaseControl.UserLogin, DateTime.Now);
                    }
                }
            }

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "" && tbxCourier.Value != null)
                return true;

            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return false;
            }

            if (tbxCourier.Value == null)
            {
                tbxCourier.Focus();
                return false;
            }

            if (tbxKendaraan.Value == null)
            {
                tbxKendaraan.Focus();
                return false;
            }

            return false;
        }

        protected override void PopulateForm(DeliveryOrderModel model)
        {
            _ClearForm(pnlTop);
            GridDeliveryOrder.DataSource = null;
            EnabledForm(true);
            if (model == null) return;

            DeletedRows = new List<int>();
            EnableBtnPrint = true;
            EnableBtnPrintPreview = true;

            ToolbarCode = model.Code;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = model.DateProcess.ToString();

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            tbxCourier.DefaultValue = new IListParameter[] { WhereTerm.Default(model.MessengerId, "id", EnumSqlOperator.Equals) };
            if (model.AsstId != null) tbxAsstDriver.DefaultValue = new IListParameter[] { WhereTerm.Default((int)model.AsstId, "id", EnumSqlOperator.Equals) };

            if (model.FleetId != null)
            {
                tbxKendaraan.DefaultValue = new IListParameter[]
                {WhereTerm.Default((int) model.FleetId, "id", EnumSqlOperator.Equals)};
            }

            var details = new DeliveryOrderDetailDataManager().Get<DeliveryOrderDetailModel>(WhereTerm.Default(model.Id, "delivery_order_id"));

            GridDeliveryOrder.DataSource = details;

            if (model.Createdby != BaseControl.UserLogin) EnabledForm(false);

            cbxCabang.Enabled = true;
        }

        protected override DeliveryOrderModel PopulateModel(DeliveryOrderModel model)
        {
            model.DateProcess = tbxDate.Value;
            model.Code = Code;
            model.BranchId = (int) cbxCabang.SelectedValue;

            if (tbxCourier.Value != null)
            {
                model.MessengerId = (int)tbxCourier.Value;
                model.MessengerName = tbxCourier.Text;
            }

            if (tbxAsstDriver.Value != null)
            {
                model.AsstId = (int)tbxAsstDriver.Value;
                model.AsstName = tbxAsstDriver.Text;
            }

            if (tbxKendaraan.Value != null)
            {
                var fleet = new FleetDataManager().GetFirst<FleetModel>(WhereTerm.Default((int)tbxKendaraan.Value, "id", EnumSqlOperator.Equals));
                model.FleetId = tbxKendaraan.Value;
                model.FleetNumber = fleet.PlateNumber;
            }

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override DeliveryOrderModel Find(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm)) tsBaseTxt_Code.Text = searchTerm;
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<DeliveryOrderModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as DeliveryOrderModel;

            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            var model = CurrentModel as DeliveryOrderModel;
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