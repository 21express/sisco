using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Native;
using Franchise.Presentation.Common.Component.Interfaces;
using Franchise.Presentation.Common.Forms;
using Franchise.Presentation.Common.Interfaces;

namespace Franchise.Presentation.Common.Component
{
    [ToolboxItem(true)]
    // ReSharper disable once InconsistentNaming
    public partial class dLookupF : ButtonEdit, IValidatableComponent
    {
        public class AutoCompleteWhereExpressionParam
        {
            public string Expression { get; set; }
            public object[] Parameters { get; set; }

            public void SetWhereExpression(string expression, params object[] parameters)
            {
                Expression = expression;
                Parameters = parameters;
            }
        }

        static dLookupF() { ComponentRepositories.LookupFRepo.RegisterdLookupF(); }

        public override string EditorTypeName { get { return ComponentRepositories.LookupFRepo.dLookupName; } }

        public int AutocompleteMinimumTextLength { get; set; }

        public int? Value { get; set; }
        public bool ClearOnLeave { get; set; }

        public event EventHandler ValueChanged;

        public IPopup LookupPopup
        {
            get { return Properties.LookupPopup; }
            set { Properties.LookupPopup = value; }
        }

        public IDataManager AutoCompleteDataManager
        {
            get { return Properties.AutoCompleteDataManager; }
            set { Properties.AutoCompleteDataManager = value; }
        }

        public Func<IBaseModel, string> AutoCompleteText
        {
            get { return Properties.AutoCompleteText; }
            set { Properties.AutoCompleteText = value; }
        }

        public Func<IBaseModel, string> AutoCompleteDisplayFormater
        {
            get { return Properties.AutoCompleteDisplayFormater; }
            set { Properties.AutoCompleteDisplayFormater = value; }
        }

        public Func<string, IListParameter[]> AutoCompleteWheretermFormater
        {
            get { return Properties.AutoCompleteWheretermFormater; }
            set { Properties.AutoCompleteWheretermFormater = value; }
        }

        public Action<string, AutoCompleteWhereExpressionParam> AutoCompleteWhereExpression
        {
            get { return Properties.AutoCompleteWhereExpression; }
            set { Properties.AutoCompleteWhereExpression = value; }
        }

        public bool AutoCompleteInitialized { get; set; }

        protected string[] AutoCompleteCachedSource = {};
        public string DisplayString { get; set; }

        public dLookupF()
        // ReSharper disable once RedundantBaseConstructorCall
            : base()
        {
            ComponentRepositories.LookupFRepo.RegisterdLookupF();
                InitializeComponent();
                Init();
            }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new ComponentRepositories.LookupFRepo Properties
        {
            get
            {
                return (ComponentRepositories.LookupFRepo)base.Properties;
            }
        }

        public dLookupF(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            ByAuto = false;
            ClearOnLeave = true;
            Size = new Size(225, 20);

            Properties.CharacterCasing = CharacterCasing.Upper;
        }

        private string FirstValue { get; set; }
        private bool ByAuto { get; set; }
        private int OriginalTextStartPosition { get; set; }

        private CancellationTokenSource _cancellationTokenSource;

