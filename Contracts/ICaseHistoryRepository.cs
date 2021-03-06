﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICaseHistoryRepository : IRepositoryBase<CaseHistory>
    {
        IEnumerable<CaseHistory> GetCaseHistoriesByStand(string standName);
    }
}
