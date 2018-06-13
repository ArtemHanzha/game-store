using System.Collections.Generic;
using EpamLibrary.Contracts.Models;

namespace EpamLibrary.Contracts.UIL
{
    class BookReviewsViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Comment> Reviews { get; set; }
        public float AvarageMark { get; set; }
    }
}
