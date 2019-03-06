using System.Drawing;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors;

using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Properties;

namespace SISCO.Presentation.Common.ComponentRepositories
{
    public class DateEditRepo : RepositoryItemDateEdit
    {
        static DateEditRepo() { }

        // ReSharper disable once EmptyConstructor
        // ReSharper disable once RedundantBaseConstructorCall
        public DateEditRepo() : base() { }

        public static string FormatDateTime = "dd-MM-yyyy";
        // ReSharper disable once InconsistentNaming
        internal const string dCalendarName = "dCalendar";

        public override string EditorTypeName
        {
            get
            {
                return dCalendarName;
            }
        }

        public static void RegisterdCalendar()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(dCalendarName, typeof(dCalendar),
               typeof(DateEditRepo), typeof(DateEditViewInfo), new ButtonEditPainter(), true));
        }

        public override void CreateDefaultButton()
        {
            base.CreateDefaultButton();

            Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            Buttons[0].Image = Resources.Rep_Cal_Icon;
            Buttons[0].ImageLocation = ImageLocation.MiddleRight;
            AutoHeight = false;
            NullText = Resources.null_text;
            DisplayFormat.FormatString = FormatDateTime;
            DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            EditFormat.FormatString = FormatDateTime;
            EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            Mask.EditMask = FormatDateTime;
            Mask.MaskType = MaskType.DateTimeAdvancingCaret;
            Mask.AutoComplete = AutoCompleteType.Optimistic;
            Mask.UseMaskAsDisplayFormat = true;
            BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            NullText = "";
        }
    }
}
