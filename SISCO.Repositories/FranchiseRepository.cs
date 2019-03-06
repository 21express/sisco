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
    public class FranchiseRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "Franchise";
        public FranchiseRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public FranchiseRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as FranchiseModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddTofranchises(entity);
            Entities.SaveChanges();

            businessModel.Id = entity.id;
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as FranchiseModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from f in Entities.franchises where f.id == model.Id select f).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as FranchiseModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from f in Entities.franchises select f).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        private static franchise PopulateModelToNewEntity(FranchiseModel model)
        {
            return new franchise
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                code = model.Code,
                branch_id = model.BranchId,
                name = model.Name,
                address = model.Address,
                city_id = model.CityId,
                zip = model.ZipCode,
                phone = model.Phone,
                email = model.Email,
                contact_person = model.ContactPerson,
                contact_email = model.ContactEmail,
                contact_phone = model.ContactPhone,
                commission = model.Commission,
                product_key = model.ProductKey,
                active_flag = model.ActiveFlag,
                org_type = model.OrgType,
                npwp = model.NPWP,
                npwp_name = model.NPWPName,
                payment_method_id = model.PaymentMethodId,
                credit = model.Credit,
                createddate = model.Createddate,
                createdby = model.Createdby,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
            };
        }

        private static void PopulateModelToNewEntity(franchise query, FranchiseModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.code = model.Code;
            query.branch_id = model.BranchId;
            query.name = model.Name;
            query.address = model.Address;
            query.city_id = model.CityId;
            query.zip = model.ZipCode;
            query.phone = model.Phone;
            query.email = model.Email;
            query.contact_person = model.ContactPerson;
            query.contact_email = model.ContactEmail;
            query.contact_phone = model.ContactPhone;
            query.commission = model.Commission;
            query.product_key = model.ProductKey;
            query.active_flag = model.ActiveFlag;
            query.org_type = model.OrgType;
            query.npwp = model.NPWP;
            query.npwp_name = model.NPWPName;
            query.payment_method_id = model.PaymentMethodId;
            query.credit = model.Credit;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
        }

        private static FranchiseModel PopulateEntityToNewModel(franchise item)
        {
            return new FranchiseModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                Code = item.code,
                BranchId = item.branch_id,
                Name = item.name,
                Address = item.address,
                CityId = item.city_id,
                ZipCode = item.zip,
                Phone = item.phone,
                Email = item.email,
                ContactPerson = item.contact_person,
                ContactEmail = item.contact_email,
                ContactPhone = item.contact_phone,
                Commission = item.commission,
                ProductKey = item.product_key,
                ActiveFlag = item.active_flag,
                OrgType = item.org_type,
                NPWP = item.npwp,
                NPWPName = item.npwp_name,
                PaymentMethodId = item.payment_method_id,
                Credit = item.credit,
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby
            };
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from f in Entities.franchises where f.id == id select f).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from f in Entities.franchises where f.id == id select f).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchises select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchises select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchises select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchises select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public string GenerateCode(FranchiseModel model)
        {
            var branchCode = (from a in Entities.branches
                              where a.id == model.BranchId
                              select a.code).FirstOrDefault();

            var pattern = string.Format("{0}###-{1}", model.Name[0], branchCode);

            return GenerateCode("franchise", pattern);
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.franchises select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchises select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }
    }
}
