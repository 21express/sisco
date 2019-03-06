
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Annotations;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Billing.Forms
{
    public partial class ViewShipmentListForm : BaseMasterForm<ShipmentModel, ViewShipmentListForm.ShipmentDataRow, ShipmentDataManager>//BaseForm//
    {
        public class ShipmentDataRow : ShipmentModel, INotifyPropertyChanged
        {
            public PaymentMethodDataManager PaymentMethodDataManager { get; set; }
            public PackageTypeDataManager PackageTypeDataManager { get; set; }

            private string _paymentMethod;
            public new string PaymentMethod
            {
                get
                {
                    if (string.IsNullOrEmpty(_paymentMethod) && PaymentMethodId != 0)
                    {
                        var model = PaymentMethodDataManager.GetFirst<PaymentMethodModel>(WhereTerm.Default(PaymentMethodId, "id"));
                        _paymentMethod = string.Format("{0}", model.Name);
                    }
                    return _paymentMethod;
                }
                set { _paymentMethod = value; }
            }
            private string _packageType;
            public new string PackageType
            {
                get
                {
                    if (string.IsNullOrEmpty(_packageType) && PackageTypeId != 0)
                    {
                        var model = PackageTypeDataManager.GetFirst<PackageTypeModel>(WhereTerm.Default(PackageTypeId, "id"));
                        _packageType = model != null ? string.Format("{0}", model.Name) : "";
                    }
                    return _packageType;
                }
                set { _packageType = value; }
            }

            public bool PodSentStatus
            {
                get { return PodSent == 1; }
            }

            public bool PodReceivedStatus
            {
                get { return PodReceived == 1; }
            }

            public bool PodReturnedStatus
            {
                get { return PodReturned == 1; }
            }

            public bool InvoicedStatus
            {
                get { return Invoiced == 1; }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }

            internal void NotifyUpdate(string propertyName)
            {
                OnPropertyChanged(propertyName);

                switch (propertyName)
                {
                    case "PaymentMethodId":
                        PaymentMethod = null;
                        NotifyUpdate("PaymentMethod");
                        break;
                    case "PackageTypeId":
                        base.PackageType = null;
                        NotifyUpdate("PackageType");
                        break;
                }
            }
        }

        public PaymentMethodDataManager PaymentMethodDataManager { get; set; }
        public PackageTypeDataManager PackageTypeDataManager { get; set; }

        public ViewShipmentListForm()
        {
            InitializeComponent();
            form = this;

            PaymentMethodDataManager = new PaymentMethodDataManager();
            PackageTypeDataManager = new PackageTypeDataManager();

            MainModelTransformFunc = model =>
            {
                var row = ConvertModel<ShipmentModel, ShipmentDataRow>(model);

                row.PaymentMethodDataManager = PaymentMethodDataManager;
                row.PackageTypeDataManager = PackageTypeDataManager;

                return row;
            };

            PageLimit = 99999;

            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            Init();
            // Save ke Excel
            btnSave.Click += (sender, args) => ExportExcel(grid);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            grid.BeginInvoke(new MethodInvoker(() => lkpCustomer.Focus()));
        }

        public override void SelectRow(object sender, EventArgs e)
        {
            //
        }

        public override void Init()
        {
            CtlClearButton = null;
            CtlGridControl = grid;
            CtlGridView = gridView;
            CtlSearchButton = btnSearch;

            base.Init();
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            lkpCustomer.LookupPopup = new CustomerPopup();
            lkpCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpCustomer.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);

            lkpDestCity.LookupPopup = new CityPopup();
            lkpDestCity.AutoCompleteDataManager = new CityDataManager();
            lkpDestCity.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpDestCity.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            lkpPackageType.LookupPopup = new PackageTypePopup();
            lkpPackageType.AutoCompleteDataManager = new PackageTypeDataManager();
            lkpPackageType.AutoCompleteDisplayFormater = model => ((PackageTypeModel)model).Name;
            lkpPackageType.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            var now = DateTime.Now;
            txtDateFrom.DateTime = new DateTime(now.Year, now.Month, 1);
            txtDateTo.DateTime = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));

            gridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.Appearance.FocusedCell.Options.UseForeColor = false;
            gridView.OptionsNavigation.UseTabKey = false;
            gridView.OptionsBehavior.FocusLeaveOnTab = true;
            
            gridView.RowCellStyle += (o, args) =>
            {
                if (args.RowHandle < 0) return;

                if (((bool)gridView.GetRowCellValue(args.RowHandle, "Cancelled")))
                {
                    args.Appearance.ForeColor = Color.Green;
                }
                else if (((int)gridView.GetRowCellValue(args.RowHandle, "Invoiced")) == 1)
                {
                    args.Appearance.ForeColor = Color.Blue;
                }
                else if (((bool)gridView.GetRowCellValue(args.RowHandle, "Posted")))
                {
                    args.Appearance.ForeColor = Color.Black;
                }
                else
                {
                    args.Appearance.ForeColor = Color.Red;
                }
            };


            grid.DoubleClick += GridOnDoubleClick;
            grid.KeyPress += (o, args) =>
            {
                if (args.KeyChar == 13)
                {
                    GridOnDoubleClick(o, args);
                }
            };

            txtDateFrom.FieldLabel = "Date From";
            txtDateFrom.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtDateTo.FieldLabel = "Date To";
            txtDateTo.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpCustomer.FieldLabel = "Customer";
            lkpCustomer.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            ActiveControl = lkpCustomer;
            lkpCustomer.Focus();
        }

        private void GridOnDoubleClick(object o, EventArgs args)
        {
            var rows = gridView.GetSelectedRows();

            if (rows.Length > 0)
            {
                BaseControl.OpenRelatedForm(new ValidateShipmentOrderForm(), gridView.GetRowCellValue(rows[0], "Code").ToString(), CallingCommand);
            }
        }

        protected override bool ValidateForm()
        {
            var errors = ComponentValidationHelper.Validate(txtDateFrom, txtDateTo, lkpCustomer);

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors));
                return false;
            }

            return true;
        }

        protected override void PopulateForm(ShipmentModel model)
        {
            //;
        }

        protected override ShipmentModel PopulateModel(ShipmentModel model)
        {
            return model;
        }

        protected override IListParameter[] Filter()
        {
            var p = new List<IListParameter>();
            p.Add(WhereTerm.Default(false, "voided"));

            var fromdate = txtDateFrom.DateTime;
            var todate = txtDateTo.DateTime;

            if (txtDateFrom.DateTime != DateTime.MinValue) p.Add(WhereTerm.Default(new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0), "date_process", EnumSqlOperator.GreatThanEqual));
            if (txtDateTo.DateTime != DateTime.MinValue) p.Add(WhereTerm.Default(new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59), "date_process", EnumSqlOperator.LesThanEqual));

            if (lkpDestCity.Value != null) p.Add(WhereTerm.Default((int)lkpDestCity.Value, "dest_city_id"));
            if (lkpPackageType.Value != null) p.Add(WhereTerm.Default((int) lkpPackageType.Value, "package_type_id"));

            if (rdoValidatedYes.Checked)
            {
                p.Add(WhereTerm.Default(true, "posted"));
            }
            else if (rdoValidatedNo.Checked)
            {
                p.Add(WhereTerm.Default(false, "posted"));
            }

            if (rdoCustomerTypePersonal.Checked)
            {
                p.Add(WhereTerm.Default(true, "personal"));
            }
            else if (rdoCustomerTypeCorporate.Checked)
            {
                p.Add(WhereTerm.Default(false, "personal"));
            }

            return p.ToArray();
        }

        protected override IEnumerable<T> GetFromDataManager<T>(Paging paging, out int count, IListParameter[] parameters)
        {
            return ((ShipmentDataManager)DataManager).GetByCustomerOrCustomerCollect(lkpCustomer.Value, paging, out count, parameters).OrderBy(r => r.DateProcess.Date).ThenBy(r => r.Code).Cast<T>();
        }

        private void grid_Click(object sender, EventArgs e)
        {

        }
    }
}
