using LibraryConsole;
using LibraryData;
using LibraryDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;


//using (LibraryBookContext _context = new LibraryBookContext())
//{
//    _context.Database.EnsureCreated();
//}

//var options = new DbContextOptionsBuilder<LibraryBookContext>()
//    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LibraryDatabase;Trusted_Connection=True;MultipleActiveResultSets=true")
//    .Options;

//var builder = WebApplication.CreateBuilder(args);
//var currentDirectory = Directory.GetCurrentDirectory();

//var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

var currentDirectory = Directory.GetCurrentDirectory();
var basePath = currentDirectory;

string startupPath = System.IO.Directory.GetCurrentDirectory();
basePath = Path.Combine(startupPath, "..", "..", "..");

//var basePath = Path.Combine(currentDirectory, "..", "..", "..");

//var basePath = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..\..\"));
var configuration = new ConfigurationBuilder()
.SetBasePath(basePath)
.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
.Build();



var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection, configuration);

using var serviceProvider = serviceCollection.BuildServiceProvider();
using var scope = serviceProvider.CreateScope();

//var context = scope.ServiceProvider.GetRequiredService<LibraryBookContext>();

var connectionString = configuration.GetConnectionString("DefaultConnection");
var options = new DbContextOptionsBuilder<LibraryBookContext>()
    .UseSqlServer(connectionString)
    .Options;






LibraryBookContext context = new LibraryBookContext(options);

Console.WriteLine("Hello World");
Utilities.context = context;


//var book = Book.CreateBook("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565", 1925);
//context.Add(book);
//await context.SaveChangesAsync();
//InitializeDatabase();

//DeleteBookById(1);

Utilities.ShowMainMenu();

//void DeleteBookById(int id)
//{
//        var book = context.Books.Find(id);
//    if (book != null)
//    {
//           context.Books.Remove(book);
//           context.SaveChanges();
//           Console.WriteLine($"The book with id: {id} was successfully deleted");
//    }
//    else
//    {
//        Console.WriteLine($"There is no such book with id: {id}");
//    }


//}
void InitializeDatabase()
{

    var books = new List<Book>
            {
                new Book("Book 1", "Author 1", "1234567890", 2020),
                new Book("Book 2", "Author 2", "1234567891", 2021),
                new Book("Book 3", "Author 3", "1234567892", 2022),
                new Book("Book 4", "Author 4", "1234567893", 2023),
                new Book("Book 5", "Author 5", "1234567894", 2024)
            };


    var eBooks = new List<EBook>
            {
                new EBook("EBook 1", "Author E1", 2020, 5.5, "PDF"),
                new EBook("EBook 2", "Author E2", 2021, 6.0, "EPUB"),
                new EBook("EBook 3", "Author E3", 2022, 4.5, "MOBI"),
                new EBook("EBook 4", "Author E4", 2023, 7.0, "PDF"),
                new EBook("EBook 5", "Author E5", 2024, 8.0, "EPUB")
            };


    var magazines = new List<Magazine>
            {
                new Magazine("Magazine 1", "Editor 1", 2020, 1),
                new Magazine("Magazine 2", "Editor 2", 2021, 2),
                new Magazine("Magazine 3", "Editor 3", 2022, 3),
                new Magazine("Magazine 4", "Editor 4", 2023, 4),
                new Magazine("Magazine 5", "Editor 5", 2024, 5)
            };


    context.Books.AddRange(books);
    context.EBooks.AddRange(eBooks);
    context.Magazines.AddRange(magazines);

    context.SaveChanges();

}

static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Register DbContext with SQL Server
    services.AddDbContext<LibraryBookContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
}
