using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class CaseHistoryRepository : RepositoryBase<CaseHistory>, ICaseHistoryRepository
    {
        public CaseHistoryRepository(RepositoryContext repositoryContext) : base (repositoryContext)
        {

        }
    }
}
