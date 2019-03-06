using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Corporate.Presentation.Common.Component.Interfaces;

namespace Corporate.Presentation.Common.Component
{
    // ReSharper disable once InconsistentNaming
    public partial class dTextBox : TextBox, IValidatableComponent
    {
        public bool Capslock
        {
            get { return CharacterCasing == CharacterCasing.Upper; }
            set { CharacterCasing = value ? CharacterCasing.Upper : CharacterCasing.Normal; }
        }

        public dTextBox()
        {
            InitializeComponent();

            Init();
        }

        public dTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            Init();
        }

        private void Init()
        {
            CharacterCasing = CharacterCasing.Upper;
        }

        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            SelectionStart = 0;
            SelectionLength = TextLength;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if ((SelectionLength > 0 || Text.Length == 0) && e.Modifiers != Keys.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                    case Keys.Up:
                        SendKeys.Send("+{TAB}");
                        break;
                    case Keys.Right:
                    case Keys.Down:
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
                    OriginalBackColor = BackColor;
                }
            }
        }

        public Color OriginalBackColor { get; set; }
        private bool _enabled = true;
        public new bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;

                if (_enabled)
                {
                    ReadOnly = false;
                    BackColor = OriginalBackColor;
                }
                else
                {
                    if (!ReadOnly)
                        OriginalBackColor = BackColor;

                    ReadOnly = true;
                    BackColor = Color.FromArgb(235, 236, 239);
                }
            }
        }
    }
}