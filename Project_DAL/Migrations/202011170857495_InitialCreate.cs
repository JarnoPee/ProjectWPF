namespace Project_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorys",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Naam = c.String(nullable: false, maxLength: 50),
                        Location_LocationID = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.Locations", t => t.Location_LocationID)
                .Index(t => t.Location_LocationID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Naam = c.String(nullable: false),
                        Prijs = c.Decimal(nullable: false, storeType: "money"),
                        Land = c.String(nullable: false),
                        Stad = c.String(nullable: false),
                        Straat = c.String(nullable: false),
                        Huisnummer = c.String(nullable: false),
                        Diepte = c.String(nullable: false),
                        Geschiktheid = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.Descriptions",
                c => new
                    {
                        DescriptionID = c.Int(nullable: false, identity: true),
                        Beschrijving = c.String(nullable: false),
                        Location_LocationID = c.Int(),
                    })
                .PrimaryKey(t => t.DescriptionID)
                .ForeignKey("dbo.Locations", t => t.Location_LocationID)
                .Index(t => t.Location_LocationID);
            
            CreateTable(
                "dbo.LocationCustomers",
                c => new
                    {
                        LocationCustomerID = c.Int(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationCustomerID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationID, cascadeDelete: true)
                .Index(t => new { t.LocationID, t.CustomerID }, unique: true, name: "IX_LocationIDCustomerID");
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Achternaam = c.String(nullable: false, maxLength: 30),
                        Voornaam = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 150),
                        Land = c.String(nullable: false),
                        Straat = c.String(nullable: false),
                        Huisnummer = c.String(nullable: false),
                        Postcode = c.String(nullable: false),
                        Gemeente = c.String(nullable: false),
                        Paswoord = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Previews",
                c => new
                    {
                        PreviewID = c.Int(nullable: false, identity: true),
                        Beschrijving = c.String(nullable: false),
                        Location_LocationID = c.Int(),
                    })
                .PrimaryKey(t => t.PreviewID)
                .ForeignKey("dbo.Locations", t => t.Location_LocationID)
                .Index(t => t.Location_LocationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Previews", "Location_LocationID", "dbo.Locations");
            DropForeignKey("dbo.LocationCustomers", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.LocationCustomers", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Descriptions", "Location_LocationID", "dbo.Locations");
            DropForeignKey("dbo.Categorys", "Location_LocationID", "dbo.Locations");
            DropIndex("dbo.Previews", new[] { "Location_LocationID" });
            DropIndex("dbo.Customers", new[] { "Email" });
            DropIndex("dbo.LocationCustomers", "IX_LocationIDCustomerID");
            DropIndex("dbo.Descriptions", new[] { "Location_LocationID" });
            DropIndex("dbo.Categorys", new[] { "Location_LocationID" });
            DropTable("dbo.Previews");
            DropTable("dbo.Customers");
            DropTable("dbo.LocationCustomers");
            DropTable("dbo.Descriptions");
            DropTable("dbo.Locations");
            DropTable("dbo.Categorys");
        }
    }
}
