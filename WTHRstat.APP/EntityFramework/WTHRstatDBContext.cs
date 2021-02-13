using Microsoft.EntityFrameworkCore;
using WTHRstat.APP.Models;

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
                .HasOne(u => u.Source)
                .WithOne(a => a.Emission)
                .HasForeignKey<SourceERD>(a => a.Emission_Id);

            modelBuilder.Entity<EmissionERD>().HasData(
                new EmissionERD
                {
                    Id = 1,
                    Name = "Emiss-23",
                    Count = 23,
                    Date = "23.23.2011",
                    Source_Id = 1
                },
                new EmissionERD
                {
                    Id = 2,
                    Name = "Coqwe-211",
                    Count = 25,
                    Date = "23.23.2011",
                    Source_Id = 2
                },
                new EmissionERD
                {
                    Id = 3,
                    Name = "Rqeeq-214",
                    Count = 51,
                    Date = "23.23.2011",
                    Source_Id = 3
                });

            modelBuilder.Entity<SourceERD>().HasData(
                new SourceERD
                {
                    Id = 1,
                    Name = "Emiss-23",
                    Address = "Nrqr St.14 Ap.21",
                    Emission_Id = 1
                },
                new SourceERD
                {
                    Id = 2,
                    Name = "Coqwe-211",
                    Address = "Nragagag St.145 Ap.212",
                    Emission_Id = 2
                },
                new SourceERD
                {
                    Id = 3,
                    Name = "Rqeeq-214",
                    Address = "Nrqexxx St.24 Ap.251",
                    Emission_Id = 3
                });
        }
    }
}