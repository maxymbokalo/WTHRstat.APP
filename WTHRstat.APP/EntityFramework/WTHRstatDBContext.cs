using Microsoft.EntityFrameworkCore;
using System;
using WTHRstat.APP.Models;
using WTHRstat.APP.ModelsERD;

namespace WTHRstat.APP.EntityFramework
{
    public class WTHRstatDBContext : DbContext
    {
        public DbSet<EmissionERD> Emissions { get; set; }
        public DbSet<SourceERD> Sources { get; set; }
        public WTHRstatDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmissionERD>()
                .HasOne(e => e.Source)
                .WithMany(s => s.Emissions)
                .HasForeignKey(e => e.Source_Id);

            modelBuilder.Entity<EmissionERD>().HasData(
                new EmissionERD
                {
                    Id = 1,
                    Pollutant = "Emiss-23",
                    Concentration = 23,
                    Date = new DateTime(2015, 12, 31, 5, 10, 20),
                    Source_Id = 1
                },
                new EmissionERD
                {
                    Id = 2,
                    Pollutant = "Coqwe-211",
                    Concentration = 25,
                    Date = new DateTime(2015, 12, 31, 5, 10, 20),
                    Source_Id = 2
                },
                new EmissionERD
                {
                    Id = 3,
                    Pollutant = "Rqeeq-214",
                    Concentration = 51,
                    Date = new DateTime(2015, 12, 31, 5, 10, 20),
                    Source_Id = 3
                });

            modelBuilder.Entity<SourceERD>().HasData(
                new SourceERD
                {
                    Id = 1,
                    Country = "India",
                    City = "Bangladesh"
                },
                new SourceERD
                {
                    Id = 2,
                    Country = "Japan",
                    City = "Tokyo"
                },
                new SourceERD
                {
                    Id = 3,
                    Country = "Ukraine",
                    City = "Kyiv"
                });
        }
    }
}