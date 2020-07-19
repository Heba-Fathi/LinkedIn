namespace Linkedin.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mariamAddrequiredUserfk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Award", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Course", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EducationExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkExperience", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Award", new[] { "UserId" });
            DropIndex("dbo.Course", new[] { "UserId" });
            DropIndex("dbo.EducationExperience", new[] { "UserId" });
            DropIndex("dbo.WorkExperience", new[] { "UserId" });
            AlterColumn("dbo.Award", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Course", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.EducationExperience", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.WorkExperience", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Award", "UserId");
            CreateIndex("dbo.Course", "UserId");
            CreateIndex("dbo.EducationExperience", "UserId");
            CreateIndex("dbo.WorkExperience", "UserId");
            AddForeignKey("dbo.Award", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Course", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EducationExperience", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkExperience", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EducationExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Course", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Award", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.WorkExperience", new[] { "UserId" });
            DropIndex("dbo.EducationExperience", new[] { "UserId" });
            DropIndex("dbo.Course", new[] { "UserId" });
            DropIndex("dbo.Award", new[] { "UserId" });
            AlterColumn("dbo.WorkExperience", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.EducationExperience", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Course", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Award", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.WorkExperience", "UserId");
            CreateIndex("dbo.EducationExperience", "UserId");
            CreateIndex("dbo.Course", "UserId");
            CreateIndex("dbo.Award", "UserId");
            AddForeignKey("dbo.WorkExperience", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.EducationExperience", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Course", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Award", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
