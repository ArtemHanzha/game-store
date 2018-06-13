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
        :base("Server=tcp:ganzhalibrary.database.windows.net,1433;Initial Catalog=Library;Persist Security Info=False;User ID=ganzha;Password=7294682aA;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        {
            Database.SetInitializer<LibraryContext>(new LibraryDbInitializer());
            Database.Initialize(true);
        }

        public LibraryContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer<LibraryContext>(new LibraryDbInitializer());
            Database.Initialize(true);
        }
    }
}
