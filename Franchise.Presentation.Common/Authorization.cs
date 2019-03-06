using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using SISCO.App.Franchise;
using SISCO.Models;

namespace Franchise.Presentation.Common
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
        private static List<FranchiseUserPrivilegeModel> _privileges;

        protected static List<FranchiseUserPrivilegeModel> Privileges
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

        public static int FranchiseUserId { get; set; }

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

        private static List<FranchiseUserPrivilegeModel> GetPrivileges()
        {
            using (var dm = new FranchiseUserPrivilegeDataManager())
            {
                return dm.Get<FranchiseUserPrivilegeModel>(WhereTerm.Default(FranchiseUserId, "franchise_user_id")).ToList();
            }
        }

        public static void Reset()
        {
            FranchiseUserId = 0;
            _privileges = null;
        }

        public static void SetFranchseUserId(int userId)
        {
            FranchiseUserId = userId;
            _privileges = null;
        }

        public static void ClearPrivileges()
        {
            _privileges = null;
        }
    }
}
