using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Billing.Forms
{
    public partial class ViewPublishedTariffDialogForm : Form
    {
        public ViewPublishedTariffDialogForm()
        {
            InitializeComponent();
        }

        public string OriginCity
        {
            set { lblOriginCity.Text = value; }
        }

        public string DestinationCity
        {
            set { lblDestinationCity.Text = value; }
        }

        public string ServiceType
        {
            set { lblServiceType.Text = value; }
        }

        public Decimal TariffPerKg
        {
            set { lblTariffPerKg.Text = string.Format("Rp. {0:###,###,##0.00}", value); }
        }

        public Decimal HandlingFee
        {
            set { lblHandlingFee.Text = string.Format("Rp. {0:###,###,##0.00}", value); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Dispose();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
