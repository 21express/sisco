using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraPrinting.Native;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.ComponentRepositories;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Billing.Forms
{
    public partial class SelectShipmentForInvoiceForm : Form
    {
        public SelectShipmentForInvoiceForm()
        {
            InitializeComponent();

            lkpDestinationCity.LookupPopup = new CityPopup();
            lkpDestinationCity.AutoCompleteDataManager = new CityDataManager();
            lkpDestinationCity.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpDestinationCity.AutoCompleteWheretermFormater = s => new IListParameter[]
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

            lkpPaymentMethod.LookupPopup = new PaymentMethodPopup();
            lkpPaymentMethod.AutoCompleteDataManager = new PaymentMethodDataManager();
            lkpPaymentMethod.AutoCompleteDisplayFormater = model => ((PaymentMethodModel)model).Name;
            lkpPaymentMethod.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            Load += SelectShipmentForInvoiceForm_Load;
        }

        void SelectShipmentForInvoiceForm_Load(object sender, EventArgs e)
        {
            Shipments = new BindingList<ShipmentModel>();

            grid.DataSource = Shipments;

            Shipments.ListChanged += (o, args) =>
            {
                txtTotalRecords.Text = Shipments.Count.ToString(CultureInfo.InvariantCulture);
            };

            //gridColumn4.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn4.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn4.RealColumnEdit).Mask.EditMask = @"###,0";
            //((TextEditRepo)gridColumn4.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            //gridColumn5.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn5.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn5.RealColumnEdit).Mask.EditMask = @"###,0.0";
            //((TextEditRepo)gridColumn5.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            //gridColumn6.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn6.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn6.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn6.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            //gridColumn7.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn7.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn7.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn7.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            //gridColumn8.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn8.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn8.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn8.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            //gridColumn9.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn9.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn9.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn9.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            //gridColumn10.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn10.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn10.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn10.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            //gridColumn11.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn11.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn11.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn11.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            //gridColumn12.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn12.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn12.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn12.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            //gridColumn13.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn13.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn13.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn13.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            //gridColumn14.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn14.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn14.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn14.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
        }

        public DateTime FilterDateFrom {
            set { txtDateFrom.DateTime = value; }
            get { return txtDateFrom.DateTime; }
        }
        public DateTime FilterDateTo {
            set { txtDateTo.DateTime = value; }
            get { return txtDateTo.DateTime; }
        }
        public int? FilterDestCityId
        {
            set
            {
                if (value != null && value != 0)
                {
                    lkpDestinationCity.DefaultValue = new IListParameter[] { WhereTerm.Default((int)value, "id") };
                }
            }
            get { return lkpDestinationCity.Value; }
        }
        public string FilterDestCityName
        {
            get { return lkpDestinationCity.Value != null ? lkpDestinationCity.Text : string.Empty; }
        }
        public int? FilterPackageTypeId
        {
            set
            {
                if (value != null && value != 0)
                {
                    lkpPackageType.DefaultValue = new IListParameter[] {WhereTerm.Default((int) value, "id")};
                }
            }
            get { return lkpPackageType.Value; }
        }
        public int? FilterPaymentMethodId
        {
            set
            {
                if (value != null && value != 0)
                {
                    lkpPaymentMethod.DefaultValue = new IListParameter[] {WhereTerm.Default((int) value, "id")};
                }
            }
            get { return lkpPaymentMethod.Value; }
        }
        public string FilterPeriod
        {
            set { txtPeriod.Text = value; }
            get { return txtPeriod.Text; }
        }
        public int FilterIsPersonal { get; set; }
        public int FilterCustomerId { get; set; }
        public int[] FilterExcludeShipmentIds { get; set; }

        public BindingList<ShipmentModel> Shipments;

        public IEnumerable<ShipmentModel> SelectedShipmentList {
            get
            {
                var selectedRows = gridView.GetSelectedRows();

                return Shipments.Where((row, i) => Array.Exists(selectedRows, x => x == i));
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            Shipments.RaiseListChangedEvents = false;
            Shipments.Clear();

            var whereClauses = new List<IListParameter>();

            var fromdate = txtDateFrom.DateTime;
            var todate = txtDateTo.DateTime;

            if (txtDateFrom.DateTime != DateTime.MinValue)
            {
                whereClauses.Add(WhereTerm.Default(new DateTime(fromdate.Year, fromdate.Month, fromdate.Day, 0, 0, 0), "date_process", EnumSqlOperator.GreatThanEqual));
            }
            if (txtDateTo.DateTime != DateTime.MinValue)
            {
                whereClauses.Add(WhereTerm.Default(new DateTime(todate.Year, todate.Month, todate.Day, 23, 59, 59), "date_process", EnumSqlOperator.LesThanEqual));
            }
            if (lkpDestinationCity.Value != null)
            {
                whereClauses.Add(WhereTerm.Default((int)lkpDestinationCity.Value, "dest_city_id"));
            }
            if (lkpPackageType.Value != null)
            {
                whereClauses.Add(WhereTerm.Default((int)lkpPackageType.Value, "package_type_id"));
            }
            if (lkpPaymentMethod.Value != null)
            {
                whereClauses.Add(WhereTerm.Default((int)lkpPaymentMethod.Value, "payment_method_id"));
            }

            whereClauses.Add(WhereTerm.Default(FilterIsPersonal == 1, "personal"));
            whereClauses.Add(WhereTerm.Default(true, "posted"));
            whereClauses.Add(WhereTerm.Default(0, "invoiced"));
            whereClauses.Add(WhereTerm.Default(false, "voided"));

            new ShipmentDataManager()
                .GetGetCreditCollectOnlyExclude<ShipmentModel>(FilterCustomerId, whereClauses.ToArray(), FilterExcludeShipmentIds)
                .OrderBy(r => r.DateProcess.Date).ThenBy(r => r.Code)
                .ForEach(row => Shipments.Add(row));

            txtTotalRecords.Text = Shipments.Count.ToString("#,0");

            Shipments.RaiseListChangedEvents = true;
            Shipments.ResetBindings();

            gridView.SelectAll();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Shipments.Clear();
            Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            gridView.SelectAll();
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            gridView.ClearSelection();
        }
    }
}