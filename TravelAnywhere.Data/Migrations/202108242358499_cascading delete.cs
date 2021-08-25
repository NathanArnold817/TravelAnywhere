namespace TravelAnywhere.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cascadingdelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Location", "RegionID", "dbo.Region");
            AddColumn("dbo.Region", "Locations_LocationID", c => c.Int());
            CreateIndex("dbo.Region", "Locations_LocationID");
            AddForeignKey("dbo.Region", "Locations_LocationID", "dbo.Location", "LocationID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Region", "Locations_LocationID", "dbo.Location");
            DropIndex("dbo.Region", new[] { "Locations_LocationID" });
            DropColumn("dbo.Region", "Locations_LocationID");
            AddForeignKey("dbo.Location", "RegionID", "dbo.Region", "RegionID");
        }
    }
}
