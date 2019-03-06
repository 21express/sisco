using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;

namespace SISCO.App.Billing
{
    public class SalesInvoiceListDataManager : BaseDataManager
    {
        public SalesInvoiceListDataManager()
        {
            Repository = new SalesInvoiceListRepository();
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

        public void Save<T>(SalesInvoiceModel parent, IList<T> shipments)
        {
            ((SalesInvoiceListRepository)Repository).Save<T>(parent, shipments);
        }

        public void RemoveDetail (int pid)
        {
            new SalesInvoiceListRepository().RemoveDetail(pid);
        }

        public void CancelInvoice(List<int> canceledInvoiceIds)
        {
            ((SalesInvoiceListRepository)Repository).CancelInvoice(canceledInvoiceIds);
        }

        public void DeleteRow(List<int> deleteInvoiceIds, int parentId, string modifiedBy)
        {
            ((SalesInvoiceListRepository)Repository).DeleteRows(deleteInvoiceIds, parentId, modifiedBy);
        }

        public List<SalesInvoiceListModel> GetJoinShipmentAndDelivery(int salesInvoiceId)
        {
            return ((SalesInvoiceListRepository)Repository).GetJoinShipmentAndDelivery(salesInvoiceId);
        }

        public List<SalesInvoiceListDataRow> GetFuckingShipments(int salesInvoiceId)
        {
            return new SalesInvoiceListRepository().GetFuckingShipments(salesInvoiceId);
        }
    }
}
