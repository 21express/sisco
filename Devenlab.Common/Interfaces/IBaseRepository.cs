using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Devenlab.Common.Interfaces
{
    public interface IBaseRepository : IDisposable
    {

        void Save<T>(T businessModel) where T : IBaseModel;
        void Update<T>(T businessModel) where T : IBaseModel;
        void Update<T>(T businessModel, params IListParameter[] parameter) where T : IBaseModel;
        void DeActive(int id, string userName, DateTime deleteDate);
        void Delete(int id);
        IEnumerable<T> Get<T>(params IListParameter[] parameter) where T : IBaseModel;
        T GetSingle<T>(params IListParameter[] parameter) where T : IBaseModel;
        IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter) where T : IBaseModel;
    }
}
