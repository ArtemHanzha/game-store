using System.Collections.Generic;
using EpamLibrary.Contracts.Models;

namespace EpamLibrary.Contracts.UIL
{
    class ConsumerBooksViewModel
    {
        public Consumer Consumer { get; set; }
       // public SortedSet<BookInUseBusinessModel> BooksInUse { get; set; }
        public float DebtCount { get; set; }
    }
}
