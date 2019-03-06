using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Devenlab.Common;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Interfaces;
using BaseControl = SISCO.Presentation.Common.BaseControl;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageAccountReferenceForm : BasePage, IGridChildForm
    {
        protected ExtendedBindingList<AccountReferenceModel> Items;
        protected List<AccountReferenceModel> DeletedItems;

        public ManageAccountReferenceForm()
        {
            InitializeComponent();

            form = this;

            DataManager = new AccountReferenceDataManager();
            Load += LoadForm;

            Items = new ExtendedBindingList<AccountReferenceModel>();
            DeletedItems = new List<AccountReferenceModel>();
            gridControl1.DataSource = Items;

            gridColumn1.Caption = @"Reference Type";
            gridColumn1.FieldName = "ReferenceType";

            gridColumn2.Caption = @"Account Code";
            gridColumn2.FieldName = "AccountCode";

            gridControl1.EmbeddedNavigator.Buttons.First.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.Prev.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.Next.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.Last.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.Remove.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.Append.Visible = false;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            button1.Click += (o, args) => Save();

            Items.BeforeRemove += (o, args) =>
            {
                var item = Items[args.NewIndex];
                DeletedItems.Add(item);
            };

            NavigationMenu.BottomStrip.Enabled = false;
            NavigationMenu.DeleteStrip.Enabled = false;
            NavigationMenu.FindStrip.Enabled = false;
            NavigationMenu.NewStrip.Enabled = false;
            NavigationMenu.NextStrip.Enabled = false;
            NavigationMenu.PreviousStrip.Enabled = false;
            NavigationMenu.RefreshStrip.Enabled = false;
            NavigationMenu.SaveStrip.Enabled = true;
            NavigationMenu.TopStrip.Enabled = false;

            RefreshGrid();
        }

        protected void RefreshGrid()
        {
            PageLimit = 99999;

            Items.RaiseListChangedEvents = false;

            Items.Clear();
            BindListDataSource<AccountReferenceModel>().ForEach(row => Items.Add(row));

            Items.RaiseListChangedEvents = true;
            Items.ResetBindings();
        }

        public void Save()
        {
            gridView1.PostEditor();
            ((AccountReferenceDataManager)DataManager).Save(Items, DeletedItems, BaseControl.UserLogin);

            RefreshGrid();

            MessageBox.Show(@"Changes have been saved");
        }

        public void DetailNew()
        {
            //
        }

        public void DetailDelete()
        {
            //
        }

        public EnumStateChange StateChange { get; set; }

        public virtual new void ActiveForm(object sender, EventArgs e)
        {
            BaseControl.ChildForm = this;
        }

        public virtual void InactiveForm(object sender, EventArgs e)
        {
            BaseControl.ChildForm = null;
        }

        public void CloseForm()
        {
            DataManager.Dispose();
            form.Dispose();
        }

        public virtual void New()
        {
        }

        public virtual void Delete()
        {
        }

        // ReSharper disable once CSharpWarnings::CS0108
        public new void Top()
        {
        }

        public void Previous()
        {
        }

        public void Next()
        {
        }

        // ReSharper disable once CSharpWarnings::CS0108
        public new void Bottom()
        {
        }

        public void OpenData(string codeText)
        {
        }

        public void Find()
        {
        }


        public void SetNoPod(string code)
        {
            throw new NotImplementedException();
        }
    }
}
