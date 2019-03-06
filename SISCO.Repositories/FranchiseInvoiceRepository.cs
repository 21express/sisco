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
    public class FranchiseInvoiceRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Franchise Invoice";
        public FranchiseInvoiceRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public FranchiseInvoiceRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as FranchiseInvoiceModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTofranchise_invoice(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as FranchiseInvoiceModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.franchise_invoice where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as FranchiseInvoiceModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.franchise_invoice select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.franchise_invoice where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
            var query = (from d in Entities.franchise_invoice where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static franchise_invoice PopulateModelToNewEntity(FranchiseInvoiceModel model)
		{
			return new franchise_invoice
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
                date_process = model.DateProcess,
                code = model.Code,
                branch_id = model.BranchId,
                franchise_id = model.FranchiseId,
                invoiced_to = model.InvoicedTo,
                due_date = model.DueDate,
                description1 = model.Description1,
                description2 = model.Description2,
                description3 = model.Description3,
                materai = model.Materai,
                total_invoice = model.TotalInvoice,
                total = model.Total,
                printed = model.Printed,
                cancelled = model.Cancelled,
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.CreatedPc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
			};
		}
        
        private static void PopulateModelToNewEntity(franchise_invoice query, FranchiseInvoiceModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.date_process = model.DateProcess;
            query.code = model.Code;
            query.branch_id = model.BranchId;
            query.franchise_id = model.FranchiseId;
            query.invoiced_to = model.InvoicedTo;
            query.due_date = model.DueDate;
            query.description1 = model.Description1;
            query.description2 = model.Description2;
            query.description3 = model.Description3;
            query.materai = model.Materai;
            query.total_invoice = model.TotalInvoice;
            query.total = model.Total;
            query.printed = model.Printed;
            query.cancelled = model.Cancelled;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
		}

        private static FranchiseInvoiceModel PopulateEntityToNewModel(franchise_invoice item)
		{
			return new FranchiseInvoiceModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				DateProcess = item.date_process,
                Code = item.code,
                BranchId = item.branch_id,
                FranchiseId = item.franchise_id,
                InvoicedTo = item.invoiced_to,
                DueDate = item.due_date,
                Description1 = item.description1,
                Description2 = item.description2,
                Description3 = item.description3,
                Materai = item.materai,
                TotalInvoice = item.total_invoice,
                Total = item.total,
                Printed = item.printed,
                Cancelled = item.cancelled,
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
			var query = (from a in Entities.franchise_invoice select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_invoice select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_invoice select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_invoice select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.franchise_invoice select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_invoice select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<FranchiseInvoiceListModel> GetUninvoiced(IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var shipment = (from a in Entities.shipments select a).Where(whereterm, ListValue.ToArray()).ToList();

            var result = (from s in shipment
                          join sv in Entities.service_type on s.service_type_id equals sv.id
                          join f in Entities.franchises on s.franchise_id equals f.id
                          join fc in Entities.franchise_commission on s.id equals fc.shipment_id
                          where f.rowstatus && fc.rowstatus
                          select new FranchiseInvoiceListModel
                          {
                                Id = 0,
                                ShipmentId = s.id,
                                ShipmentCode = s.code,
                                ShipmentDate = s.date_process,
                                DestCityId = s.dest_city_id,
                                DestCity = s.dest_city,
                                TotalPieces = s.ttl_piece,
                                TotalCw = s.ttl_chargeable_weight,
                                ServiceTypeId = s.service_type_id,
                                ServiceType = sv.name,
                                InsuranceFee = s.insurance_fee,
                                OtherFee = s.other_fee,
                                PackingFee = s.packing_fee,
                                TotalSales = fc.total_sales,
                                Ppn = fc.ppn_1,
                                Commission = fc.commission,
                                Pph23 = fc.pph_23,
                                NetCommission = fc.total_net_commission,
                                TotalInvoice = fc.debs,
                                StateChange = EnumStateChange.Insert
                          }).ToList();

            return result;
        }

        public string GenerateReceipt()
        {
            var pattern = "#######";
            return GenerateCode("auto-receipt", pattern);
        }
    }
}


