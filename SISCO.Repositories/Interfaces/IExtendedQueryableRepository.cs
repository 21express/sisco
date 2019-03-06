using System.Collections.Generic;
using Devenlab.Common;

namespace SISCO.Repositories.Interfaces
{
    interface IExtendedQueryableRepository
    {
        IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters);
    }
}
