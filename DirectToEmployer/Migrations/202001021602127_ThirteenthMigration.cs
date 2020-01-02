namespace DirectToEmployer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirteenthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobPostings", "CompanyName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobPostings", "CompanyName");
        }
    }
}
