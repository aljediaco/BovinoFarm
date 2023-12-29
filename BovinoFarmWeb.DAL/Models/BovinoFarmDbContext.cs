using BovinoFarmWeb.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BovinoFarmWeb.DAL.Models
{
    public class BovinoFarmDbContext : DbContext
    {
        static string database = "dbBovinoFarm.db";
        public DbSet<AnimalDAL> Animals { get; set; }
        public DbSet<BreedDAL> Breeds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "Filename=" + database,
                sqliteOptionsAction: op =>
                {
                    op.MigrationsAssembly(
                        Assembly.GetExecutingAssembly().FullName
                        );
                });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalDAL>().ToTable("Animal");
            modelBuilder.Entity<AnimalDAL>(entity =>
            {
                entity.HasKey(a => a.IdAnimal);
            });

            modelBuilder.Entity<BreedDAL>().ToTable("Breed");
            modelBuilder.Entity<BreedDAL>(entity =>
            {
                entity.HasKey(b => b.IdBreed);
            });

            modelBuilder.Entity<AnimalDAL>()
                .HasOne(a => a.BreedType)  
                .WithMany(b => b.Animals)
                .HasForeignKey(a => a.IdBreed)  
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
