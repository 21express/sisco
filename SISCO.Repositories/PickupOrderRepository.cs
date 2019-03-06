

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
using MySql.Data.MySqlClient;

namespace SISCO.Repositories
{
    public class PickupOrderRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "PickupOrder";
        public PickupOrderRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public PickupOrderRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as PickupOrderModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTopickup_order(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as PickupOrderModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.pickup_order where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as PickupOrderModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.pickup_order select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.pickup_order where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.pickup_order where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static pickup_order PopulateModelToNewEntity(PickupOrderModel model)
		{
			return new pickup_order
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				date_process = model.DateProcess,
				branch_id = model.BranchId,
				employee_id = model.EmployeeId,
				customer_id = model.CustomerId,
                frachise_id = model.FranchiseId,
                drop_point_id = model.DropPointId,
				customer_name = model.CustomerName,
				customer_address = model.CustomerAddress,
				customer_phone = model.CustomerPhone,
				customer_contact = model.CustomerContact,
                new_customer = model.NewCustomer,
				pickup_date = model.PickupDate,
				service_type_id = model.ServiceTypeId,
				package_type_id = model.PackageTypeId,
				payment_method_id = model.PaymentMethodId,
				nature_of_goods = model.NatureOfGoods,
				dimension = model.Dimension,
				ttl_piece = model.TtlPiece,
				ttl_gross_weight = model.TtlGrossWeight,
				ttl_chargeable_weight = model.TtlChargeableWeight,
				total = model.Total,
				vehicle_type_id = model.VehicleTypeId,
				messenger_id = model.MessengerId,
				cancelled = model.Cancelled,
				confirmed = model.Confirmed,
				picked_up = model.PickedUp,
				note = model.Note,
				pickup_note = model.PickupNote,
				status_id = model.StatusId,
                received_cash = model.ReceivedCash,
                total_cash = model.TotalCash,
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.CreatedPc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
			};
		}
        
        private static void PopulateModelToNewEntity(pickup_order query, PickupOrderModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.date_process = model.DateProcess;
			query.branch_id = model.BranchId;
			query.employee_id = model.EmployeeId;
			query.customer_id = model.CustomerId;
            query.frachise_id = model.FranchiseId;
            query.drop_point_id = model.DropPointId;
			query.customer_name = model.CustomerName;
			query.customer_address = model.CustomerAddress;
			query.customer_phone = model.CustomerPhone;
			query.customer_contact = model.CustomerContact;
            query.new_customer = model.NewCustomer;
			query.pickup_date = model.PickupDate;
			query.service_type_id = model.ServiceTypeId;
			query.package_type_id = model.PackageTypeId;
			query.payment_method_id = model.PaymentMethodId;
			query.nature_of_goods = model.NatureOfGoods;
			query.dimension = model.Dimension;
			query.ttl_piece = model.TtlPiece;
			query.ttl_gross_weight = model.TtlGrossWeight;
			query.ttl_chargeable_weight = model.TtlChargeableWeight;
			query.total = model.Total;
			query.vehicle_type_id = model.VehicleTypeId;
			query.messenger_id = model.MessengerId;
			query.cancelled = model.Cancelled;
			query.confirmed = model.Confirmed;
			query.picked_up = model.PickedUp;
			query.note = model.Note;
			query.pickup_note = model.PickupNote;
			query.status_id = model.StatusId;
            query.received_cash = model.ReceivedCash;
            query.total_cash = model.TotalCash;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
		}
        
