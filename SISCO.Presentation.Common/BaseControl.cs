using System;
using System.Deployment.Application;
using System.IO;
using System.Windows.Forms;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Interfaces;
using System.Globalization;

namespace SISCO.Presentation.Common
{
    public class BaseControl
    {
        public static string UserLogin { get; set; }
        public static int? UserId { get; set; }
        public static string UserRole { get; set; }
        public static int? RoleId { get; set; }
        public static int EmployeeId { get; set; }
        public static string EmployeeCode { get; set; }
        public static int BranchId { get; set; }
        public static string BranchCode { get; set; }
        public static int CityId { get; set; }
        public static string CityName { get; set; }
        public static int CountryId { get; set; }
        public static string CountryName { get; set; }
        public static object DepartmentName { get; set; }
        public static bool ExitApp { get; set; }

        public const decimal GoodValuesInsurance = (decimal)0.002;
        public const int GoodValuesAdministration = 5000;

        # if(DEBUG)
        public static string SiscoBaseAddressApi = "http://192.168.4.3/sisco/";
        public static string SiscoTokenApi = "uVoJtAJdQCEEtY+b6+T7T7bfPQrdyz8XUSvZNUD+E7v4N4AktArie8cm00wdtfpI";
        # else
        public static string SiscoBaseAddressApi = "http://pgchome.g21express.com/sisco/";
        public static string SiscoTokenApi = "uVoJtAJdQCEEtY+b6+T7T7bfPQrdyz8XUSvZNUD+E7v4N4AktArie8cm00wdtfpI";
        # endif

        public struct PrinterSettings
        {
            public string DotMatrix { get; set; }
            public string Barcode { get; set; }
            public string InkJet { get; set; }
        }

        public struct DatabaseSettings
        {
            public string Host { get; set; }
            public string Port { get; set; }
            public string DatabaseName { get; set; }
            public string Username { get; set; }
        }

        public static PrinterSettings PrinterSetting { get; set; }
        public static PrinterSettings PrinterRangkapSetting { get; set; }
        public static DatabaseSettings DatabaseSetting { get; set; }
        public static string BackgroundImagePath { get; set; }

        // ReSharper disable once InconsistentNaming
        public static CultureInfo culture = new CultureInfo("id-ID");

        public static bool CloseOpenedForm { get; set; }

        private static IChildForm _childForm;
        public static IChildForm ChildForm
        {
            get { return _childForm; }
            set
            {
                _childForm = value;
            }
        }

        public static Foo OpenPopup(IPopup popup)
        {
            var foo = new Foo();
            if (popup != null)
            {
                ((BasePopup) popup).ShowDialog();
                
                foo.Text = popup.SelectedText;
                foo.Value = popup.SelectedValue;
            }
            else
            {
                foo.Text = "";
                foo.Value = 0;
            }

            return foo;
        }

        public static void OpenForm(Form form, Type callingClass)
        {
            OpenForm(form, false, callingClass);
        }

        public static void OpenForm(Form form, Type callingClass, string moduleName)
        {
            OpenForm(form, moduleName, false, callingClass);
        }

