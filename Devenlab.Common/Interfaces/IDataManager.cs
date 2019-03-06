using System;
using System.Collections;
using System.Collections.Generic;

namespace Devenlab.Common.Interfaces
{
    public interface IDataManager
    {
        IEnumerable<T> Get<T>(params IListParameter[] listParameter) where T : IBaseModel;
        T GetFirst<T>(params IListParameter[] listParameter) where T : IBaseModel;
        IEnumerable<T> Get<T>(Paging paging, out int count, params IListParameter[] listParameter) where T : IBaseModel;
        IListParameter[] DefaultParameters { set; get; }
        void Dispose();
    }
}
