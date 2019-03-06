using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.MasterData
{
    public class CustomerDataManager : BaseDataManager, IExtendedQueryableDataManager
    {
        public CustomerDataManager()
        {
            Repository = new CustomerRepository();
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
            if (string.IsNullOrEmpty(((CustomerModel)businessModel).Code))
            {
                ((CustomerModel)businessModel).Code = GenerateCode(businessModel as CustomerModel);
            }

            Repository.Save(businessModel);
        }

        public string GenerateCode(CustomerModel model)
        {
            return ((CustomerRepository)Repository).GenerateCode(model);
        }

        public string GenerateFranchiseCode(CustomerModel model)
        {
            return ((CustomerRepository)Repository).GenerateFranchiseCode(model);
        }

        public string GenerateFranchiseCode_2(CustomerModel model)
        {
            return ((CustomerRepository)Repository).GenerateFranchiseCode_2(model);
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            return ((CustomerRepository)Repository).Get<T>(paging, out totalCount, expression, parameters);
        }

        public int GetCount(params IListParameter[] parameter)
        {
            return ((CustomerRepository)Repository).GetCount(parameter);
        }
    }
}
