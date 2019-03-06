using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Transactions;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;

namespace SISCO.Repositories
{
    public class CorporateUserPrivilegeRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "CorporateUserPrivilege";
        public CorporateUserPrivilegeRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public CorporateUserPrivilegeRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as CorporateUserPrivilegeModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddTocorporate_user_priviledge(entity);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as CorporateUserPrivilegeModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.corporate_user_priviledge where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as CorporateUserPrivilegeModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.corporate_user_priviledge select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.corporate_user_priviledge where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.corporate_user_priviledge where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static corporate_user_priviledge PopulateModelToNewEntity(CorporateUserPrivilegeModel model)
        {
            return new corporate_user_priviledge
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                corporate_user_id = model.CorporateUserId,
                module_name = model.ModuleName,
                form_name = model.FormName,
                allow_access = model.AllowAccess,
                allow_view = model.AllowView,
                allow_view_all = model.AllowViewAll,
                allow_create = model.AllowCreate,
                allow_edit = model.AllowEdit,
                allow_delete = model.AllowDelete,
                allow_print = model.AllowPrint,
                createddate = model.Createddate,
                createdby = model.Createdby,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
            };
        }

        private static void PopulateModelToNewEntity(corporate_user_priviledge query, CorporateUserPrivilegeModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.corporate_user_id = model.CorporateUserId;
            query.module_name = model.ModuleName;
            query.form_name = model.FormName;
            query.allow_access = model.AllowAccess;
            query.allow_view = model.AllowView;
            query.allow_view_all = model.AllowViewAll;
            query.allow_create = model.AllowCreate;
            query.allow_edit = model.AllowEdit;
            query.allow_delete = model.AllowDelete;
            query.allow_print = model.AllowPrint;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
        }

        private static CorporateUserPrivilegeModel PopulateEntityToNewModel(corporate_user_priviledge item)
        {
            return new CorporateUserPrivilegeModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                CorporateUserId = item.corporate_user_id,
                ModuleName = item.module_name,
                FormName = item.form_name,
                AllowAccess = item.allow_access,
                AllowView = item.allow_view,
                AllowViewAll = item.allow_view_all,
                AllowCreate = item.allow_create,
                AllowEdit = item.allow_edit,
                AllowDelete = item.allow_delete,
                AllowPrint = item.allow_print,
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby,

            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.corporate_user_priviledge select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.corporate_user_priviledge select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.corporate_user_priviledge select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.corporate_user_priviledge select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public void Save(int corporateUserId, IList<CorporateUserPrivilegeModel> models)
        {
            using (var scope = new TransactionScope())
            {
                Entities.ExecuteStoreCommand("DELETE FROM corporate_user_priviledge WHERE corporate_user_id = {0}", corporateUserId);

                for (var i = 0; i < models.Count(); i++)
                {
                    var model = models[i] as CorporateUserPrivilegeModel;
                    if (model == null)
                        throw new ModelNullException();

                    model.CorporateUserId = corporateUserId;

                    var entity = PopulateModelToNewEntity(model);
                    Entities.AddTocorporate_user_priviledge(entity);
                }

                Entities.SaveChanges();

                scope.Complete();
            }
        }

        public void DeletePriviledge(int corporateUserId)
        {
            using (var scope = new TransactionScope())
            {
                Entities.ExecuteStoreCommand("DELETE FROM corporate_user_priviledge WHERE corporate_user_id = {0}", corporateUserId);
                Entities.SaveChanges();

                scope.Complete();
            }
        }
    }
}