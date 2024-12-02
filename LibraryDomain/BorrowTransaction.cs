using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDomain
{
    public class BorrowTransaction
    {
        public int Id { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }  // Nullable, since the item may not be returned yet

        // Foreign key to LibraryItem
        public int LibraryItemId { get; set; }
        public LibraryItem LibraryItem { get; set; }  // Navigation property
    }
}
