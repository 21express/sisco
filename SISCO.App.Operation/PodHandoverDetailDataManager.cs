﻿using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.App.Operation
{
    public class PodHandoverDetailDataManager : BaseDataManager
    {
        public PodHandoverDetailDataManager()
        {
            Repository = new PodHandoverDetailRepository();
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

        public List<PodHandoverRowDetail> GetPodHandovers(int handoverId)
        {
            return new PodHandoverDetailRepository().GetPodHandovers(handoverId);
        }
    }
}
