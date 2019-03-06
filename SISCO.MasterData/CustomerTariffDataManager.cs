using System;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;
using SISCO.Repositories.Context;

namespace SISCO.App.MasterData
{
    public class CustomerTariffDataManager : BaseDataManager
    {
        public CustomerTariffDataManager()
        {
            Repository = new CustomerTariffRepository();
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

        public CustomerTariffModel GetTariff(int cityOrigId, int cityDestId, int serviceTypeId, int packageTypeId, int customerId, decimal weight)
        {
            return ((CustomerTariffRepository)Repository).GetTariff(cityOrigId, cityDestId, serviceTypeId, packageTypeId, customerId, weight);
        }

        public void Save(CustomerModel p, IList<CustomerTariffModel> tariffs)
        {
            ((CustomerTariffRepository)Repository).Save(p, tariffs); ;
        }
    }
}
