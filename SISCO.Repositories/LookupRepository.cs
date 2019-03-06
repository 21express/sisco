using MySql.Data.MySqlClient;
using SISCO.Models;
using SISCO.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.Repositories
{
    public class LookupRepository : SISCOBaseRepository
    {
        public LookupModel Get(string category)
        {
            var sql = @"SELECT
                            id,
                            category,
                            value
                        FROM lookups
                        WHERE category = @category";

            return Entities.ExecuteStoreQuery<LookupModel>(sql, new MySqlParameter("category", category)).FirstOrDefault();
        }

        public override void Save<T>(T businessModel)
        {
            throw new NotImplementedException();
        }

        public override void Update<T>(T businessModel)
        {
            throw new NotImplementedException();
        }

        public override void Update<T>(T businessModel, params Devenlab.Common.Interfaces.IListParameter[] parameter)
        {
            throw new NotImplementedException();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<T> Get<T>(params Devenlab.Common.Interfaces.IListParameter[] parameter)
        {
            throw new NotImplementedException();
        }

        public override T GetSingle<T>(params Devenlab.Common.Interfaces.IListParameter[] parameter)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<T> Get<T>(Devenlab.Common.Paging paging, out int totalCount, params Devenlab.Common.Interfaces.IListParameter[] parameter)
        {
            throw new NotImplementedException();
        }
    }
}