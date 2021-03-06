﻿using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class CasesRepository : RepositoryBase<Cases>, ICasesRepository
    {
        public CasesRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public IEnumerable<Cases> GetCasesByStand(string standName)
        {
            List<Cases> returnCases = new List<Cases>();
            List<Cases> allCases = FindAll().OrderBy(cases => cases.StandName).ToList();
            foreach (Cases cases in allCases)
            {
                if (cases.StandName == standName)
                {
                    returnCases.Add(cases);
                }
            }
            return returnCases;
        }

        public void CreateCase(Cases cases)
        {
            
            Create(cases);
        }

        public IEnumerable<Cases> GetAllCases()
        {
            return FindAll().OrderBy(cases => cases.CaseId).ToList();
        }

        public Cases GetCaseById(int id)
        {
            return FindByCondition(cases => cases.CaseId.Equals(id)).FirstOrDefault();
        }

    }
}
