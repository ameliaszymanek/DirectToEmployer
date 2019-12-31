namespace DirectToEmployer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TenthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobPostings", "JobTitle", c => c.String());
            AddColumn("dbo.JobPostings", "Suspense", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobPostings", "Suspense");
            DropColumn("dbo.JobPostings", "JobTitle");
        }
    }
}