        public static void OpenForm(Form form, bool dialog = false, Type callingCommand = null)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == form.Name)
                {
                    if (frm.Visible) frm.Activate();
                    else frm.Visible = true;
                    return;
                }
            }

            if (form is BaseForm)
            {
                ((BaseForm)form).CallingCommand = callingCommand;
                ((BaseForm)form).AllowAccess = Authorization.IsAuthorized(callingCommand, AuthorizationAction.Access);
                ((BaseForm)form).AllowView = Authorization.IsAuthorized(callingCommand, AuthorizationAction.View);
                ((BaseForm)form).AllowViewAll = Authorization.IsAuthorized(callingCommand, AuthorizationAction.ViewAll);
                ((BaseForm)form).AllowCreate = Authorization.IsAuthorized(callingCommand, AuthorizationAction.Create);
                ((BaseForm)form).AllowEdit = Authorization.IsAuthorized(callingCommand, AuthorizationAction.Edit);
                ((BaseForm)form).AllowDelete = Authorization.IsAuthorized(callingCommand, AuthorizationAction.Delete);
                ((BaseForm)form).AllowPrint = Authorization.IsAuthorized(callingCommand, AuthorizationAction.Print);
            }
            
            ChildForm = form as IChildForm;

            if (form is IGridChildForm)
            {
                if (NavigationMenu.DetailNewStrip != null) NavigationMenu.DetailNewStrip.Visible = true;
                if (NavigationMenu.DetailDeleteStrip != null) NavigationMenu.DetailDeleteStrip.Visible = true;
                if (NavigationMenu.DetailSeparator1 != null) NavigationMenu.DetailSeparator1.Visible = true;
            }
            else
            {
                if (NavigationMenu.DetailNewStrip != null) NavigationMenu.DetailNewStrip.Visible = false;
                if (NavigationMenu.DetailDeleteStrip != null) NavigationMenu.DetailDeleteStrip.Visible = false;
                if (NavigationMenu.DetailSeparator1 != null) NavigationMenu.DetailSeparator1.Visible = false;
            }

            if (!dialog) form.Show();
            else form.ShowDialog();
        }

        public static void OpenForm(Form form, string moduleName, bool dialog = false, Type callingCommand = null)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == form.Name)
                {
                    if (frm.Visible) frm.Activate();
                    else frm.Visible = true;
                    return;
                }
            }

            if (form is BaseForm)
            {
                ((BaseForm)form).CallingCommand = callingCommand;
                ((BaseForm)form).AllowAccess = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.Access, moduleName);
                ((BaseForm)form).AllowView = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.View, moduleName);
                ((BaseForm)form).AllowViewAll = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.ViewAll, moduleName);
                ((BaseForm)form).AllowCreate = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.Create, moduleName);
                ((BaseForm)form).AllowEdit = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.Edit, moduleName);
                ((BaseForm)form).AllowDelete = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.Delete, moduleName);
                ((BaseForm)form).AllowPrint = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.Print, moduleName);
            }

            ChildForm = form as IChildForm;

            if (form is IGridChildForm)
            {
                if (NavigationMenu.DetailNewStrip != null) NavigationMenu.DetailNewStrip.Visible = true;
                if (NavigationMenu.DetailDeleteStrip != null) NavigationMenu.DetailDeleteStrip.Visible = true;
                if (NavigationMenu.DetailSeparator1 != null) NavigationMenu.DetailSeparator1.Visible = true;
            }
            else
            {
                if (NavigationMenu.DetailNewStrip != null) NavigationMenu.DetailNewStrip.Visible = false;
                if (NavigationMenu.DetailDeleteStrip != null) NavigationMenu.DetailDeleteStrip.Visible = false;
                if (NavigationMenu.DetailSeparator1 != null) NavigationMenu.DetailSeparator1.Visible = false;
            }

            if (!dialog) form.Show();
            else form.ShowDialog();
        }

        public static void OpenRelatedForm(IChildForm form, string code, Type callingCommand)
        {
            FormCollection fc = Application.OpenForms;
            CloseOpenedForm = CloseOpenedForm == null ? false : CloseOpenedForm;
            foreach (Form frm in fc)
            {
                if (frm.Name == "MainForm") ((Form)form).MdiParent = frm;
                if (frm.Name == ((Form)form).Name)
                {
                    if (CloseOpenedForm)
                    {
                        frm.Close();
                        CloseOpenedForm = false;
                        break;
                    }
                    else
                    {
                        if (frm.Visible) frm.Activate();
                        else frm.Visible = true;
                        if (!string.IsNullOrEmpty(code)) ((IChildForm)frm).OpenData(code);
                        return;
                    }
                }
            }

            if (form is BaseForm)
            {
                ((BaseForm)form).CallingCommand = callingCommand;
                ((BaseForm)form).AllowAccess = Authorization.IsAuthorized(callingCommand, AuthorizationAction.Access);
                ((BaseForm)form).AllowView = Authorization.IsAuthorized(callingCommand, AuthorizationAction.View);
                ((BaseForm)form).AllowViewAll = Authorization.IsAuthorized(callingCommand, AuthorizationAction.ViewAll);
                ((BaseForm)form).AllowCreate = Authorization.IsAuthorized(callingCommand, AuthorizationAction.Create);
                ((BaseForm)form).AllowEdit = Authorization.IsAuthorized(callingCommand, AuthorizationAction.Edit);
                ((BaseForm)form).AllowDelete = Authorization.IsAuthorized(callingCommand, AuthorizationAction.Delete);
                ((BaseForm)form).AllowPrint = Authorization.IsAuthorized(callingCommand, AuthorizationAction.Print);
            }

            ChildForm = form;

            if (form is IGridChildForm)
            {
                NavigationMenu.DetailNewStrip.Visible = true;
                NavigationMenu.DetailDeleteStrip.Visible = true;
                NavigationMenu.DetailSeparator1.Visible = true;
            }
            else
            {
                NavigationMenu.DetailNewStrip.Visible = false;
                NavigationMenu.DetailDeleteStrip.Visible = false;
                NavigationMenu.DetailSeparator1.Visible = false;
            }
            
            ((Form)form).Show();
            if (!string.IsNullOrEmpty(code)) form.OpenData(code);
        }

        public static void OpenRelatedForm(IChildForm form, string code, Type callingCommand, string moduleName)
        {
            FormCollection fc = Application.OpenForms;
            CloseOpenedForm = CloseOpenedForm == null ? false : CloseOpenedForm;
            foreach (Form frm in fc)
            {
                if (frm.Name == "MainForm") ((Form)form).MdiParent = frm;
                if (frm.Name == ((Form)form).Name)
                {
                    if (CloseOpenedForm)
                    {
                        frm.Close();
                        CloseOpenedForm = false;
                        break;
                    }
                    else
                    {
                        if (frm.Visible) frm.Activate();
                        else frm.Visible = true;
                        if (!string.IsNullOrEmpty(code)) ((IChildForm)frm).OpenData(code);
                        return;
                    }
                }
            }

            if (form is BaseForm)
            {
                ((BaseForm)form).CallingCommand = callingCommand;
                ((BaseForm)form).AllowAccess = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.Access, moduleName);
                ((BaseForm)form).AllowView = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.View, moduleName);
                ((BaseForm)form).AllowViewAll = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.ViewAll, moduleName);
                ((BaseForm)form).AllowCreate = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.Create, moduleName);
                ((BaseForm)form).AllowEdit = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.Edit, moduleName);
                ((BaseForm)form).AllowDelete = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.Delete, moduleName);
                ((BaseForm)form).AllowPrint = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.Print, moduleName);
            }

            ChildForm = form;

            if (form is IGridChildForm)
            {
                NavigationMenu.DetailNewStrip.Visible = true;
                NavigationMenu.DetailDeleteStrip.Visible = true;
                NavigationMenu.DetailSeparator1.Visible = true;
            }
            else
            {
                NavigationMenu.DetailNewStrip.Visible = false;
                NavigationMenu.DetailDeleteStrip.Visible = false;
                NavigationMenu.DetailSeparator1.Visible = false;
            }

            ((Form)form).Show();
            if (!string.IsNullOrEmpty(code)) form.OpenData(code);
        }

        public static void OpenDataEntryFranchiseForm(IChildForm form, string code, Type callingCommand, string moduleName)
        {
            FormCollection fc = Application.OpenForms;
            
            foreach (Form frm in fc)
            {
                if (frm.Name == "MainForm") ((Form)form).MdiParent = frm;
                if (frm.Name == ((Form)form).Name)
                {
                    if (frm.Visible) frm.Activate();
                    else frm.Visible = true;

                    ((IChildForm)frm).New();
                    ((IChildForm)frm).SetNoPod(code);
                    return;
                }
            }

            if (form is BaseForm)
            {
                ((BaseForm)form).CallingCommand = callingCommand;
                ((BaseForm)form).AllowAccess = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.Access, moduleName);
                ((BaseForm)form).AllowView = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.View, moduleName);
                ((BaseForm)form).AllowViewAll = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.ViewAll, moduleName);
                ((BaseForm)form).AllowCreate = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.Create, moduleName);
                ((BaseForm)form).AllowEdit = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.Edit, moduleName);
                ((BaseForm)form).AllowDelete = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.Delete, moduleName);
                ((BaseForm)form).AllowPrint = Authorization.IsAuthorized(callingCommand.Name, AuthorizationAction.Print, moduleName);
            }

            ChildForm = form;

            if (form is IGridChildForm)
            {
                NavigationMenu.DetailNewStrip.Visible = true;
                NavigationMenu.DetailDeleteStrip.Visible = true;
                NavigationMenu.DetailSeparator1.Visible = true;
            }
            else
            {
                NavigationMenu.DetailNewStrip.Visible = false;
                NavigationMenu.DetailDeleteStrip.Visible = false;
                NavigationMenu.DetailSeparator1.Visible = false;
            }

            ((Form)form).Show();
            ((IChildForm)form).New();
            ((IChildForm)form).SetNoPod(code);
        }

        public static void New()
        {
            ChildForm.New();
        }

        public static void Save()
        {
            ChildForm.Save();
        }

        public static void Delete()
        {
            ChildForm.Delete();
        }

        public static void Top()
        {
            ChildForm.Top();
        }

        public static void Previous()
        {
            ChildForm.Previous();
        }

        public static void Next()
        {
            ChildForm.Next();
        }

        public static void Bottom()
        {
            ChildForm.Bottom();
        }

        public static void Find()
        {
            ChildForm.Find();
        }

        public static void Refresh()
        {
            ChildForm.Refresh();
        }

        public static void Close()
        {
            ChildForm.CloseForm();
        }

        internal static void Print()
        {
            var form = ChildForm as BaseForm;
            if (form != null)
            {
                form.Print();
            }
        }

        internal static void DetailNew()
        {
            var form = ChildForm as IGridChildForm;
            if (form != null)
            {
                form.DetailNew();
            }
        }

        internal static void DetailDelete()
        {
            var form = ChildForm as IGridChildForm;
            if (form != null)
            {
                form.DetailDelete();
            }
        }

        public static int DepartmentId { get; set; }

        private static string _connAppsLocation = "connapps.xml";
        public static string ConnAppsLocation
        {
            get
            {
                if (!ApplicationDeployment.IsNetworkDeployed)
                {
                    return _connAppsLocation;
                }

                var localConnAppsLocation = Path.Combine(ApplicationDeployment.CurrentDeployment.DataDirectory, _connAppsLocation);

                if (!File.Exists(localConnAppsLocation))
                {
                    File.Copy(_connAppsLocation, localConnAppsLocation);
                }

                return localConnAppsLocation;
            }
        }

        private static string _printerconfigLocation = "printerconfig.xml";
        public static string PrinterConfigLocation
        {
            get
            {
                if (!ApplicationDeployment.IsNetworkDeployed)
                {
                    return _printerconfigLocation;
                }

                var localConnAppsLocation = Path.Combine(ApplicationDeployment.CurrentDeployment.DataDirectory, _printerconfigLocation);

                if (!File.Exists(localConnAppsLocation))
                {
                    File.Copy(_printerconfigLocation, localConnAppsLocation);
                }

                return localConnAppsLocation;
            }
        }

        private static string _changedLogLocation = "changedlog.txt";
        public static string ChangedLogLocation
        {
            get
            {
                if (!ApplicationDeployment.IsNetworkDeployed)
                {
                    return _changedLogLocation;
                }

                var localchangedlog = Path.Combine(ApplicationDeployment.CurrentDeployment.DataDirectory, _changedLogLocation);
                File.Copy(_changedLogLocation, localchangedlog, true);
                return localchangedlog;
            }
        }
    }

    public class Foo
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
}
