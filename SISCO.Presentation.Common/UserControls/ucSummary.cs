using System;
using System.Windows.Forms;

namespace SISCO.Presentation.Common.UserControls
{
    // ReSharper disable once InconsistentNaming
    public partial class ucSummary : UserControl
    {
        public ucSummary()
        {
            InitializeComponent();
        }

        public float Pieces
        {
            get { return (float)tbxPcs.Value; }
            set
            {
                // ReSharper disable once SpecifyACultureInStringConversionExplicitly
                tbxPcs.SetValue(value.ToString());
            }
        }

        public float Gw
        {
            get { return (float)tbxGW.Value; }
            set
            {
                // ReSharper disable once SpecifyACultureInStringConversionExplicitly
                tbxGW.SetValue(value.ToString());
            }
        }

        public float Cw
        {
            get { return (float)tbxCW.Value; }
            set
            {
                // ReSharper disable once SpecifyACultureInStringConversionExplicitly
                tbxCW.SetValue(value.ToString());
            }
        }

        public float Total
        {
            get { return (float)tbxTotal.Value; }
            set
            {
                // ReSharper disable once SpecifyACultureInStringConversionExplicitly
                tbxTotal.SetValue(value.ToString());
            }
        }
    }
}
