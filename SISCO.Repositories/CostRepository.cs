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
    public class CostRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Cost";

        public CostRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public CostRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as CostModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddTocosts(entity);
            Entities.SaveChanges();

            businessModel.Id = entity.id;
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as CostModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.costs where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as CostModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.costs select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.costs where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.costs where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static cost PopulateModelToNewEntity(CostModel model)
        {
            return new cost
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                date_process = model.DateProcess,
                code = model.Code,
                branch_id = model.BranchId,
                payment_type_id = model.PaymentTypeId,
                description = model.Description,
                total = model.Total,
                hard_cash = model.HardCash,
                printed = model.Printed,
                createddate = model.Createddate,
                createdby = model.Createdby,
                createdpc = model.Createdpc,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
                modifiedpc = model.Modifiedpc
            };
        }

        private static void PopulateModelToNewEntity(cost query, CostModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.date_process = model.DateProcess;
            query.code = model.Code;
            query.branch_id = model.BranchId;
            query.payment_type_id = model.PaymentTypeId;
            query.description = model.Description;
            query.total = model.Total;
            query.hard_cash = model.HardCash;
            query.printed = model.Printed;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.createdpc = model.Createdpc;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.Modifiedpc;
        }

        private static CostModel PopulateEntityToNewModel(cost item)
        {
            return new CostModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                DateProcess = item.date_process,
                Code = item.code,
                BranchId = item.branch_id,
                PaymentTypeId = item.payment_type_id,
                Description = item.description,
                Total = item.total,
                HardCash = item.hard_cash,
                Printed = item.printed,
                Createddate = item.createddate,
                Createdby = item.createdby,
                Createdpc = item.createdpc,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby,
                Modifiedpc = item.modifiedpc,
                StateChange2 = EnumStateChange.Select.ToString()
            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.costs select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var obj = (from item in query
                join p in Entities.payment_type on item.payment_type_id equals p.id
                select new CostModel
                {
                    Id = item.id,
                    Rowstatus = item.rowstatus,
                    Rowversion = item.rowversion,
                    DateProcess = item.date_process,
                    Code = item.code,
                    BranchId = item.branch_id,
                    PaymentTypeId = item.payment_type_id,
                    PaymentType = p.name,
                    Description = item.description,
                    Total = item.total,
                    HardCash = item.hard_cash,
                    Printed = item.printed,
                    Createddate = item.createddate,
                    Createdby = item.createdby,
                    Createdpc = item.createdpc,
                    Modifieddate = item.modifieddate,
                    Modifiedby = item.modifiedby,
                    Modifiedpc = item.modifiedpc,
                    StateChange2 = EnumStateChange.Select.ToString()
                });

            return (IEnumerable<T>) obj.ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.costs select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query =
                (from a in Entities.costs select a).Where(whereterm, ListValue.ToArray())
                    .OrderBy(paging.SortColumn + " " + paging.Direction)
                    .Skip(paging.Start)
                    .Take(paging.Limit)
                    .ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.costs select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();

            var obj = (from item in query
                join p in Entities.payment_type on item.payment_type_id equals p.id
                select new CostModel
                {
                    Id = item.id,
                    Rowstatus = item.rowstatus,
                    Rowversion = item.rowversion,
                    DateProcess = item.date_process,
                    Code = item.code,
                    BranchId = item.branch_id,
                    PaymentTypeId = item.payment_type_id,
                    PaymentType = p.name,
                    Description = item.description,
                    Total = item.total,
                    HardCash = item.hard_cash,
                    Printed = item.printed,
                    Createddate = item.createddate,
                    Createdby = item.createdby,
                    Createdpc = item.createdpc,
                    Modifieddate = item.modifieddate,
                    Modifiedby = item.modifiedby,
                    Modifiedpc = item.modifiedpc,
                    StateChange2 = EnumStateChange.Select.ToString()
                }).ToList();
            return (IEnumerable<T>) obj;
        }

        public IEnumerable<PaymentInJournal> DetailJournals(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.costs select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var obj = (from d in
                           (from d in Entities.cost_detail where d.rowstatus.Equals(true) select d)
                       join q in query on d.cost_id equals q.id
                       join p in
                           (from p in Entities.payment_type where p.rowstatus.Equals(true) select p) on q.payment_type_id
                           equals p.id
                       join c in Entities.cost_type on d.cost_type_id equals c.id
                       select new PaymentInJournal
                       {
                           Code = q.code,
                           DateProcces = d.date_process,
                           PaymentType = p.name,
                           Description = c.name,
                           Company = "",
                           Balance = 0,
                           Total = d.amount
                       }).ToList();

            return obj;
        }

        public IEnumerable<T> GetMonthlyCostSummary<T>(int branchId, DateTime? fromDate, DateTime? toDate)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("c.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            whereClauses.Add("c.branch_id = @branchId");
            parameters.Add(new MySqlParameter("branchId", branchId));


            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(c.date_process) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(c.date_process) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            string sql = @"
                        SELECT
                            CONCAT (DisplayDate, ' (', FORMAT(t2.GrandTotal, 0), ')') DisplayDate,
                            DateProcess,
                            Total
                        FROM (
                            SELECT
                                DATE_FORMAT(c.date_process, '%b/%Y') AS DisplayDate,
                                CAST(DATE_FORMAT(c.date_process ,'%Y-%m-01') as DATE) AS DateProcess,
                                SUM(c.Total) AS Total
                            FROM cost c
                            WHERE " + string.Join(" AND ", whereClauses) + @"
                            GROUP BY DATE_FORMAT(c.date_process, '%b/%Y')
                        )t
                        LEFT JOIN (
                            SELECT SUM(c.total) GrandTotal, DATE_FORMAT(c.date_process, '%b/%Y') AS Date1
                            FROM shipment c WHERE " + string.Join(" AND ", whereClauses) + @"
                            GROUP BY DATE_FORMAT(c.date_process, '%b/%Y')
                        )t2 ON t.DisplayDate = t2.Date1
                        ORDER BY t.DateProcess ASC";

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<T> GetDailyCostSummary<T>(int branchId, DateTime? fromDate, DateTime? toDate)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("c.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            whereClauses.Add("c.branch_id = @branchId");
            parameters.Add(new MySqlParameter("branchId", branchId));


            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(c.date_process) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(c.date_process) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            string sql = @"
                        SELECT
                            CONCAT (DisplayDate, ' (', FORMAT(t2.GrandTotal, 0), ')') DisplayDate,
                            DateProcess,
                            Total
                        FROM (
                            SELECT
                                DATE_FORMAT(c.date_process, '%d/%m/%Y') AS DisplayDate,
                                CAST(c.date_process as DATE) AS DateProcess,
                                SUM(c.Total) AS Total
                            FROM cost c
                            WHERE " + string.Join(" AND ", whereClauses) + @"
                            GROUP BY CAST(c.date_process as DATE)
                        )t
                        LEFT JOIN (
                            SELECT SUM(c.total) GrandTotal, DATE_FORMAT(c.date_process, '%d/%m/%Y') AS Date1
                            FROM shipment c WHERE " + string.Join(" AND ", whereClauses) + @"
                            GROUP BY CAST(c.date_process as DATE)
                        )t2 ON t.DisplayDate = t2.Date1
                        ORDER BY t.DateProcess ASC";

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }
    }
}