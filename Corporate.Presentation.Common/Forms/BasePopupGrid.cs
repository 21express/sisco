﻿using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using Corporate.Presentation.Common.Interfaces;
using Corporate.Presentation.Common.Properties;

namespace Corporate.Presentation.Common.Forms
{
    public partial class BasePopupGrid : BasePage, IPopup
    {
        public BasePopupGrid()
        {
            InitializeComponent();

            btnSelect.Click += SelectRow;
            gridView.DoubleClick += SelectRow;

            Load += LoadPopup;
        }

        public GridControl objGrid
        {
            get { return grid; }
        }

        protected virtual void LoadPopup(object sender, EventArgs e)
        {
            clName.FieldName = string.IsNullOrEmpty(DisplayMember) ? "Name" : DisplayMember;

            gridView.Focus();
        }

        public int SelectedValue { get; set; }
        public string SelectedCode { get; set; }
        public string SelectedText { get; set; }

        public virtual void SelectRow(object sender, EventArgs e)
        {
            var rows = gridView.GetSelectedRows();

            if (rows.Count() > 0)
            {
                SelectedValue = Convert.ToInt32(gridView.GetRowCellValue(rows[0], "Id"));
                SelectedCode = gridView.GetRowCellValue(rows[0], string.IsNullOrEmpty(DisplayMember) ? "Name" : DisplayMember).ToString();
                SelectedText = gridView.GetRowCellValue(rows[0], string.IsNullOrEmpty(DisplayMember) ? "Name" : DisplayMember).ToString();

                Hide();
            }
            else MessageBox.Show(Resources.alert_choose_data, Resources.title_information);
        }

        public string DisplayMember { get; set; }
    }
}
