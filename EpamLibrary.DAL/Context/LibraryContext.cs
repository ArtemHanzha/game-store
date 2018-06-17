using System.Data.Entity;
using EpamLibrary.Contracts.Models;

namespace EpamLibrary.DAL.Context
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookInstance> BookInstances { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<LibraryLogRecord> LibraryLogRecords { get; set; }

        public LibraryContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer<LibraryContext>(new LibraryDbInitializer());
            Database.Initialize(true);
        }

        public LibraryContext()
        {
            
        }
    }
}
