

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
    public class ConfigRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Airline";
        public ConfigRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public ConfigRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
        
        public string Get(string key)
        {
            var query = from o in Entities.configs
                        where o.key == key
                        select o.value;

            return query.FirstOrDefault();
        }

        public override void Save<T>(T businessModel)
        {
            throw new NotImplementedException();
        }

        public override void Update<T>(T businessModel)
        {
            throw new NotImplementedException();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
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

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            throw new NotImplementedException();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            throw new NotImplementedException();
        }

        public DateTime GetServerDateTime()
        {
            string sql = @"SELECT NOW() AS DateTime";

            var serverDateTimeInquiryResult = Entities.ExecuteStoreQuery<ServerDateTimeInquiryResult>(sql).FirstOrDefault();
            if (serverDateTimeInquiryResult != null)
                return serverDateTimeInquiryResult.DateTime;

            return new DateTime();
        }

        public class ServerDateTimeInquiryResult
        {
            public DateTime DateTime { get; set; }
        }
    }
}


