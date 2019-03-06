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
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Operation.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class ManifestVendorForm : BaseCrudForm<ManifestVendorModel, ManifestVendorDataManager>//BaseToolbarForm//
    {
        private List<int> DeletedRows { get; set; }
        public ManifestVendorForm()
        {
            InitializeComponent();

            form = this;
            Load += FormLoad;
            btnScan.Click += ScanPod;

            FormTrackingStatus = EnumTrackingStatus.Vendor;
            ManifestView.CustomColumnDisplayText += NumberGrid;

            btnRowDelete.ButtonClick += DeleteRow;
            tbxPod.KeyDown += (sender, args) =>
            {
                switch (args.KeyCode)
                {
                    case Keys.Enter:
                        if (!args.Shift)
                        {
                            ScanPod(sender, args);
                        }
                        break;
                }
            };

            tsBaseBtn_Print.Click += Print;
            tsBaseBtn_PrintPreview.Click += PrintPreview;
        }

        private void DeleteRow(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (!btnScan.Enabled) return;
            var dialog = MessageForm.Ask(form, Resources.delete_confirm, Resources.delete_confirm_msg);
            if (dialog == DialogResult.Yes)
            {
                var rowHandle = ManifestView.FocusedRowHandle;
                if (ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["Id"]) != null) DeletedRows.Add((int)ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["Id"]));
                ManifestView.DeleteSelectedRows();
            }
        }

        public override void New()
        {
            base.New();

            ClearForm();
            ToolbarCode = string.Empty;
            StateChange = EnumStateChange.Insert;
            GridManifest.DataSource = null;
            ManifestView.RefreshData();

            DeletedRows = new List<int>();
            lkpVendor.Focus();

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;
            tbxDate.DateTime = DateTime.Now;
            lkpVendor.Enabled = true;
            lkpVendor.Properties.Buttons[0].Enabled = true;
            btnScan.Enabled = true;
        }

        public override void Save()
        {
            if (ManifestView.RowCount == 0)
            {
                //MessageBox.Show(Resources.stt_detail_empty, Resources.title_save_changes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageForm.Info(form, Resources.title_save_changes, Resources.stt_detail_empty);
                tbxPod.Focus();
                tbxPod.Clear();
                return;
            }

            base.Save();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            form.Enabled = false;
            var manifest = new ManifestVendorDataManager().GetFirst<ManifestVendorModel>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));

            StateChange = EnumStateChange.Select;
            short totalPiece = 0;
            decimal totalGw = 0;
            decimal totalCw = 0;
            for (int i = 0; i < ManifestView.RowCount; i++)
            {
                int rowHandle = ManifestView.GetVisibleRowHandle(i);
                if (ManifestView.IsDataRow(rowHandle))
                {
                    var state = ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["StateChange2"]);
                    if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                    {
                        var detail = new ManifestVendorDetailModel();
                        detail.Rowstatus = true;
                        detail.Rowversion = DateTime.Now;
                        detail.ManifestVendorId = CurrentModel.Id;

                        detail.ShipmentId =
                            (int)ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ShipmentId"]);
                        detail.ShipmentDate =
                            (DateTime)
                                ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ShipmentDate"]);
                        detail.ShipmentCode =
                            ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ShipmentCode"])
                                .ToString();
                        detail.BranchId =
                            (int)ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["BranchId"]);
                        detail.DestCityId =
                            (int)ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["DestCityId"]);

                        if (ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ShipperName"]) != null)
                            detail.ShipperName =
                                ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ShipperName"])
                                    .ToString();

                        if (ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ConsigneeName"]) != null)
                            detail.ConsigneeName =
                                ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ConsigneeName"])
                                    .ToString();

                        detail.ServiceTypeId =
                            (int)ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ServiceTypeId"]);

                        detail.PackageTypeId =
                            (int)
                                ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["PackageTypeId"]);
                        
                        detail.PaymentMethodId =
                            (int)
                                ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["PaymentMethodId"]);
                        
                        detail.TtlPiece =
                            (short)ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["TtlPiece"]);
                        detail.TtlGrossWeight =
                            (decimal)
                                ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["TtlGrossWeight"]);
                        detail.TtlChargeableWeight =
                            (decimal)
                                ManifestView.GetRowCellValue(rowHandle,
                                    ManifestView.Columns["TtlChargeableWeight"]);

                        detail.Createddate = DateTime.Now;
                        detail.Createdby = BaseControl.UserLogin;

                        new ManifestVendorDetailDataManager().Save<ManifestVendorDetailModel>(detail);

                        var ship =
                            new ShipmentDataManager().GetFirst<ShipmentModel>(
                                WhereTerm.Default((int)detail.ShipmentId, "id", EnumSqlOperator.Equals));
                        if (ship != null)
                        {
                            ship.Manifested = true;
                            if (ship.TrackingStatusId != (int)EnumTrackingStatus.Received && ship.TrackingStatusId != (int)EnumTrackingStatus.Claimed && ship.TrackingStatusId != (int)EnumTrackingStatus.Gudang) ship.TrackingStatusId = (int)EnumTrackingStatus.Manifested;
                            ship.Modifiedby = BaseControl.UserLogin;
                            ship.Modifieddate = DateTime.Now;
                            new ShipmentDataManager().Update<ShipmentModel>(ship);

                            InsertTracking = true;
                            PodStatusModel.ShipmentId = ship.Id;
                            PodStatusModel.Reference = manifest.Code;
                            PodStatusModel.PositionStatusId = BaseControl.BranchId;
                            PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();

                            PodStatusModel.StatusBy = BaseControl.BranchCode;

                            ShipmentStatusUpdate();
                        }
                    }

                    if (state.ToString().Equals(EnumStateChange.Delete.ToString()))
                    {
                        if (ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["Id"]) != null)
                        {
                            new ManifestVendorDetailDataManager().DeActive(
                                (int)ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["Id"]),
                                BaseControl.UserLogin, DateTime.Now);

                            var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default((int)ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ShipmentId"]), "id", EnumSqlOperator.Equals));

                            var shipmentStatus = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                            {
                                WhereTerm.Default(shipment.Id, "shipment_id", EnumSqlOperator.Equals),
                                WhereTerm.Default((int) EnumTrackingStatus.Manifested, "tracking_status_id", EnumSqlOperator.Equals)
                            });
                            if (shipmentStatus != null)
                            {
                                new ShipmentStatusDataManager().DeActive(shipmentStatus.Id, BaseControl.UserLogin, DateTime.Now);
                            }
                        }
                    }
                    else
                    {
                        totalPiece +=
                            (short)ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["TtlPiece"]);
                        totalGw +=
                            (decimal)
                                ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["TtlGrossWeight"]);
                        totalCw +=
                            (decimal)
                                ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["TtlChargeableWeight"]);
                    }
                }
            }

            manifest.TtlPiece = totalPiece;
            manifest.TtlGrossWeight = totalGw;
            manifest.TtlChargeableWeight = totalCw;

            new ManifestVendorDataManager().Update<ManifestVendorModel>(manifest);

            foreach (int o in DeletedRows)
            {
                var data = new ManifestVendorDetailDataManager().GetFirst<ManifestVendorDetailModel>(WhereTerm.Default(o, "id", EnumSqlOperator.Equals));
                if (data != null)
                {
                    if (data.ShipmentId != null && data.ShipmentId > 0)
                    {
                        var shipmentStatus = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                                {
                                    WhereTerm.Default((int) data.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                                    WhereTerm.Default((int) EnumTrackingStatus.Manifested, "tracking_status_id", EnumSqlOperator.Equals),
                                    WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
                                });
                        if (shipmentStatus != null)
                        {
                            new ShipmentStatusDataManager().DeActive(shipmentStatus.Id, BaseControl.UserLogin, DateTime.Now);
                        }
                    }

                    new ManifestVendorDetailDataManager().DeActive(o, BaseControl.UserLogin, DateTime.Now);
                }
            }

            Enabled = true;
            ToolbarCode = manifest.Code;
        }

        protected override void AfterSave()
        {
            OpenData(ToolbarCode);
            tsBaseTxt_Code.Focus();
        }

        private void ScanPod(object sender, EventArgs e)
        {
            if (tbxPod.Text == string.Empty) return;

            var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxPod.Text, "code", EnumSqlOperator.Equals));
            if (shipment == null)
            {
                var cd = tbxPod.Text.Substring(0, tbxPod.TextLength - 3);
                shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(cd, "code", EnumSqlOperator.Equals));
            }

            if (shipment == null)
            {
                MessageBox.Show("Nomor resi tidak dikenali.");
            }
            else
            {
                var city = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(shipment.DestCityId, "id"));
                if (city == null)
                {
                    MessageBox.Show("Kota tujuan tidak dikenali.");
                }
                else
                {
                    if (!city.IsOutArea)
                    {
                        MessageBox.Show("Nomor resi ini tidak bisa dilakukan manifest vendor.");
                    }
                    else Detail(shipment, string.Empty);
                }
            }

            tbxPod.Clear();
            tbxPod.Focus();
        }

        private void Detail(ShipmentModel shipment, string consolidationcode)
        {
            var payment = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default(shipment.PaymentMethodId, "id", EnumSqlOperator.Equals));
            var service = new ServiceTypeDataManager().GetFirst<ServiceTypeModel>(WhereTerm.Default(shipment.ServiceTypeId, "id", EnumSqlOperator.Equals));
            var package = new PackageDataManager().GetFirst<PackageTypeModel>(WhereTerm.Default(shipment.PackageTypeId, "id", EnumSqlOperator.Equals));

            // ReSharper disable once RedundantAssignment
            var cons = new List<ManifestVendorDetailModel>();

            if (ManifestView.RowCount > 0)
            {
                cons = GridManifest.DataSource as List<ManifestVendorDetailModel>;

                var s = new ManifestVendorDetailDataManager().Get<ManifestVendorDetailModel>(WhereTerm.Default(shipment.Code, "shipment_code", EnumSqlOperator.Equals)).FirstOrDefault(p => p.BranchId == BaseControl.BranchId);
                if (s != null)
                {
                    MessageForm.Info(form, Resources.information, string.Format("{0} sudah di manifest", shipment.Code));
                    return;
                }

                if (cons != null && cons.FirstOrDefault(b => b.ShipmentCode == shipment.Code) != null) return;
            }

            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(shipment.Id, "shipment_id"));

            var detail = new ManifestVendorDetailModel
            {
                ShipmentId = shipment.Id,
                ShipmentDate = shipment.DateProcess,
                ShipmentCode = shipment.Code,
                BranchId = shipment.BranchId,
                DestCityId = shipment.DestCityId,
                DestCity = shipment.DestCityId > 0 ? new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(shipment.DestCityId, "id", EnumSqlOperator.Equals)).Name : "",
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
                StateChange2 = EnumStateChange.Insert.ToString()
            };

            if (cons != null)
            {
                cons.Add(detail);
                GridManifest.DataSource = cons;

                ManifestView.RefreshData();
                ManifestView.FocusedRowHandle = ManifestView.RowCount - 1;
            }
        }

        private void FormLoad(object sender, EventArgs e)
        {
            EnableBtnSearch = true;
            EnableBtnPrint = false;
            EnableBtnPrintPreview = false;

            lkpVendor.LookupPopup = new VendorPopup();
            lkpVendor.AutoCompleteDataManager = new VendorDataManager();
            lkpVendor.AutoCompleteDisplayFormater = model => ((VendorModel)model).Name;
            lkpVendor.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("name.StartsWith(@0)", s);
        }

        protected override bool ValidateForm()
        {
            if (lkpVendor.Value == null)
            {
                lkpVendor.Focus();
                return false;
            }

            return true;
        }

        protected override void PopulateForm(ManifestVendorModel model)
        {
            ClearForm();
            if (model == null) return;

            DeletedRows = new List<int>();
            EnableBtnPrint = true;
            EnableBtnPrintPreview = true;

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;
            lkpVendor.Enabled = false;
            lkpVendor.Properties.Buttons[0].Enabled = false;

            ToolbarCode = model.Code;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = model.DateProcess.ToString();
            lkpVendor.DefaultValue = new IListParameter[] { WhereTerm.Default(model.VendorId, "id", EnumSqlOperator.Equals) };

            var details =
                new ManifestVendorDetailDataManager().Get<ManifestVendorDetailModel>(WhereTerm.Default(model.Id,
                    "manifest_vendor_id", EnumSqlOperator.Equals));

            GridManifest.DataSource = details;
            //ConsolidationView.RefreshData();
            tsBaseTxt_Code.Focus();

            EnabledForm(false);
        }

        protected override ManifestVendorModel PopulateModel(ManifestVendorModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.BranchId = BaseControl.BranchId;

            model.VendorId = (int)lkpVendor.Value;

            if (model.Id == 0)
            {
                model.Code = GetCode("manifest-vendor", tbxDate.Value);
                model.CreatedPc = Environment.MachineName;
            }
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override ManifestVendorModel Find(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm)) tsBaseTxt_Code.Text = searchTerm;
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<ManifestVendorModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as ManifestVendorModel;

            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }

        private void PrintPreview(object sender, EventArgs e)
        {
            var print = new ManifestVendorPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = new ManifestVendorDetailDataManager().Get<ManifestVendorDetailModel>(WhereTerm.Default(CurrentModel.Id, "manifest_vendor_id", EnumSqlOperator.Equals));
                var curmodel = CurrentModel as ManifestVendorModel;

                var vendor = new VendorDataManager().GetFirst<VendorModel>(WhereTerm.Default(curmodel.VendorId, "id"));
                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "Code",
                    Value = ((ManifestVendorModel)CurrentModel).Code,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Tanggal",
                    Value = ((ManifestVendorModel)CurrentModel).DateProcess,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "VendorName",
                    Value = vendor.Name,
                    Visible = false
                });

                if (BaseControl.UserId != null)
                {
                    var user = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)BaseControl.UserId, "user_id", EnumSqlOperator.Equals));
                    print.Parameters.Add(new Parameter
                    {
                        Name = "Printed",
                        Value = string.Format("{0} ({1}) {2}", user.Name, user.Code, DateTime.Now.ToString("d-M-yyyy HH:mm")),
                        Visible = false
                    });
                }

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
            var print = new ManifestPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = new ManifestVendorDetailDataManager().Get<ManifestVendorDetailModel>(WhereTerm.Default(CurrentModel.Id, "manifest_vendor_id", EnumSqlOperator.Equals));
                var curmodel = CurrentModel as ManifestVendorModel;

                var vendor = new VendorDataManager().GetFirst<VendorModel>(WhereTerm.Default(curmodel.VendorId, "id"));
                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "Code",
                    Value = ((ManifestVendorModel)CurrentModel).Code,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Tanggal",
                    Value = ((ManifestVendorModel)CurrentModel).DateProcess,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "VendorName",
                    Value = vendor.Name,
                    Visible = false
                });

                if (BaseControl.UserId != null)
                {
                    var user = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)BaseControl.UserId, "user_id", EnumSqlOperator.Equals));
                    print.Parameters.Add(new Parameter
                    {
                        Name = "Printed",
                        Value = string.Format("{0} ({1}) {2}", user.Name, user.Code, DateTime.Now.ToString("d-M-yyyy HH:mm")),
                        Visible = false
                    });
                }

                print.CreateDocument();

                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                };
                printTool.Print();
            }
        }
    }
}