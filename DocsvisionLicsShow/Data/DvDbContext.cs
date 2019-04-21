using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DocsvisionLicsShow.Models;

namespace DocsvisionLicsShow.Data
{
    public class DvDbContext : DbContext
    {
        public DvDbContext(DbContextOptions<DvDbContext> options) : base(options) { }

        public DbSet<DvSession> Sessions { get; set; }

        public DbSet<DvEmployee> Employees { get; set; }

        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<DvUser>.h
         }*/
    }
}
