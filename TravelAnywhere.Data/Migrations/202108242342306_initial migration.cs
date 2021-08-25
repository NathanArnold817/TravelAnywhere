namespace TravelAnywhere.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Region", "Regions", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Region", "Regions", c => c.String());
        }
    }
}
