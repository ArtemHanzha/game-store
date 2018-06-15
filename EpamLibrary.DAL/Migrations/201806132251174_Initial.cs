namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        LibraryNumber = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        DateOfPublication = c.DateTime(nullable: false),
                        PublicationHouse = c.String(),
                        Price = c.Single(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublicationDateTime = c.DateTime(nullable: false),
                        Review = c.String(),
                        Rating = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Book_Id = c.Int(),
                        Reviewer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .ForeignKey("dbo.AbstractUsers", t => t.Reviewer_Id)
                .Index(t => t.Book_Id)
                .Index(t => t.Reviewer_Id);
            
            CreateTable(
                "dbo.AbstractUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        LastName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ReaderCardNumber = c.Int(),
                        IsBlocked = c.Boolean(),
                        WorkerNumber = c.String(),
                        HiringDate = c.DateTime(),
                        WorkerType = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.Book_Id);
            
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
                "dbo.LibraryLogRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RentalTime = c.DateTime(nullable: false),
                        ExpectedReturnTime = c.DateTime(nullable: false),
                        ReturnTime = c.DateTime(nullable: false),
                        Comment = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        BookInstance_Id = c.Int(),
                        Librariant_Id = c.Int(),
                        Reader_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookInstances", t => t.BookInstance_Id)
                .ForeignKey("dbo.AbstractUsers", t => t.Librariant_Id)
                .ForeignKey("dbo.AbstractUsers", t => t.Reader_Id)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LibraryLogRecords", "Reader_Id", "dbo.AbstractUsers");
            DropForeignKey("dbo.LibraryLogRecords", "Librariant_Id", "dbo.AbstractUsers");
            DropForeignKey("dbo.LibraryLogRecords", "BookInstance_Id", "dbo.BookInstances");
            DropForeignKey("dbo.Tags", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.BookInstances", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Comments", "Reviewer_Id", "dbo.AbstractUsers");
            DropForeignKey("dbo.Comments", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Books");
            DropIndex("dbo.BookAuthors", new[] { "Author_Id" });
            DropIndex("dbo.BookAuthors", new[] { "Book_Id" });
            DropIndex("dbo.LibraryLogRecords", new[] { "Reader_Id" });
            DropIndex("dbo.LibraryLogRecords", new[] { "Librariant_Id" });
            DropIndex("dbo.LibraryLogRecords", new[] { "BookInstance_Id" });
            DropIndex("dbo.Tags", new[] { "Book_Id" });
            DropIndex("dbo.BookInstances", new[] { "Book_Id" });
            DropIndex("dbo.Comments", new[] { "Reviewer_Id" });
            DropIndex("dbo.Comments", new[] { "Book_Id" });
            DropTable("dbo.BookAuthors");
            DropTable("dbo.LibraryLogRecords");
            DropTable("dbo.Genres");
            DropTable("dbo.Tags");
            DropTable("dbo.BookInstances");
            DropTable("dbo.AbstractUsers");
            DropTable("dbo.Comments");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
