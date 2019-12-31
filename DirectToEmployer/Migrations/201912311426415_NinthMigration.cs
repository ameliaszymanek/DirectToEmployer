namespace DirectToEmployer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NinthMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        ApplicationId = c.Guid(nullable: false),
                        ApplicantName = c.String(),
                        ApplicantEmailAddress = c.String(),
                        ChallengeSolution = c.String(),
                    })
                .PrimaryKey(t => t.ApplicationId);
            
            CreateTable(
                "dbo.Checklists",
                c => new
                    {
                        ChecklistId = c.Guid(nullable: false),
                        CompanyResearch = c.Boolean(nullable: false),
                        QuestionsToPrepare = c.Boolean(nullable: false),
                        PracticeQuestions = c.Boolean(nullable: false),
                        ResponsesToPrepare = c.Boolean(nullable: false),
                        PracticeResponses = c.Boolean(nullable: false),
                        WhatToWear = c.Boolean(nullable: false),
                        PrepareOutfit = c.Boolean(nullable: false),
                        WhatToBring = c.Boolean(nullable: false),
                        PrepareInterviewEssentials = c.Boolean(nullable: false),
                        InterviewFollowUp = c.Boolean(nullable: false),
                        InterviewId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ChecklistId)
                .ForeignKey("dbo.Interviews", t => t.InterviewId, cascadeDelete: true)
                .Index(t => t.InterviewId);
            
            CreateTable(
                "dbo.Interviews",
                c => new
                    {
                        InterviewId = c.Guid(nullable: false),
                        CompanyName = c.String(),
                        CompanyAddress = c.String(),
                        DateAndTimeOfInterview = c.DateTime(nullable: false),
                        DistanceToInterview = c.String(),
                        DurationToInterview = c.String(),
                        JobseekerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.InterviewId)
                .ForeignKey("dbo.Jobseekers", t => t.JobseekerId, cascadeDelete: true)
                .Index(t => t.JobseekerId);
            
            CreateTable(
                "dbo.Jobseekers",
                c => new
                    {
                        JobseekerId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        HomeAddress = c.String(),
                        Industry = c.String(),
                        TopThreeSkills = c.String(),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.JobseekerId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                "dbo.Employers",
                c => new
                    {
                        EmployerId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        Industry = c.String(),
                        CompanyName = c.String(),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EmployerId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.JobPostings",
                c => new
                    {
                        JobPostingId = c.Guid(nullable: false),
                        DesiredSkills = c.String(),
                        JobPostingSummary = c.String(),
                        ApplicationChallenge = c.String(),
                        EmployerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.JobPostingId)
                .ForeignKey("dbo.Employers", t => t.EmployerId, cascadeDelete: true)
                .Index(t => t.EmployerId);
            
            CreateTable(
                "dbo.JobseekerApplications",
                c => new
                    {
                        JobseekerApplicationId = c.Guid(nullable: false),
                        JobseekerId = c.Guid(nullable: false),
                        ApplicationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.JobseekerApplicationId)
                .ForeignKey("dbo.Applications", t => t.ApplicationId, cascadeDelete: true)
                .ForeignKey("dbo.Jobseekers", t => t.JobseekerId, cascadeDelete: true)
                .Index(t => t.JobseekerId)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.JobseekerApplications", "JobseekerId", "dbo.Jobseekers");
            DropForeignKey("dbo.JobseekerApplications", "ApplicationId", "dbo.Applications");
            DropForeignKey("dbo.JobPostings", "EmployerId", "dbo.Employers");
            DropForeignKey("dbo.Employers", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Checklists", "InterviewId", "dbo.Interviews");
            DropForeignKey("dbo.Interviews", "JobseekerId", "dbo.Jobseekers");
            DropForeignKey("dbo.Jobseekers", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.JobseekerApplications", new[] { "ApplicationId" });
            DropIndex("dbo.JobseekerApplications", new[] { "JobseekerId" });
            DropIndex("dbo.JobPostings", new[] { "EmployerId" });
            DropIndex("dbo.Employers", new[] { "ApplicationId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Jobseekers", new[] { "ApplicationId" });
            DropIndex("dbo.Interviews", new[] { "JobseekerId" });
            DropIndex("dbo.Checklists", new[] { "InterviewId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.JobseekerApplications");
            DropTable("dbo.JobPostings");
            DropTable("dbo.Employers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Jobseekers");
            DropTable("dbo.Interviews");
            DropTable("dbo.Checklists");
            DropTable("dbo.Applications");
        }
    }
}
