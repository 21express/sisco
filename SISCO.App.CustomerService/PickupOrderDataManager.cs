using System;
using System.Collections.Generic;

using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Repositories;

namespace SISCO.App.CustomerService
{
    public class PickupOrderDataManager : BaseDataManager
    {
        public PickupOrderDataManager()
        {
            Repository = new PickupOrderRepository();
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

        public IEnumerable<PickupOrderModel> Grid(int show, DateTime? date, int? messengerId)
        {
            IListParameter[] param;
            var p = new List<WhereTerm>();
            p.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));

            var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);

            switch (show)
            {
                case 0:
                    p.Add(WhereTerm.Default(false, "cancelled"));
                    p.Add(WhereTerm.Default(false, "picked_up"));
                    break;
                case 1:
                    if (date > dateNull)
                    {
                        p.Add(WhereTerm.Default((DateTime) date, "date_process", EnumSqlOperator.Equals));
                    }
                    break;
                case 2:
                    // ReSharper disable once PossibleInvalidOperationException
                    if (messengerId > 0) p.Add(WhereTerm.Default((int) messengerId, "messenger_id", EnumSqlOperator.Equals));                    
                    break;
                case 3:
                    if (date > dateNull)
                    {
                        p.Add(WhereTerm.Default((DateTime)date, "date_process", EnumSqlOperator.Equals));
                    }
                    p.Add(WhereTerm.Default(true, "cancelled"));
                    break;
            }

            // ReSharper disable once CoVariantArrayConversion
            param = p.ToArray();
            return new PickupOrderRepository().GetGrid<PickupOrderModel>(param);
        }

        public IEnumerable<PickupOrderModel> GridCash(params IListParameter[] parameter)
        {
            return new PickupOrderRepository().GetGrid<PickupOrderModel>(parameter);
        }

        public IEnumerable<PickupOrderModel> Arrangement(IListParameter[] param)
        {
            return new PickupOrderRepository().GetGrid<PickupOrderModel>(param);
        }
    }
}
