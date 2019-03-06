using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using SISCO.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using Devenlab.Common;

namespace SISCO.Repositories
{
    public class ShipmentInsuranceRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        private const string OBJECT_NAME = "Shipment Insurance";
        public ShipmentInsuranceRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public ShipmentInsuranceRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as ShipmentInsuranceModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToshipment_insurance(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as ShipmentInsuranceModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.shipment_insurance where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as ShipmentInsuranceModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.shipment_insurance select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.shipment_insurance where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
            var query = (from d in Entities.shipment_insurance where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static shipment_insurance PopulateModelToNewEntity(ShipmentInsuranceModel model)
		{
            return new shipment_insurance
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
                date_process = model.DateProcess,
				code = model.Code,
                is_cash = model.IsCash,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}

        private static void PopulateModelToNewEntity(shipment_insurance query, ShipmentInsuranceModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.date_process = model.DateProcess;
			query.code = model.Code;
            query.is_cash = model.IsCash;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static ShipmentInsuranceModel PopulateEntityToNewModel(shipment_insurance item)
		{
			return new ShipmentInsuranceModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
                DateProcess = item.date_process,
				Code = item.code,
                IsCash = item.is_cash,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.shipment_insurance select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.shipment_insurance select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.shipment_insurance select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.shipment_insurance select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.shipment_insurance select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.shipment_insurance select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<T> Search<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            List<string> param = new List<string>();
            param.Add("si.rowstatus = 1");

            var shipmentCode = parameter.Any(r => r.ColumnName.Equals("resi"))
                ? parameter.First(r => r.ColumnName.Equals("resi")).Value.ToString()
                : string.Empty;

            if (parameter.Any(r => r.ColumnName.Equals("code")))
                param.Add(string.Format("si.code = '{0}'", parameter.First(r => r.ColumnName.Equals("code")).Value.ToString()));

            if (parameter.Any(r => r.ColumnName.Equals("date_process") && r.Operator == EnumSqlOperator.GreatThanEqual))
                param.Add(string.Format("si.date_process >= '{0}'", ((DateTime)parameter.First(r => r.ColumnName.Equals("date_process") && r.Operator == EnumSqlOperator.GreatThanEqual).Value).ToString("yyyy-MM-dd hh:mm:ss")));
            
            if (parameter.Any(r => r.ColumnName.Equals("date_process") && r.Operator == EnumSqlOperator.LesThanEqual))
            {
                param.Add(string.Format("si.date_process <= '{0}'", ((DateTime)parameter.First(r => r.ColumnName.Equals("date_process") && r.Operator == EnumSqlOperator.LesThanEqual).Value).ToString("yyyy-MM-dd hh:mm:ss")));
            }

            var sql = @"SELECT
                            si.id Id,
                            si.rowstatus Rowstatus,
                            si.rowversion Rowversion,
                            si.code Code,
                            si.date_process DateProcess,
                            si.is_cash IsCash,
                            si.createddate CreatedDate,
                            si.createdby CreatedBy,
                            si.modifieddate ModifiedDate,
                            si.modifiedby Modifiedby
                            {0}
                        FROM shipment_insurance si 
                        {1}
                        WHERE {2}
                        ORDER BY si.date_process ASC";

            sql = string.Format(sql, 
                    !string.IsNullOrEmpty(shipmentCode) ? ",s.code ShipmentCode " : ",'' ShipmentCode",
                    !string.IsNullOrEmpty(shipmentCode) ? string.Format("INNER JOIN shipment_insurance_detail sid ON sid.shipment_insurance_id = si.id AND sid.rowstatus = 1 INNER JOIN shipment s ON sid.shipment_id = s.id AND s.rowstatus = 1 AND s.code = '{0}'", shipmentCode) : string.Empty,
                    string.Join(" AND ", param.ToArray())
                );

            totalCount = Entities.ExecuteStoreQuery<T>(sql).ToList().Count;

            sql += string.Format(" LIMIT {0}, {1}", paging.Start, paging.Limit);
            return (IEnumerable<T>)Entities.ExecuteStoreQuery<T>(sql).ToList();
        }
    }
}