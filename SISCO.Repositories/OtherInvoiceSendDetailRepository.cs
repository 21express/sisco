using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using MySql.Data.MySqlClient;
using SISCO.Models;
using SISCO.Repositories.Context;
using SISCO.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace SISCO.Repositories
{
    public class OtherInvoiceSendDetailRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        private const string OBJECT_NAME = "Other Invoice Send Detail";
        public OtherInvoiceSendDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public OtherInvoiceSendDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as OtherInvoiceSendDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToother_invoice_send_detail(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as OtherInvoiceSendDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.other_invoice_send_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as OtherInvoiceSendDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.other_invoice_send_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.other_invoice_send_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
            var query = (from d in Entities.other_invoice_send_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static other_invoice_send_detail PopulateModelToNewEntity(OtherInvoiceSendDetailModel model)
		{
            return new other_invoice_send_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
                other_invoice_id = model.OtherInvoiceId,
                other_invoice_send_id = model.OtherInvoiceSendId,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}

        private static void PopulateModelToNewEntity(other_invoice_send_detail query, OtherInvoiceSendDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.other_invoice_send_id = model.OtherInvoiceSendId;
            query.other_invoice_id = model.OtherInvoiceId;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static OtherInvoiceSendDetailModel PopulateEntityToNewModel(other_invoice_send_detail item)
		{
            return new OtherInvoiceSendDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
                OtherInvoiceSendId = item.other_invoice_send_id,
                OtherInvoiceId = item.other_invoice_id,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.other_invoice_send_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.other_invoice_send_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.other_invoice_send_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.other_invoice_send_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.other_invoice_send_detail select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.other_invoice_send_detail select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<SendInvoice> GetDetailsInvoice(int sendId)
        {
            var sql = @"SELECT
	                        o.id Id,
                            1 Checked,
                            o.date_process DateProcess,
                            o.ref_number RefNumber,
                            o.customer_name CustomerName,
                            o.total Total
                        FROM other_invoice_send_detail osd
                        INNER JOIN other_invoice_send os ON osd.other_invoice_send_id = os.id AND os.rowstatus = 1
                        INNER JOIN other_invoice o ON osd.other_invoice_id = o.id AND o.rowstatus = 1
                        WHERE osd.rowstatus = 1 AND os.id = @sendId;";

            return Entities.ExecuteStoreQuery<SendInvoice>(sql, new MySqlParameter("sendId", sendId)).ToList();
        }

        public List<SendInvoice> Filter(string letterNo = null, string refNumber = null, DateTime? start = null, DateTime? end = null)
        {
            var sql = @"SELECT
                            o.id Id,
	                        o.date_process DateProcess,
                            i.ref_number RefNumber,
                            i.customer_name CustomerName,
                            i.total Total,
                            o.code LetterNo
                        FROM other_invoice_send_detail od
                        INNER JOIN other_invoice_send o ON od.other_invoice_send_id = o.id AND o.rowstatus = 1 {0}
                        INNER JOIN other_invoice i ON od.other_invoice_id = i.id AND i.rowstatus = 1 {1}
                        WHERE od.rowstatus = 1";

            var sqlParams = new List<MySqlParameter>();
            var strSend = new List<string>();
            var strInv = new List<string>();

            if (!string.IsNullOrEmpty(letterNo))
            {
                strSend.Add("o.code = @letterNo");
                sqlParams.Add(new MySqlParameter("letterNo", letterNo));
            }

            var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
            if (start != null && start > dateNull)
            {
                DateTime s = (DateTime) start;
                strSend.Add("o.date_process >= @start");
                sqlParams.Add(new MySqlParameter("start", new DateTime(s.Year, s.Month, s.Day, 0, 0, 0)));
            }

            if (end != null && end > dateNull)
            {
                DateTime e = (DateTime)end;
                strSend.Add("o.date_process <= @end");
                sqlParams.Add(new MySqlParameter("end", new DateTime(e.Year, e.Month, e.Day, 23, 59, 59)));
            }

            if (!string.IsNullOrEmpty(refNumber))
            {
                strInv.Add("i.ref_number = @refNumber");
                sqlParams.Add(new MySqlParameter("refNumber", refNumber));
            }

            var send = strSend.Count > 0 ? string.Format(" AND {0}", string.Join(" AND ", strSend)) : string.Empty;
            var inv = strInv.Count > 0 ? string.Format(" AND {0}", string.Join(" AND ", strInv)) : string.Empty;
            sql = string.Format(sql, send, inv);

            return Entities.ExecuteStoreQuery<SendInvoice>(sql, sqlParams.ToArray()).ToList();
        }
    }
}
