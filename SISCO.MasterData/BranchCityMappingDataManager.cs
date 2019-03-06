using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;
using SISCO.Models.MasterData;

namespace SISCO.App.MasterData
{
    public class BranchCityListDataManager : BaseDataManager
    {
        public BranchCityListDataManager()
        {
            Repository = new BranchCityListRepository();
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

        public void Save(BranchModel p, IList<BranchCityListModel> schedules)
        {
            ((BranchCityListRepository)Repository).Save(p, schedules); ;
        }
    }
}
