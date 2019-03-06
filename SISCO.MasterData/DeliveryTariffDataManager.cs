using System.Collections.Generic;

using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.MasterData
{
    public class DeliveryTariffDataManager : BaseDataManager
    {
        public DeliveryTariffDataManager()
        {
            Repository = new DeliveryTariffRepository();
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

        public void Save(PackageTypeModel p, IList<DeliveryTariffModel> tariffs)
        {
            ((DeliveryTariffRepository)Repository).Save(p, tariffs);
        }

        public DeliveryTariffModel GetByPackageTypeAndWeight(int packageTypeId, int destCityId, decimal chargeableWeight)
        {
            return ((DeliveryTariffRepository)Repository).GetByPackageTypeAndWeight(packageTypeId, destCityId, chargeableWeight);
        }
    }
}
