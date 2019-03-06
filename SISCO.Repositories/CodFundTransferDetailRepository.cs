using System;
using System.Collections.Generic;
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
    public class CodFundTransferDetailRepository: SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "COD Fund Transfer Detail";
        public CodFundTransferDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public CodFundTransferDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as CodFundTransferDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTocod_fund_transfer_detail(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as CodFundTransferDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.cod_fund_transfer_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as CodFundTransferDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.cod_fund_transfer_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.cod_fund_transfer_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.cod_fund_transfer_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static cod_fund_transfer_detail PopulateModelToNewEntity(CodFundTransferDetailModel model)
		{
			return new cod_fund_transfer_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				date_process = model.DateProcess,
                cod_fund_transfer_id = model.CodFundTransferId,
                invoice_id = model.InvoiceId,
                invoice_code = model.InvoiceCode,
                invoice_date = model.InvoiceDate,
                invoice_total = model.InvoiceTotal,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}

        private static void PopulateModelToNewEntity(cod_fund_transfer_detail query, CodFundTransferDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.date_process = model.DateProcess;
            query.cod_fund_transfer_id = model.CodFundTransferId;
            query.invoice_id = model.InvoiceId;
            query.invoice_code = model.InvoiceCode;
            query.invoice_date = model.InvoiceDate;
            query.invoice_total = model.InvoiceTotal;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static CodFundTransferDetailModel PopulateEntityToNewModel(cod_fund_transfer_detail item)
		{
            return new CodFundTransferDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
                DateProcess = item.date_process,
                CodFundTransferId = item.cod_fund_transfer_id,
                InvoiceId = item.invoice_id,
                InvoiceDate = item.invoice_date,
                InvoiceCode = item.invoice_code,
                InvoiceTotal = item.invoice_total,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                Checked = true,
                StateChange2 = EnumStateChange.Update.ToString()
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.cod_fund_transfer_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.cod_fund_transfer_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.cod_fund_transfer_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.cod_fund_transfer_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.cod_fund_transfer_detail select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.cod_fund_transfer_detail select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<PaymentInAndDetailModel> FilterPayment(IEnumerable<CodFundTransferModel> master,
            params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query =
                (from a in Entities.cod_fund_transfer_detail select a).Where(whereterm, ListValue.ToArray()).ToList();

            var obj = (IEnumerable<PaymentInAndDetailModel>)(from a in query
                                                             join m in master on a.cod_fund_transfer_id equals m.Id
                                                             select new PaymentInAndDetailModel
                                                             {
                                                                 DateProcess = m.DateProcess,
                                                                 Code = m.Code,
                                                                 CustomerName = string.Empty,
                                                                 PaymentType = string.Empty,
                                                                 Kwitansi = a.invoice_code
                                                             }).ToList();

            return obj;
        }
    }
}
