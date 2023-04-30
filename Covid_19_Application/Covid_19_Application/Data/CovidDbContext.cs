using Covid_19_Application.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Covid_19_Application.Data
{
    public class CovidDbContext : DbContext
    {
        public DbSet<MyRecord> Records { get; set; }

        public CovidDbContext(DbContextOptions options):base(options) 
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MyRecord>().HasKey(x => x.ID);

        }

    }
}
