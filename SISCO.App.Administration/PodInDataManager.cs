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
    public class PodInDataManager : BaseDataManager
    {
        public PodInDataManager()
        {
            Repository = new PodInRepository();
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
            if (string.IsNullOrEmpty(((PodInModel)businessModel).Code))
            {
                ((PodInModel)businessModel).Code = GenerateCode(businessModel as PodInModel);
            }

            Repository.Save(businessModel);
        }

        public string GenerateCode(PodInModel model)
        {
            return ((PodInRepository)Repository).GenerateCode(model);
        }

        public IEnumerable<PodInModel.PodInLookupDataRow> GetJoinShipment(Paging paging, out int count, IListParameter[] parameters)
        {
            return ((PodInRepository)Repository).GetJoinShipment(paging, out count, parameters);
        }
    }
}
