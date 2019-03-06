using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;
using SISCO.Models.MasterData;

namespace SISCO.App.MasterData
{
    public class BankAccountDataManager : BaseDataManager, IExtendedQueryableDataManager
    {
        public BankAccountDataManager()
        {
            Repository = new BankAccountRepository();
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] listParameter)
        {
            return Repository.Get<T>(listParameter);
        }

        public override T GetFirst<T>(params IListParameter[] listParameter)
        {
            return Repository.GetSingle<T>(listParameter);
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int count, params IListParameter[] listParameter)
        {
            return Repository.Get<T>(paging, out count, listParameter);
        }

        public override void Save<T>(IBaseModel businessModel)
        {
            Repository.Save(businessModel);
        }

        public override void Update<T>(IBaseModel businessModel)
        {
            Repository.Update(businessModel);
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            Repository.DeActive(id, userName, deleteDate);
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            return ((BankAccountRepository)Repository).Get<T>(paging, out totalCount, expression, parameters);
        }
    }
}
