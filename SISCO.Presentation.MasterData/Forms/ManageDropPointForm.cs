using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageDropPointForm : BaseCrudForm<DropPointModel, DropPointDataManager>//BaseToolbarForm//
    {
        public ManageDropPointForm()
        {
            InitializeComponent();
            form = this;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            EnableBtnSearch = true;
            SearchPopup = new DropPointPopup();

            lkpBranch.LookupPopup = new BranchPopup();
            lkpBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpBranch.AutoCompleteDisplayFormater =
                model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            lkpBranch.AutoCompleteWhereExpression =
                (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);
        }

        protected override bool ValidateForm()
        {
            if (string.IsNullOrEmpty(tbxName.Text))
            {
                MessageForm.Warning(this, "Mandatory Field", "Nama tidak boleh kosong");
                tbxName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbxAddress.Text))
            {
                MessageForm.Warning(this, "Mandatory Field", "Alamat tidak boleh kosong");
                tbxName.Focus();
                return false;
            }

            if (lkpBranch.Value == null)
            {
                MessageForm.Warning(this, "Mandatory Field", "Kota tidak boleh kosong");
                tbxName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbxId.Text))
            {
                MessageForm.Warning(this, "Mandatory Field", "Nomor KTP tidak boleh kosong");
                tbxName.Focus();
                return false;
            }

            if (tbxCommission.Value < 10)
            {
                MessageForm.Warning(this, "Mandatory Field", "Komisi tidak boleh kurang dari 10%");
                tbxName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbxEmail.Text))
            {
                MessageForm.Warning(this, "Mandatory Field", "Email KTP tidak boleh kosong");
                tbxName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbxPhone.Text))
            {
                MessageForm.Warning(this, "Mandatory Field", "Nomor telepon tidak boleh kosong");
                tbxName.Focus();
                return false;
            }

            return true;
        }

        public override void Save()
        {
            base.Save();
        }

        protected override void PopulateForm(DropPointModel model)
        {
            ClearForm();
            if (model == null) return;

            tsBaseTxt_Code.Text = model.Code;
            tbxName.Text = model.Name;
            tbxAddress.Text = model.Address;
            lkpBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(model.BranchId, "id") };
            tbxId.Text = model.NoId;
            tbxCommission.SetValue(model.Commission);
            tbxEmail.Text = model.Email;
            tbxPhone.Text = model.Phone;
        }

        protected override DropPointModel PopulateModel(DropPointModel model)
        {
            if (model.Id == 0)
            {
                model.Code = ((DropPointDataManager)DataManager).GenerateCode(new DropPointModel
                {
                    BranchId = (int)lkpBranch.Value
                });
                model.CreatedPc = Environment.MachineName;
            }
            else model.ModifiedPc = Environment.MachineName;

            model.Name = tbxName.Text;
            model.Address = tbxAddress.Text;
            model.BranchId = (int) lkpBranch.Value;
            model.NoId = tbxId.Text;
            model.Commission = tbxCommission.Value;
            model.Email = tbxEmail.Text;
            model.Phone = tbxPhone.Text;

            return model;
        }

        protected override DropPointModel Find(string searchTerm)
        {
            return DataManager.GetFirst<DropPointModel>(WhereTerm.Default(searchTerm, "code"));
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            ClearForm();
            tsBaseTxt_Code.Text = "";

            tbxName.Focus();
        }

        protected override void AfterSave()
        {
            base.AfterSave();
            var model = CurrentModel as DropPointModel;
            tsBaseTxt_Code.Text = model.Code;
            PerformFind();
        }
    }
}