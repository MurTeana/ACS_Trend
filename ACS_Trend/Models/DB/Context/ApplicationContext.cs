using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using ACS_Trend.Models.DB.Entities;

namespace ACS_Trend.Models.DB.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
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
        public DbSet<Unit> Units { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .HasMany(e => e.PrikormList)
            //    .WithOne(e => e.User)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Product>()
            //    .HasMany(e => e.PrikormList)
            //    .WithOne(e => e.User)
            //    .HasForeignKey(e => e.IdUser)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<PrikormList>()
            //    .HasMany(e => e.Users)
            //    .WithOne(e => e.University)
            //    .HasForeignKey(e => e.IdUser)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Meal>()
            //    .HasMany(e => e.Users)
            //    .WithOne(e => e.University)
            //    .HasForeignKey(e => e.IdUser)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
