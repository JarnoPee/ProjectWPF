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
                    })
                .PrimaryKey(t => t.CategoryID);
            
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
                        CategoryID = c.Int(nullable: false),
                        DescriptionID = c.Int(nullable: false),
                        PreviewID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocationID)
                .ForeignKey("dbo.Categorys", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Descriptions", t => t.DescriptionID, cascadeDelete: true)
                .ForeignKey("dbo.Previews", t => t.PreviewID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.DescriptionID)
                .Index(t => t.PreviewID);
            
            CreateTable(
                "dbo.Descriptions",
                c => new
                    {
                        DescriptionID = c.Int(nullable: false, identity: true),
                        Beschrijving = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DescriptionID);
            
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
                    })
                .PrimaryKey(t => t.PreviewID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "PreviewID", "dbo.Previews");
            DropForeignKey("dbo.LocationCustomers", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.LocationCustomers", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Locations", "DescriptionID", "dbo.Descriptions");
            DropForeignKey("dbo.Locations", "CategoryID", "dbo.Categorys");
            DropIndex("dbo.Customers", new[] { "Email" });
            DropIndex("dbo.LocationCustomers", "IX_LocationIDCustomerID");
            DropIndex("dbo.Locations", new[] { "PreviewID" });
            DropIndex("dbo.Locations", new[] { "DescriptionID" });
            DropIndex("dbo.Locations", new[] { "CategoryID" });
            DropTable("dbo.Previews");
            DropTable("dbo.Customers");
            DropTable("dbo.LocationCustomers");
            DropTable("dbo.Descriptions");
            DropTable("dbo.Locations");
            DropTable("dbo.Categorys");
        }
    }
}
