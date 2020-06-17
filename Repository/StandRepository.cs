using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class StandRepository : RepositoryBase<Stand>, IStandRepository
    {
        public StandRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public void CreateStand(Stand stand)
        {
            Create(stand);
        }
        public IEnumerable<Stand> GetAllStands()
        {
            return FindAll().OrderBy(stands => stands.StandName).ToList();
        }
        public Stand GetStandByName(string standName)
        {
            return FindByCondition(stand => stand.StandName.Equals(standName)).FirstOrDefault();
        }
    }
}
