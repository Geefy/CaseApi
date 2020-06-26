using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext repositoryContext;
        private ICasesRepository cases;
        private ICaseHistoryRepository caseHistory;
        private IStandRepository stand;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public ICaseHistoryRepository CaseHistory
        {
            get
            {
                if(caseHistory == null)
                {
                    caseHistory = new CaseHistoryRepository(repositoryContext);
                }
                return caseHistory;
            }
        }

        public ICasesRepository Cases
        {
            get
            {
                if(cases == null)
                {
                    cases = new CasesRepository(repositoryContext);
                }
                return cases;
            }
        }

        public IStandRepository Stand
        {
            get
            {
                if(stand == null)
                {
                    stand = new StandRepository(repositoryContext);
                }
                return stand;
            }
        }

        public void Save()
        {
            repositoryContext.SaveChanges();
        }
    }
}
