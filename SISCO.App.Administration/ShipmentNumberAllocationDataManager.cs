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
using SISCO.Repositories.Context;

namespace SISCO.App.Administration
{
    public class ShipmentNumberAllocationDataManager : BaseDataManager
    {
        public ShipmentNumberAllocationDataManager()
        {
            Repository = new ShipmentAllocationRepository();
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

        public int GetAllocationUsedCount(ShipmentAllocationModel model)
        {
            return ((ShipmentAllocationRepository)Repository).GetAllocationUsedCount(model);
        }

        public ShipmentAllocationModel GetAllocationByCustomer(Int64 shipmentNo, int branchId)
        {
            return Repository.GetSingle<ShipmentAllocationModel>(new IListParameter[]
            {
                WhereTerm.Default(branchId, "branch_id", EnumSqlOperator.Equals),
                WhereTerm.Default(shipmentNo, "shipment_code_start", EnumSqlOperator.LesThanEqual),
                WhereTerm.Default(shipmentNo, "shipment_code_end", EnumSqlOperator.GreatThanEqual)
            });
        }

        public bool CheckIsUsed(int currentId, Int64 start, Int64 end)
        {
            return ((ShipmentAllocationRepository)Repository).CheckIsUsed(currentId, start, end);
        }
    }
}