        protected virtual void OnValueChanged(EventArgs e)
        {
            //Properties.PerformValueChanged();
            ValueChanged(this, e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            SelectionStart = 0;
            SelectionLength = Text.Length;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    break;
                case Keys.Back:
                    break;
                default:
                    if (Text != FirstValue) AutoComplete();
                    break;
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
                    if (Text.IsEmpty())
                    {
                        if (ClearOnLeave)
                        {
                            if (BackColor == Color.AntiqueWhite) OpenLookupPopup();
                        }
                    }
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
           
            FirstValue = Text;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (ClearOnLeave)
            {
                if (Value == null && ByAuto)
                {
                    if (BackColor == Color.AntiqueWhite)
                    {
                        Text = string.Empty;
                        Focus();
                        OpenLookupPopup();
                    }
                }
                else if (Text.IsEmpty())
                {
                    Value = null;
                    DisplayString = string.Empty;
                }

                Text = string.IsNullOrEmpty(DisplayString) ? Text : DisplayString;
                ByAuto = false;
            }
        }

        private void AutoComplete()
        {
            // ReSharper disable once TooWideLocalVariableScope
            int count;

            if (!ClearOnLeave) return;
            if (Text.Length < OriginalTextStartPosition)
            {
                OriginalTextStartPosition = 0;
            }

            var strlen = Text.Length - OriginalTextStartPosition - SelectionLength;
            if (strlen > Text.Length - OriginalTextStartPosition || strlen < 0)
            {
                strlen = Text.Length - OriginalTextStartPosition;
            }

            var searchTerm = Text.Substring(OriginalTextStartPosition, strlen);

            if (!searchTerm.IsEmpty() && !Array.Exists(AutoCompleteCachedSource, s => s.Contains(searchTerm)) &&
                searchTerm.Length > AutocompleteMinimumTextLength)
            {
                IQueryable<IBaseModel> result = null;

                if (AutoCompleteWheretermFormater != null)
                {
                    result = AutoCompleteDataManager
                        .Get<IBaseModel>(Paging.Instance(0, 1), out count, AutoCompleteWheretermFormater(searchTerm))
                        .AsQueryable();
                }
                else if (AutoCompleteWhereExpression != null)
                {
                    if (!(AutoCompleteDataManager is IExtendedQueryableDataManager))
                    {
                        throw new Exception(string.Format("Autocomplete field {0} is using AutoCompleteWhereExpression property, but the AutoCompleteDataManager property does not implement IExtendedQueryableDataManager.", Name));
                    }

                    var param = new AutoCompleteWhereExpressionParam();
                    AutoCompleteWhereExpression(searchTerm, param);

                    result = ((IExtendedQueryableDataManager)AutoCompleteDataManager)
                        .Get<IBaseModel>(Paging.Instance(0, 1), out count, param.Expression, param.Parameters)
                        .AsQueryable();
                }

                if (result != null && result.Any())
                {
                    Value = (int) result.Select(model => model.Id).ToArray().GetValue(0);
                    DisplayString = result.Select(AutoCompleteDisplayFormater).ToArray().GetValue(0).ToString();

                    ByAuto = true;
                    var strtemp = searchTerm;
                    if (AutoCompleteText != null)
                    {
                        Text = result.Select(AutoCompleteText).ToArray().GetValue(0).ToString();
                    }
                    else
                    {
                        Text = DisplayString;
                    }

                    OriginalTextStartPosition = Text.ToLower().IndexOf(strtemp.ToLower(), StringComparison.Ordinal);
                    var startSel = OriginalTextStartPosition + strtemp.Length;
                    SelectionStart = startSel;
                    SelectionLength = Text.Length - startSel;

                    OriginalTextStartPosition = OriginalTextStartPosition < 0 ? 0 : OriginalTextStartPosition;

                    DisplayString = Text;
                }
                else
                {
                    Value = null;
                    DisplayString = string.Empty;
                }
            }

            if (Text.IsEmpty())
            {
                Value = null;
                DisplayString = string.Empty;
            }
        }

        public void OpenLookupPopup()
        {
            if (LookupPopup != null && Enabled)
            {
                ((BaseForm)LookupPopup).ShowDialog();

                if (LookupPopup.SelectedValue > 0)
                {
                    DefaultValue = new IListParameter[] {WhereTerm.Default(LookupPopup.SelectedValue, "id")};
                }
            }
        }

        private IBaseModel[] BaseModelTemp { get; set; }

        public string GetFieldModel(Func<IBaseModel, string> selectFunct)
        {
            var mdls = BaseModelTemp;
            var mdl = mdls.Select(selectFunct).ToArray();

            if (mdl.Any())
            {
                Value = Convert.ToInt32(mdls.Select(m => m.Id).ToArray()[0]);
                return mdl[0];
            }

            return string.Empty;
        }

        public int GetFieldModel(Func<IBaseModel, int> selectFunct)
        {
            var mdls = BaseModelTemp;
            var mdl = mdls.Select(selectFunct).ToArray();

            if (mdl.Any())
            {
                Value = Convert.ToInt32(mdls.Select(m => m.Id).ToArray()[0]);
                return mdl[0];
            }

            return 0;
        }

        public IListParameter[] DefaultValue
        {
            set
            {
                var origEnableState = Enabled;
                Enabled = false;

                Value = null;
                Text = string.Empty;
                DisplayString = string.Empty;

                UpdateDefaultValue(origEnableState, value);
            }
        }

        protected void UpdateDefaultValue(bool origEnableState, IListParameter[] parameters)
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
            }

            var model = LoadModel(parameters);

            BaseModelTemp = model as IBaseModel[] ?? model.ToArray();
            var mdls = BaseModelTemp;
            var mdl = mdls.Select(AutoCompleteDisplayFormater).ToArray();

            if (mdl.Any())
            {
                Value = Convert.ToInt32(mdls.Select(m => m.Id).ToArray()[0]);
                DisplayString = mdl[0];
            }
            else
            {
                Value = null;
                DisplayString = string.Empty;
            }

            Text = DisplayString;
            FirstValue = Text;

            Enabled = origEnableState;
        }

        protected IEnumerable<IBaseModel> LoadModel(params IListParameter[] parameters)
        {
            _cancellationTokenSource = new CancellationTokenSource();

            //var ret = TaskEx.Run(() => AutoCompleteDataManager.Get<IBaseModel>(parameters), _cancellationTokenSource.Token);
            if (AutoCompleteDataManager == null) return null;
            var ret = AutoCompleteDataManager.Get<IBaseModel>(parameters);

            _cancellationTokenSource = null;

            return ret;
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
                    BackColor = Color.AntiqueWhite;
                    OriginalBackColor = BackColor;
                }
                else
                {
                    BackColor = Color.White;
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
