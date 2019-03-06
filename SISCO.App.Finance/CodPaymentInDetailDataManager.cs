using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;
using SISCO.Models;

namespace SISCO.App.Finance
{
    public class CodPaymentInDetailDataManager : BaseDataManager
    {
        public CodPaymentInDetailDataManager()
        {
            Repository = new CodPaymentInDetailRepository();
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

        public List<CodPaymentInDetailModel> GetUpaidShipment(int branchId)
        {
            return new CodPaymentInDetailRepository().GetUpaidShipment(branchId);
        }

        public CodPaymentInDetailModel GetUpaidShipment(int branchId, string code)
        {
            return new CodPaymentInDetailRepository().GetUpaidShipment(branchId, code);
        }

        public IEnumerable<CodPaymentAndShipmentCode> FilterCod(IEnumerable<CodPaymentInModel> master, params IListParameter[] parameter)
        {
            return new CodPaymentInDetailRepository().FilterCod(master, parameter);
        }
    }
}