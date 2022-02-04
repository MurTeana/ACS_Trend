using ACS_Trend.Models.DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACS_Trend.Models.DB.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Graph> graphs { get; set; }
        public DbSet<Unit> units { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options)
        {
            //Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>().HasData(
                new Unit[]
                {
                new Unit { ID_Unit=1, Unit_name = "кг"},
                new Unit { ID_Unit=2, Unit_name = "м.куб."},
                });
        }

    }
}
