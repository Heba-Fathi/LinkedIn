namespace Linkedin.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmpTypeInWorkExperience : DbMigration
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
