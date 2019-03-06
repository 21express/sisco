using System;
using System.Data;
using System.Linq;
using Devenlab.Common.Patterns;
using MySql.Data.MySqlClient;
using SISCO.Repositories.Context;
using System.Configuration;

namespace SISCO.Repositories
{
    // ReSharper disable once InconsistentNaming
    public abstract class SISCOBaseRepository : BaseRepository
    {
        public SISCODBEntities Entities;

        protected SISCOBaseRepository()
        {
            if (!string.IsNullOrEmpty(ConnectionString)) Entities = new SISCODBEntities(ConnectionString);
            else Entities = new SISCODBEntities();

            Entities.CommandTimeout = Timeout;
            _withoutDefault = false;
            //((IObjectContextAdapter)Entities).ObjectContext.CommandTimeout = Timeout;
        }

        protected int Timeout
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["EntityTimeout"]); }
        }

        public override void Dispose()
        {
        }

        public string GenerateCode(string entity, string pattern)
        {
            var row = Entities.ExecuteStoreQuery<GenerateCodeResultRow>("call GenerateCode(@entity, @pattern)",
                new MySqlParameter("entity", entity),
                new MySqlParameter("pattern", pattern)
            ).FirstOrDefault();

            // ReSharper disable once PossibleNullReferenceException
            return row.GeneratedCode;
        }

        public string GenerateCode_2(string entity, string pattern)
        {
            var row = Entities.ExecuteStoreQuery<GenerateCodeResultRow>(string.Format("call GenerateCode('{0}', '{1}')", entity, pattern)).FirstOrDefault();
            return row.GeneratedCode;
        }

        public int PrefixCodeGenerator(string tableName, int branchId, int tgl, int bulan, int tahun, ref string prefix)
        {
            var row = Entities.ExecuteStoreQuery<PrefixCodeResult>("call PrefixCodeGenerator(@tablename, @branch_id, @tgl, @bulan, @tahun)",
                new MySqlParameter("tablename", tableName),
                new MySqlParameter("branch_id", branchId),
                new MySqlParameter("tgl", tgl),
                new MySqlParameter("bulan", bulan),
                new MySqlParameter("tahun", tahun)
            ).FirstOrDefault();

            prefix = row.prefix;

            // ReSharper disable once PossibleNullReferenceException
            return row.index;
        }

        public int BookingGenerator(int bookingCount, int branchId, int tgl, int bulan, int tahun, ref string prefix)
        {
            var row = Entities.ExecuteStoreQuery<PrefixCodeResult>("call GenerateBooking(@booking_count, @branch_id, @tgl, @bulan, @tahun)",
                new MySqlParameter("booking_count", bookingCount),
                new MySqlParameter("branch_id", branchId),
                new MySqlParameter("tgl", tgl),
                new MySqlParameter("bulan", bulan),
                new MySqlParameter("tahun", tahun)
            ).FirstOrDefault();

            prefix = row.prefix;

            // ReSharper disable once PossibleNullReferenceException
            return row.index;
        }

        protected class GenerateCodeResultRow
        {
            public string GeneratedCode { get; set; }
        }

        protected class PrefixCodeResult
        {
            public int index { get; set; }
            public string prefix { get; set; }
        }
    }
}
