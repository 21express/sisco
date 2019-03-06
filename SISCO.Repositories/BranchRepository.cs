

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
    public class BranchRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Branch";
        public BranchRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public BranchRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as BranchModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddTobranches(entity);
            Entities.SaveChanges();

            businessModel.Id = entity.id;
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as BranchModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.branches where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as BranchModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.branches select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.branches where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.branches where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static branch PopulateModelToNewEntity(BranchModel model)
        {
            return new branch
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                max_discount = model.MaxDiscount,
                ra_fee = model.RaFee,
                code = model.Code,
                name = model.Name,
                address = model.Address,
                phone = model.Phone,
                contact = model.Contact,
                contact_email = model.ContactEmail,
                contact_phone = model.ContactPhone,
                city_id = model.CityId,
                branch_type_id = model.BranchTypeId,
                wh_kg = model.WhKg,
                wh_admin = model.WhAdmin,
                prefix_code = model.PrefixCode,
                prefix_code1 = model.PrefixCode1,
                prefix_code2 = model.PrefixCode2,
                prefix_online_code1 = model.PrefixOnlineCode1,
                header_shipment = model.HeaderShipment,
                invoice_header1 = model.InvoiceHeader1,
                invoice_header2 = model.InvoiceHeader2,
                invoice_header3 = model.InvoiceHeader3,
                invoice_footer1 = model.InvoiceFooter1,
                invoice_footer2 = model.InvoiceFooter2,
                bank_name = model.BankName,
                bank_account_name = model.BankAccountName,
                bank_account_number = model.BankAccountNumber,
                createddate = model.Createddate,
                createdby = model.Createdby,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
            };
        }

        private static void PopulateModelToNewEntity(branch query, BranchModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.max_discount = model.MaxDiscount;
            query.ra_fee = model.RaFee;
            query.code = model.Code;
            query.name = model.Name;
            query.address = model.Address;
            query.phone = model.Phone;
            query.contact = model.Contact;
            query.contact_email = model.ContactEmail;
            query.contact_phone = model.ContactPhone;
            query.city_id = model.CityId;
            query.branch_type_id = model.BranchTypeId;
            query.wh_kg = model.WhKg;
            query.wh_admin = model.WhAdmin;
            query.prefix_code = model.PrefixCode;
            query.prefix_code1 = model.PrefixCode1;
            query.prefix_code2 = model.PrefixCode2;
            query.prefix_online_code1 = model.PrefixOnlineCode1;
            query.header_shipment = model.HeaderShipment;
            query.invoice_header1 = model.InvoiceHeader1;
            query.invoice_header2 = model.InvoiceHeader2;
            query.invoice_header3 = model.InvoiceHeader3;
            query.invoice_footer1 = model.InvoiceFooter1;
            query.invoice_footer2 = model.InvoiceFooter2;
            query.bank_name = model.BankName;
            query.bank_account_name = model.BankAccountName;
            query.bank_account_number = model.BankAccountNumber;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
        }

        private static BranchModel PopulateEntityToNewModel(branch item)
        {
            return new BranchModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                MaxDiscount = item.max_discount,
                RaFee = item.ra_fee,
                Code = item.code,
                Name = item.name,
                Address = item.address,
                Phone = item.phone,
                Contact = item.contact,
                ContactEmail = item.contact_email,
                ContactPhone = item.contact_phone,
                CityId = item.city_id,
                BranchTypeId = item.branch_type_id,
                WhKg = item.wh_kg,
                WhAdmin = item.wh_admin,
                PrefixCode = item.prefix_code,
                PrefixCode1 = item.prefix_code1,
                PrefixCode2 = item.prefix_code2,
                PrefixOnlineCode1 = item.prefix_online_code1,
                HeaderShipment = item.header_shipment,
                InvoiceHeader1 = item.invoice_header1,
                InvoiceHeader2 = item.invoice_header2,
                InvoiceHeader3 = item.invoice_header3,
                InvoiceFooter1 = item.invoice_footer1,
                InvoiceFooter2 = item.invoice_footer2,
                BankName = item.bank_name,
                BankAccountName = item.bank_account_name,
                BankAccountNumber = item.bank_account_number,
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby,

            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.branches select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.branches select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.branches select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.branches select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }


        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.branches select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.branches select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }
    }
}
