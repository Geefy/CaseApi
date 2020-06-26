using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ICaseHistoryRepository CaseHistory { get; }
        ICasesRepository Cases { get; }

        IStandRepository Stand { get; }

        void Save();
    }
}
