using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Dynamic;
using System.Text.RegularExpressions;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using SISCO.Repositories.Interfaces;

namespace SISCO.Repositories
{
    public class CustomerRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
// ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Customer";
        public CustomerRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public CustomerRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as CustomerModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTocustomers(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as CustomerModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.customers where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as CustomerModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.customers select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.customers where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.customers where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static customer PopulateModelToNewEntity(CustomerModel model)
		{
			return new customer
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				code = model.Code,
				branch_id = model.BranchId,
				name = model.Name,
				address = model.Address,
				postal_code = model.PostalCode,
				city_id = model.CityId,
				locality = model.Locality,
				province = model.Province,
				country_code = model.CountryCode,
				phone = model.Phone,
				fax = model.Fax,
				email = model.Email,
				npwp = model.Npwp,
				tax_name = model.TaxName,
				tax_address = model.TaxAddress,
				same = model.Same,
				contact = model.Contact,
				contact_email = model.ContactEmail,
				contact_phone = model.ContactPhone,
				credit = model.Credit,
				credit_limit = model.CreditLimit,
				discount = model.Discount,
				handling_fee = model.HandlingFee,
				rc_percent = model.RcPercent,
				rc_kg = model.RcKg,
				rc_fixed = model.RcFixed,
				comm_percent = model.CommPercent,
				comm_kg = model.CommKg,
				marketing_employee_id = model.MarketingEmployeeId,
				mc_percent = model.McPercent,
				mc_kg = model.McKg,
				mc_fixed = model.McFixed,
				bank_name = model.BankName,
				bank_account_name = model.BankAccountName,
				bank_account_number = model.BankAccountNumber,
				pod_needed = model.PodNeeded,
				disabled = model.Disabled,
				start_date = model.StartDate,
				initial_balance = model.InitialBalance,
				closing_balance = model.ClosingBalance,
				balance = model.Balance,
				balance_in = model.BalanceIn,
				balance_out = model.BalanceOut,
				note = model.Note,
                franchise_id = model.FranchiseId,
                product_key = model.ProductKey,
                active_flag = model.ActiveFlag,
				footer1 = model.Footer1,
                corporate_key = model.CorporateKey,
                ip_static = model.IPStatic,
                corporate_flag = model.CorporateFlag,
                tax_invoice_id = model.TaxInvoiceId,
                service_type_id = model.ServiceTypeId,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(customer query, CustomerModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.code = model.Code;
			query.branch_id = model.BranchId;
			query.name = model.Name;
			query.address = model.Address;
			query.postal_code = model.PostalCode;
			query.city_id = model.CityId;
			query.locality = model.Locality;
			query.province = model.Province;
			query.country_code = model.CountryCode;
			query.phone = model.Phone;
			query.fax = model.Fax;
			query.email = model.Email;
			query.npwp = model.Npwp;
			query.tax_name = model.TaxName;
			query.tax_address = model.TaxAddress;
			query.same = model.Same;
			query.contact = model.Contact;
			query.contact_email = model.ContactEmail;
			query.contact_phone = model.ContactPhone;
			query.credit = model.Credit;
			query.credit_limit = model.CreditLimit;
			query.discount = model.Discount;
			query.handling_fee = model.HandlingFee;
			query.rc_percent = model.RcPercent;
			query.rc_kg = model.RcKg;
			query.rc_fixed = model.RcFixed;
			query.comm_percent = model.CommPercent;
			query.comm_kg = model.CommKg;
			query.marketing_employee_id = model.MarketingEmployeeId;
			query.mc_percent = model.McPercent;
			query.mc_kg = model.McKg;
			query.mc_fixed = model.McFixed;
			query.bank_name = model.BankName;
			query.bank_account_name = model.BankAccountName;
			query.bank_account_number = model.BankAccountNumber;
			query.pod_needed = model.PodNeeded;
			query.disabled = model.Disabled;
			query.start_date = model.StartDate;
			query.initial_balance = model.InitialBalance;
			query.closing_balance = model.ClosingBalance;
			query.balance = model.Balance;
			query.balance_in = model.BalanceIn;
			query.balance_out = model.BalanceOut;
			query.note = model.Note;
            query.franchise_id = model.FranchiseId;
            query.product_key = model.ProductKey;
            query.active_flag = model.ActiveFlag;
			query.footer1 = model.Footer1;
            query.corporate_key = model.CorporateKey;
            query.ip_static = model.IPStatic;
            query.corporate_flag = model.CorporateFlag;
            query.tax_invoice_id = model.TaxInvoiceId;
            query.service_type_id = model.ServiceTypeId;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static CustomerModel PopulateEntityToNewModel(customer item)
		{
			return new CustomerModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				Code = item.code,
				BranchId = item.branch_id,
				Name = item.name,
				Address = item.address,
				PostalCode = item.postal_code,
				CityId = item.city_id,
				Locality = item.locality,
				Province = item.province,
				CountryCode = item.country_code,
				Phone = item.phone,
				Fax = item.fax,
				Email = item.email,
				Npwp = item.npwp,
				TaxName = item.tax_name,
				TaxAddress = item.tax_address,
				Same = item.same,
				Contact = item.contact,
				ContactEmail = item.contact_email,
				ContactPhone = item.contact_phone,
				Credit = item.credit,
				CreditLimit = item.credit_limit,
				Discount = item.discount,
				HandlingFee = item.handling_fee,
				RcPercent = item.rc_percent,
				RcKg = item.rc_kg,
				RcFixed = item.rc_fixed,
				CommPercent = item.comm_percent,
				CommKg = item.comm_kg,
				MarketingEmployeeId = item.marketing_employee_id,
				McPercent = item.mc_percent,
				McKg = item.mc_kg,
				McFixed = item.mc_fixed,
				BankName = item.bank_name,
				BankAccountName = item.bank_account_name,
				BankAccountNumber = item.bank_account_number,
				PodNeeded = item.pod_needed,
				Disabled = item.disabled,
				StartDate = item.start_date,
				InitialBalance = item.initial_balance,
				ClosingBalance = item.closing_balance,
				Balance = item.balance,
				BalanceIn = item.balance_in,
				BalanceOut = item.balance_out,
				Note = item.note,
                FranchiseId = item.franchise_id,
                ProductKey = item.product_key,
                ActiveFlag = item.active_flag,
				Footer1 = item.footer1,
                CorporateKey = item.corporate_key,
                IPStatic = item.ip_static,
                CorporateFlag = item.corporate_flag,
                TaxInvoiceId = item.tax_invoice_id,
                ServiceTypeId = item.service_type_id,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.customers select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.customers select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.customers select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.customers select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public int GetCount(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.customers select a).Where(whereterm, ListValue.ToArray());

            if (query == null)
                throw new Exception(MessageEntityNotFound);

            return query.Count();
        }

        public string GenerateCode(CustomerModel model)
        {
            var branchCode = (from a in Entities.branches
                                where a.id == model.BranchId
                                select a.code).FirstOrDefault();

            var pattern = string.Format("{0}###-{1}", model.Name[0], branchCode);

            return GenerateCode("customer", pattern);
        }

        public string GenerateFranchiseCode(CustomerModel model)
        {
            var branchCode = (from a in Entities.branches
                              where a.id == model.BranchId
                              select a.code).FirstOrDefault();

            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            var name = rgx.Replace(model.Name.Trim().Replace(" ", ""), "");
            if (name.Length < 4) name = name + "O";
            var pattern = string.Format("{0}###-{1}", name.Substring(0, 3), branchCode);

            return GenerateCode("customer", pattern);
        }

        public string GenerateFranchiseCode_2(CustomerModel model)
        {
            var branchCode = (from a in Entities.branches
                              where a.id == model.BranchId
                              select a.code).FirstOrDefault();

            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            var name = rgx.Replace(model.Name.Trim().Replace(" ", ""), "");
            if (name.Length < 4) name = name + "O";
            var pattern = string.Format("{0}###-{1}", name.Substring(0, 3), branchCode);

            return GenerateCode_2("customer", pattern);
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string whereExpression, object[] parameters)
        {
            whereExpression = GetQueryParameterLinqRaw(whereExpression, ref parameters);
            var query = (from a in Entities.customers select a).Where(whereExpression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.customers select a).Where(whereExpression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }
    }
}