using System;
using System.Collections.Generic;

using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.MasterData
{
    public class ConfigDataManager : BaseDataManager
    {
        public ConfigDataManager()
        {
            Repository = new ConfigRepository();
        }

        public string Get(string key)
        {
            return ((ConfigRepository)Repository).Get(key);
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] listParameter)
        {
            throw new NotImplementedException();
        }

        public override T GetFirst<T>(params IListParameter[] listParameter)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int count, params IListParameter[] listParameter)
        {
            throw new NotImplementedException();
        }

        public DateTime GetServerDateTime()
        {
            return ((ConfigRepository)Repository).GetServerDateTime();
        }
    }
}
