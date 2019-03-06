using System.Drawing;
using Corporate.Presentation.Common.Component;
using Corporate.Presentation.Common.Properties;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors;

namespace Corporate.Presentation.Common.ComponentRepositories
{
    public class DateEditCRepo : RepositoryItemDateEdit
    {
        static DateEditCRepo() { }

        // ReSharper disable once EmptyConstructor
        // ReSharper disable once RedundantBaseConstructorCall
        public DateEditCRepo() : base() { }

        public static string FormatDateTimeF = "dd-MM-yyyy";
        // ReSharper disable once InconsistentNaming
        internal const string dCalendarNameF = "dCalendarF";

        public override string EditorTypeName
        {
            get
            {
                return dCalendarNameF;
            }
        }

        public static void RegisterdCalendar()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(dCalendarNameF, typeof(dCalendar),
               typeof(DateEditCRepo), typeof(DateEditViewInfo), new ButtonEditPainter(), true));
        }

        public override void CreateDefaultButton()
        {
            base.CreateDefaultButton();

            Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            Buttons[0].Image = Resources.Rep_Cal_Icon;
            Buttons[0].ImageLocation = ImageLocation.MiddleRight;
            AutoHeight = false;
            DisplayFormat.FormatString = FormatDateTimeF;
            DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            EditFormat.FormatString = FormatDateTimeF;
            EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            Mask.EditMask = FormatDateTimeF;
            Mask.MaskType = MaskType.DateTimeAdvancingCaret;
            Mask.AutoComplete = AutoCompleteType.Optimistic;
            Mask.UseMaskAsDisplayFormat = true;
            BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            NullText = "";
        }
    }
}
