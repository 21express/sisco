using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Native;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.ComponentRepositories;
using SISCO.Presentation.Common.Forms;
using SISCO.App.MasterData;
using Devenlab.Common;
using SISCO.Presentation.Common.Interfaces;
using DevExpress.XtraEditors;
using BaseControl = SISCO.Presentation.Common.BaseControl;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageVendorForm : BasePage, IGridChildForm
    {
        protected ExtendedBindingList<VendorModel> Items;
        protected List<VendorModel> DeletedItems;

        public ManageVendorForm()
        {
            InitializeComponent();

            form = this;

            DataManager = new VendorDataManager();
            Load += LoadForm;

            Items = new ExtendedBindingList<VendorModel>();
            DeletedItems = new List<VendorModel>();
            gridControl1.DataSource = Items;

            gridColumn1.Caption = @"Nama Vendor";
            gridColumn1.FieldName = "Name";

            gridControl1.EmbeddedNavigator.Buttons.First.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.Prev.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.Next.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            gridControl1.EmbeddedNavigator.Buttons.Last.Visible = false;

            gridControl1.EmbeddedNavigator.ButtonClick += (sender, e) =>
            {
                switch (e.Button.ButtonType)
                {
                    case NavigatorButtonType.Append:
                        DetailNew();
                        break;
                    case NavigatorButtonType.Remove:
                        DetailDelete();
                        break;
                }

                e.Handled = true;
            };

            gridView1.Columns[0].ColumnEdit = new TextEditRepo
            {
                CharacterCasing = CharacterCasing.Upper
            };

            gridColumn1.ColumnEdit = new TextEditRepo
            {
                CharacterCasing = CharacterCasing.Upper
            };

            gridColumn1.RealColumnEdit.Validating += (sender, args) =>
            {
                var code = (sender as TextEdit).Text;

                if (string.IsNullOrEmpty(code))
                {
                    args.Cancel = true;
                    MessageBox.Show(@"Nama tidak boleh kosong");
                }

                var dups = from r in Items.Select((value, index) => new { value, index })
                           where r.value.Name.ToUpper() == code.ToUpper()
                                 && r.index != gridView1.FocusedRowHandle
                           select r;

                if (dups.Any())
                {
                    args.Cancel = true;
                    MessageBox.Show(@"Service type dengan nama yang sama sudah terdaftar");
                }
            };
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
            BindListDataSource<VendorModel>().ForEach(row => Items.Add(row));

            Items.RaiseListChangedEvents = true;
            Items.ResetBindings();
        }

        public void Save()
        {
            if (!gridView1.PostEditor() || !gridView1.UpdateCurrentRow())
            {
                return;
            }

            ((VendorDataManager)DataManager).Save(Items, DeletedItems, SISCO.Presentation.Common.BaseControl.UserLogin);

            RefreshGrid();

            MessageBox.Show(@"Changes have been saved");
        }

        public void DetailNew()
        {
            Items.Add(new VendorModel
            {
                Name = "",
                Createddate = DateTime.Now,
                Createdby = SISCO.Presentation.Common.BaseControl.UserLogin,
                Rowstatus = true,
                Rowversion = DateTime.Now,
            });

            Items.ResetBindings();

            gridView1.FocusedRowHandle = Items.Count - 1;
        }

        public void DetailDelete()
        {
            if (gridView1.FocusedRowHandle < 0)
            {
                MessageBox.Show(@"No detail item selected", @"Delete Detail Item", MessageBoxButtons.OK);
                return;
            }

            Items.RemoveAt(gridView1.FocusedRowHandle);
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
