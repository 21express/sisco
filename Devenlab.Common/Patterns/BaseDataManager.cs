using System;
using System.Collections.Generic;
using Devenlab.Common.Interfaces;

namespace Devenlab.Common.Patterns
{
    public abstract class BaseDataManager : IDataManager, IDisposable
    {
        protected BaseRepository Repository;
        public abstract IEnumerable<T> Get<T>(params IListParameter[] listParameter) where T : IBaseModel;

        public abstract T GetFirst<T>(params IListParameter[] listParameter) where T : IBaseModel;

        public abstract IEnumerable<T> Get<T>(Paging paging, out int count, params IListParameter[] listParameter)
            where T : IBaseModel;


        public virtual IListParameter[] DefaultParameters
        {
            set { Repository.DefaultParameters = value; }
            get { return Repository.DefaultParameters; }
        }

        public virtual void Save<T>(IBaseModel businessModel)
        {
            Repository.Save(businessModel);
        }

        public virtual void Update<T>(IBaseModel businessModel)
        {
            Repository.Update(businessModel);
        }

        public virtual void DeActive(int id, string userName, System.DateTime deleteDate)
        {
            Repository.DeActive(id, userName, deleteDate);
        }

        public virtual void Dispose()
        {
            if (Repository != null)
                Repository.Dispose();
        }
    }
}
