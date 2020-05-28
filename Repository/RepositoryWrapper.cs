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
        private IAccountRepository account;
        private ICasesRepository cases;
        private ICaseHistoryRepository caseHistory;
        private IColorRepository color;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }
        public IAccountRepository Account
        {
            get
            {
                if(account == null)
                {
                    account = new AccountRepository(repositoryContext);
                }
                return account;
            }
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

        public IColorRepository Color
        {
            get
            {
                if(color == null)
                {
                    color = new ColorRepository(repositoryContext);
                }
                return color;
            }
        }

        public void Save()
        {
            repositoryContext.SaveChanges();
        }
    }
}
