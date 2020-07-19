namespace Linkedin.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Award",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Issuer = c.String(),
                        DateTime = c.DateTime(),
                        Description = c.String(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Country = c.Int(nullable: false),
                        Address = c.String(),
                        About = c.String(),
                        BirthDay = c.DateTime(nullable: true),
                        HeadLine = c.String(),
                        Gender = c.Int(nullable: false),
                        Indstry = c.Int(nullable: false),
                        ProfilePicURL = c.String(),
                        CoverPicURL = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Content = c.String(),
                        PicURL = c.String(),
                        PostId = c.Guid(nullable: false),
                        AuthorId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .ForeignKey("dbo.Post", t => t.PostId)
                .Index(t => t.PostId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Status = c.String(),
                        ImageUrl = c.String(),
                        AuthorId = c.String(nullable: false, maxLength: 128),
                        SharedPostId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .ForeignKey("dbo.Post", t => t.SharedPostId)
                .Index(t => t.AuthorId)
                .Index(t => t.SharedPostId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Number = c.String(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.EducationExperience",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Grade = c.String(),
                        Degree = c.Int(),
                        Description = c.String(),
                        Activites = c.String(),
                        StartYear = c.DateTime(),
                        EndYear = c.DateTime(),
                        SchoolId = c.Guid(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SavedPlace", t => t.SchoolId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.SchoolId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SavedPlace",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        PlaceType = c.Int(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VolunteerExperience",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        CompanyId = c.Guid(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Cause = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SavedPlace", t => t.CompanyId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.CompanyId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.WorkExperience",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        CompanyId = c.Guid(),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Location = c.String(),
                        Headline = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        IsPresent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SavedPlace", t => t.CompanyId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.CompanyId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Level = c.Int(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Patent",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        Office = c.Int(nullable: false),
                        Date = c.DateTime(),
                        Url = c.String(),
                        Issued = c.Boolean(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        URL = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publication",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Date = c.DateTime(),
                        PublisherId = c.Guid(),
                        Url = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SavedPlace", t => t.PublisherId)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Skill",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TestScore",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Score = c.Int(),
                        DateTime = c.DateTime(),
                        Description = c.String(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.LikedComments",
                c => new
                    {
                        CommentId = c.Guid(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CommentId, t.UserId })
                .ForeignKey("dbo.Comment", t => t.CommentId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.CommentId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.LikedPosts",
                c => new
                    {
                        PostId = c.Guid(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PostId, t.UserId })
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.PostId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CommentReplies",
                c => new
                    {
                        CommentId = c.Guid(nullable: false),
                        ReplyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CommentId, t.ReplyId })
                .ForeignKey("dbo.Comment", t => t.CommentId)
                .ForeignKey("dbo.Comment", t => t.ReplyId)
                .Index(t => t.CommentId)
                .Index(t => t.ReplyId);
            
            CreateTable(
                "dbo.UserConnections",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        ConnectionId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.ConnectionId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ConnectionId)
                .Index(t => t.UserId)
                .Index(t => t.ConnectionId);
            
            CreateTable(
                "dbo.PatentApplicationUsers",
                c => new
                    {
                        Patent_Id = c.Guid(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Patent_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Patent", t => t.Patent_Id, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: false)
                .Index(t => t.Patent_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ProjectApplicationUsers",
                c => new
                    {
                        Project_Id = c.Guid(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Project_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Project", t => t.Project_Id, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: false)
                .Index(t => t.Project_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.PublicationApplicationUsers",
                c => new
                    {
                        Publication_Id = c.Guid(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Publication_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Publication", t => t.Publication_Id, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: false)
                .Index(t => t.Publication_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.UserRequests",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RequestId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RequestId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.RequestId)
                .Index(t => t.UserId)
                .Index(t => t.RequestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Award", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TestScore", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Skill", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserRequests", "RequestId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserRequests", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Publication", "PublisherId", "dbo.SavedPlace");
            DropForeignKey("dbo.PublicationApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PublicationApplicationUsers", "Publication_Id", "dbo.Publication");
            DropForeignKey("dbo.ProjectApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectApplicationUsers", "Project_Id", "dbo.Project");
            DropForeignKey("dbo.PatentApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PatentApplicationUsers", "Patent_Id", "dbo.Patent");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Language", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EducationExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EducationExperience", "SchoolId", "dbo.SavedPlace");
            DropForeignKey("dbo.WorkExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkExperience", "CompanyId", "dbo.SavedPlace");
            DropForeignKey("dbo.VolunteerExperience", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.VolunteerExperience", "CompanyId", "dbo.SavedPlace");
            DropForeignKey("dbo.Course", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserConnections", "ConnectionId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserConnections", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CommentReplies", "ReplyId", "dbo.Comment");
            DropForeignKey("dbo.CommentReplies", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropForeignKey("dbo.Post", "SharedPostId", "dbo.Post");
            DropForeignKey("dbo.LikedPosts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.LikedPosts", "PostId", "dbo.Post");
            DropForeignKey("dbo.Post", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.LikedComments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.LikedComments", "CommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserRequests", new[] { "RequestId" });
            DropIndex("dbo.UserRequests", new[] { "UserId" });
            DropIndex("dbo.PublicationApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.PublicationApplicationUsers", new[] { "Publication_Id" });
            DropIndex("dbo.ProjectApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ProjectApplicationUsers", new[] { "Project_Id" });
            DropIndex("dbo.PatentApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.PatentApplicationUsers", new[] { "Patent_Id" });
            DropIndex("dbo.UserConnections", new[] { "ConnectionId" });
            DropIndex("dbo.UserConnections", new[] { "UserId" });
            DropIndex("dbo.CommentReplies", new[] { "ReplyId" });
            DropIndex("dbo.CommentReplies", new[] { "CommentId" });
            DropIndex("dbo.LikedPosts", new[] { "UserId" });
            DropIndex("dbo.LikedPosts", new[] { "PostId" });
            DropIndex("dbo.LikedComments", new[] { "UserId" });
            DropIndex("dbo.LikedComments", new[] { "CommentId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.TestScore", new[] { "UserId" });
            DropIndex("dbo.Skill", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Publication", new[] { "PublisherId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Language", new[] { "UserId" });
            DropIndex("dbo.WorkExperience", new[] { "UserId" });
            DropIndex("dbo.WorkExperience", new[] { "CompanyId" });
            DropIndex("dbo.VolunteerExperience", new[] { "UserId" });
            DropIndex("dbo.VolunteerExperience", new[] { "CompanyId" });
            DropIndex("dbo.EducationExperience", new[] { "UserId" });
            DropIndex("dbo.EducationExperience", new[] { "SchoolId" });
            DropIndex("dbo.Course", new[] { "UserId" });
            DropIndex("dbo.Post", new[] { "SharedPostId" });
            DropIndex("dbo.Post", new[] { "AuthorId" });
            DropIndex("dbo.Comment", new[] { "AuthorId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Award", new[] { "UserId" });
            DropTable("dbo.UserRequests");
            DropTable("dbo.PublicationApplicationUsers");
            DropTable("dbo.ProjectApplicationUsers");
            DropTable("dbo.PatentApplicationUsers");
            DropTable("dbo.UserConnections");
            DropTable("dbo.CommentReplies");
            DropTable("dbo.LikedPosts");
            DropTable("dbo.LikedComments");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TestScore");
            DropTable("dbo.Skill");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Publication");
            DropTable("dbo.Project");
            DropTable("dbo.Patent");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Language");
            DropTable("dbo.WorkExperience");
            DropTable("dbo.VolunteerExperience");
            DropTable("dbo.SavedPlace");
            DropTable("dbo.EducationExperience");
            DropTable("dbo.Course");
            DropTable("dbo.Post");
            DropTable("dbo.Comment");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Award");
        }
    }
}
