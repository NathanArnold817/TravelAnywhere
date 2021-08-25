namespace TravelAnywhere.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addregionbylistnotid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Location", "Regions", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Location", "Regions");
        }
    }
}
