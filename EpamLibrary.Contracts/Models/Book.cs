using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using EpamLibrary.Contracts.Models.Abstracts;

namespace EpamLibrary.Contracts.Models
{
    public class Book : AbstractDbObject
    {
        private DateTime? _dateOfPublication;
        
        public int? LibraryNumber { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<BookInstance> ConcreteBooks { get; set; }

        public ICollection<Comment> BookReviews { get; set; }

        public ICollection<Author> Authors { get; set; }

        public DateTime? DateOfPublication
        {
            get => _dateOfPublication?.Date;
            set
            {
                if (value != null) _dateOfPublication = value.Value.Date;
            }
        }

        public string PublicationHouse { get; set; }

        public float? Price { get; set; }

        public ICollection<Tag> Tags { get; set; }

        //TODO: add image for a book

        public bool Equals(Book book)
        {
            return LibraryNumber == book.LibraryNumber &&
                   Title.Equals(book.Title) &&
                   DateOfPublication.Equals(book.DateOfPublication) &&
                   PublicationHouse.Equals(book.PublicationHouse);
        }
    }
}
