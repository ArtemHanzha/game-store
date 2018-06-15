namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeNewMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbstractUsers", "EMail", c => c.String());
            AddColumn("dbo.BookInstances", "AbstractUser_Id", c => c.Int());
            CreateIndex("dbo.BookInstances", "AbstractUser_Id");
            AddForeignKey("dbo.BookInstances", "AbstractUser_Id", "dbo.AbstractUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookInstances", "AbstractUser_Id", "dbo.AbstractUsers");
            DropIndex("dbo.BookInstances", new[] { "AbstractUser_Id" });
            DropColumn("dbo.BookInstances", "AbstractUser_Id");
            DropColumn("dbo.AbstractUsers", "EMail");
        }
    }
}
