using System;
using System.Collections.Generic;
using System.Linq.Dynamic;
using System.Windows.Forms;
using SISCO.Models;

namespace SISCO.Presentation.Operation.Popup
{
    public partial class BarcodeLookup : Form
    {
        public string SelectedBarcode { get; set; }
        private List<BarcodeList> DataSource { get; set; } 
        public BarcodeLookup(List<BarcodeList> datasource)
        {
            InitializeComponent();
            DataSource = datasource;

            Load += BarcodeLookupLoad;
            BarcodeGrid.DoubleClick += SelectRow;

            BarcodeView.KeyPress += (sender, args) =>
            {
                if (args.KeyChar == 13) SelectRow(sender, args);
            };
        }

        private void BarcodeLookupLoad(object sender, EventArgs e)
        {
            BarcodeGrid.DataSource = DataSource;
            BarcodeGrid.Focus();
        }

        private void SelectRow(object sender, EventArgs e)
        {
            var rows = BarcodeView.GetSelectedRows();

            if (rows.Count() > 0)
            {
                SelectedBarcode = BarcodeView.GetRowCellValue(rows[0], "Code").ToString();
                Dispose();
            }
        }
    }
}
