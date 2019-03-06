using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraReports.Parameters;
using SISCO.App.Franchise;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Billing.Popup;
using SISCO.Presentation.Billing.Reports;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.CustomerService.Forms;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Billing.Forms
{
    public partial class FranchiseSalesInvoiceForm : BaseCrudForm<FranchiseInvoiceModel, FranchiseInvoiceDataManager>//BaseToolbarForm//
    {
        public FranchiseSalesInvoiceForm()
        {
            InitializeComponent();
            form = this;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            EnableBtnSearch = true;
            SearchPopup = new FranchiseSalesInvoicePopup();
            VisibleBtnPdf = true;
            EnableBtnPdf = false;

            var payment = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default("CREDIT", "name", EnumSqlOperator.Equals));
            lkpFranchise.LookupPopup =
                new FranshicePopup(new IListParameter[]
                {
                    WhereTerm.Default(payment.Id, "payment_method_id", EnumSqlOperator.Equals)
                });
            lkpFranchise.AutoCompleteDataManager = new FranchiseDataManager();
            lkpFranchise.AutoCompleteDisplayFormater = model => ((FranchiseModel)model).Code + " - " + ((FranchiseModel)model).Name;
            lkpFranchise.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND payment_method_id = @1", s, payment.Id);

            btnGetPod.Click += GetPOD;
            tbxMaterai.Leave += (o, asr) => GrandTotal();
            lkpFranchise.Leave += InvoicedTo;
            tsBaseBtn_Pdf.Click += CreateInvoicePDF;
            btnCancel.Click += CancelInvoice;

            InvoiceView.CustomColumnDisplayText += NumberGrid;
            GridInvoice.DoubleClick += (s, args) => OpenRelatedForm(InvoiceView, new TrackingViewForm(), "ShipmentCode");
            btnExcel.Click += (s, args) => ExportExcel(GridInvoice);
            btnDeletePod.Click += DeletePOD;
        }

        private void DeletePOD(object sender, EventArgs e)
        {
            if (InvoiceView.SelectedRowsCount == 0)
            {
                MessageBox.Show("Silakan pilih salah satu POD untuk di delete");
                return;
            }

            var dialog = MessageForm.Ask(form, "Remove Shipment", "Anda yakin akan menghapus POD tersebut dari invoice ini?");
            if (dialog == DialogResult.Yes) InvoiceView.DeleteSelectedRows();
        }

        private void CancelInvoice(object sender, EventArgs e)
        {
            var dialog = MessageForm.Ask(form, "Invoice Cancellation", "Anda yakin akan membatalkan invoice ini?");
            cbxCancelled.Checked = true;
            if (dialog == DialogResult.Yes)
            {
                var model = CurrentModel as FranchiseInvoiceModel;
                model.Cancelled = true;
                model.Modifiedby = BaseControl.UserLogin;
                model.Modifieddate = DateTime.Now;
                model.ModifiedPc = Environment.MachineName;

                new FranchiseInvoiceDataManager().Update<FranchiseInvoiceModel>(model);
                var details = GridInvoice.DataSource as List<FranchiseInvoiceListModel>;
                var ids = details.Select(d => d.ShipmentId.ToString()).ToArray();

                new FranchiseInvoiceListDataManager().CancellationInvoice(ids, BaseControl.UserLogin);
                PerformFind();
            }
        }

        private void CreateInvoicePDF(object sender, EventArgs e)
        {
            if (!((FranchiseInvoiceModel)CurrentModel).Printed)
            {
                var confirm = MessageForm.Ask(form, "Print Invoice", "Apakah anda akan melanjutkan proses export invoice ke PDF? Jika iya maka data di invoice tidak dapat diubah kembali.");
                if (confirm == DialogResult.Yes)
                {
                    ((FranchiseInvoiceModel)CurrentModel).Printed = true;
                    cbxPrinted.Checked = true;

                    Save();
                    PerformFind();
                }
                else return;
            }

            var salesInvoice = CurrentModel as FranchiseInvoiceModel;
            var franchise = new FranchiseDataManager().GetFirst<FranchiseModel>(WhereTerm.Default(salesInvoice.FranchiseId, "id"));
            var shipments = GridInvoice.DataSource as List<FranchiseInvoiceListModel>;
            var printout = new FranchiseInvoicePDF
            {
                DataSource = shipments,
                Parameters =
                        {
                            new Parameter
                            {
                                Name = "FranchiseSalesInvoice",
                                Value = salesInvoice
                            },
                            new Parameter
                            {
                                Name = "Franchise",
                                Value = franchise
                            },
                            new Parameter
                            {
                                Name = "OtherFee",
                                Value = (from a in shipments select a.OtherFee).Sum()
                            },
                            new Parameter
                            {
                                Name = "RaMateraiFee",
                                Value = tbxMaterai.Value
                            },
                            new Parameter
                            {
                                Name = "PackingInsuranceFee",
                                Value = (from a in shipments select a.InsuranceFee).Sum()
                            },
                            new Parameter
                            {
                                Name = "GrandTotal",
                                Value = tbxGrandTotal.Value
                            }
                        }
            };

            using (var dialog = new SaveFileDialog())
            {
                dialog.FileName = string.Format("invoicefcs-{0}-{1}{2}", salesInvoice.Code.Replace(" ", "_"), DateTime.Now.ToString("yyyyMMddHHmm"), ".pdf");
                dialog.Filter = @"PDF files |*.pdf|All files (*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    printout.ExportToPdf(dialog.FileName);
                    if (File.Exists(dialog.FileName))
                    {
                        System.Diagnostics.Process.Start("explorer.exe", @"/select,""" + dialog.FileName + "\"");
                    }
                }
            }
        }

        private IEnumerable<FranchiseInvoiceModel> GetReceiptPrintDataSource()
        {
            var model = CurrentModel as FranchiseInvoiceModel;
            return new List<FranchiseInvoiceModel>
            {
                model
            };
        }

        private void InvoicedTo(object sender, EventArgs e)
        {
            if (lkpFranchise.Value != null)
            {
                var franchise = new FranchiseDataManager().GetFirst<FranchiseModel>(WhereTerm.Default((int)lkpFranchise.Value, "id"));
                tbxInvoiceTo.Text = franchise.Name;
                tbxDueDate.DateTime = DateTime.Now.AddDays(franchise.Credit);
            }
        }

        private void GetPOD(object sender, EventArgs e)
        {
            if (lkpFranchise.Value == null)
            {
                MessageBox.Show("Silakan pilih franchise untuk membuat Invoice");
                lkpFranchise.Focus();
                return;
            }

            GridInvoice.DataSource = new FranchiseInvoiceDataManager().GetUninvoiced(new IListParameter[]
                {
                    WhereTerm.Default(false, "voided"),
                    WhereTerm.Default(0, "invoiced", EnumSqlOperator.Equals),
                    WhereTerm.Default((int) lkpFranchise.Value, "franchise_id"),
                    WhereTerm.Default(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0), "date_process", EnumSqlOperator.LessThan)
                });
            InvoiceView.RefreshData();

            var details = GridInvoice.DataSource as List<FranchiseInvoiceListModel>;
            tbxTotalInvoice.SetValue(details.Sum(d => d.TotalInvoice));
            tbxMaterai.Focus();

            GrandTotal();
        }

        private void GrandTotal()
        {
            tbxGrandTotal.SetValue(tbxTotalInvoice.Value + tbxMaterai.Value);
        }

        protected override void BeforeNew()
        {
            ClearForm();
            EnabledForm(true);

            tbxDate.DateTime = DateTime.Now;
            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            tbxTotalInvoice.Enabled = false;
            tbxGrandTotal.Enabled = false;
            btnGetPod.Enabled = true;
            btnCancel.Enabled = false;
            btnExcel.Enabled = false;

            EnableBtnPdf = false;
            lkpFranchise.Focus();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return false;
            }

            if (lkpFranchise.Value == null)
            {
                lkpFranchise.Focus();
                return false;
            }

            if (tbxDueDate.Text == "")
            {
                tbxDueDate.Focus();
                return false;
            }

            if (InvoiceView.RowCount == 0)
            {
                btnGetPod.Focus();
                return false;
            }

            return true;
        }

        protected override void PopulateForm(FranchiseInvoiceModel model)
        {
            ClearForm();
            EnabledForm(true);

            if (model == null) return;

            tbxTotalInvoice.Enabled = false;
            tbxGrandTotal.Enabled = false;
            btnGetPod.Enabled = false;
            btnCancel.Enabled = true;
            btnDeletePod.Enabled = true;
            btnExcel.Enabled = true;

            EnableBtnPdf = true;

            tsBaseTxt_Code.Text = model.Code;
            tbxDate.DateTime = model.DateProcess;
            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            lkpFranchise.DefaultValue = new IListParameter[] { WhereTerm.Default(model.FranchiseId, "id") };
            lkpFranchise.Enabled = false;
            lkpFranchise.Properties.Buttons[0].Enabled = false;

            tbxInvoiceTo.Text = model.InvoicedTo;
            tbxDueDate.DateTime = model.DueDate;
            tbxDescription1.Text = model.Description1;
            tbxDescription2.Text = model.Description2;
            tbxDescription3.Text = model.Description3;
            tbxTotalInvoice.SetValue(model.TotalInvoice);
            tbxMaterai.SetValue(model.Materai);
            tbxGrandTotal.SetValue(model.Total);

            cbxPrinted.Checked = model.Printed;
            cbxCancelled.Checked = model.Cancelled;

            GridInvoice.DataSource = new FranchiseInvoiceListDataManager().Get<FranchiseInvoiceListModel>(WhereTerm.Default(model.Id, "franchise_invoice_id"));

            if (model.Cancelled)
            {
                EnabledForm(false);
                EnableBtnPdf = false;
                btnCancel.Enabled = false;
                btnDeletePod.Enabled = false;
                btnExcel.Enabled = false;
            }

            if (model.Printed)
            {
                EnabledForm(false);
                btnDeletePod.Enabled = false;
            }
        }

        protected override FranchiseInvoiceModel PopulateModel(FranchiseInvoiceModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.FranchiseId = (int) lkpFranchise.Value;
            model.BranchId = BaseControl.BranchId;
            model.InvoicedTo = tbxInvoiceTo.Text;
            model.DueDate = tbxDueDate.DateTime;
            model.Description1 = tbxDescription1.Text;
            model.Description2 = tbxDescription2.Text;
            model.Description3 = tbxDescription3.Text;
            model.Materai = tbxMaterai.Value;
            model.TotalInvoice = tbxTotalInvoice.Value;
            model.Total = tbxGrandTotal.Value;

            if (model.Id == 0)
            {
                model.Code = new FranchiseInvoiceDataManager().GenerateReceipt();
                model.CreatedPc = Environment.MachineName;
            }
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            for (var i = 0; i < InvoiceView.RowCount; i++)
            {
                var state = InvoiceView.GetRowCellValue(i, InvoiceView.Columns["StateChange"]).ToString();
                var detail = new FranchiseInvoiceListModel();

                if (state == EnumStateChange.Insert.ToString())
                {
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.FranchiseInvoiceId = CurrentModel.Id;
                    detail.ShipmentId = (int) InvoiceView.GetRowCellValue(i, InvoiceView.Columns["ShipmentId"]);
                    detail.ShipmentCode = InvoiceView.GetRowCellValue(i, InvoiceView.Columns["ShipmentCode"]).ToString();
                    detail.ShipmentDate = (DateTime) InvoiceView.GetRowCellValue(i, InvoiceView.Columns["ShipmentDate"]);
                    detail.DestCityId = (int) InvoiceView.GetRowCellValue(i, InvoiceView.Columns["DestCityId"]);
                    detail.TotalPieces = (short) InvoiceView.GetRowCellValue(i, InvoiceView.Columns["TotalPieces"]);
                    detail.TotalCw = (decimal)InvoiceView.GetRowCellValue(i, InvoiceView.Columns["TotalCw"]);
                    detail.ServiceTypeId = (int)InvoiceView.GetRowCellValue(i, InvoiceView.Columns["ServiceTypeId"]);
                    detail.InsuranceFee = (decimal)InvoiceView.GetRowCellValue(i, InvoiceView.Columns["InsuranceFee"]);
                    detail.OtherFee = (decimal)InvoiceView.GetRowCellValue(i, InvoiceView.Columns["OtherFee"]);
                    detail.TotalSales = (decimal)InvoiceView.GetRowCellValue(i, InvoiceView.Columns["TotalSales"]);
                    detail.Ppn = (decimal)InvoiceView.GetRowCellValue(i, InvoiceView.Columns["Ppn"]);
                    detail.Commission = (decimal)InvoiceView.GetRowCellValue(i, InvoiceView.Columns["Commission"]);
                    detail.Pph23 = (decimal)InvoiceView.GetRowCellValue(i, InvoiceView.Columns["Pph23"]);
                    detail.NetCommission = (decimal)InvoiceView.GetRowCellValue(i, InvoiceView.Columns["NetCommission"]);
                    detail.TotalInvoice = (decimal)InvoiceView.GetRowCellValue(i, InvoiceView.Columns["TotalInvoice"]);
                    detail.Createdby = BaseControl.UserLogin;
                    detail.Createddate = DateTime.Now;

                    new FranchiseInvoiceListDataManager().Save<FranchiseInvoiceListModel>(detail);

                    var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(detail.ShipmentId, "id"));
                    shipment.Invoiced = 1;
                    shipment.InvoiceId = detail.Id;
                    shipment.InvoiceRef = ((FranchiseInvoiceModel)CurrentModel).Code;
                    shipment.RefNumber = ((FranchiseInvoiceModel)CurrentModel).Code;
                    shipment.Modifiedby = BaseControl.UserLogin;
                    shipment.Modifieddate = DateTime.Now;

                    new ShipmentDataManager().Update<ShipmentModel>(shipment);
                }
            }
        }

        protected override void AfterSave()
        {
            tsBaseTxt_Code.Text = ((FranchiseInvoiceModel)CurrentModel).Code;
            base.AfterSave();
        }

        protected override FranchiseInvoiceModel Find(string searchTerm)
        {
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<FranchiseInvoiceModel>(param);
            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as FranchiseInvoiceModel;
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

            var model = CurrentModel as FranchiseInvoiceModel;
            if (model != null && model.Cancelled && model.Printed)
            {
                tsBaseBtn_Save.Enabled = false;
                NavigationMenu.SaveStrip.Enabled = false;
            }
        }
    }
}