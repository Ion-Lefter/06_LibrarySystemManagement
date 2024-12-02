
using LibraryData;
using LibraryDomain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryConsole
{
    internal class Utilities
    {

        public static LibraryBookContext context;
        internal static void ShowMainMenu()
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("********************");
            Console.WriteLine("* Select an action *");
            Console.WriteLine("********************");

            Console.WriteLine("1: Library management");
            Console.WriteLine("0: Close application");

            Console.Write("Your selection: ");

            string? userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "1":
                    ShowLibraryManagementMenuAll();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
        }

        private static void ShowLibraryManagementMenuAll()
        {
            string? userSelection;

            do
            {
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("************************");
                Console.WriteLine("* Inventory management *");
                Console.WriteLine("************************");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Choose an option:");
                Console.ResetColor();

                Console.WriteLine("1:Books");
                Console.WriteLine("2:eBooks");
                Console.WriteLine("3:Magazines");
                Console.WriteLine("0: Back to main menu");

                Console.Write("Your selection: ");

                userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        ShowLibraryManagementMenu();
                        break;

                    case "2":
                        ShowLibraryManagementEBooks();
                        break;

                    case "3":
                        ShowLibraryManagementMagazines();
                        break;
                    case "0":
                        ShowMainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
            while (userSelection != "0");

            ShowMainMenu();


        }


        private static void ShowLibraryManagementMenu()
        {
            string? userSelection;

            do
            {
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("************************");
                Console.WriteLine("* Inventory management *");
                Console.WriteLine("************************");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("What do you want to do?");
                Console.ResetColor();

                Console.WriteLine("1: View details of books");
                Console.WriteLine("2: Add new book");
                Console.WriteLine("3: Search book by Title");
                Console.WriteLine("4: Borrow Book");
                Console.WriteLine("5: Return book");
                Console.WriteLine("6: Edit detailes of book");
                Console.WriteLine("7: Delete book by Id");
                Console.WriteLine("8: Search book by Author");
                Console.WriteLine("9: Show Transactions");
                Console.WriteLine("0: Back");

                Console.Write("Your selection: ");

                userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        ShowAllItemsByType<Book>();
                        break;

                    case "2":
                        ShowAddNewBook();
                        break;

                    case "3":
                        ShowFilterBooks();
                        break;
                    case "4":
                        ShowBorrowBook();
                        break;
                    case "5":
                        ShowReturnBook();
                        break;
                    case "6":
                        ShowEditDetailesOfBook();
                        break;
                    case "7":
                        ShowDeleteItemById<Book>();
                        break;
                    case "8":
                        ShowFilterBooksByAuthor();
                        break;                    
                    case "9":
                        ShowBookTransactions();
                        break;
                    case "0":
                        ShowLibraryManagementMenuAll();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
            while (userSelection != "0");

            //ShowMainMenu();
            ShowLibraryManagementMenuAll();
            

        }

        private static void ShowLibraryManagementEBooks()
        {
            string? userSelection;

            do
            {
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("************************");
                Console.WriteLine("* Inventory management *");
                Console.WriteLine("************************");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("What do you want to do?");
                Console.ResetColor();

                Console.WriteLine("1: View details of eBooks");
                Console.WriteLine("2: Search Ebook by File range");
                Console.WriteLine("0: Back");

                Console.Write("Your selection: ");

                userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        ShowAllItemsByType<EBook>();
                        break;

                    case "2":
                        ShowFilterdEBooks();
                        break;
                    case "0":
                        ShowLibraryManagementMenuAll();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
            while (userSelection != "0");
            ShowLibraryManagementMenuAll();
        }

        private static void ShowLibraryManagementMagazines()
        {
            string? userSelection;

            do
            {
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine("************************");
                Console.WriteLine("* Inventory management *");
                Console.WriteLine("************************");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("What do you want to do?");
                Console.ResetColor();

                Console.WriteLine("1: View details of Magazines");
                Console.WriteLine("2: Borrow Magazine");
                Console.WriteLine("3: Return Magazine");
                Console.WriteLine("4: Show Transactions");
                Console.WriteLine("0: Back");

                Console.Write("Your selection: ");

                userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        ShowAllItemsByType<Magazine>();
                        break;
                    case "2":
                        ShowBorrowMagazine();
                        break;
                    case "3":
                        ShowReturnMagazine();
                        break;                    
                    case "4":
                        ShowMagazineTransactions();
                        break;
                    case "0":
                        ShowLibraryManagementMenuAll();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
            while (userSelection != "0");
            ShowLibraryManagementMenuAll();
        }


        private static void ShowAddNewBook()
        {
            Book? newBook = null;

            Console.Write("Enter the Title of the book: ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter the Author of the book: ");
            string author = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter the ISBN of the book: ");
            string isbn;
            var book = new Book();
            do
            {
                isbn = Console.ReadLine() ?? string.Empty;
                book = context.Books.FirstOrDefault(x => x.ISBN == isbn);
                if(book != null) {
                Console.Write("Please use another ISBN, this one is already assigned to the book:\n");
                Console.WriteLine(book.ToString());
                }
            }
            while (book != null);

            Console.Write("Enter the year published of the book: ");
            int yearPublished;
            while (!int.TryParse(Console.ReadLine(), out yearPublished) || yearPublished < 1600 || yearPublished > DateTime.Now.Year)
            {
                Console.WriteLine("Please enter a valid year (greater than 1600 and less or equal than the current year).");
            }
            newBook = new Book(name, author, isbn, yearPublished);
            
            context.Books.Add(newBook);
            context.SaveChanges();
            Console.WriteLine("The book was successfully added!\n");

            Console.WriteLine("Press press enter to continue");
            Console.ReadLine();
        }

        private static void ShowEditDetailesOfBook()
        {
            Console.Write("Enter the ID of the book: ");
            int bookId;
            while (!int.TryParse(Console.ReadLine(), out bookId))
                Console.WriteLine("Integers only allowed.");

            Book targetBook = context.Books.FirstOrDefault(b => b.Id == bookId);
            if (targetBook == null)
            {
                Console.WriteLine("Target book not found.");
                Console.WriteLine("Press press enter to continue");
                Console.ReadLine();
                return;
            }

            targetBook.DisplayInfo();
            Book? newBook = null;

            Console.Write("Enter the new title of the book: ");
            string title = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter the new author of the book: ");
            string author = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter the new isbn of the book: ");
            string isbn;
            var book = new Book();
            do
            {
                isbn = Console.ReadLine() ?? string.Empty;
                book = context.Books.FirstOrDefault(x => x.ISBN == isbn);
                if (book != null)
                {
                    Console.Write("Please use another ISBN, this one is already assigned to the book:\n");
                    Console.WriteLine(book.ToString());
                }
            }
            while (book != null);

            Console.Write("Enter the new year published of the book: ");
            int yearPublished;
            while (!int.TryParse(Console.ReadLine(), out yearPublished) || yearPublished < 1600 || yearPublished > DateTime.Now.Year)
            {
                Console.WriteLine("Please enter a valid year (greater than 1600 and less or equal than the current year).");
            }
                        
            targetBook.Title = title;
            targetBook.Author = author;
            targetBook.YearPublished = yearPublished;
            targetBook.ISBN = isbn;

            //context.Books.Add(newBook);
            context.SaveChanges();
            Console.WriteLine("The book was successfully updated!\n");

            Console.WriteLine("Press press enter to continue");
            Console.ReadLine();
        }

        private static void ShowFilterBooks() {
        
        Console.WriteLine("Please enter the title of book:");
        string titleOfTheBook = Console.ReadLine();
            var filteredBooks = context.Books
                .Where(b => b.Title.Contains(titleOfTheBook))
                .ToList();

            if (filteredBooks.Count > 0)
            {
                foreach (Book book in filteredBooks)
                {
                    Console.WriteLine(book.ToString());
                }
            }
            else {
                Console.WriteLine("No book was found with this title!");
            }

            Console.WriteLine("Press press enter to continue");
            Console.ReadLine();

        }

        private static async void ShowFilterBooksByAuthor()
        {

            Console.WriteLine("Please enter the Author of the book:");
            string authorOfTheBook = Console.ReadLine();
            //var filteredBooks = await SearchBooksByAuthorAsync(authorOfTheBook);
            //var filteredBooks = await context.Set<Book>().FromSqlRaw($"EXEC SearchBooksByAuthor @Author = {0}", authorOfTheBook).ToListAsync();
            //var filteredBooks = await context.Set<BookDto>()
            //.FromSqlInterpolated($"EXEC SearchBooksByAuthor @Author = {authorOfTheBook}")
            //.ToListAsync();

            var filteredBooks = new List<Book>();
            try
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SearchBooksByAuthor";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    var parameter = command.CreateParameter();
                    parameter.ParameterName = "@Author";
                    parameter.Value = authorOfTheBook;
                    command.Parameters.Add(parameter);

                    context.Database.OpenConnection();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            filteredBooks.Add(new Book
                            {
                                Title = reader.GetString(1),
                                Author = reader.GetString(2),
                                YearPublished = reader.GetInt32(3),
                                ISBN = reader.GetString(4),
                            });
                        }
                    }
                }
            }
            catch (Exception ex) { 
                Console.WriteLine("Please check database connection SQL Error");
            }

                if (filteredBooks.Count > 0)
                {
                    foreach (var book in filteredBooks)
                    {
                        Console.WriteLine(book.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No book was found with this Author!");
                }

                Console.WriteLine("Press press enter to continue");
                Console.ReadLine();

            }

        public static async Task<List<Book>> SearchBooksByAuthorAsync(string authorOfTheBook)
        {
            // Raw SQL query to filter books by title
            var query = @"
                SELECT 
                        li.Id,
                        li.Title,
                        li.Author,
                        li.YearPublished,
		                b.ISBN
                    FROM 
                        LibraryItems li
                    INNER JOIN 
                        Books b ON li.Id = b.Id
                    WHERE 
                        li.Author LIKE '%' + @Author + '%';";

            // Execute the raw SQL query
            var filteredBooks = new List<Book>();
            try {
                var rawResults = await context.Database.SqlQueryRaw<Book>(
                        query, new SqlParameter("@Author", $"%{authorOfTheBook}%")
                    ).ToListAsync();
                filteredBooks.AddRange(rawResults);
            } 
            catch(Exception ex) { 
                Console.WriteLine(ex.ToString());
            }


            return filteredBooks;
        }

        private static void ShowBorrowBook() {
            Console.WriteLine("Please enter the ID of the book that you wwant to borrow");
            int bookId;
            while (!int.TryParse(Console.ReadLine(), out bookId))
                Console.WriteLine("Integers only allowed.");
            var book = context.Books.Find(bookId);
            if (book != null) {
                DBQuerys.InsertBorrowTransaction(context, bookId);
                Console.WriteLine("The transaction was succesfully added!");
            }
            else{
                Console.WriteLine("There is no book with this ID");
            }

                Console.WriteLine("Press press enter to continue");
            Console.ReadLine();
        }

        private static void ShowBorrowMagazine()
        {
            Console.WriteLine("Please enter the ID of the magazine that you wwant to borrow");
            int magazineId;
            while (!int.TryParse(Console.ReadLine(), out magazineId))
                Console.WriteLine("Integers only allowed.");
            var magazine = context.Magazines.Find(magazineId);
            if (magazine != null)
            {
                DBQuerys.InsertBorrowTransaction(context, magazineId);
                Console.WriteLine("The transaction was succesfully added!");
            }
            else
            {
                Console.WriteLine("There is no magzine with this ID");
            }

            Console.WriteLine("Press press enter to continue");
            Console.ReadLine();
        }
        private static void ShowReturnBook() {
            Console.WriteLine("Please enter the ID of the book that you want to return");
            int bookId;
            while (!int.TryParse(Console.ReadLine(), out bookId))
                Console.WriteLine("Integers only allowed.");
            var book = context.Books.Find(bookId);
            if (book != null)
            {
                DBQuerys.InsertReturnTransaction(context, bookId);
                Console.WriteLine("The transaction was succesfully added!");
            }
            else
            {
                Console.WriteLine("Please check again the ID of the book");
            }

            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        private static void ShowReturnMagazine()
        {
            Console.WriteLine("Please enter the ID of the magazine that you want to return");
            int magzineId;
            while (!int.TryParse(Console.ReadLine(), out magzineId))
                Console.WriteLine("Integers only allowed.");
            var magzine = context.Magazines.Find(magzineId);
            if (magzine != null)
            {
                DBQuerys.InsertReturnTransaction(context, magzineId);
                Console.WriteLine("The transaction was succesfully added!");
            }
            else
            {
                Console.WriteLine("Please check again the ID of the magzine");
            }

            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        private static void ShowFilterdEBooks()
        {
            Console.WriteLine("Please enter the min range o Ebook");
            int minRange;
            while (!int.TryParse(Console.ReadLine(), out minRange))
            Console.WriteLine("Integers only allowed.");
            Console.WriteLine("Please enter the max range o Ebook");
            int maxRange;
            while (!int.TryParse(Console.ReadLine(), out maxRange))
            Console.WriteLine("Integers only allowed.");
            try
            {
                List<EBook> eBooks = FilterEbooksByFileRange(minRange, maxRange);
                if (eBooks.Count == 0)
                {
                    Console.WriteLine($"No items of type {typeof(EBook).Name} are available");
                    //throw new ItemNotAvailableException($"No items of type {typeof(EBook).Name} are available");
                }
                foreach (EBook eBook in eBooks) { Console.WriteLine(eBook.ToString()); }
            }
            catch(Exception e) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.ToString());
                Console.ResetColor();
            }
            Console.WriteLine("Press press enter to continue");
            Console.ReadLine();
        }

        public static List<EBook> FilterEbooksByFileRange(int minFileSize, int maxFileSize)
        {
            if (minFileSize < 0 || maxFileSize < 0)
            {
                Console.WriteLine("File size cannot be negative");
                //throw new ArgumentException("File size cannot be negative");

            }

            if (minFileSize > maxFileSize)
            {
                Console.WriteLine("Min file size cannot be greater than max file size");
                //throw new ArgumentException("Min file size cannot be greater than max file size");
            }

            var eBooks = context.EBooks
                .Where(e => e.FileSizeMB >= minFileSize && e.FileSizeMB <= maxFileSize)
                .ToList();
            return eBooks;

        }
        private static void ShowAllItemsByType<T>() where T : LibraryItem
        {

            var filteredItems = DBQuerys.GetItemsByType<T>(context);
            foreach (LibraryItem item in filteredItems)
            {
                Console.WriteLine(item.ToString());
            }


            Console.WriteLine("Press press enter to continue");
            Console.ReadLine();
        }

        public static void ShowDeleteItemById<T>() where T : class
        {
                Console.WriteLine($"Please enter the ID of the {typeof(T).Name} that you want to delete");
                int itemId;
                while (!int.TryParse(Console.ReadLine(), out itemId))
                Console.WriteLine("Integers only allowed.");

                var item = context.Set<T>().Find(itemId);
                if (item == null)
                {
                    Console.WriteLine($"Item of type {typeof(T).Name} with ID {itemId} not found.");
                }
                else {
                    context.Set<T>().Remove(item);
                    context.SaveChanges();
                    Console.WriteLine($"Item of type {typeof(T).Name} with ID {itemId} deleted successfully.");
                }
                Console.WriteLine("Press press enter to continue");
                Console.ReadLine();
        }

        private static async void ShowBookTransactions() {
            
            var bookTransactions = await DBQuerys.GetBookTransactionsAsync<Book>(context);
            Console.WriteLine("\n\n");
            foreach (var transaction in bookTransactions)
            {
                if (transaction.BorrowDate != null)
                {

                    Console.WriteLine($"Transaction ID: {transaction.Id},       BookID:{(transaction.LibraryItem as Book).Id}, Book Title: {(transaction.LibraryItem as Book).Title}, Book Author: {(transaction.LibraryItem as Book).Author} Borrow date: {transaction.BorrowDate}");

                }
                else {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Transaction ID: {transaction.Id},       BookID:{(transaction.LibraryItem as Book).Id}, Book Title: {(transaction.LibraryItem as Book).Title}, Book Author: {(transaction.LibraryItem as Book).Author} Return date: {transaction.ReturnDate}");
                    Console.ResetColor();
                }
            }

            Console.WriteLine("Press press enter to continue");
            //Console.ReadLine();
        }

        private static async void ShowMagazineTransactions()
        {

            var magazineTransactions = await DBQuerys.GetBookTransactionsAsync<Magazine>(context);
            Console.WriteLine("\n\n");
            foreach (var transaction in magazineTransactions)
            {
                if (transaction.BorrowDate != null)
                {
                    Console.WriteLine($"Transaction ID: {transaction.Id},       MagazineID:{(transaction.LibraryItem as Magazine).Id}, Magazine Title: {(transaction.LibraryItem as Magazine).Title}, Magazine Author: {(transaction.LibraryItem as Magazine).Author} Borrow date: {transaction.BorrowDate}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Transaction ID: {transaction.Id},       MagazineID:{(transaction.LibraryItem as Magazine).Id}, Magazine Title: {(transaction.LibraryItem as Magazine).Title}, Magazine Author: {(transaction.LibraryItem as Magazine).Author} Return date: {transaction.ReturnDate}");
                    Console.ResetColor();
                }
            }

            Console.WriteLine("Press press enter to continue");
            //Console.ReadLine();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
