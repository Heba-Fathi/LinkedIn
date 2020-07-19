namespace Linkedin.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mariammshFahma7agabsOkay : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Language", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Skill", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TestScore", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.VolunteerExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkExperience", "CompanyId", "dbo.SavedPlace");
            DropIndex("dbo.VolunteerExperience", new[] { "UserId" });
            DropIndex("dbo.WorkExperience", new[] { "CompanyId" });
            DropIndex("dbo.Language", new[] { "UserId" });
            DropIndex("dbo.Skill", new[] { "UserId" });
            DropIndex("dbo.TestScore", new[] { "UserId" });
            AlterColumn("dbo.VolunteerExperience", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.WorkExperience", "CompanyId", c => c.Guid());
            AlterColumn("dbo.Language", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Skill", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TestScore", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.VolunteerExperience", "UserId");
            CreateIndex("dbo.WorkExperience", "CompanyId");
            CreateIndex("dbo.Language", "UserId");
            CreateIndex("dbo.Skill", "UserId");
            CreateIndex("dbo.TestScore", "UserId");
            AddForeignKey("dbo.Language", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Skill", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.TestScore", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.VolunteerExperience", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.WorkExperience", "CompanyId", "dbo.SavedPlace", "Id");
            DropColumn("dbo.WorkExperience", "EmploymentType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkExperience", "EmploymentType", c => c.Int(nullable: false));
            DropForeignKey("dbo.WorkExperience", "CompanyId", "dbo.SavedPlace");
            DropForeignKey("dbo.VolunteerExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TestScore", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Skill", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Language", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.TestScore", new[] { "UserId" });
            DropIndex("dbo.Skill", new[] { "UserId" });
            DropIndex("dbo.Language", new[] { "UserId" });
            DropIndex("dbo.WorkExperience", new[] { "CompanyId" });
            DropIndex("dbo.VolunteerExperience", new[] { "UserId" });
            AlterColumn("dbo.TestScore", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Skill", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Language", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.WorkExperience", "CompanyId", c => c.Guid(nullable: false));
            AlterColumn("dbo.VolunteerExperience", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.TestScore", "UserId");
            CreateIndex("dbo.Skill", "UserId");
            CreateIndex("dbo.Language", "UserId");
            CreateIndex("dbo.WorkExperience", "CompanyId");
            CreateIndex("dbo.VolunteerExperience", "UserId");
            AddForeignKey("dbo.WorkExperience", "CompanyId", "dbo.SavedPlace", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VolunteerExperience", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TestScore", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Skill", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Language", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
