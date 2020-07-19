namespace Linkedin.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mariam_AddEmploymentTypeToWE : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkExperience", "EmploymentType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkExperience", "EmploymentType");
        }
    }
}
