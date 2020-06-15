using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface IStandRepository : IRepositoryBase<Stand>
    {
        IEnumerable<Stand> GetAllStands();
        void CreateStand(Stand stand);
    }
}
