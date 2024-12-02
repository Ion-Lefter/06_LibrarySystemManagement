using LibraryData;
using Microsoft.EntityFrameworkCore;
using LibraryDomain;
using System.Net;

namespace LibraryConsole
{
    public class DBQuerys
    {
        public static void Delete(LibraryBookContext context, int id) {
            var book = context.Books.Find(id);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
                Console.WriteLine($"The book with id: {id} was successfully deleted");
            }
            else
            {
                Console.WriteLine($"There is no such book with id: {id}");
            }
        }

        public static List<T> GetItemsByType<T>(LibraryBookContext context) where T : LibraryItem
        {
            var libraryItems = context.LibraryItems.ToList();
            var filteredItems = libraryItems.OfType<T>().ToList();
            return filteredItems;
        }


        public static void InsertBorrowTransaction(LibraryBookContext context, int id) {
            var transaction = new BorrowTransaction
            
            {
                LibraryItemId = id,
                BorrowDate = DateTime.Now
            };

            context.BorrowTransactions.Add(transaction);
            context.SaveChanges();

        }

        public static void InsertReturnTransaction(LibraryBookContext context, int id)
        {
            var transaction = new BorrowTransaction

            {
                LibraryItemId = id,
                ReturnDate = DateTime.Now
            };

            context.BorrowTransactions.Add(transaction);
            context.SaveChanges();

        }



    }
}
