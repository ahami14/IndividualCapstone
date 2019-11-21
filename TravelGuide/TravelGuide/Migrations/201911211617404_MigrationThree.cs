namespace TravelGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationThree : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemInItineraries",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        DateOfEvent = c.DateTime(nullable: false),
                        LocationOfEvent = c.String(nullable: false),
                        EventName = c.String(nullable: false),
                        DetailsOfEvent = c.String(nullable: false),
                        ItineraryId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Itineraries", t => t.ItineraryId)
                .Index(t => t.ItineraryId);
            
            CreateTable(
                "dbo.Itineraries",
                c => new
                    {
                        ItineraryId = c.Int(nullable: false, identity: true),
                        ItineraryName = c.String(),
                        CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.ItineraryId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemInItineraries", "ItineraryId", "dbo.Itineraries");
            DropForeignKey("dbo.Itineraries", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Itineraries", new[] { "CustomerId" });
            DropIndex("dbo.ItemInItineraries", new[] { "ItineraryId" });
            DropTable("dbo.Itineraries");
            DropTable("dbo.ItemInItineraries");
        }
    }
}
