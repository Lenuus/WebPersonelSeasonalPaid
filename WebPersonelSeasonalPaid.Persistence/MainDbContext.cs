using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPersonelSeasonalPaid.Domain;

namespace WebPersonelSeasonalPaid.Persistence
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {
        }
        public DbSet<Season> Seasons { get; set; }

        public DbSet<Personel> Personels { get; set; }

      //  public DbSet<SalaryPrim> SalaryPrims { get; set; }

        public DbSet<PersonelSeason> PersonelSeasons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /* modelBuilder.Entity<SalaryPrim>()
                  .HasOne(f => f.Personel)
                  .WithMany(f => f.SalaryPrim).HasForeignKey(f => f.PersonelId)
                  .OnDelete(DeleteBehavior.NoAction);

             modelBuilder.Entity<SalaryPrim>()
                 .HasOne(f => f.Season)
                 .WithMany(f => f.Paid).HasForeignKey(f => f.SeasonId)
                 .OnDelete(DeleteBehavior.NoAction);*/

            modelBuilder.Entity<PersonelSeason>().HasOne(f => f.Personel)
                 .WithMany(f => f.ExistingSeason)
                 .HasForeignKey(f => f.PersonelId)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PersonelSeason>().HasOne(f => f.Season)
                .WithMany(f => f.SeasonPersonel)
                .HasForeignKey(f => f.SeasonId)
                .OnDelete(DeleteBehavior.NoAction);



        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Database=PaidSystemV2;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
