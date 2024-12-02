using LibraryDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        //may be it is for migration
        public LibraryBookContext() : base()
        {
        }
        public LibraryBookContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LibraryItem> LibraryItems { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<EBook> EBooks { get; set; }
        public DbSet<BorrowTransaction> BorrowTransactions { get; set; }
        public LibraryBookContext(DbContextOptions<LibraryBookContext> options)
            : base(options)
        { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var basePath = Path.Combine(currentDirectory, "..", "..", "..");

            string[] args = Environment.GetCommandLineArgs();
            bool isMigrationAdd = args.Contains("migrations", StringComparer.OrdinalIgnoreCase) &&
                                  args.Contains("add", StringComparer.OrdinalIgnoreCase);

            if (isMigrationAdd) {
                basePath = currentDirectory;
            }

            var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);


            //optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = LibraryDatabase");
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

            modelBuilder.Entity<BorrowTransaction>()
            .HasOne(bt => bt.LibraryItem)
            .WithMany()  // A LibraryItem can be borrowed many times
            .HasForeignKey(bt => bt.LibraryItemId)
            .OnDelete(DeleteBehavior.Restrict);  // Restrict deletion to prevent deleting a LibraryItem that's in a transaction
        }
    }
}
