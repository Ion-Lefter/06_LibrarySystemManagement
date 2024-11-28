using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDomain
{
    public class EBook : LibraryItem
    {


        public double FileSizeMB {  get; set; }
        public string FileFormat { get; set; }

        public EBook() { }
        public EBook(string title, string author, int yearPublished, double fileSizeMB, string FileFormat) 
            : base(title, author, yearPublished)
        {
            this.FileSizeMB = fileSizeMB;
            this.FileFormat = FileFormat;
        }

        public override void DisplayInfo()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Title}, {Author}, {YearPublished}, {FileSizeMB}, {FileFormat}";
        }
    }
}
