using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using SISCO.Repositories.Interfaces;

namespace SISCO.Repositories
{
    public class ApiLogRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Api Log";
        public ApiLogRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public ApiLogRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as ApiLogModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToapi_log(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
            throw new NotImplementedException();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            throw new NotImplementedException();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            throw new NotImplementedException();
        }
        
        public override void Delete(int id)
		{
            throw new NotImplementedException();
		}
        
        private static api_log PopulateModelToNewEntity(ApiLogModel model)
		{
			return new api_log
			{
                id = model.Id,
				ref_id = model.RefId,
                method_name = model.MethodName,
                message = model.Message,
                ip = model.Ip,
                api_type = model.ApiType,
                inserted_at = model.InsertedAt
			};
		}
        
        private static void PopulateModelToNewEntity(api_log query, ApiLogModel model)
		{
            query.id = model.Id;
			query.ref_id = model.RefId;
            query.method_name = model.MethodName;
            query.message = model.Message;
            query.ip = model.Ip;
            query.api_type = model.ApiType;
            query.inserted_at = model.InsertedAt;
		}
        
        private static ApiLogModel PopulateEntityToNewModel(api_log item)
		{
			return new ApiLogModel
			{
                Id = item.id,
				RefId = item.ref_id,
                MethodName = item.method_name,
                Message = item.message,
                Ip = item.ip,
                ApiType = item.api_type,
                InsertedAt = item.inserted_at
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
            throw new NotImplementedException();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
            throw new NotImplementedException();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
            throw new NotImplementedException();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}


