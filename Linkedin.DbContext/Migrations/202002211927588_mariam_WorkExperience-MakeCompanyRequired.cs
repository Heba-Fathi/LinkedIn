namespace Linkedin.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mariam_WorkExperienceMakeCompanyRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkExperience", "CompanyId", "dbo.SavedPlace");
            DropIndex("dbo.WorkExperience", new[] { "CompanyId" });
            AlterColumn("dbo.WorkExperience", "CompanyId", c => c.Guid(nullable: false));
            CreateIndex("dbo.WorkExperience", "CompanyId");
            AddForeignKey("dbo.WorkExperience", "CompanyId", "dbo.SavedPlace", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkExperience", "CompanyId", "dbo.SavedPlace");
            DropIndex("dbo.WorkExperience", new[] { "CompanyId" });
            AlterColumn("dbo.WorkExperience", "CompanyId", c => c.Guid());
            CreateIndex("dbo.WorkExperience", "CompanyId");
            AddForeignKey("dbo.WorkExperience", "CompanyId", "dbo.SavedPlace", "Id");
        }
    }
}
