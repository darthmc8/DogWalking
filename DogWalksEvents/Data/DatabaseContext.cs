using DogWalksEvents.EntityDefinitios;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System.Collections.Generic;

namespace DogWalksEvents.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the context to use SQLite and specify the database file name.
            // The file will be created in the project directory.
            optionsBuilder.UseSqlite("Data Source=DogWalksEvents.db");
        }
    }
}
