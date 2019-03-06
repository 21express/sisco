using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.App.CustomerService
{
    public class ShipmentInsuranceDetailDataManager : BaseDataManager
    {
        public  ShipmentInsuranceDetailDataManager()
        {
            Repository = new ShipmentInsuranceDetailRepository();
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

        public List<InsuranceDetail> GetInsuranceDetail(int insuranceId)
        {
            return new ShipmentInsuranceDetailRepository().GetInsuranceDetail(insuranceId);
        }

        public void SaveInsurance(List<InsuranceDetail> data, int insuranceId, string username, string machineName)
        {
            new ShipmentInsuranceDetailRepository().SaveInsurance(data, insuranceId, username, machineName);
        }

        public void DeleteAll(int insuranceId)
        {
            new ShipmentInsuranceDetailRepository().DeleteAll(insuranceId);
        }
    }
}