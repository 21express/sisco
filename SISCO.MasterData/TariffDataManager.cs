using System;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.MasterData
{
    public class TariffDataManager : BaseDataManager
    {
        public TariffDataManager()
        {
            Repository = new TariffRepository();
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

        public TariffModel GetTariff(int cityOrigId, int cityDestId, int serviceTypeId, int packageTypeId, decimal weight)
        {
            return ((TariffRepository)Repository).GetTariff(cityOrigId, cityDestId, serviceTypeId, packageTypeId, weight);
        }

        public void Save(CityModel p, IList<TariffModel> tariffs)
        {
            ((TariffRepository)Repository).Save(p, tariffs);
        }

        public IEnumerable<TariffModel> GetTariffs(string cityOrgName)
        {
            return ((TariffRepository)Repository).GetTariffs(cityOrgName);
        }

        public List<TariffModel> GetTarif(int OrigId, int DestId)
        {
            return new TariffRepository().GetTarif(OrigId, DestId);
        }
    }
}
