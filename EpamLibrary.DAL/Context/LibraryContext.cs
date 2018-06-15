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
        public DbSet<Consumer> Consumers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<LibraryLogRecord> LibraryLogRecords { get; set; }

        public LibraryContext()
         //:this(@"Data Source=.\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True;MultipleActiveResultSets=true;")
        {

        }

        public LibraryContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer<LibraryContext>(new LibraryDbInitializer());
            Database.Initialize(true);
        }
    }
}
