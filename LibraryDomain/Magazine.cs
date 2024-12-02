using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDomain
{
    public class Magazine : LibraryItem, IBorrowable
    {
        public int IssueNumber { get; set; }

        public Magazine() { }
        public Magazine(string title, string author, int yearPublished, int issueNumber)
        : base(title, author, yearPublished){
         this.IssueNumber = issueNumber;   
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}, Author: {Author}, Year Published: {YearPublished}, IssueNumber: {IssueNumber}");

        }

        public void Borrow()
        {
            Console.WriteLine("The magazine was borrowed");
        }

        public void Return()
        {
            Console.WriteLine("The magazine was returned");
        }

        public override string ToString() {
            return ($"ID: {Id} Title: {Title}, Author: {Author}, Year Published: {YearPublished}, IssueNumber: {IssueNumber}");

        }
    }
}
