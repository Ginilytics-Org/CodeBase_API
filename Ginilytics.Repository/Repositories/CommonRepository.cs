using Ginilytics.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ginilytics.Repository.Repositories
{
    [SingletonService]
    public class CommonRepository : ICommonRepository
    {
        private readonly IDbProvider _dbProvider;

        public CommonRepository(IDbProvider dbProvider)
        {
            _dbProvider = dbProvider;
        }
       
    }
}
