using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using System;
using System.Windows.Forms;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class NotificationForm : BaseCrudForm<NotificationModel, NotificationDataManager>
    {
        public NotificationForm()
        {
            InitializeComponent();
            form = this;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            tbxExpired.FieldLabel = "Expired Date";
            tbxExpired.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            if (tbxExpired.Text == "")
            {
                MessageBox.Show("Expired date harap diisi.");
                tbxExpired.Focus();
                return false;
            }

            if (rtMessage.Text == "")
            {
                MessageBox.Show("Harap diisi.");
                rtMessage.Focus();
                return false;
            }

            return true;
        }

        protected override void PopulateForm(NotificationModel model)
        {
            ClearForm();
            if (model == null) return;
            tbxExpired.DateTime = model.ExpiredDate;
            rtMessage.Text = model.Message;

            tsBaseTxt_Code.Text = model.Id.ToString();
        }

        protected override NotificationModel PopulateModel(NotificationModel model)
        {
            model.ExpiredDate = new DateTime(tbxExpired.DateTime.Year, tbxExpired.DateTime.Month, tbxExpired.DateTime.Day, 23, 59, 59);
            model.Message = rtMessage.Text;

            if (model.Id == 0) model.DateProcess = DateTime.Now;

            return model;
        }

        protected override NotificationModel Find(string searchTerm)
        {
            return DataManager.GetFirst<NotificationModel>(WhereTerm.Default(Convert.ToInt32(searchTerm), "id"));
        }

        protected override void AfterSave()
        {
            var model = CurrentModel as NotificationModel;

            if (model == null) return;

            tsBaseTxt_Code.Text = model.Id.ToString();
            PerformFind();
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            ClearForm();
            tbxExpired.Focus();
        }
    }
}
