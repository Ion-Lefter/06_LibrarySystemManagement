using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDomain
{
    public abstract class LibraryItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearPublished { get; set; }

        //[JsonDiscriminator] // Optional to support type differentiation in JSON
        public string Type => GetType().Name;

        public LibraryItem() { }

        // Constructor to initialize common properties
        protected LibraryItem(string title, string author, int yearPublished)
        {
            Title = title;
            Author = author;
            YearPublished = yearPublished;
        }

        // Abstract method to display item information; subclasses must implement this
        public abstract void DisplayInfo();
    }
}
