using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Franchise.Presentation.Common.Component.Interfaces;

namespace Franchise.Presentation.Common.Component
{
    [ToolboxItem(true)]
    // ReSharper disable once InconsistentNaming
    public partial class dCalendar : DateEdit, IValidatableComponent
    {
        static dCalendar() { ComponentRepositories.DateEditFRepo.RegisterdCalendar(); }

        public dCalendar()
            // ReSharper disable once RedundantBaseConstructorCall
            : base() 
            {
                InitializeComponent();
                DateTimeChanged += DateChanged;
            }

        public override string EditorTypeName { get { return ComponentRepositories.DateEditFRepo.dCalendarNameF; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new ComponentRepositories.DateEditFRepo Properties
        {
            get
            {
                return (ComponentRepositories.DateEditFRepo)base.Properties;
            }
        }

        public dCalendar(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            Nullable = false;
            DateTimeChanged += DateChanged;
        }

        private void DateChanged(object sender, EventArgs e)
        {
            Value = DateTime;
            if (Value == Convert.ToDateTime("1/1/0001 12:00:00 AM")) EditValue = null;
            else EditValue = Value;
        }

        public bool Nullable { get; set; }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (SelectionLength > 0 || Text.Length == 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Right:
                    case Keys.Up:
                        if (TabIndex != 1) SendKeys.Send("+{TAB}");
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

            e.Handled = true;
        }

        public string FormatDateTime
        {
            get { return ComponentRepositories.DateEditFRepo.FormatDateTimeF; }
            set { ComponentRepositories.DateEditFRepo.FormatDateTimeF = value; }
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
                    base.Text = value;
                }
                else
                {
                    if (!Nullable)
                    {
                        Value = DateTime.Now;
                        base.EditValue = Value;
                    }
                    else
                    {
                        Value = new DateTime(1, 1, 1, 0, 0, 0);
                        base.EditValue = null;
                    }
                }
            }
        }

        public DateTime Value { get; set; }

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
