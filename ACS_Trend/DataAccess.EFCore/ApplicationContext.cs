using ACS_Trend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ACS_Trend.DataAccess.EFCore
{
    public class ApplicationContext : DbContext
    {       
        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        public DbSet<Unit> Units { get; set; }

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
