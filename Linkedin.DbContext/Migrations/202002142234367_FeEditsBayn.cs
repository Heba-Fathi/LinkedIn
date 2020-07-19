namespace Linkedin.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeEditsBayn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Post", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Post", "Date");
            DropColumn("dbo.Comment", "Date");
        }
    }
}
