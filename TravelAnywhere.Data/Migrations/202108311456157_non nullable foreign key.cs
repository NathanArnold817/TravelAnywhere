namespace TravelAnywhere.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nonnullableforeignkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Property", "LocationID", "dbo.Location");
            DropIndex("dbo.Property", new[] { "LocationID" });
            AlterColumn("dbo.Property", "LocationID", c => c.Int(nullable: false));
            CreateIndex("dbo.Property", "LocationID");
            AddForeignKey("dbo.Property", "LocationID", "dbo.Location", "LocationID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Property", "LocationID", "dbo.Location");
            DropIndex("dbo.Property", new[] { "LocationID" });
            AlterColumn("dbo.Property", "LocationID", c => c.Int());
            CreateIndex("dbo.Property", "LocationID");
            AddForeignKey("dbo.Property", "LocationID", "dbo.Location", "LocationID");
        }
    }
}
