using System.Drawing;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors;

using Franchise.Presentation.Common.Component;
using Franchise.Presentation.Common.Properties;

namespace Franchise.Presentation.Common.ComponentRepositories
{
    public class DateEditFRepo : RepositoryItemDateEdit
    {
        static DateEditFRepo() { }

        // ReSharper disable once EmptyConstructor
        // ReSharper disable once RedundantBaseConstructorCall
        public DateEditFRepo() : base() { }

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
               typeof(DateEditFRepo), typeof(DateEditViewInfo), new ButtonEditPainter(), true));
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
