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
using System.Security.Cryptography;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using MySql.Data.MySqlClient;
using SISCO.Models;
using SISCO.Repositories.Context;

namespace SISCO.Repositories
{
    public class ComplaintRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Complaint";
        public ComplaintRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public ComplaintRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as ComplaintModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTocomplaints(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as ComplaintModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.complaints where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as ComplaintModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.complaints select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.complaints where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.complaints where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static complaint PopulateModelToNewEntity(ComplaintModel model)
		{
			return new complaint
			{
				id = model.Id,
				vdate = model.Vdate,
				branch_id = model.BranchId,
				employee_id = model.EmployeeId,
				complaint_branch_id = model.ComplaintBranchId,
				customer_id = model.CustomerId,
				customer_name = model.CustomerName,
				customer_phone = model.CustomerPhone,
                customer_contact = model.CustomerContact,
                ref_code = model.RefCode,
                shipment_id = model.ShipmentId,
				complaint_category_id = model.ComplaintCategoryId,
				note = model.Note,
				status = model.Status,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(complaint query, ComplaintModel model)
		{
			query.id = model.Id;
			query.vdate = model.Vdate;
			query.branch_id = model.BranchId;
			query.employee_id = model.EmployeeId;
			query.complaint_branch_id = model.ComplaintBranchId;
			query.customer_id = model.CustomerId;
			query.customer_name = model.CustomerName;
			query.customer_phone = model.CustomerPhone;
            query.customer_contact = model.CustomerContact;
            query.ref_code = model.RefCode;
            query.shipment_id = model.ShipmentId;
			query.complaint_category_id = model.ComplaintCategoryId;
			query.note = model.Note;
			query.status = model.Status;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static ComplaintModel PopulateEntityToNewModel(complaint item)
		{
			return new ComplaintModel
			{
				Id = item.id,
				Vdate = item.vdate,
				BranchId = item.branch_id,
				EmployeeId = item.employee_id,
				ComplaintBranchId = item.complaint_branch_id,
				CustomerId = item.customer_id,
				CustomerName = item.customer_name,
				CustomerPhone = item.customer_phone,
                CustomerContact = item.customer_contact,
                RefCode = item.ref_code,
                ShipmentId = item.shipment_id,
				ComplaintCategoryId = item.complaint_category_id,
				Note = item.note,
				Status = item.status,
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
			var query = (from a in Entities.complaints select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.complaints select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.complaints select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.complaints select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> GetComplaintSummary<T>(DateTime? fromDate, DateTime? toDate, int? branchId, int? originCityId, int? destinationCityId)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("c.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(c.vdate) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(c.vdate) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            if (branchId != null && branchId != 0)
            {
                whereClauses.Add("c.branch_id = @branchId");
                parameters.Add(new MySqlParameter("branchId", branchId));
            }

            if (originCityId != null && originCityId != 0)
            {
                whereClauses.Add("s.city_id = @originCityId");
                parameters.Add(new MySqlParameter("originCityId", originCityId));
            }

            if (destinationCityId != null && destinationCityId != 0)
            {
                whereClauses.Add("s.dest_city_id = @destinationCityId");
                parameters.Add(new MySqlParameter("destinationCityId", destinationCityId));
            }

            string sql = @"SELECT c.date_process,
                                b.code as branch,
                                IFNULL(oc.name, 'Unknown') as origin_city,
                                IFNULL(dc.name, 'Unknown') as destination_city,
                                c.total_complaint_count,
                                c.open_complaint_count,
                                c.closed_complaint_count,
                                CASE WHEN (0 = c.total_complaint_count) THEN (0)  ELSE (c.open_complaint_count / c.total_complaint_count) END AS open_complaint_percent,
                                CASE WHEN (0 = c.total_complaint_count) THEN (0)  ELSE (c.closed_complaint_count / c.total_complaint_count) END AS closed_complaint_percent
                        FROM (
                            SELECT DATE(c.vdate) AS date_process,
                                    c.branch_id AS branch_id,
                                    s.city_id,
                                    s.dest_city_id,
                                    COUNT(1) AS total_complaint_count,
                                    SUM(c.status = 0) AS open_complaint_count,
                                    SUM(c.status = 1) AS closed_complaint_count
                            FROM complaint c
                            LEFT JOIN shipment s ON s.id = c.shipment_id
                            WHERE " + string.Join(" AND ", whereClauses) + @"
                            GROUP BY DATE(c.vdate), c.branch_id, s.city_id, s.dest_city_id
                        ) c
                        JOIN branch b ON b.id = c.branch_id
                        LEFT JOIN city oc ON oc.id = c.city_id
                        LEFT JOIN city dc ON dc.id = c.dest_city_id";

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }
    }
}


