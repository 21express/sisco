using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Corporate.Presentation.Common.Forms;
using Corporate.Presentation.Common.Interfaces;
using Corporate.Presentation.Common.Properties;
using Corporate.Presentation.Common.ViewModel;

namespace Corporate.Presentation.Common
{
    public class BaseControl
    {
        public static int UserId { get; set; }
        public static string UserLogin { get; set; }
        public static int CorporateId { get; set; }
        public static string CorporateName { get; set; }
        public static int BranchId { get; set; }
        public static string BranchCode { get; set; }
        public static int CityId { get; set; }
        public static string CityName { get; set; }
        public static int CountryId { get; set; }
        public static string CountryName { get; set; }

        public static bool ExitApp { get; set; }

        public static string ClientId { get { return "b390a9fb4ef3f3b205e49820218b3331"; } }
        public static string ClientSecret { get { return "d078f6700d8e1f085a71d37566afac9e"; } }
        public static string APIUsername { get { return "franchise_api_user_990028"; } }
        public static string APIPassword { get { return "[i;phsfimh"; } }
        public static string AccessToken { get; set; }

        public const decimal GoodValuesInsurance = (decimal)0.002;
        public const int GoodValuesAdministration = 5000;
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

        # if (!DEBUG)
        private static string BaseAddress { get { return "http://119.110.72.234/"; } }
        public static string UrlAPiAccessToken { get { return "api/oauth/access_token"; } }
        public static string UrlAPiCustomer { get { return "api/v1/customer/validation"; } }
        # else
        private static string BaseAddress { get { return "http://119.110.72.234/"; } }
        public static string UrlAPiAccessToken { get { return "api/oauth/access_token"; } }
        public static string UrlAPiCustomer { get { return "api/v1/customer/validation"; } }
        # endif

        private static string _corporateConfigLocation = "corporateconfig.xml";
        public static string CorporateConfigLocation
        {
            get
            {
                if (!ApplicationDeployment.IsNetworkDeployed)
                {
                    return _corporateConfigLocation;
                }

                var localConnAppsLocation = Path.Combine(ApplicationDeployment.CurrentDeployment.DataDirectory, _corporateConfigLocation);

                if (!File.Exists(localConnAppsLocation))
                {
                    File.Copy(_corporateConfigLocation, localConnAppsLocation);
                }

                return localConnAppsLocation;
            }
        }

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
        public static DatabaseSettings DatabaseSetting { get; set; }

        public static IChildForm ChildForm;

        public static void OpenForm(Form form, Type callingClass)
        {
            OpenForm(form, false, callingClass);
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

            if (!dialog) form.Show();
            else form.ShowDialog();
        }

        public static void OpenRelatedForm(IChildForm form, string code, Type callingCommand)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == "MainForm") ((Form)form).MdiParent = frm;
                if (frm.Name == ((Form)form).Name)
                {
                    if (frm.Visible) frm.Activate();
                    else frm.Visible = true;
                    if (!string.IsNullOrEmpty(code)) ((IChildForm)frm).OpenData(code);
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

            ChildForm = form;

            ((Form)form).Show();
            if (!string.IsNullOrEmpty(code)) form.OpenData(code);
        }

        public static void GetToken()
        {
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"), 
                new KeyValuePair<string, string>("client_id", ClientId), 
                new KeyValuePair<string, string>("client_secret", ClientSecret),
                new KeyValuePair<string, string>("username", APIUsername),
                new KeyValuePair<string, string>("password", APIPassword)
            });

            var client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddress);
            var task = client.PostAsync(UrlAPiAccessToken, formContent).ContinueWith((s) =>
            {
                var response = s.Result;
                var jsonResponse = response.Content.ReadAsStringAsync();
                jsonResponse.Wait();

                var jsonConvert = new JavaScriptSerializer();
                var actionResult = jsonConvert.Deserialize<AccessTokenViewModel>(jsonResponse.Result);
                if (actionResult != null)
                {
                    if (string.IsNullOrEmpty(actionResult.error)) AccessToken = actionResult.access_token;
                    else
                    {
                        MessageBox.Show(actionResult.error, Resources.title_information);
                        Application.Exit();
                    }
                }
                else
                {
                    MessageBox.Show(Resources.contact_it_support, Resources.title_information);
                    Application.Exit();
                }
            });

            task.Wait();
        }

        public static CorporateViewModel GetProductKey(string productKey)
        {
            var result = new CorporateViewModel();
            var client = new HttpClient();
            client.BaseAddress = new Uri(BaseAddress);
            var uri = string.Format("{0}?access_token={1}&product_key={2}", UrlAPiCustomer, AccessToken, HttpUtility.UrlEncode(productKey));
            var task = client.GetAsync(uri).ContinueWith((s) =>
            {
                var response = s.Result;
                var jsonResponse = response.Content.ReadAsStringAsync();
                jsonResponse.Wait();

                var jsonConvert = new JavaScriptSerializer();
                var actionResult = jsonConvert.Deserialize<CorporateViewModel>(jsonResponse.Result);
                if (actionResult != null)
                {
                    result = actionResult;
                }
            });

            task.Wait();

            return result;
        }
    }
}