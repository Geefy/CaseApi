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
        public CaseHistoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public IEnumerable<CaseHistory> GetCaseHistoriesByStand(string standName)
        {
            List<CaseHistory> returnCases = new List<CaseHistory>();
            List<CaseHistory> allCases = FindAll().OrderBy(cases => cases.StandName).ToList();
            foreach (CaseHistory caseHistory in allCases)
            {
                if (caseHistory.StandName == standName)
                {
                    returnCases.Add(caseHistory);
                }
            }
            return returnCases;
        }
    }
}
