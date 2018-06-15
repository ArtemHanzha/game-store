namespace EpamLibrary.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modifie2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AbstractUsers", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AbstractUsers", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
