using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Operation.Popup
{
    public partial class FindAirwaybillPopup : BaseForm
    {
        public List<int> SelectedId { get; set; }
        public FindAirwaybillPopup()
        {
            InitializeComponent();

            Shown += FindAirwaybillPopup_Shown;

            tbxFrom.DateTime = DateTime.Now.AddDays(-1);
            tbxTo.DateTime = DateTime.Now;

            lkpAirline.LookupPopup = new AirlinePopup();
            lkpAirline.AutoCompleteDataManager = new AirlineDataManager();
            lkpAirline.AutoCompleteText = model => ((AirlineModel)model).Code + " - " + ((AirlineModel)model).Name;
            lkpAirline.AutoCompleteDisplayFormater = model => ((AirlineModel)model).Code + " - " + ((AirlineModel)model).Name;
            lkpAirline.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code = @0 or name.StartsWith(@0)", s);

            lkpOrigin.LookupPopup = new AirportPopup();
            lkpOrigin.AutoCompleteDataManager = new AirportDataManager();
            lkpOrigin.AutoCompleteText = model => ((AirportModel)model).Code + " - " + ((AirportModel)model).Name;
            lkpOrigin.AutoCompleteDisplayFormater = model => ((AirportModel)model).Code + " - " + ((AirportModel)model).Name;
            lkpOrigin.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code = @0 or name.StartsWith(@0)", s);

            lkpDestination.LookupPopup = new AirportPopup();
            lkpDestination.AutoCompleteDataManager = new AirportDataManager();
            lkpDestination.AutoCompleteText = model => ((AirportModel)model).Code + " - " + ((AirportModel)model).Name;
            lkpDestination.AutoCompleteDisplayFormater = model => ((AirportModel)model).Code + " - " + ((AirportModel)model).Name;
            lkpDestination.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code = @0 or name.StartsWith(@0)", s);

            AirwaybillView.CustomColumnDisplayText += NumberGrid;

            btnSelect.Click += btnSelect_Click;
            btnOk.Click += btnOk_Click;
            btnClose.Click += (s, a) => Hide();
            btnFind.Click += btnFind_Click;
        }

        void FindAirwaybillPopup_Shown(object sender, EventArgs e)
        {
            SelectedId = new List<int>();
        }

        void btnFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxFrom.Text) && string.IsNullOrEmpty(tbxTo.Text) && string.IsNullOrEmpty(tbxAwb.Text) &&
                lkpAirline.Value == null && lkpOrigin.Value == null && lkpDestination.Value == null)
            {
                MessageBox.Show("Silakan isi parameter pencarian");
                tbxFrom.Focus();
            }

            GridAirwaybill.DataSource = new AirwaybillDataManager().FindAriwaybillList(BaseControl.BranchId, tbxAwb.Text, tbxFrom.DateTime, tbxTo.DateTime, lkpAirline.Value, lkpOrigin.Value, lkpDestination.Value);
            AirwaybillView.RefreshData();

            GridAirwaybill.Focus();
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < AirwaybillView.RowCount; i++)
            {
                if ((bool)AirwaybillView.GetRowCellValue(i, AirwaybillView.Columns["Select"]))
                    SelectedId.Add((int)AirwaybillView.GetRowCellValue(i, AirwaybillView.Columns["Id"]));
            }

            if (SelectedId.Count == 0) MessageBox.Show("Anda belum memilih AWB.");
            else btnClose.PerformClick();
        }

        void btnSelect_Click(object sender, EventArgs e)
        {
            var check = true;
            switch (btnSelect.Text)
            {
                case "Pilih Semua":
                    btnSelect.Text = "Hapus Semua";
                    check = true;
                    break;
                case "Hapus Semua":
                    btnSelect.Text = "Pilih Semua";
                    check = false;
                    break;
            }

            for (int i = 0; i < AirwaybillView.RowCount; i++)
            {
                AirwaybillView.SetRowCellValue(i, AirwaybillView.Columns["Select"], check);
            }

            AirwaybillView.RefreshData();
        }
    }
}
