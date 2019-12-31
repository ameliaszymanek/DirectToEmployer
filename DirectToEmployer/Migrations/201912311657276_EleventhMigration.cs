namespace DirectToEmployer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EleventhMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applications", "ApplicantPortfolioLink", c => c.String());
            AddColumn("dbo.Applications", "JobPostingId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Applications", "JobPostingId");
            AddForeignKey("dbo.Applications", "JobPostingId", "dbo.JobPostings", "JobPostingId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "JobPostingId", "dbo.JobPostings");
            DropIndex("dbo.Applications", new[] { "JobPostingId" });
            DropColumn("dbo.Applications", "JobPostingId");
            DropColumn("dbo.Applications", "ApplicantPortfolioLink");
        }
    }
}
