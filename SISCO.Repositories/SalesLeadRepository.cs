

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
using MySql.Data.MySqlClient;
using SISCO.Models;
using SISCO.Repositories.Context;

namespace SISCO.Repositories
{
    public class SalesLeadRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "SalesLead";
        public SalesLeadRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public SalesLeadRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as SalesLeadModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTosales_lead(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as SalesLeadModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.sales_lead where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as SalesLeadModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.sales_lead select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.sales_lead where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.sales_lead where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static sales_lead PopulateModelToNewEntity(SalesLeadModel model)
		{
			return new sales_lead
			{
				id = model.Id,
				vdate = model.Vdate,
				marketing_id = model.MarketingId,
				employee_id = model.EmployeeId,
				customer_id = model.CustomerId,
				contact_id = model.ContactId,
				contact_name = model.ContactName,
				contact_phone = model.ContactPhone,
				contact_email = model.ContactEmail,
				note = model.Note,
                follow_ups_count = model.FollowUpsCount,
                last_lead_status_id = model.LastLeadStatusId,
                last_follow_up_date = model.LastFollowUpDate,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(sales_lead query, SalesLeadModel model)
		{
			query.id = model.Id;
			query.vdate = model.Vdate;
			query.marketing_id = model.MarketingId;
			query.employee_id = model.EmployeeId;
			query.customer_id = model.CustomerId;
			query.contact_id = model.ContactId;
			query.contact_name = model.ContactName;
			query.contact_phone = model.ContactPhone;
			query.contact_email = model.ContactEmail;
			query.note = model.Note;
            query.follow_ups_count = model.FollowUpsCount;
            query.last_lead_status_id = model.LastLeadStatusId;
            query.last_follow_up_date = model.LastFollowUpDate;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static SalesLeadModel PopulateEntityToNewModel(sales_lead item)
		{
			return new SalesLeadModel
			{
				Id = item.id,
				Vdate = item.vdate,
				MarketingId = item.marketing_id,
				EmployeeId = item.employee_id,
				CustomerId = item.customer_id,
				ContactId = item.contact_id,
				ContactName = item.contact_name,
				ContactPhone = item.contact_phone,
				ContactEmail = item.contact_email,
				Note = item.note,
                FollowUpsCount = item.follow_ups_count,
                LastLeadStatusId = item.last_lead_status_id,
                LastFollowUpDate = item.last_follow_up_date,
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
			var query = (from a in Entities.sales_lead select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.sales_lead select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.sales_lead select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.sales_lead select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> GetLeadsSummary<T>(DateTime? fromDate, DateTime? toDate, int? customerId, int? contactId, int? branchId, int? marketingId, int? salesLeadStatusId)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("l.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(l.vdate) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(l.vdate) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            if (customerId != null && customerId != 0)
            {
                whereClauses.Add("l.customer_id >= @customerId");
                parameters.Add(new MySqlParameter("customerId", customerId));
            }

            if (contactId != null && contactId != 0)
            {
                whereClauses.Add("l.contact_id <= @contactId");
                parameters.Add(new MySqlParameter("contactId", contactId));
            }

            if (branchId != null && branchId != 0)
            {
                whereClauses.Add("e.branch_id <= @branchId");
                parameters.Add(new MySqlParameter("branchId", branchId));
            }

            if (marketingId != null && marketingId != 0)
            {
                whereClauses.Add("l.marketing_id <= @marketingId");
                parameters.Add(new MySqlParameter("marketingId", marketingId));
            }

            if (salesLeadStatusId != null && salesLeadStatusId > 0)
            {
                whereClauses.Add("l.last_lead_status_id <= @salesLeadStatusId");
                parameters.Add(new MySqlParameter("salesLeadStatusId", salesLeadStatusId));
            }

            string sql = @"SELECT l.id,
                                l.employee_id as marketing_id,
                                e.name as marketing_name,
                                l.vdate,
                                l.contact_name,
                                sls.name as last_lead_status,
                                l.follow_ups_count,
                                l.last_follow_up_date,
                                IF(l.last_lead_status_id = 1, 1, 0) as is_open,
                                IF(l.last_lead_status_id = 2, 1, 0) as is_success,
                                IF(l.last_lead_status_id = 3, 1, 0) as is_failed
                        FROM sales_lead l
                        LEFT JOIN employee AS e ON e.id = l.marketing_id
                        LEFT JOIN sales_lead_status AS sls ON sls.id = l.last_lead_status_id
                        WHERE " + string.Join(" AND ", whereClauses) + @"
                        ORDER BY l.last_follow_up_date ASC";

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }
    }
}


