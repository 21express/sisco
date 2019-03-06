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
    public class PrefixCodeRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "PrefixCode";
        public PrefixCodeRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public PrefixCodeRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as PrefixCodeModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddToprefix_code(entity);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as PrefixCodeModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.prefix_code where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as PrefixCodeModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.prefix_code select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.prefix_code where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.airwaybills where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static prefix_code PopulateModelToNewEntity(PrefixCodeModel model)
        {
            return new prefix_code
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                branch_id = model.BranchId,
                prefix = model.Prefix,
                table = model.Table,
                tgl = model.Tgl,
                bulan = model.Bulan,
                tahun = model.Tahun,
                urut = model.Urut,
                createddate = model.Createddate,
                createdby = model.Createdby,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
            };
        }

        private static void PopulateModelToNewEntity(prefix_code query, PrefixCodeModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.branch_id = model.BranchId;
            query.prefix = model.Prefix;
            query.table = model.Table;
            query.tgl = model.Tgl;
            query.bulan = model.Bulan;
            query.tahun = model.Tahun;
            query.urut = model.Urut;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
        }

        private static PrefixCodeModel PopulateEntityToNewModel(prefix_code item)
        {
            return new PrefixCodeModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                BranchId = item.branch_id,
                Prefix = item.prefix,
                Table = item.table,
                Tgl = item.tgl,
                Bulan = item.bulan,
                Tahun = item.tahun,
                Urut = item.urut,
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby
            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query =
                (from a in Entities.prefix_code select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.prefix_code select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.prefix_code select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.prefix_code select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public int GenerateCode(string tableName, int branchId, int tgl, int bulan, int tahun, ref string prefix)
        {
            return PrefixCodeGenerator(tableName, branchId, tgl, bulan, tahun, ref prefix);
        }

        public int GenerateBookingPod (int bookingCount, int branchId, int tgl, int bulan, int tahun, ref string prefix)
        {
            return BookingGenerator(bookingCount, branchId, tgl, bulan, tahun, ref prefix);
        }
    }
}