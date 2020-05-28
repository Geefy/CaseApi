using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class ColorRepository : RepositoryBase<Color>, IColorRepository
    {
        public ColorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
