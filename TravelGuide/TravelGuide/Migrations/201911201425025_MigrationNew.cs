namespace TravelGuide.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationNew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        StreetAddress = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Insterests = c.String(nullable: false),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .Index(t => t.ApplicationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ApplicationId", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "ApplicationId" });
            DropTable("dbo.Customers");
        }
    }
}
