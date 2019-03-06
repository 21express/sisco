using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.MasterData
{
    public class PaymentTypeDataManager : BaseDataManager, IExtendedQueryableDataManager
    {
        public PaymentTypeDataManager()
        {
            Repository = new PaymentTypeRepository();
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

        public void Save(IList<PaymentTypeModel> list, IList<PaymentTypeModel> deletedList, string actor)
        {
            ((PaymentTypeRepository)Repository).SaveList(list, deletedList, actor);
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            return ((PaymentTypeRepository)Repository).Get<T>(paging, out totalCount, expression, parameters);
        }
    }
}