namespace TravelAnywhere.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Locations = c.String(nullable: false),
                        OwnerID = c.Guid(nullable: false),
                        RegionID = c.Int(),
                    })
                .PrimaryKey(t => t.LocationID)
                .ForeignKey("dbo.Region", t => t.RegionID)
                .Index(t => t.RegionID);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        RegionID = c.Int(nullable: false, identity: true),
                        Regions = c.String(nullable: false),
                        OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.RegionID);
            
            CreateTable(
                "dbo.Property",
                c => new
                    {
                        PropertyID = c.Int(nullable: false, identity: true),
                        Properties = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OwnerID = c.Guid(nullable: false),
                        LocationID = c.Int(),
                    })
                .PrimaryKey(t => t.PropertyID)
                .ForeignKey("dbo.Location", t => t.LocationID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        RatingID = c.Int(nullable: false, identity: true),
                        Ratings = c.Int(nullable: false),
                        OwnerID = c.Guid(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        PropertyID = c.Int(),
                        LocationID = c.Int(),
                    })
                .PrimaryKey(t => t.RatingID)
                .ForeignKey("dbo.Location", t => t.LocationID)
                .ForeignKey("dbo.Property", t => t.PropertyID)
                .Index(t => t.PropertyID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        Reviews = c.String(),
                        OwnerID = c.Guid(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        PropertyID = c.Int(),
                        LocationID = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Location", t => t.LocationID)
                .ForeignKey("dbo.Property", t => t.PropertyID)
                .Index(t => t.PropertyID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Review", "PropertyID", "dbo.Property");
            DropForeignKey("dbo.Review", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Rating", "PropertyID", "dbo.Property");
            DropForeignKey("dbo.Rating", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Property", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Location", "RegionID", "dbo.Region");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Review", new[] { "LocationID" });
            DropIndex("dbo.Review", new[] { "PropertyID" });
            DropIndex("dbo.Rating", new[] { "LocationID" });
            DropIndex("dbo.Rating", new[] { "PropertyID" });
            DropIndex("dbo.Property", new[] { "LocationID" });
            DropIndex("dbo.Location", new[] { "RegionID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Review");
            DropTable("dbo.Rating");
            DropTable("dbo.Property");
            DropTable("dbo.Region");
            DropTable("dbo.Location");
        }
    }
}
