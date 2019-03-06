using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using SISCO.Presentation.Common.Component.Interfaces;

namespace SISCO.Presentation.Common.Component
{
    [ToolboxItem(true)]
    // ReSharper disable once InconsistentNaming
    public partial class dTime : TimeEdit, IValidatableComponent
    {
        static dTime() { ComponentRepositories.TimeEditRepo.RegisterdTime(); }

        public dTime()
            // ReSharper disable once RedundantBaseConstructorCall
            : base()
        {
            InitializeComponent();
        }

        public override string EditorTypeName { get { return ComponentRepositories.TimeEditRepo.dTimeName; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new ComponentRepositories.TimeEditRepo Properties
        {
            get
            {
                return (ComponentRepositories.TimeEditRepo)base.Properties;
            }
        }

        public dTime(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            SelectionStart = 0;
            SelectionLength = Text.Length;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (SelectionLength > 0 || Text.Length == 0)
            {
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

        public string FormatDateTime
        {
            get { return ComponentRepositories.TimeEditRepo.FormatDateTime; }
            set { ComponentRepositories.TimeEditRepo.FormatDateTime = value; }
        }

        public override string Text
        {
            get { return base.Text; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Value = Convert.ToDateTime(value);
                    base.EditValue = value;
                }
                else
                {
                    Value = DateTime.Now;
                    base.EditValue = Value;
                }
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

        public DateTime Value { get; set; }

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
                    Properties.ReadOnly = false;
                    BackColor = OriginalBackColor;
                }
                else
                {
                    if (!Properties.ReadOnly)
                        OriginalBackColor = BackColor;

                    Properties.ReadOnly = true;
                    BackColor = Color.FromArgb(235, 236, 239);
                }
            }
        }
    }
}
