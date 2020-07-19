namespace Linkedin.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mariam_RemoverequiredUserFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Award", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Course", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EducationExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Language", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Skill", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TestScore", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.VolunteerExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkExperience", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Award", new[] { "UserId" });
            DropIndex("dbo.Course", new[] { "UserId" });
            DropIndex("dbo.EducationExperience", new[] { "UserId" });
            DropIndex("dbo.VolunteerExperience", new[] { "UserId" });
            DropIndex("dbo.WorkExperience", new[] { "UserId" });
            DropIndex("dbo.Language", new[] { "UserId" });
            DropIndex("dbo.Skill", new[] { "UserId" });
            DropIndex("dbo.TestScore", new[] { "UserId" });
            AlterColumn("dbo.Award", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Course", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.EducationExperience", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.VolunteerExperience", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.WorkExperience", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Language", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Skill", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.TestScore", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Award", "UserId");
            CreateIndex("dbo.Course", "UserId");
            CreateIndex("dbo.EducationExperience", "UserId");
            CreateIndex("dbo.VolunteerExperience", "UserId");
            CreateIndex("dbo.WorkExperience", "UserId");
            CreateIndex("dbo.Language", "UserId");
            CreateIndex("dbo.Skill", "UserId");
            CreateIndex("dbo.TestScore", "UserId");
            AddForeignKey("dbo.Award", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Course", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.EducationExperience", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Language", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Skill", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TestScore", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.VolunteerExperience", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.WorkExperience", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.VolunteerExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TestScore", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Skill", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Language", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EducationExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Course", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Award", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.TestScore", new[] { "UserId" });
            DropIndex("dbo.Skill", new[] { "UserId" });
            DropIndex("dbo.Language", new[] { "UserId" });
            DropIndex("dbo.WorkExperience", new[] { "UserId" });
            DropIndex("dbo.VolunteerExperience", new[] { "UserId" });
            DropIndex("dbo.EducationExperience", new[] { "UserId" });
            DropIndex("dbo.Course", new[] { "UserId" });
            DropIndex("dbo.Award", new[] { "UserId" });
            AlterColumn("dbo.TestScore", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Skill", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Language", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.WorkExperience", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.VolunteerExperience", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.EducationExperience", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Course", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Award", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.TestScore", "UserId");
            CreateIndex("dbo.Skill", "UserId");
            CreateIndex("dbo.Language", "UserId");
            CreateIndex("dbo.WorkExperience", "UserId");
            CreateIndex("dbo.VolunteerExperience", "UserId");
            CreateIndex("dbo.EducationExperience", "UserId");
            CreateIndex("dbo.Course", "UserId");
            CreateIndex("dbo.Award", "UserId");
            AddForeignKey("dbo.WorkExperience", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VolunteerExperience", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TestScore", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Skill", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Language", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EducationExperience", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Course", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Award", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
