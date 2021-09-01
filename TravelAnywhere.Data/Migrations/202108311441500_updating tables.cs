namespace TravelAnywhere.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingtables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Location", "RegionID", "dbo.Region");
            DropIndex("dbo.Location", new[] { "RegionID" });
            DropColumn("dbo.Location", "RegionID");
            DropColumn("dbo.Location", "Regions");
            DropColumn("dbo.Property", "Locations");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Property", "Locations", c => c.String());
            AddColumn("dbo.Location", "Regions", c => c.String());
            AddColumn("dbo.Location", "RegionID", c => c.Int());
            CreateIndex("dbo.Location", "RegionID");
            AddForeignKey("dbo.Location", "RegionID", "dbo.Region", "RegionID", cascadeDelete: true);
        }
    }
}
