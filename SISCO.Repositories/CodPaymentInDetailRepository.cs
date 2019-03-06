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
    public class CodPaymentInDetailRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "COD Payment In Detail";
        public CodPaymentInDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public CodPaymentInDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as CodPaymentInDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTocod_payment_in_detail(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as CodPaymentInDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.cod_payment_in_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as CodPaymentInDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.cod_payment_in_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.cod_payment_in_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.cod_payment_in_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static cod_payment_in_detail PopulateModelToNewEntity(CodPaymentInDetailModel model)
		{
			return new cod_payment_in_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				cod_payment_in_id = model.CodPaymentInId,
                date_process = model.DateProcess,
                shipment_id = model.ShipmentId,
                shipment_code = model.ShipmentCode,
                shipment_date = model.ShipmentDate,
                total_cod = model.TotalCod,
                actual_paid = model.ActualPaid,
                delivery_code = model.DeliveryCode,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby
			};
		}

        private static void PopulateModelToNewEntity(cod_payment_in_detail query, CodPaymentInDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.date_process = model.DateProcess;
            query.cod_payment_in_id = model.CodPaymentInId;
            query.shipment_id = model.ShipmentId;
            query.shipment_date = model.ShipmentDate;
            query.shipment_code = model.ShipmentCode;
            query.total_cod = model.TotalCod;
            query.actual_paid = model.ActualPaid;
            query.delivery_code = model.DeliveryCode;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static CodPaymentInDetailModel PopulateEntityToNewModel(cod_payment_in_detail item)
		{
            return new CodPaymentInDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				DateProcess = item.date_process,
                CodPaymentInId = item.cod_payment_in_id,
                ShipmentId = item.shipment_id,
                ShipmentDate = item.shipment_date,
                ShipmentCode = item.shipment_code,
                TotalCod = item.total_cod,
                ActualPaid = item.actual_paid,
                DeliveryCode = item.delivery_code,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                Checked = true
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.cod_payment_in_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.cod_payment_in_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.cod_payment_in_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.cod_payment_in_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.cod_payment_in_detail select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.cod_payment_in_detail select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<CodPaymentInDetailModel> GetUpaidShipment(int branchId)
        {
            var state = EnumStateChange.Insert.ToString();
            var result = (from q in Entities.shipments
                          join e in Entities.shipment_expand on q.id equals e.shipment_id
                          join t in (from x in Entities.shipment_status where x.rowstatus && x.tracking_status_id == 12 select x) on q.id equals t.shipment_id into tx
                          from t in tx.DefaultIfEmpty()
                          where q.dest_branch_id == branchId && q.rowstatus && !q.voided && !e.paid_cod && e.iscod && t.id == null
                          select new CodPaymentInDetailModel
                          {
                              Id = 0,
                              Rowstatus = true,
                              Rowversion = DateTime.Now,
                              ShipmentId = q.id,
                              ShipmentCode = q.code,
                              ShipmentDate = q.date_process,
                              TotalCod = e.total_cod,
                              StateChange2 = state,
                              Checked = false
                          }).ToList();

            return result;
        }

        public CodPaymentInDetailModel GetUpaidShipment(int branchId, string code)
        {
            //var state = EnumStateChange.Insert.ToString();
            //var result = (from q in Entities.shipments
            //              join e in Entities.shipment_expand on q.id equals e.shipment_id
            //              join t in
            //                  (from x in Entities.shipment_status where x.rowstatus && x.tracking_status_id == 12 select x) on q.id equals t.shipment_id into tx
            //              from t in tx.DefaultIfEmpty()
            //              where q.code == code && q.dest_branch_id == branchId && q.rowstatus && !q.voided && !e.paid_cod && e.iscod && t.id == null
            //              select new CodPaymentInDetailModel
            //              {
            //                  Id = 0,
            //                  Rowstatus = true,
            //                  Rowversion = DateTime.Now,
            //                  ShipmentId = q.id,
            //                  ShipmentCode = q.code,
            //                  ShipmentDate = q.date_process,
            //                  TotalCod = e.total_cod,
            //                  StateChange2 = state,
            //                  Checked = false
            //              }).FirstOrDefault();

            var sql = @"SELECT
	                        0 Id,
	                        1 Rowstatus,
	                        now() Rowversion,
	                        s.id ShipmentId,
	                        s.code ShipmentCode,
	                        s.date_process ShipmentDate,
	                        se.total_cod TotalCod,
	                        'Insert' StateChange2,
	                        0 Checked
                        FROM shipment s
                        INNER JOIN shipment_expand se ON se.shipment_id = s.id AND se.paid_cod = 0 AND se.iscod = 1
                        LEFT JOIN (
	                        SELECT
		                        shipment_id
	                        FROM shipment_status
	                        WHERE rowstatus = 1 AND tracking_status_id = 12
                        ) ss ON ss.shipment_id = s.id
                        WHERE s.code = @code AND s.branch_id = @branchId AND s.voided = 0 AND ss.shipment_id IS NULL";

            var sqlParam = new List<MySqlParameter>
            {
                new MySqlParameter("code", code),
                new MySqlParameter("branchId", branchId)
            };

            var result = Entities.ExecuteStoreQuery<CodPaymentInDetailModel>(sql, sqlParam.ToArray()).FirstOrDefault();

            if (result != null)
            {
                sql = @"SELECT
                            reference
                        FROM shipment_status 
                        WHERE shipment_id = @shipmentId AND tracking_status_id = 8
                        ORDER BY dateprocess DESC
                        ";
                string docode = Entities.ExecuteStoreQuery<string>(sql, new MySqlParameter("shipmentId", result.ShipmentId)).FirstOrDefault();
                result.DeliveryCode = docode;
            }

            return result;
        }

        public IEnumerable<CodPaymentAndShipmentCode> FilterCod(IEnumerable<CodPaymentInModel> master, params IListParameter[] parameter)
        {
            if (parameter.Count() > 0)
            {
                var whereterm = GetQueryParameterLinq(parameter);
                var query = (from a in Entities.cod_payment_in_detail select a).Where(whereterm, ListValue.ToArray()).ToList();

                var result = (from a in query
                              join m in master on a.cod_payment_in_id equals m.Id
                              select new CodPaymentAndShipmentCode
                              {
                                  DateProcess = m.DateProcess,
                                  Code = m.Code,
                                  ShipmentCode = a.shipment_code
                              }).ToList();

                return result;
            }
            else
            {
                var query = (from m in master
                             select new CodPaymentAndShipmentCode
                             {
                                 DateProcess = m.DateProcess,
                                 Code = m.Code,
                                 ShipmentCode = string.Empty
                             }).ToList();

                return query;
            }
        }
    }
}