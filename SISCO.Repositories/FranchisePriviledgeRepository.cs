using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using SISCO.Repositories.Interfaces;

namespace SISCO.Repositories
{
    public class FranchisePriviledgeRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "FranchisePriviledge";
        public FranchisePriviledgeRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public FranchisePriviledgeRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as FranchisePriviledgeModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddTofranchise_priviledge(entity);
            Entities.SaveChanges();

            businessModel.Id = entity.id;
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as FranchisePriviledgeModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.franchise_priviledge where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as FranchisePriviledgeModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.franchise_priviledge select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.franchise_priviledge where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        private static franchise_priviledge PopulateModelToNewEntity(FranchisePriviledgeModel model)
        {
            return new franchise_priviledge
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                module_name = model.ModuleName,
                module_display_name = model.ModuleDisplayName,
                form_name = model.FormName,
                form_display_name = model.FormDisplayName,
                allow_access = model.AllowAccess,
                allow_view = model.AllowView,
                allow_view_all = model.AllowViewAll,
                allow_create = model.AllowCreate,
                allow_edit = model.AllowEdit,
                allow_delete = model.AllowDelete,
                allow_print = model.AllowPrint,
                order_number = model.OrderNumber,
                createddate = model.Createddate,
                createdby = model.Createdby,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
            };
        }

        private static void PopulateModelToNewEntity(franchise_priviledge query, FranchisePriviledgeModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.module_name = model.ModuleName;
            query.module_display_name = model.ModuleDisplayName;
            query.form_name = model.FormName;
            query.form_display_name = model.FormDisplayName;
            query.allow_access = model.AllowAccess;
            query.allow_view = model.AllowView;
            query.allow_view_all = model.AllowViewAll;
            query.allow_create = model.AllowCreate;
            query.allow_edit = model.AllowEdit;
            query.allow_delete = model.AllowDelete;
            query.allow_print = model.AllowPrint;
            query.order_number = model.OrderNumber;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
        }

        private static FranchisePriviledgeModel PopulateEntityToNewModel(franchise_priviledge item)
        {
            return new FranchisePriviledgeModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                ModuleName = item.module_name,
                ModuleDisplayName = item.module_display_name,
                FormName = item.form_name,
                FormDisplayName = item.form_display_name,
                AllowAccess = item.allow_access,
                AllowView = item.allow_view,
                AllowViewAll = item.allow_view_all,
                AllowCreate = item.allow_create,
                AllowEdit = item.allow_edit,
                AllowDelete = item.allow_delete,
                AllowPrint = item.allow_print,
                OrderNumber = item.order_number,
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby
            };
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.franchise_priviledge where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_priviledge select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_priviledge select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_priviledge select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_priviledge select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<T> GetJoinFranchiseUserPrivilegeByFranchiseUserId<T>(int franchiseUserId)
        {
            var query = from p in Entities.franchise_priviledge
                        from up in Entities.franchise_user_priviledge.Where(r => r.module_name == p.module_name && r.form_name == p.form_name && r.franchise_user_id == franchiseUserId && r.rowstatus).DefaultIfEmpty()
                        where p.rowstatus
                        select new FranchisePrivilegeJoinFranchiseUserPrivilegeModel
                        {
                            Id = p.id,
                            Rowstatus = p.rowstatus,
                            Rowversion = p.rowversion,

                            ModuleName = p.module_name,
                            ModuleDisplayName = p.module_display_name,
                            FormName = p.form_name,
                            FormDisplayName = p.form_display_name,
                            AllowAccess = p.allow_access,
                            AllowView = p.allow_view,
                            AllowViewAll = p.allow_view_all,
                            AllowCreate = p.allow_create,
                            AllowEdit = p.allow_edit,
                            AllowDelete = p.allow_delete,
                            AllowPrint = p.allow_print,
                            OrderNumber = p.order_number,

                            FranchiseUserId = up.franchise_user_id,
                            RoleAllowAccess = up != null && up.allow_access,
                            RoleAllowView = up != null && up.allow_view,
                            RoleAllowViewAll = up != null && up.allow_view_all,
                            RoleAllowCreate = up != null && up.allow_create,
                            RoleAllowEdit = up != null && up.allow_edit,
                            RoleAllowDelete = up != null && up.allow_delete,
                            RoleAllowPrint = up != null && up.allow_print,

                            Createddate = p.createddate,
                            Createdby = p.createdby,
                            Modifieddate = p.modifieddate,
                            Modifiedby = p.modifiedby,
                        };

            return query.ToList().Cast<T>();
        }
    }
}