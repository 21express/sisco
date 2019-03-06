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
    public class PickupSchedulerRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "PickupScheduler";
        public PickupSchedulerRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public PickupSchedulerRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as PickupSchedulerModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTopickup_scheduler(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as PickupSchedulerModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.pickup_scheduler where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as PickupSchedulerModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.pickup_scheduler select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.pickup_scheduler where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.pickup_scheduler where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static pickup_scheduler PopulateModelToNewEntity(PickupSchedulerModel model)
		{
			return new pickup_scheduler
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
                active = model.Active,
                mon = model.Mon,
                tue = model.Tue,
                wed = model.Wed,
                thu = model.Thu,
                fri = model.Fri,
                sat = model.Sat,
                sun = model.Sun,
                start_date = model.StartDate,
				branch_id = model.BranchId,
				employee_id = model.EmployeeId,
				customer_id = model.CustomerId,
				customer_name = model.CustomerName,
				customer_address = model.CustomerAddress,
				customer_phone = model.CustomerPhone,
				customer_contact = model.CustomerContact,
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
				note = model.Note,
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.CreatedPc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
			};
		}
        
        private static void PopulateModelToNewEntity(pickup_scheduler query, PickupSchedulerModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.active = model.Active;
            query.mon = model.Mon;
            query.tue = model.Tue;
            query.wed = model.Wed;
            query.thu = model.Thu;
            query.fri = model.Fri;
            query.sat = model.Sat;
            query.sun = model.Sun;
            query.start_date = model.StartDate;
			query.branch_id = model.BranchId;
			query.employee_id = model.EmployeeId;
			query.customer_id = model.CustomerId;
			query.customer_name = model.CustomerName;
			query.customer_address = model.CustomerAddress;
			query.customer_phone = model.CustomerPhone;
			query.customer_contact = model.CustomerContact;
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
			query.note = model.Note;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
		}
        
        private static PickupSchedulerModel PopulateEntityToNewModel(pickup_scheduler item)
		{
			return new PickupSchedulerModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
                Active = item.active,
                Mon = item.mon,
                Tue = item.tue,
                Wed = item.wed,
                Thu = item.thu,
                Fri = item.fri,
                Sat = item.sat,
                Sun = item.sun,
                StartDate = item.start_date,
				BranchId = item.branch_id,
				EmployeeId = item.employee_id,
				CustomerId = item.customer_id,
				CustomerName = item.customer_name,
				CustomerAddress = item.customer_address,
				CustomerPhone = item.customer_phone,
				CustomerContact = item.customer_contact,
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
				Note = item.note,
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
            var query = (from a in Entities.pickup_scheduler select a).Where(whereterm, ListValue.ToArray()).Select(PopulateEntityToNewModel).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            return (IEnumerable<T>) query.ToList();
		}

        public IEnumerable<T> GetGrid<T>(params IListParameter[] parameter) where T : IBaseModel
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.pickup_scheduler select a).Where(whereterm, ListValue.ToArray()).ToList();
            return (IEnumerable<T>)query;
        }

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.pickup_scheduler select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.pickup_scheduler select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.pickup_scheduler select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public List<PickupSchedulerModel> Search(int branchId, bool active, bool mon, bool tue, bool wed, bool thu, bool fri,
            bool sat, bool sun, int? customerId = null, string customerName = null)
        {
            var sql = @"SELECT
                            id Id,
                            customer_name CustomerName
                        FROM pickup_scheduler
                        WHERE {0};";

            var sqlparam = new List<string>();
            var mysqlParam = new List<MySqlParameter>();
            sqlparam.Add("rowstatus = 1");
            sqlparam.Add("branch_id = @branchId");
            mysqlParam.Add(new MySqlParameter("branchId", branchId));
            sqlparam.Add("active = @active");
            mysqlParam.Add(new MySqlParameter("active", active));

            if (mon) sqlparam.Add("mon = 1");
            if (tue) sqlparam.Add("tue = 1");
            if (wed) sqlparam.Add("wed = 1");
            if (thu) sqlparam.Add("thu = 1");
            if (fri) sqlparam.Add("fri = 1");
            if (sat) sqlparam.Add("sat = 1");
            if (sun) sqlparam.Add("sun = 1");

            if (customerId != null)
            {
                sqlparam.Add("customer_id = @customerId");
                mysqlParam.Add(new MySqlParameter("customerId", customerId));
            }

            if (!string.IsNullOrEmpty(customerName))
            {
                sqlparam.Add("customer_name LIKE @customerName");
                mysqlParam.Add(new MySqlParameter("customerName", string.Format("%{0}%", customerName)));
            }

            sql = string.Format(sql, string.Join(" AND ", sqlparam));
            return Entities.ExecuteStoreQuery<PickupSchedulerModel>(sql, mysqlParam.ToArray()).ToList();
        }
    }
}