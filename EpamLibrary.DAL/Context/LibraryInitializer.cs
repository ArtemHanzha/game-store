using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamLibrary.Contracts.Enums;
using EpamLibrary.Contracts.Models;

namespace EpamLibrary.DAL.Context
{
    internal class LibraryDbInitializer : DropCreateDatabaseIfModelChanges<LibraryContext>
    {
        protected override void Seed(LibraryContext db)
        {
            #region Books

            db.Books.Add(new Book { Title = "BookInstance 1", Authors = new List<Author>() { db.Authors.ToList()[0], db.Authors.ToList()[0] }, DateOfPublication = new DateTime(1989, 10, 10) });
            db.Books.Add(new Book { Title = "BookInstance 2", Authors = new List<Author>() { db.Authors.ToList()[1], db.Authors.ToList()[0] }, DateOfPublication = new DateTime(1989, 10, 10) });
            db.Books.Add(new Book { Title = "BookInstance 3", Authors = new List<Author>() { db.Authors.ToList()[3], db.Authors.ToList()[0], db.Authors.ToList()[1] }, DateOfPublication = new DateTime(1989, 10, 10) });
            db.Books.Add(new Book { Title = "BookInstance 4", Authors = new List<Author>() { db.Authors.ToList()[1] }, DateOfPublication = new DateTime(1989, 10, 10) });
            db.Books.Add(new Book { Title = "BookInstance 5", Authors = new List<Author>() { db.Authors.ToList()[2] }, DateOfPublication = new DateTime(1989, 10, 10) });
            db.Books.Add(new Book { Title = "BookInstance 6", Authors = new List<Author>() { db.Authors.ToList()[3], db.Authors.ToList()[0], db.Authors.ToList()[1], db.Authors.ToList()[2] }, DateOfPublication = new DateTime(1989, 10, 10) });
            db.Books.Add(new Book { Title = "BookInstance 7", Authors = new List<Author>() { db.Authors.ToList()[0] }, DateOfPublication = new DateTime(1989, 10, 10) });

            #endregion
            
            #region Consumers

            db.Consumers.Add(new Consumer() { Name = "Test0", Surname = "User01", Login = "user01", Password = "0000" });
            db.Consumers.Add(new Consumer() { Name = "Test1", Surname = "User02", Login = "user02", Password = "0000" });
            db.Consumers.Add(new Consumer() { Name = "Test2", Surname = "User03", Login = "user03", Password = "0000" });
            db.Consumers.Add(new Consumer() { Name = "Test3", Surname = "User04", Login = "user04", Password = "0000" });
            db.Consumers.Add(new Consumer() { Name = "Test4", Surname = "User05", Login = "user05", Password = "0000" });
            db.Consumers.Add(new Consumer() { Name = "Test5", Surname = "User06", Login = "user06", Password = "0000" });
            db.Consumers.Add(new Consumer() { Name = "Test6", Surname = "User07", Login = "user07", Password = "0000" });
            db.Consumers.Add(new Consumer() { Name = "Test7", Surname = "User08", Login = "user08", Password = "0000" });
            db.Consumers.Add(new Consumer() { Name = "Test8", Surname = "User09", Login = "user09", Password = "0000" });

            #endregion
            
            #region Workers

            db.Workers.Add(new Worker() { Name = "TestW0", Surname = "User10", Login = "user10", Password = "0000" });

            #endregion

            #region Comments

            db.Comments.Add(new Comment() { Rating = Rating.Medium, Review = "Norm vashe", Reviewer = db.Consumers.ToList()[0], Book = db.Books.ToList()[1], IsDeleted = false, PublicationDateTime = DateTime.UtcNow });
            db.Comments.Add(new Comment() { Rating = Rating.Medium, Review = "Norm vashe", Reviewer = db.Consumers.ToList()[0], Book = db.Books.ToList()[3], IsDeleted = false, PublicationDateTime = DateTime.UtcNow });
            db.Comments.Add(new Comment() { Rating = Rating.Medium, Review = "Norm vashe", Reviewer = db.Consumers.ToList()[1], Book = db.Books.ToList()[4], IsDeleted = false, PublicationDateTime = DateTime.UtcNow });
            db.Comments.Add(new Comment() { Rating = Rating.Medium, Review = "Norm vashe", Reviewer = db.Consumers.ToList()[3], Book = db.Books.ToList()[3], IsDeleted = false, PublicationDateTime = DateTime.UtcNow });

            #endregion

            #region Authors

            db.Authors.Add(new Author(){Books = new List<Book>(){ db.Books.ToList()[0], db.Books.ToList()[3], db.Books.ToList()[1] }, Name = "Ivan", Surname = "Medvedev", LastName = "Orehovich", IsDeleted = false});
            db.Authors.Add(new Author() { Books = new List<Book>() { db.Books.ToList()[6], db.Books.ToList()[2], db.Books.ToList()[1] }, Name = "Artem", Surname = "Kostikov", LastName = "Abramovech", IsDeleted = false });
            db.Authors.Add(new Author() { Books = new List<Book>() { db.Books.ToList()[4], db.Books.ToList()[3], db.Books.ToList()[0] }, Name = "Evgeniy", Surname = "Perepelitsyn", LastName = "Kinonovich", IsDeleted = false });
            db.Authors.Add(new Author() { Books = new List<Book>() { db.Books.ToList()[5], db.Books.ToList()[0], db.Books.ToList()[2] }, Name = "Valeriy", Surname = "Trubachev", LastName = "Orehovich", IsDeleted = false });

            #endregion

            #region BookInstances

            db.BookInstances.Add(new BookInstance()
            {
                Book = db.Books.ToList()[0],
                IsDeleted = false,
                IsInUse = false,
                ConditionComment = "Главная разрисована",
                LibraryNumber = "0000"
            });

            db.BookInstances.Add(new BookInstance()
            {
                Book = db.Books.ToList()[0],
                IsDeleted = false,
                IsInUse = false,
                ConditionComment = null,
                LibraryNumber = "0001"
            });

            db.BookInstances.Add(new BookInstance()
            {
                Book = db.Books.ToList()[2],
                IsDeleted = false,
                IsInUse = false,
                ConditionComment = null,
                LibraryNumber = "0002"
            });

            db.BookInstances.Add(new BookInstance()
            {
                Book = db.Books.ToList()[3],
                IsDeleted = false,
                IsInUse = false,
                ConditionComment = "Все в порядке",
                LibraryNumber = "0003"
            });

            db.BookInstances.Add(new BookInstance()
            {
                Book = db.Books.ToList()[3],
                IsDeleted = false,
                IsInUse = false,
                ConditionComment = "Все в порядке",
                LibraryNumber = "0004"
            });

            db.BookInstances.Add(new BookInstance()
            {
                Book = db.Books.ToList()[3],
                IsDeleted = false,
                IsInUse = false,
                ConditionComment = "Все в порядке",
                LibraryNumber = "0005"
            });

            db.BookInstances.Add(new BookInstance()
            {
                Book = db.Books.ToList()[3],
                IsDeleted = false,
                IsInUse = false,
                ConditionComment = "Все в порядке",
                LibraryNumber = "0006"
            });

            db.BookInstances.Add(new BookInstance()
            {
                Book = db.Books.ToList()[3],
                IsDeleted = false,
                IsInUse = false,
                ConditionComment = "Все в порядке",
                LibraryNumber = "0006"
            });

            #endregion

            #region Journal

            db.LibraryLogRecords.Add(new LibraryLogRecord()
            {
                BookInstance = db.BookInstances.ToList()[0],
                IsDeleted = false,
                Librariant = db.Workers.ToList()[0],
                Comment = null,
                Reader = db.Consumers.ToList()[0],
                RentalTime = DateTime.UtcNow.AddDays(-2)
            });
            db.LibraryLogRecords.Add(new LibraryLogRecord()
            {
                BookInstance = db.BookInstances.ToList()[1],
                IsDeleted = false,
                Librariant = db.Workers.ToList()[0],
                Comment = null,
                Reader = db.Consumers.ToList()[0],
                RentalTime = DateTime.UtcNow.AddDays(-3)
            });
            db.LibraryLogRecords.Add(new LibraryLogRecord()
            {
                BookInstance = db.BookInstances.ToList()[2],
                IsDeleted = false,
                Librariant = db.Workers.ToList()[0],
                Comment = null,
                Reader = db.Consumers.ToList()[0],
                RentalTime = DateTime.UtcNow.AddDays(-4),
                ReturnTime = DateTime.UtcNow.AddDays(-1)
            });
            db.LibraryLogRecords.Add(new LibraryLogRecord()
            {
                BookInstance = db.BookInstances.ToList()[3],
                IsDeleted = false,
                Librariant = db.Workers.ToList()[0],
                Comment = null,
                Reader = db.Consumers.ToList()[0],
                RentalTime = DateTime.UtcNow.AddDays(-7)
            });
            db.LibraryLogRecords.Add(new LibraryLogRecord()
            {
                BookInstance = db.BookInstances.ToList()[4],
                IsDeleted = false,
                Librariant = db.Workers.ToList()[0],
                Comment = null,
                Reader = db.Consumers.ToList()[0],
                RentalTime = DateTime.UtcNow
            });
            db.LibraryLogRecords.Add(new LibraryLogRecord()
            {
                BookInstance = db.BookInstances.ToList()[5],
                IsDeleted = false,
                Librariant = db.Workers.ToList()[0],
                Comment = null,
                Reader = db.Consumers.ToList()[0],
                RentalTime = DateTime.UtcNow
            });

            db.BookInstances.ToList()[0].IsInUse = true;
            db.BookInstances.ToList()[1].IsInUse = true;
            db.BookInstances.ToList()[3].IsInUse = true;
            db.BookInstances.ToList()[4].IsInUse = true;
            db.BookInstances.ToList()[5].IsInUse = true;
            #endregion

            db.SaveChanges();
        }
    }
}
