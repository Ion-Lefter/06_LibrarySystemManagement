using LibraryDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public class LibraryBookContext : DbContext
    {
        public DbSet<LibraryItem> LibraryItems { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Pies { get; set; }
        public DbSet<EBook> EBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = LibraryDatabase");
                //.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name },
                // LogLevel.Information)
                //.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure TPT inheritance (Table Per Type)
            modelBuilder.Entity<LibraryItem>()
                .ToTable("LibraryItems");  // This is the base table for common properties

            modelBuilder.Entity<Book>()
                .ToTable("Books")         // Book-specific table
                .HasBaseType<LibraryItem>(); // Book inherits from LibraryItem

            modelBuilder.Entity<Magazine>()
                .ToTable("Magazines")     // Magazine-specific table
                .HasBaseType<LibraryItem>(); // Magazine inherits from LibraryItem

            modelBuilder.Entity<EBook>()
                .ToTable("EBooks")        // EBook-specific table
                .HasBaseType<LibraryItem>(); // EBook inherits from LibraryItem
        }
    }
}
