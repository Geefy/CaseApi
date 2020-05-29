﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IAccountRepository Account { get; }
        ICaseHistoryRepository CaseHistory { get; }
        ICasesRepository Cases { get; }
        IColorRepository Color { get; }

        void Save();
    }
}