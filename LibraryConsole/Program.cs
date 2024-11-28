using LibraryData;
using LibraryDomain;

//using (LibraryBookContext _context = new LibraryBookContext())
//{
//    _context.Database.EnsureCreated();
//}

var context = new LibraryBookContext();

Console.WriteLine("Hello World");

//var book = Book.CreateBook("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565", 1925);
//context.Add(book);
//await context.SaveChangesAsync();

QueryBooks();
void QueryBooks()
{
    //using var _context = new LibraryBookContext();
    var id = 1;
    var books = context.Books.Where(a => a.Id == id).ToList();
    foreach (var book in books)
    {
        Console.WriteLine(book);
    }
}