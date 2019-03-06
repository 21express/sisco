using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Devenlab.Common.Interfaces
{
    public interface IExtendedQueryableDataManager
    {
        IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters);
    }
}