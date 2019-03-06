using System.Collections.Generic;

using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.MasterData
{
    public class AirlineTariffDataManager : BaseDataManager
    {
        public AirlineTariffDataManager()
        {
            Repository = new AirlineTariffRepository();
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

        public void Save<T>(int airlineId, IList<T> models)
        {
            ((AirlineTariffRepository)Repository).Save<T>(airlineId, models);
        }

        public void Save(AirlineModel p, IList<AirlineTariffModel> tariffs)
        {
            ((AirlineTariffRepository)Repository).Save(p, tariffs); ;
        }
    }
}
