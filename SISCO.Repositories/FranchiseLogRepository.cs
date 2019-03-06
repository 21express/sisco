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
    public class FranchiseLogRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Franchise Log";
        public FranchiseLogRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public FranchiseLogRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as FranchiseLogModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTofranchise_log(entity);
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

        private static franchise_log PopulateModelToNewEntity(FranchiseLogModel model)
		{
			return new franchise_log
			{
				id = model.Id,
                franchise_id = model.FranchiseId,
                franchise_name = model.FranchiseName,
                app_version = model.AppVersion,
                inserted_date = model.InsertedDate
			};
		}
        
        private static void PopulateModelToNewEntity(franchise_log query, FranchiseLogModel model)
		{
			query.id = model.Id;
            query.franchise_id = model.FranchiseId;
            query.franchise_name = model.FranchiseName;
            query.app_version = model.AppVersion;
            query.inserted_date = model.InsertedDate;
		}

        private static FranchiseLogModel PopulateEntityToNewModel(franchise_log item)
		{
            throw new NotImplementedException();
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


