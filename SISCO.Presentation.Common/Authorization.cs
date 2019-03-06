using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic;
using System.Windows.Forms;
using Devenlab.Common;
using DevExpress.Data.PLinq.Helpers;
using SISCO.App.MasterData;
using SISCO.Models;

namespace SISCO.Presentation.Common
{
    public enum AuthorizationAction
    {
        Access,
        View,
        ViewAll,
        Create,
        Edit,
        Delete,
        Print
    }

    public class Authorization
    {
        private static List<UserPrivilegeModel> _privileges;

        protected static List<UserPrivilegeModel> Privileges
        {
            get
            {
                if (_privileges == null)
                {
                    _privileges = GetPrivileges();
                }

                return _privileges;
            }
        }

        public static int RoleId { get; set; }

        public static void FilterToolstripMenu(ToolStripItemCollection items)
        {
            foreach (var item in items)
            {
                if (item is ToolStripMenuItem)
                {
                    FilterToolstripMenu(((ToolStripMenuItem)item).DropDownItems);
                }
                if (item is MenuCommand)
                {
                    var menuInvokerType = ((MenuCommand) item).MenuInvoker.GetType();
                    var module = GetModuleFromNameSpace(menuInvokerType.Namespace);

                    ((MenuCommand) item).Enabled = Privileges.Any(
                        o => o.AllowAccess && o.ModuleName == module && o.FormName == menuInvokerType.Name);
                }
            }
        }

        private static string GetModuleFromNameSpace(string ns)
        {
            var parts = ns.Split('.');

            return parts.Length > 2 ? parts[2] : "";
        }

        public static bool IsAuthorized(Type callerClass, AuthorizationAction action)
        {
            return IsAuthorized(callerClass.Name, action);
        }

        public static bool IsAuthorized(string callerClass, AuthorizationAction action)
        {
            var q = Privileges.Where(r => r.FormName == callerClass);

            switch (action)
            {
                case AuthorizationAction.Access:
                    return q.Any(r => r.AllowAccess);
                case AuthorizationAction.View:
                    return q.Any(r => r.AllowView);
                case AuthorizationAction.ViewAll:
                    return q.Any(r => r.AllowViewAll);
                case AuthorizationAction.Create:
                    return q.Any(r => r.AllowCreate);
                case AuthorizationAction.Edit:
                    return q.Any(r => r.AllowEdit);
                case AuthorizationAction.Delete:
                    return q.Any(r => r.AllowDelete);
                case AuthorizationAction.Print:
                    return q.Any(r => r.AllowPrint);
            }

            return false;
        }

        public static bool IsAuthorized(string callerClass, AuthorizationAction action, string moduleName)
        {
            var q = Privileges.Where(r => r.FormName == callerClass);

            switch (action)
            {
                case AuthorizationAction.Access:
                    return q.Any(r => r.AllowAccess && r.ModuleName == moduleName);
                case AuthorizationAction.View:
                    return q.Any(r => r.AllowView && r.ModuleName == moduleName);
                case AuthorizationAction.ViewAll:
                    return q.Any(r => r.AllowViewAll && r.ModuleName == moduleName);
                case AuthorizationAction.Create:
                    return q.Any(r => r.AllowCreate && r.ModuleName == moduleName);
                case AuthorizationAction.Edit:
                    return q.Any(r => r.AllowEdit && r.ModuleName == moduleName);
                case AuthorizationAction.Delete:
                    return q.Any(r => r.AllowDelete && r.ModuleName == moduleName);
                case AuthorizationAction.Print:
                    return q.Any(r => r.AllowPrint && r.ModuleName == moduleName);
            }

            return false;
        }

        private static List<UserPrivilegeModel> GetPrivileges()
        {
            using (var dm = new UserPrivilegeDataManager())
            {
                return dm.Get<UserPrivilegeModel>(WhereTerm.Default(RoleId, "role_id")).ToList();
            }
        }

        public static void Reset()
        {
            RoleId = 0;
            _privileges = null;
        }

        public static void SetRole(int roleId)
        {
            RoleId = roleId;
            _privileges = null;
        }

        public static void ClearPrivileges()
        {
            _privileges = null;
        }
    }
}
