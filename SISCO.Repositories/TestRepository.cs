using System;
using System.Collections.Generic;
using System.Diagnostics;
using Devenlab.Common.Patterns;
using Devenlab.Common.Interfaces;
using SISCO.Repositories.Context;

namespace SISCO.Repositories
{
    public class TestRepository: BaseRepository
    {
        public string MessageErrorConn { get; set; }
        // ReSharper disable once ParameterHidesMember
        public bool TestConnection(string connStr)
        {
            try
            {
                var dbConnection = new SISCODBEntities(connStr).Connection;
                dbConnection.Open();
                dbConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                // ReSharper disable once ConvertToConstant.Local
                //var source = "SISCO";
                // ReSharper disable once ConvertToConstant.Local
                //var log = "Application";
                //if (!EventLog.SourceExists(source))
                //    EventLog.CreateEventSource(source, log);

                //EventLog.WriteEntry(source, ex.Message, EventLogEntryType.Warning, 234);
                throw ex;
            }
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
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

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            throw new NotImplementedException();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<T> Get<T>(Devenlab.Common.Paging paging, out int totalCount, params IListParameter[] parameter)
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
    }
}
