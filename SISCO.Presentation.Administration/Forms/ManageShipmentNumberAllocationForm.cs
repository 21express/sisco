using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraReports.Parameters;
using SISCO.App.Administration;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Administration.Popup;
using SISCO.Presentation.Administration.Reports;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Reports;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Franchise.Popup;
using SISCO.App.Franchise;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Administration.Forms
{
    public partial class ManageShipmentNumberAllocationForm : BaseCrudForm<ShipmentAllocationModel, ShipmentNumberAllocationDataManager>//BaseToolbarForm//
    {
        public class PrintBarcode
        {
            public string Code { get; set; }
            public string BranchName { get; set; }
            public string CustomerCode { get; set; }
            public string CustomerName { get; set; }
            public string ShipperAddress { get; set; }
            public string ShipperPhone { get; set; }
        }

        public ManageShipmentNumberAllocationForm()
        {
            InitializeComponent();
            form = this;

            btnRecount.Click += BtnRecountOnClick;
            btnPrintPOD.Click += BtnPrintPodOnClick;

            tbxStart.Leave += (a, e) =>
            {
                if (tbxStart.Value < txtStart.Value) tbxStart.SetValue(txtStart.Value);
                if (tbxStart.Value > txtEnd.Value) tbxStart.SetValue(txtEnd.Value);
            };

            tbxEnd.Leave += (a, e) =>
            {
                if (tbxEnd.Value > txtEnd.Value) tbxEnd.SetValue(txtEnd.Value);
                if (tbxEnd.Value < txtStart.Value) tbxEnd.SetValue(txtStart.Value);
            };

            btnPrintBarcode.Click += PrintLabelBarcode;

            rbCustomer.CheckedChanged += RadioChanged;
            rbFranchise.CheckedChanged += RadioChanged;
            rbDropPoint.CheckedChanged += RadioChanged;
        }

        private void RadioChanged(object sender, EventArgs e)
        {
            lkpCustomer.Text = string.Empty;
            lkpCustomer.Value = null;
            lkpFranchise.Text = string.Empty;
            lkpFranchise.Value = null;
            lkpDropPoint.Text = string.Empty;
            lkpDropPoint.Value = null;

            if (rbCustomer.Checked)
            {
                lkpCustomer.Enabled = true;
                lkpCustomer.Properties.Buttons[0].Enabled = true;
                if(!_isPopulatingForm) lkpCustomer.Focus();
                lkpFranchise.Enabled = false;
                lkpFranchise.Properties.Buttons[0].Enabled = false;
                lkpDropPoint.Enabled = false;
                lkpDropPoint.Properties.Buttons[0].Enabled = false;
            }

            if (rbFranchise.Checked)
            {
                lkpCustomer.Enabled = false;
                lkpCustomer.Properties.Buttons[0].Enabled = false;
                lkpFranchise.Enabled = true;
                lkpFranchise.Properties.Buttons[0].Enabled = true;
                if (!_isPopulatingForm) lkpFranchise.Focus();
                lkpDropPoint.Enabled = false;
                lkpDropPoint.Properties.Buttons[0].Enabled = false;
            }

            if (rbDropPoint.Checked)
            {
                lkpCustomer.Enabled = false;
                lkpCustomer.Properties.Buttons[0].Enabled = false;
                lkpFranchise.Enabled = false;
                lkpFranchise.Properties.Buttons[0].Enabled = false;
                lkpDropPoint.Enabled = true;
                lkpDropPoint.Properties.Buttons[0].Enabled = true;
                if (!_isPopulatingForm) lkpDropPoint.Focus();
            }
        }

        private void PrintLabelBarcode(object sender, EventArgs e)
        {
            var barcode = new List<PrintBarcode>();
            string customerCode = string.Empty;
            string customerName = string.Empty;
            string customerPhone = string.Empty;
            string customerAddress = string.Empty;

            if (lkpFranchise.Value != null)
            {
                var franchise = new FranchiseDataManager().GetFirst<FranchiseModel>(WhereTerm.Default((int)lkpFranchise.Value, "id"));
                if (franchise != null)
                {
                    customerCode = franchise.Code;
                    customerName = franchise.Name;
                    customerPhone = franchise.Phone;
                    customerAddress = franchise.Address;
                }
            }

            if (lkpCustomer.Value != null)
            {
                var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)lkpCustomer.Value, "id"));
                if (customer != null)
                {
                    customerCode = customer.Code;
                    customerName = customer.Name;
                    customerPhone = customer.Phone;
                    customerAddress = customer.Address;
                }
            }

            for(var i = tbxStart.Value; i <= tbxEnd.Value; i++)
            {
                if (!cbxPrintName.Checked)
                {
                    customerCode = string.Empty;
                    customerName = string.Empty;
                    customerAddress = string.Empty;
                    customerPhone = string.Empty;
                }

                barcode.Add(new PrintBarcode
                {
                    Code = Convert.ToInt64(i).ToString(),
                    BranchName = BaseControl.BranchCode,
                    CustomerCode = customerCode,
                    CustomerName = customerName,
                    ShipperAddress = customerAddress,
                    ShipperPhone = customerPhone
                });
            }

            var a = new BarcodeAllocation();
            a.DataSource = barcode;
            a.CreateDocument();

            var printTool = new ReportPrintTool(a);
            printTool.PrintingSystem.StartPrint += (o, args) =>
            {
                args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.Barcode;
            };
            printTool.Print();
        }

        protected override void BindDataSource<T>()
        {
            CurrentModel = LoadModel<T>(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
        }

        private void BtnPrintPodOnClick(object sender, EventArgs eventArgs)
        {
            var model = new ShipmentModel.ShipmentReportRow();
            if (lkpCustomer.Value != null)
            {
                using (var customerDm = new CustomerDataManager())
                {
                    var customer = customerDm.GetFirst<CustomerModel>(WhereTerm.Default(lkpCustomer.Value ?? 0, "id"));
                    if (customer != null)
                    {
                        model.CustomerCode = customer.Code;
                        model.CustomerName = customer.Name;

                        model.ShipperName = customer.Name;
                        model.ShipperPhone = customer.Phone;
                    }
                }

                model.ShipperAddress = txtAddress.Text;
            }

            if (lkpFranchise.Value != null)
            {
                var franchise = new FranchiseDataManager().GetFirst<FranchiseModel>(WhereTerm.Default((int)lkpFranchise.Value, "id"));
                if (franchise != null)
                {
                    model.CustomerCode = franchise.Code;
                }
            }

            if (lkpDropPoint.Value != null)
            {
                var dropPoint = new DropPointDataManager().GetFirst<DropPointModel>(WhereTerm.Default((int)lkpDropPoint.Value, "id"));
                if (dropPoint != null)
                {
                    model.CustomerCode = dropPoint.Code;
                }
            }

            var dataSource = new List<ShipmentModel.ShipmentReportRow>();

            for (var i = Convert.ToInt64(txtStart.Text); i <= Convert.ToInt64(txtEnd.Text); i++)
            {
                dataSource.Add(model);
            }

            if (chkPrintContinuos.Checked)
            {
                var printout = new ConsignmentNoteContinuous()
                {
                    DataSource = dataSource
                };

                printout.Print();
            }
            else
            {
                var printout = new ConsignmentNote
                {
                    DataSource = dataSource
                };

                printout.Print();
            }
        }

        private void BtnRecountOnClick(object sender, EventArgs eventArgs)
        {
            txtUsed.Text =
                ((ShipmentNumberAllocationDataManager) DataManager).GetAllocationUsedCount(CurrentModel as ShipmentAllocationModel)
                    .ToString(CultureInfo.InvariantCulture);
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            EnableBtnSearch = true;

            lkpCustomer.LookupPopup = new CustomerPopup(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            lkpCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpCustomer.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) and branch_id = @1", s, BaseControl.BranchId);

            lkpCustomer.TextChanged += (o, args) =>
            {
                if (lkpCustomer.Value != null)
                {
                    txtAddress.Text = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)lkpCustomer.Value, "id")).Address;
                }
            };

            lkpFranchise.LookupPopup = new FranchisePopup();
            lkpFranchise.AutoCompleteDataManager = new FranchiseDataManager();
            lkpFranchise.AutoCompleteDisplayFormater = model => ((FranchiseModel)model).Code + " - " + ((FranchiseModel)model).Name;
            lkpFranchise.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            lkpFranchise.TextChanged += (o, args) =>
            {
                if (lkpFranchise.Value != null)
                {
                    txtAddress.Text = new FranchiseDataManager().GetFirst<FranchiseModel>(WhereTerm.Default((int)lkpFranchise.Value, "id")).Address;
                }
            };

            lkpDropPoint.LookupPopup = new DropPointPopup();
            lkpDropPoint.AutoCompleteDataManager = new DropPointDataManager();
            lkpDropPoint.AutoCompleteDisplayFormater = model => ((DropPointModel)model).Code + " - " + ((DropPointModel)model).Name;
            lkpDropPoint.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            lkpDropPoint.TextChanged += (o, args) =>
            {
                if (lkpDropPoint.Value != null)
                {
                    txtAddress.Text = new DropPointDataManager().GetFirst<DropPointModel>(WhereTerm.Default((int)lkpDropPoint.Value, "id")).Address;
                }
            };

            txtDate.FieldLabel = "Date";
            txtDate.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            //lkpCustomer.FieldLabel = "Customer";
            //lkpCustomer.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtStart.FieldLabel = "Start";
            txtStart.Properties.Mask.EditMask = @"d";
            txtStart.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtEnd.FieldLabel = "End";
            txtEnd.Properties.Mask.EditMask = @"d";
            txtEnd.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            tbxStart.Properties.Mask.EditMask = @"d";
            tbxEnd.Properties.Mask.EditMask = @"d";

            txtStart.TextChanged += (o, args) => Recalculate();
            txtEnd.TextChanged += (o, args) => Recalculate();

            tsBaseBtn_Print.Click += (o, args) =>
            {
                var printout = GetPrintoutObject();
                printout.Print();
            };

            tsBaseBtn_PrintPreview.Click += (o, args) =>
            {
                var printout = GetPrintoutObject();
                printout.PrintPreview();
            };

            SearchPopup = new ShipmentNumberAllocationPopup();
        }

        private SerahTerimaPodPrintOut GetPrintoutObject()
        {
            var customerCode = "";
            var customerName = "";

            if (lkpCustomer.Value > 0)
            using (var customerDm = new CustomerDataManager())
            {
                var customer = customerDm.GetFirst<CustomerModel>(WhereTerm.Default(lkpCustomer.Value ?? 0, "id"));
                if (customer != null)
                {
                    customerCode = customer.Code;
                    customerName = customer.Name;
                }
            }

            if (lkpFranchise.Value > 0)
            using (var franchiseDm = new FranchiseDataManager())
            {
                var franchise = franchiseDm.GetFirst<FranchiseModel>(WhereTerm.Default((int)lkpFranchise.Value, "id"));
                if (franchise != null)
                {
                    customerCode = franchise.Code;
                    customerName = franchise.Name;
                }
            }

            var printout = new SerahTerimaPodPrintOut
            {
                Parameters =
                {
                    new Parameter
                    {
                        Name = "CustomerCode",
                        Value = customerCode
                    },
                    new Parameter
                    {
                        Name = "CustomerName",
                        Value = customerName
                    },
                    new Parameter
                    {
                        Name = "Address",
                        Value = txtAddress.Text
                    },
                    new Parameter
                    {
                        Name = "CodeStart",
                        Value = txtStart.Text
                    },
                    new Parameter
                    {
                        Name = "CodeEnd",
                        Value = txtEnd.Text
                    },
                    new Parameter
                    {
                        Name = "Count",
                        Value = txtCount.Text
                    },
                    new Parameter
                    {
                        Name = "DateProcess",
                        Value = txtDate.DateTime
                    },
                },
                DataSource = new List<object>
                {
                    "test"
                }
            };

            return printout;
        }

        private void Recalculate()
        {
            Decimal a;
            if (!Decimal.TryParse(txtStart.Text, out a) || !Decimal.TryParse(txtEnd.Text, out a)) return;

            txtCount.Text = (Decimal.Parse(txtEnd.Text) - Decimal.Parse(txtStart.Text) + 1).ToString(CultureInfo.InvariantCulture);
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            if (txtDate.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter a date");
                return false;
            }

            if (txtStart.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter the starting number");
                return false;
            }

            if (txtEnd.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter the ending number");
                return false;
            }

            if (txtStart.Text.Length != 12)
            {
                MessageBox.Show(@"Starting POD number must be of 12 digits");
                return false;
            }

            if (txtEnd.Text.Length != 12)
            {
                MessageBox.Show(@"Ending POD number must be of 12 digits");
                return false;
            }

            if (txtStart.Value < 0)
            {
                MessageBox.Show(@"Start nomor POD harus lebih besar dari 0");
                return false;
            }

            if (Decimal.Parse(txtCount.Text) <= 0)
            {
                MessageBox.Show(@"The ending number must be greater than the starting number");
                return false;
            }

            if (Decimal.Parse(txtCount.Text) <= 0)
            {
                MessageBox.Show(@"The ending number must be greater than the starting number");
                return false;
            }

            var result = ((ShipmentNumberAllocationDataManager) DataManager).CheckIsUsed(CurrentModel.Id, Convert.ToInt64(txtStart.Text), Convert.ToInt64(txtEnd.Text));
            if (result)
            {
                MessageBox.Show(@"Alokasi POD sudah pernah dipakai.");
                return false;
            }

            return true;
        }

        protected override void PopulateForm(ShipmentAllocationModel currentModel)
        {
            ClearForm();

            tsBaseTxt_Code.Text = currentModel.Id.ToString(CultureInfo.InvariantCulture);

            txtDate.DateTime = currentModel.AllocDate;
            if (currentModel.CustomerId != null)
            {
                rbCustomer.Checked = true;
                lkpCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default((int)currentModel.CustomerId, "id") };
                lkpFranchise.Enabled = false;
                lkpFranchise.Properties.Buttons[0].Enabled = false;
                lkpDropPoint.Enabled = false;
                lkpDropPoint.Properties.Buttons[0].Enabled = false;
            }
            
            if (currentModel.FranchiseId != null)
            {
                rbFranchise.Checked = true;
                lkpFranchise.DefaultValue = new IListParameter[] { WhereTerm.Default((int)currentModel.FranchiseId, "id") };
                lkpCustomer.Enabled = false;
                lkpCustomer.Properties.Buttons[0].Enabled = false;
                lkpDropPoint.Enabled = false;
                lkpDropPoint.Properties.Buttons[0].Enabled = false;
            }

            if (currentModel.DropPointId != null)
            {
                rbDropPoint.Checked = true;
                lkpDropPoint.DefaultValue = new IListParameter[] { WhereTerm.Default((int) currentModel.DropPointId, "id") };
                lkpCustomer.Enabled = false;
                lkpCustomer.Properties.Buttons[0].Enabled = false;
                lkpFranchise.Enabled = false;
                lkpFranchise.Properties.Buttons[0].Enabled = false;
            }

            txtAddress.Text = currentModel.CustomerAddress;
            txtStart.Text = currentModel.ShipmentCodeStart.ToString(CultureInfo.InvariantCulture);
            txtEnd.Text = currentModel.ShipmentCodeEnd.ToString(CultureInfo.InvariantCulture);
            txtCount.Text = currentModel.ShipmentCodeCount.ToString(CultureInfo.InvariantCulture);
            txtUsed.Text = currentModel.ShipmentCodeUsed.ToString(CultureInfo.InvariantCulture);

            using (var branchDm = new BranchDataManager())
            {
                var branch = branchDm.GetFirst<BranchModel>(WhereTerm.Default(currentModel.BranchId, "id"));
                chkPrintContinuos.Checked = branch.Code.Equals("JKT");
            }

            txtCount.Enabled = false;
            txtUsed.Enabled = false;

            pnlBarcode.Enabled = true;
            pnlBlanko.Enabled = true;

            tbxStart.Text = currentModel.ShipmentCodeStart.ToString(CultureInfo.InvariantCulture);
            tbxEnd.Text = currentModel.ShipmentCodeEnd.ToString(CultureInfo.InvariantCulture);
        }

        protected override ShipmentAllocationModel PopulateModel(ShipmentAllocationModel model)
        {
            model.AllocDate = txtDate.DateTime;
            model.CustomerName = lkpCustomer.Text;
            model.CustomerId = lkpCustomer.Value ?? null;
            model.FranchiseId = lkpFranchise.Value ?? null;
            model.DropPointId = lkpDropPoint.Value ?? null;
            model.CustomerAddress = txtAddress.Text;
            model.ShipmentCodeStart = Convert.ToInt64(txtStart.Text);
            model.ShipmentCodeEnd = Convert.ToInt64(txtEnd.Text);
            model.ShipmentCodeCount = Int32.Parse(txtCount.Text);
            model.ShipmentCodeUsed = Int32.Parse(txtUsed.Text);

            model.BranchId = BaseControl.BranchId;

            return model;
        }

        protected override ShipmentAllocationModel Find(string searchTerm)
        {
            return DataManager.GetFirst<ShipmentAllocationModel>(WhereTerm.Default(string.IsNullOrEmpty(searchTerm) ? 0 : Convert.ToInt32(searchTerm), "id"), WhereTerm.Default(BaseControl.BranchId, "branch_id"));
        }

        public override void Save()
        {
            if (lkpFranchise.Value == null && lkpCustomer.Value == null && lkpDropPoint.Value == null)
            {
                MessageBox.Show("Please enter a valid customer or franchise or drop point.", "Mandatory Field", MessageBoxButtons.OK);
                lkpCustomer.Focus();
                return;
            }

            base.Save();
        }

        protected override void AfterSave()
        {
            base.AfterSave();

            btnRecount.Enabled = true;

            ActiveControl = tsBaseTxt_Code.Control;
            tsBaseTxt_Code.Text = CurrentModel.Id.ToString(CultureInfo.InvariantCulture);
            PerformFind();
        }

        public override void New()
        {
            base.New();
            ClearForm();

            btnRecount.Enabled = false;
            txtUsed.Enabled = false;
            txtCount.Enabled = false;

            pnlBarcode.Enabled = false;
            pnlBlanko.Enabled = false;

            chkPrintContinuos.Checked = BaseControl.BranchCode == "JKT";

            txtStart.Text = @"0";
            txtEnd.Text = @"0";
            txtCount.Text = @"0";
            txtUsed.Text = @"0";

            PageLimit = 20;

            rbFranchise.Checked = true;
            rbCustomer.Checked = true;
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            _ClearForm(grpDetail);

            chkPrintContinuos.Checked = true;
            lkpCustomer.Focus();
            lkpCustomer.Select();

            txtDate.DateTime = DateTime.Now;
            txtDate.Focus();

            tsBaseTxt_Code.Clear();
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            if (TotalPage > 0)
            {
                tsBaseBtn_Print.Enabled = true;
                tsBaseBtn_PrintPreview.Enabled = true;
            }
        }
    }
}