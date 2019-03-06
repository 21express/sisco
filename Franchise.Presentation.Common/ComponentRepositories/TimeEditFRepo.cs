using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using Franchise.Presentation.Common.Component;

namespace Franchise.Presentation.Common.ComponentRepositories
{
    public partial class TimeEditFRepo : RepositoryItemTimeEdit
    {
        static TimeEditFRepo() { }

        // ReSharper disable once EmptyConstructor
        // ReSharper disable once RedundantBaseConstructorCall
        public TimeEditFRepo() : base() { }

        public static string FormatDateTime = "hh:mm";
        // ReSharper disable once InconsistentNaming
        internal const string dTimeName = "dTime";

        public override string EditorTypeName
        {
            get
            {
                return dTimeName;
            }
        }

        public static void RegisterdTime()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(dTimeName, typeof(dTime),
               typeof(TimeEditFRepo), typeof(DateEditViewInfo), new ButtonEditPainter(), true));
        }

        public override void CreateDefaultButton()
        {
            base.CreateDefaultButton();

            AutoHeight = false;
            NullText = @"00:00";
            DisplayFormat.FormatString = FormatDateTime;
            DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            EditFormat.FormatString = FormatDateTime;
            EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            Mask.EditMask = FormatDateTime;
            Mask.MaskType = MaskType.DateTimeAdvancingCaret;
            Mask.AutoComplete = AutoCompleteType.Optimistic;

            BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
        }
    }
}
