using System;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Contracts
{
    public interface ICasesRepository : IRepositoryBase<Cases>
    {
        IEnumerable<Cases> GetAllCases();
        Cases GetCaseById(int id);

        void CreateCase(Cases cases);
    }
}
