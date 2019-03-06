using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories;
using Devenlab.Common.Patterns;

namespace SISCO.App.Administration
{
    public class PodCustomerDataManager : BaseDataManager
    {
        public PodCustomerDataManager()
        {
            Repository = new PodCustomerRepository();
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
            if (string.IsNullOrEmpty(((PodCustomerModel)businessModel).Code))
            {
                ((PodCustomerModel)businessModel).Code = GenerateCode(businessModel as PodCustomerModel);
            }

            Repository.Save(businessModel);
        }

        public string GenerateCode(PodCustomerModel model)
        {
            return ((PodCustomerRepository)Repository).GenerateCode(model);
        }

        public IEnumerable<PodCustomerModel.PodCustomerLookupDataRow> GetJoinShipment(Paging paging, out int count, IListParameter[] parameters)
        {
            return ((PodCustomerRepository)Repository).GetJoinShipment(paging, out count, parameters);
        }
    }
}