        private static PickupOrderModel PopulateEntityToNewModel(pickup_order item)
		{
			return new PickupOrderModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				DateProcess = item.date_process,
				BranchId = item.branch_id,
				EmployeeId = item.employee_id,
				CustomerId = item.customer_id,
                FranchiseId = item.frachise_id,
                DropPointId = item.drop_point_id,
				CustomerName = item.customer_name,
				CustomerAddress = item.customer_address,
				CustomerPhone = item.customer_phone,
				CustomerContact = item.customer_contact,
                NewCustomer = item.new_customer,
				PickupDate = item.pickup_date,
				ServiceTypeId = item.service_type_id,
				PackageTypeId = item.package_type_id,
				PaymentMethodId = item.payment_method_id,
				NatureOfGoods = item.nature_of_goods,
				Dimension = item.dimension,
				TtlPiece = item.ttl_piece,
				TtlGrossWeight = item.ttl_gross_weight,
				TtlChargeableWeight = item.ttl_chargeable_weight,
				Total = item.total,
				VehicleTypeId = item.vehicle_type_id,
				MessengerId = item.messenger_id,
				Cancelled = item.cancelled,
				Confirmed = item.confirmed,
				PickedUp = item.picked_up,
				Note = item.note,
				PickupNote = item.pickup_note,
				StatusId = item.status_id,
                ReceivedCash = item.received_cash,
                TotalCash = item.total_cash,
				Createddate = item.createddate,
				Createdby = item.createdby,
                CreatedPc = item.createdpc,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                ModifiedPc = item.modifiedpc
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.pickup_order select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            var obj = (from item in query
                join c in (from c in Entities.customers where c.rowstatus.Equals(true) select c) on item.customer_id equals
                    c.id
                join e in (from e in Entities.employees where e.rowstatus.Equals(true) select e) on item.messenger_id equals
                    e.id into ex
                    from e in ex.DefaultIfEmpty()
                join v in (from v in Entities.vehicle_type where v.rowstatus.Equals(true) select v) on item.vehicle_type_id
                    equals v.id into vx
                    from v in vx.DefaultIfEmpty()
                select new PickupOrderModel
                {
                    Id = item.id,
                    Rowstatus = item.rowstatus,
                    Rowversion = item.rowversion,
                    DateProcess = item.date_process,
                    BranchId = item.branch_id,
                    EmployeeId = item.employee_id,
                    CustomerId = item.customer_id,
                    FranchiseId = item.frachise_id,
                    DropPointId = item.drop_point_id,
                    CustomerName = c.name,
                    CustomerAddress = item.customer_address,
                    CustomerPhone = item.customer_phone,
                    CustomerContact = item.customer_contact,
                    NewCustomer = item.new_customer,
                    PickupDate = item.pickup_date,
                    ServiceTypeId = item.service_type_id,
                    PackageTypeId = item.package_type_id,
                    PaymentMethodId = item.payment_method_id,
                    NatureOfGoods = item.nature_of_goods,
                    Dimension = item.dimension,
                    TtlPiece = item.ttl_piece,
                    TtlGrossWeight = item.ttl_gross_weight,
                    TtlChargeableWeight = item.ttl_chargeable_weight,
                    Total = item.total,
                    VehicleTypeName = v!=null?v.name:"",
                    VehicleTypeId = item.vehicle_type_id,
                    MessengerId = item.messenger_id,
                    MessengerName = e!=null?e.name:"",
                    Cancelled = item.cancelled,
                    Confirmed = item.confirmed,
                    PickedUp = item.picked_up,
                    Note = item.note,
                    PickupNote = item.pickup_note,
                    StatusId = item.status_id,
                    ReceivedCash = item.received_cash,
                    TotalCash = item.total_cash,
                    Createddate = item.createddate,
                    Createdby = item.createdby,
                    CreatedPc = item.createdpc,
                    Modifieddate = item.modifieddate,
                    Modifiedby = item.modifiedby,
                    ModifiedPc = item.modifiedpc
                });

            return (IEnumerable<T>) obj.ToList();
            //return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> GetGrid<T>(params IListParameter[] parameter) where T : IBaseModel
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.pickup_order select a).Where(whereterm, ListValue.ToArray()).ToList();
            var obj = (from a in query
                       join e in Entities.employees on a.employee_id equals e.id
                       join v in Entities.vehicle_type on a.vehicle_type_id equals v.id
                       join s in Entities.service_type on a.service_type_id equals s.id
                       join mg in Entities.employees on a.messenger_id equals mg.id into mgg
                       join pm in Entities.payment_method on a.payment_method_id equals pm.id
                       from m in mgg.DefaultIfEmpty()
                       select new PickupOrderModel
                       {
                           Id = a.id,
                           Rowstatus = a.rowstatus,
                           Rowversion = a.rowversion,
                           DateProcess = a.date_process,
                           BranchId = a.branch_id,
                           EmployeeId = a.employee_id,
                           EmployeeName = e.name,
                           CustomerId = a.customer_id,
                           FranchiseId = a.frachise_id,
                           DropPointId = a.drop_point_id,
                           CustomerName = a.customer_name,
                           CustomerAddress = a.customer_address,
                           CustomerPhone = a.customer_phone,
                           CustomerContact = a.customer_contact,
                           NewCustomer = a.new_customer,
                           PickupDate = a.pickup_date,
                           ServiceTypeId = a.service_type_id,
                           ServiceName = s.name,
                           PackageTypeId = a.package_type_id,
                           PaymentMethodId = a.payment_method_id,
                           PaymentMethodName = pm.name,
                           NatureOfGoods = a.nature_of_goods,
                           Dimension = a.dimension,
                           TtlPiece = a.ttl_piece,
                           TtlGrossWeight = a.ttl_gross_weight,
                           TtlChargeableWeight = a.ttl_chargeable_weight,
                           Total = a.total,
                           VehicleTypeId = a.vehicle_type_id,
                           VehicleTypeName = v.name,
                           MessengerId = a.messenger_id,
                           MessengerName = m == null ? null : m.code + " - " + m.name,
                           Cancelled = a.cancelled,
                           Confirmed = a.confirmed,
                           PickedUp = a.picked_up,
                           Note = a.note,
                           PickupNote = a.pickup_note,
                           StatusId = a.status_id,
                           ReceivedCash = a.received_cash,
                           TotalCash = a.total_cash,
                           Createddate = a.createddate,
                           Createdby = a.createdby,
                           CreatedPc = a.createdpc,
                           Modifieddate = a.modifieddate,
                           Modifiedby = a.modifiedby,
                           ModifiedPc = a.modifiedpc,
                           StateChange2 = EnumStateChange.Select.ToString()
                       }).AsQueryable();
            if (obj == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)obj.ToList();
        }

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.pickup_order select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.pickup_order select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.pickup_order select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> GetMissedPickupList<T>(DateTime? fromDate, DateTime? toDate, int? customerId, int? branchId, int? messengerId)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(date_process) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(date_process) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            if (customerId != null && customerId != 0)
            {
                whereClauses.Add("customer_id = @customerId");
                parameters.Add(new MySqlParameter("customerId", customerId));
            }

            if (branchId != null && branchId != 0)
            {
                whereClauses.Add("branch_id = @branchId");
                parameters.Add(new MySqlParameter("branchId", branchId));
            }

            if (messengerId != null && messengerId != 0)
            {
                whereClauses.Add("messenger_id = @messengerId");
                parameters.Add(new MySqlParameter("messengerId", messengerId));
            }

            string sql = @"SELECT po.date_process,
                                b.code as branch,
                                m.code as messenger_code,
                                c.name as customer_name,
                                po.pu_order_count,
                                po.pu_count,
                                po.missed_count,
                                CASE WHEN (0 = po.pu_order_count) THEN (0)  ELSE (po.pu_count / po.pu_order_count) END AS pickup_percent,
                                CASE WHEN (0 = po.pu_order_count) THEN (0)  ELSE (po.missed_count / po.pu_order_count) END AS missed_percent
                        FROM (
                            SELECT DATE(date_process) AS date_process,
                                    branch_id,
                                    messenger_id,
                                    customer_id,
                                    COUNT(1) AS pu_order_count,
                                    SUM(picked_up = 1) AS pu_count,
                                    SUM(cancelled = 1) AS missed_count
                            FROM pickup_order
                            WHERE " + string.Join(" AND ", whereClauses) + @"
                            GROUP BY DATE(date_process), branch_id, messenger_id, customer_id
                        ) po
                        JOIN customer c ON c.id = po.customer_id
                        JOIN branch b ON b.id = po.branch_id
                        JOIN employee m ON m.id = po.messenger_id";

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<T> GetVehicleSummary<T>(DateTime? fromDate, DateTime? toDate, int? customerId, int? branchId, int? messengerId)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(date_process) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(date_process) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            if (customerId != null && customerId != 0)
            {
                whereClauses.Add("customer_id = @customerId");
                parameters.Add(new MySqlParameter("customerId", customerId));
            }

            if (branchId != null && branchId != 0)
            {
                whereClauses.Add("branch_id = @branchId");
                parameters.Add(new MySqlParameter("branchId", branchId));
            }

            if (messengerId != null && messengerId != 0)
            {
                whereClauses.Add("messenger_id = @messengerId");
                parameters.Add(new MySqlParameter("messengerId", messengerId));
            }

            string sql = @"SELECT po.date_process,
                                b.code as branch,
                                m.code as messenger_code,
                                c.name as customer_name,
                                po.pu_order_count,
                                po.car_pu_count,
                                po.bike_pu_count,
                                CASE WHEN (0 = po.pu_order_count) THEN (0)  ELSE (po.car_pu_count / po.pu_order_count) END AS car_pu_percent,
                                CASE WHEN (0 = po.pu_order_count) THEN (0)  ELSE (po.bike_pu_count / po.pu_order_count) END AS bike_pu_percent
                        FROM (
                            SELECT DATE(date_process) AS date_process,
                                    branch_id,
                                    messenger_id,
                                    customer_id,
                                    COUNT(1) AS pu_order_count,
                                    SUM(vehicle_type_id = 2) AS car_pu_count,
                                    SUM(vehicle_type_id = 1) AS bike_pu_count
                            FROM pickup_order
                            WHERE " + string.Join(" AND ", whereClauses) + @"
                            GROUP BY DATE(date_process), branch_id, messenger_id, customer_id
                        ) po
                        JOIN customer c ON c.id = po.customer_id
                        JOIN branch b ON b.id = po.branch_id
                        JOIN employee m ON m.id = po.messenger_id";

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }
    }
}