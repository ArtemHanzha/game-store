namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genresfix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        LastName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LibraryNumber = c.Int(),
                        Title = c.String(),
                        Description = c.String(),
                        DateOfPublication = c.DateTime(),
                        PublicationHouse = c.String(),
                        Price = c.Single(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublicationDateTime = c.DateTime(),
                        Review = c.String(),
                        Rating = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Book_Id = c.Int(),
                        Reviewer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .ForeignKey("dbo.Users", t => t.Reviewer_Id)
                .Index(t => t.Book_Id)
                .Index(t => t.Reviewer_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        LastName = c.String(),
                        Birthday = c.DateTime(),
                        EMail = c.String(),
                        WorkerNumber = c.String(),
                        HiringDate = c.DateTime(),
                        UserType = c.Int(nullable: false),
                        ReaderCardNumber = c.Int(nullable: false),
                        IsBlocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookInstances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LibraryNumber = c.String(),
                        ConditionComment = c.String(),
                        IsInUse = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Book_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Book_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LibraryLogRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RentalTime = c.DateTime(),
                        ExpectedReturnTime = c.DateTime(),
                        ReturnTime = c.DateTime(),
                        Comment = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        BookInstance_Id = c.Int(),
                        Librariant_Id = c.Int(),
                        Reader_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookInstances", t => t.BookInstance_Id)
                .ForeignKey("dbo.Users", t => t.Librariant_Id)
                .ForeignKey("dbo.Users", t => t.Reader_Id)
                .Index(t => t.BookInstance_Id)
                .Index(t => t.Librariant_Id)
                .Index(t => t.Reader_Id);
            
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Book_Id = c.Int(nullable: false),
                        Author_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_Id, t.Author_Id })
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.Author_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.GenreBooks",
                c => new
                    {
                        Genre_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Book_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.TagBooks",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Book_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LibraryLogRecords", "Reader_Id", "dbo.Users");
            DropForeignKey("dbo.LibraryLogRecords", "Librariant_Id", "dbo.Users");
            DropForeignKey("dbo.LibraryLogRecords", "BookInstance_Id", "dbo.BookInstances");
            DropForeignKey("dbo.TagBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.TagBooks", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.GenreBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.GenreBooks", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Comments", "Reviewer_Id", "dbo.Users");
            DropForeignKey("dbo.BookInstances", "User_Id", "dbo.Users");
            DropForeignKey("dbo.BookInstances", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Comments", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Books");
            DropIndex("dbo.TagBooks", new[] { "Book_Id" });
            DropIndex("dbo.TagBooks", new[] { "Tag_Id" });
            DropIndex("dbo.GenreBooks", new[] { "Book_Id" });
            DropIndex("dbo.GenreBooks", new[] { "Genre_Id" });
            DropIndex("dbo.BookAuthors", new[] { "Author_Id" });
            DropIndex("dbo.BookAuthors", new[] { "Book_Id" });
            DropIndex("dbo.LibraryLogRecords", new[] { "Reader_Id" });
            DropIndex("dbo.LibraryLogRecords", new[] { "Librariant_Id" });
            DropIndex("dbo.LibraryLogRecords", new[] { "BookInstance_Id" });
            DropIndex("dbo.BookInstances", new[] { "User_Id" });
            DropIndex("dbo.BookInstances", new[] { "Book_Id" });
            DropIndex("dbo.Comments", new[] { "Reviewer_Id" });
            DropIndex("dbo.Comments", new[] { "Book_Id" });
            DropTable("dbo.TagBooks");
            DropTable("dbo.GenreBooks");
            DropTable("dbo.BookAuthors");
            DropTable("dbo.LibraryLogRecords");
            DropTable("dbo.Tags");
            DropTable("dbo.Genres");
            DropTable("dbo.BookInstances");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
