using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDomain
{
    public class Book : LibraryItem, IBorrowable
    {


        public string ISBN { get; set; }

        public Book() { }

        public Book(string title, string author, string isbn, int yearPublished)
        : base(title, author, yearPublished)
        {
            this.ISBN = isbn;
        }

        public static Book CreateBook(string title, string author, string isbn, int yearPublished)
        {
            return new Book(title, author, isbn, yearPublished);
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}, Author: {Author}, Year Published: {YearPublished}, ISBN: {ISBN}");
        }

        public void Borrow()
        {
            Console.WriteLine("The book was borrowed");
        }

        public void Return()
        {
            Console.WriteLine("The book was returned");
        }

        public void ModifyTiltle(string newTitle) { 
            base.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title}, {Author}, {ISBN}, {YearPublished}";
        }
    }
}
