using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Entities.Models;
using System.Threading.Tasks;
using Contracts;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public Account GetAccountByUsername(string username)
        {
            return FindByCondition(account => account.Username.Equals(username)).FirstOrDefault();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return FindAll().OrderBy(acc => acc.Username).ToList();
        }
    }
}
