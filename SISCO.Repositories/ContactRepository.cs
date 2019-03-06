

/* 
*  SOLUTION 	: WaterManagementSolution
*  PROJECT		: Pdam.Common
*  TYPE 		: Generated - Data Access Repository
*  CREATED BY	: K
*  CREATED DATE	: Wednesday, May 21, 2014
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;

namespace SISCO.Repositories
{
    public class ContactRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "Contact";
        public ContactRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public ContactRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as ContactModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTocontacts(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as ContactModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.contacts where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as ContactModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.contacts select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.contacts where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.contacts where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static contact PopulateModelToNewEntity(ContactModel model)
		{
			return new contact
			{
				id = model.Id,
				vdate = model.Vdate,
				company_name = model.CompanyName,
				company_address = model.CompanyAddress,
				company_phone = model.CompanyPhone,
				branch_id = model.BranchId,
				customer_id = model.CustomerId,
				marketing_id = model.MarketingId,
				contact_name = model.ContactName,
				contact_phone = model.ContactPhone,
				contact_email = model.ContactEmail,
				note = model.Note,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(contact query, ContactModel model)
		{
			query.id = model.Id;
			query.vdate = model.Vdate;
			query.company_name = model.CompanyName;
			query.company_address = model.CompanyAddress;
			query.company_phone = model.CompanyPhone;
			query.branch_id = model.BranchId;
			query.customer_id = model.CustomerId;
			query.marketing_id = model.MarketingId;
			query.contact_name = model.ContactName;
			query.contact_phone = model.ContactPhone;
			query.contact_email = model.ContactEmail;
			query.note = model.Note;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static ContactModel PopulateEntityToNewModel(contact item)
		{
			return new ContactModel
			{
				Id = item.id,
				Vdate = item.vdate,
				CompanyName = item.company_name,
				CompanyAddress = item.company_address,
				CompanyPhone = item.company_phone,
				BranchId = item.branch_id,
				CustomerId = item.customer_id,
				MarketingId = item.marketing_id,
				ContactName = item.contact_name,
				ContactPhone = item.contact_phone,
				ContactEmail = item.contact_email,
				Note = item.note,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.contacts select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.contacts select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.contacts select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.contacts select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).Cast<ContactModel>().ToList();
		}        
       
    }
}


