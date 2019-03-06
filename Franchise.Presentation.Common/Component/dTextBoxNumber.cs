using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using Franchise.Presentation.Common.Component.Interfaces;

namespace Franchise.Presentation.Common.Component
{
    // ReSharper disable once InconsistentNaming
    public partial class dTextBoxNumber : TextEdit, IValidatableComponent
    {
        public dTextBoxNumber()
        {
            InitializeComponent();

            Init();
        }

        public dTextBoxNumber(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            Init();
        }

        protected void Init()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;

            Properties.Mask.MaskType = MaskType.Numeric;
            Properties.Mask.EditMask = @"###,###,###,###,###,##0.00";
            Properties.Mask.BeepOnError = true;
            Properties.Mask.UseMaskAsDisplayFormat = true;
            Properties.AllowMouseWheel = false;
        }

        protected override void OnSpin(SpinEventArgs e)
        {
            e.Handled = true;
        }

        protected override void OnLoaded()
        {
            base.OnLoaded();

            Init();
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

        [Localizable(false)]
        public void SetValue(string value)
        {
            Text = value;
        }

        [Localizable(false)]
        public void SetValue(decimal value)
        {
            SetValue(value.ToString(CultureInfo.InvariantCulture));
        }

        [Localizable(false)]
        public void SetValue(float value)
        {
            SetValue(value.ToString(CultureInfo.InvariantCulture));
        }

        public decimal Value
        {
            get
            {
                if (EditValue != null && EditValue.ToString() != string.Empty)
                    return Convert.ToDecimal(EditValue);

                return 0;
            }
            set { EditValue = value; }
        }

        public bool IsNumber
        {
            set {
                Properties.Mask.EditMask = value ? @"###,###,###,###,###,##0" : @"###,###,###,###,###,##0.0";
            }
        }

        public bool ReadOnly
        {
            get { return Properties.ReadOnly; }
            set { Properties.ReadOnly = value; }
        }

        public object TextAlign { get; set; }

        public string EditMask
        {
            get { return Properties.Mask.EditMask; }
            set { Properties.Mask.EditMask = value; }
        }

        public int DefaultNumber { set { Value = value; } }

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
