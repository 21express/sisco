using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Corporate.Presentation.Common.Component.Interfaces;

namespace Corporate.Presentation.Common.Component
{
    // ReSharper disable once InconsistentNaming
    public partial class dComboBox : ComboBox, IValidatableComponent
    {
        public dComboBox()
        {
            InitializeComponent();
            AutoCompleteSource = AutoCompleteSource.ListItems;
            AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            FlatStyle = FlatStyle.Popup;
        }

        public dComboBox(IContainer container)
        {
            container.Add(this);

            AutoCompleteSource = AutoCompleteSource.ListItems;
            AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            FlatStyle = FlatStyle.Popup;

            InitializeComponent();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (SelectedValue == null)
            {
                Text = string.Empty;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (SelectionLength > 0 || Text.Length == 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Right:
                        SendKeys.Send("+{TAB}");
                        break;
                    case Keys.Left:
                        SendKeys.Send("{TAB}");
                        break;
                }
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