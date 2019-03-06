using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Repositories;
using SISCO.Models;
using System;

namespace SISCO.App.Finance
{
    public class PettyCashJournalDataManager : BaseDataManager
    {
        public PettyCashJournalDataManager()
        {
            Repository = new PettyCashJournalRepository();
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

        public List<PettyCashDetailJournalModel> GetJournals (int pettyId)
        {
            return new PettyCashJournalRepository().GetJournals(pettyId);
        }

        public List<PettyCashSearch> Search (int branchId, string code = null, string description = null, DateTime? dateFrom = null,
            DateTime? dateTo = null, int? employeeId = null)
        {
            return new PettyCashJournalRepository().Search(branchId, code, description, dateFrom, dateTo, employeeId);
        }

        public List<PettyCashSummary> GetSummary(int branchId, DateTime beforeDate)
        {
            return new PettyCashJournalRepository().GetSummary(branchId, beforeDate);
        }
    }
}