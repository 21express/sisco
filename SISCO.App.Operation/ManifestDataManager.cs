using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.Repositories;
using Devenlab.Common.Patterns;
using SISCO.Models;
using System;

namespace SISCO.App.Operation
{
    public class ManifestDataManager : BaseDataManager
    {
        public ManifestDataManager()
        {
            Repository = new ManifestRepository();
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
            base.Save<T>(businessModel);

            ActionPoster.Post(0, businessModel.Createdby, Transaction.Manifest, businessModel);
        }

        public List<ManifestList> GetManifestList(int branchId, DateTime date, int? destId)
        {
            return new ManifestRepository().GetManifestList(branchId, date, destId);
        }
    }
}