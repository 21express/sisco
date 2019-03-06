using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories;
using Devenlab.Common.Patterns;

namespace SISCO.App.Operation
{
    public class ManifestDetailDataManager : BaseDataManager
    {
        public ManifestDetailDataManager()
        {
            Repository = new ManifestDetailRepository();
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

        public IEnumerable<ManifestDetailModel> GetInbound(int destbranchid, string shipmentcode)
        {
            return ((ManifestDetailRepository) Repository).GetInbound(destbranchid, shipmentcode);
        }

        public IEnumerable<ManifestDetailModel> GetDetail(params IListParameter[] parameter)
        {
            return new ManifestDetailRepository().GetDetail(parameter);
        }

        public List<ManifestDetailTemp> IsManifested(List<string> shipmentCodes)
        {
            return new ManifestDetailRepository().IsManifested(shipmentCodes);
        }

        public bool IsConsolExists(string consolCode)
        {
            return new ManifestDetailRepository().IsConsolExists(consolCode);
        }
    }
}