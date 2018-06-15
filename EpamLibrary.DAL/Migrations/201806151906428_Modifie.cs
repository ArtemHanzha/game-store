namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modifie : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "LibraryNumber", c => c.Int());
            AlterColumn("dbo.Books", "DateOfPublication", c => c.DateTime());
            AlterColumn("dbo.Books", "Price", c => c.Single());
            AlterColumn("dbo.Comments", "PublicationDateTime", c => c.DateTime());
            AlterColumn("dbo.LibraryLogRecords", "RentalTime", c => c.DateTime());
            AlterColumn("dbo.LibraryLogRecords", "ExpectedReturnTime", c => c.DateTime());
            AlterColumn("dbo.LibraryLogRecords", "ReturnTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LibraryLogRecords", "ReturnTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LibraryLogRecords", "ExpectedReturnTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.LibraryLogRecords", "RentalTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Comments", "PublicationDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Books", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.Books", "DateOfPublication", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Books", "LibraryNumber", c => c.Int(nullable: false));
        }
    }
}
