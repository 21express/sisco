﻿using System;
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
    public class PickupDocumentPodDataManager : BaseDataManager
    {
        public PickupDocumentPodDataManager()
        {
            Repository = new PickupDocumentPodRepository();
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

        public IEnumerable<PickupDocumentAndPod> FilterDocumentPickup(IEnumerable<PickupDocumentModel> master,
            params IListParameter[] parameter)
        {
            return new PickupDocumentPodRepository().FilterDocumentPickup(master, parameter);
        }
    }
}
