namespace Linkedin.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mariam : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "BirthDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.AspNetUsers", "BirthDay", c => c.DateTime(nullable: false));
        }
    }
}
