using System;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors;
using Franchise.Presentation.Common.Component;
using Franchise.Presentation.Common.Interfaces;
using Franchise.Presentation.Common.Properties;

namespace Franchise.Presentation.Common.ComponentRepositories
{
    public class LookupFRepo : RepositoryItemButtonEdit
    {
        // ReSharper disable once EmptyConstructor
        static LookupFRepo()
        {
            RegisterdLookupF();
        }
        // ReSharper disable once EmptyConstructor
        // ReSharper disable once RedundantBaseConstructorCall
        public LookupFRepo() : base() { }

        // ReSharper disable once InconsistentNaming
        internal const string dLookupName = "dLookupF";
        private bool _parsingEditValue;
        private bool _skipNextEditValueParsing;
        private bool _formattingEditValue;
        private string _previousDisplayString;

        private Dictionary<int, string> _autocompleteCache;
        private IDataManager _autoCompleteDataManager;

        public override string EditorTypeName
        {
            get
            {
                return dLookupName;
            }
        }

        public static void RegisterdLookupF()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(dLookupName, typeof(dLookupF),
               typeof(LookupFRepo), typeof(ButtonEditViewInfo), new ButtonEditPainter(), true, EditImageIndexes.LookUpEdit,
                  typeof(DevExpress.Accessibility.PopupEditAccessible)));

        }

        protected override void OnLoaded()
        {
            base.OnLoaded();

            AppearanceReadOnly.TextOptions.HAlignment = HorzAlignment.Near;

            _autocompleteCache = new Dictionary<int, string>();

            ButtonClick += (sender, args) =>
            {
                var dLookup = sender as dLookupF;
                if (dLookup != null && dLookup.Enabled) dLookup.OpenLookupPopup();
            };

            CustomDisplayText += (sender, args) =>
            {
                int output;
                if (args.Value != null && int.TryParse(args.Value.ToString(), out output))
                {
                    var model = AutoCompleteDataManager.GetFirst<IBaseModel>(WhereTerm.Default(output, "id"));

                    args.DisplayText = model != null ? AutoCompleteDisplayFormater(model) : string.Empty;

                    _autocompleteCache.Clear();
                    _autocompleteCache.Add(output, args.DisplayText);
                }
            };

            ParseEditValue += (sender, args) =>
            {
                if (_parsingEditValue) return;

                if (_skipNextEditValueParsing)
                {
                    _skipNextEditValueParsing = false;
                    return;
                }

                _parsingEditValue = true;

                int output;
                var lookup = sender as dLookupF;
                if (lookup == null) return;

                if (args.Value != null && int.TryParse(args.Value.ToString(), out output))
                {
                    if (!_autocompleteCache.ContainsKey(output))
                    {
                        lookup.DefaultValue = new IListParameter[] { WhereTerm.Default(output, "id") };
                        args.Value = lookup.DisplayString;
                        _previousDisplayString = lookup.DisplayString;

                        _autocompleteCache.Add(output, lookup.DisplayString);
                    }
                    else
                    {
                        lookup.Value = output;
                        args.Value = _autocompleteCache[output];
                    }
                }
                else if (lookup.Value != null && int.TryParse(lookup.Value.ToString(), out output))
                {
                    if (args.Value != null && !args.Value.Equals(_previousDisplayString))
                    {
                        _skipNextEditValueParsing = true;
                    }

                    args.Value = output;
                }
                _skipNextEditValueParsing = true;

                args.Handled = true;

                _parsingEditValue = false;
            };

            FormatEditValue += (sender, args) =>
            {
                if (_formattingEditValue) return;

                _formattingEditValue = true;

                int output;
                if (args.Value != null && int.TryParse(args.Value.ToString(), out output))
                {
                    if (!_autocompleteCache.ContainsKey(output))
                    {
                        var model = AutoCompleteDataManager.GetFirst<IBaseModel>(WhereTerm.Default(output, "id"));

                        args.Value = model != null ? AutoCompleteDisplayFormater(model) : string.Empty;

                        _autocompleteCache.Add(output, args.Value.ToString());
                    }
                    else
                    {
                        args.Value = _autocompleteCache[output];
                    }
                }

                args.Handled = true;

                _formattingEditValue = false;
            };
        }

        public override void CreateDefaultButton()
        {
            base.CreateDefaultButton();

            Buttons[0].Kind = ButtonPredefines.Glyph;
            Buttons[0].Image = Resources.system_search_small;
            Buttons[0].ImageLocation = ImageLocation.MiddleRight;
            Buttons[0].Caption = "";
            Buttons[0].ToolTip = "";
            AutoHeight = false;

            AutocompleteMinimumTextLength = 2;

            BorderStyle = BorderStyles.Default;
        }

        public override void Assign(RepositoryItem item)
        {
            base.Assign(item);

            var ri = item as LookupFRepo;

            if (ri != null)
            {
                LookupPopup = ri.LookupPopup;
                AutoCompleteDataManager = ri.AutoCompleteDataManager;
                AutoCompleteText = ri.AutoCompleteText;
                AutoCompleteDisplayFormater = ri.AutoCompleteDisplayFormater;
                AutoCompleteWheretermFormater = ri.AutoCompleteWheretermFormater;
                AutoCompleteWhereExpression = ri.AutoCompleteWhereExpression;
                AutocompleteMinimumTextLength = ri.AutocompleteMinimumTextLength;
            }
        }

        public IPopup LookupPopup { get; set; }

        public IDataManager AutoCompleteDataManager
        {
            get
            {
                return _autoCompleteDataManager;
            }
            set
            {
                _autoCompleteDataManager = value;
            }
        }

        public Func<IBaseModel, string> AutoCompleteText { get; set; }
        public Func<IBaseModel, string> AutoCompleteDisplayFormater { get; set; }
        public Func<string, IListParameter[]> AutoCompleteWheretermFormater { get; set; }
        public Action<string, dLookupF.AutoCompleteWhereExpressionParam> AutoCompleteWhereExpression { get; set; }
        public int AutocompleteMinimumTextLength { get; set; }
    }
}
