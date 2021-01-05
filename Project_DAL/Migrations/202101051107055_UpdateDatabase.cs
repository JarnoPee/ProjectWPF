namespace Project_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locations", "CategoryID", "dbo.Categorys");
            DropForeignKey("dbo.Locations", "DescriptionID", "dbo.Descriptions");
            DropForeignKey("dbo.LocationCustomers", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Locations", "PreviewID", "dbo.Previews");
            DropForeignKey("dbo.LocationCustomers", "CustomerID", "dbo.Customers");
            AddForeignKey("dbo.Locations", "CategoryID", "dbo.Categorys", "CategoryID");
            AddForeignKey("dbo.Locations", "DescriptionID", "dbo.Descriptions", "DescriptionID");
            AddForeignKey("dbo.LocationCustomers", "LocationID", "dbo.Locations", "LocationID");
            AddForeignKey("dbo.Locations", "PreviewID", "dbo.Previews", "PreviewID");
            AddForeignKey("dbo.LocationCustomers", "CustomerID", "dbo.Customers", "CustomerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LocationCustomers", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Locations", "PreviewID", "dbo.Previews");
            DropForeignKey("dbo.LocationCustomers", "LocationID", "dbo.Locations");
            DropForeignKey("dbo.Locations", "DescriptionID", "dbo.Descriptions");
            DropForeignKey("dbo.Locations", "CategoryID", "dbo.Categorys");
            AddForeignKey("dbo.LocationCustomers", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
            AddForeignKey("dbo.Locations", "PreviewID", "dbo.Previews", "PreviewID", cascadeDelete: true);
            AddForeignKey("dbo.LocationCustomers", "LocationID", "dbo.Locations", "LocationID", cascadeDelete: true);
            AddForeignKey("dbo.Locations", "DescriptionID", "dbo.Descriptions", "DescriptionID", cascadeDelete: true);
            AddForeignKey("dbo.Locations", "CategoryID", "dbo.Categorys", "CategoryID", cascadeDelete: true);
        }
    }
}
