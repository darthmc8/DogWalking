using DogWalksEvents.EntityDefinitios;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System.Collections.Generic;

namespace DogWalksEvents.Data
{
    /// <summary>
    /// Configures and Stablish the relation between Entities definitions and database
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DbSet<DBClient> Clients { get; set; }
        public DbSet<DBDog> Dogs { get; set; }
        public DbSet<DBWalkEvent> WalkEvents { get; set; }
        public DbSet<DBUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the context to use SQLite and specify the database file name.
            // The file will be created in the project directory.
            optionsBuilder.UseSqlite("Data Source=DogWalksEvents.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DBClient>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<DBDog>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<DBWalkEvent>()
                .HasOne(c => c.Client)
                .WithMany(w => w.Events);

            modelBuilder.Entity<DBWalkEvent>()
                .HasOne(d => d.Dog)
                .WithMany(w => w.Events);

            modelBuilder.Entity<DBWalkEvent>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<DBUser>()
                .HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);

            // Seed data for login table
            modelBuilder.Entity<DBUser>()
                .HasData(
                    new DBUser
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = "admin",
                        UserPassword = "admin"
                    }
                );
        }
    }
}
