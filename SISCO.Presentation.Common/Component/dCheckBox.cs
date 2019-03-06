using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SISCO.Presentation.Common.Component.Interfaces;

namespace SISCO.Presentation.Common.Component
{
    // ReSharper disable once InconsistentNaming
    public partial class dCheckBox : CheckBox, IValidatableComponent
    {
        public dCheckBox()
        {
            InitializeComponent();
        }

        public dCheckBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            switch (e.KeyCode)
            {
                case Keys.Right:
                case Keys.Up:
                    SendKeys.Send("+{TAB}");
                    break;
                case Keys.Left:
                case Keys.Down:
                    SendKeys.Send("{TAB}");
                    break;
            }

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (e.Shift)
                    {
                        SendKeys.Send("+{TAB}");
                    }
                    else
                    {
                        SendKeys.Send("{TAB}");
                    }
                    break;
            }
        }

        [Description("Field label"), Category("Appearance")] 
        public string FieldLabel { get; set; }

        private ComponentValidationRule[] _validationRules;
        public ComponentValidationRule[] ValidationRules
        {
            get { return _validationRules; }
            set
            {
                if (value == null) return;

                _validationRules = value;
                if (_validationRules.Any(row => row.Rule == EnumComponentValidationRule.Mandatory))
                {
                    BackColor = Color.MistyRose;
                }
            }
        }
    }
}