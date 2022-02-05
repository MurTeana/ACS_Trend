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

        public DbSet<Control_object> Control_objects { get; set; }
        public DbSet<Control_object_type> Control_object_types { get; set; }
        public DbSet<Regulator> Regulators { get; set; }
        public DbSet<Signal_type> Signal_types { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Station_type> Station_types { get; set; }
        public DbSet<Transient_characteristic> Transient_characteristics { get; set; }
        public DbSet<Trend> Trends { get; set; }
        public DbSet<Trend_parameter> Trend_parameters { get; set; }
        public DbSet<Trend_parameter_type> Trend_parameter_types { get; set; }
        public DbSet<TrendPoint> TrendPoints { get; set; }
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
