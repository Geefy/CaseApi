using Microsoft.EntityFrameworkCore;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Cases> Cases { get; set; }
        public DbSet<CaseHistory> CaseHistories { get; set; }
        public DbSet<Stand> Stands { get; set; }
    }
}
