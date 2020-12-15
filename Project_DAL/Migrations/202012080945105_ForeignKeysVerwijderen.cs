namespace Project_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeysVerwijderen : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categorys", "Location_LocationID", "dbo.Locations");
            DropForeignKey("dbo.Descriptions", "Location_LocationID", "dbo.Locations");
            DropForeignKey("dbo.Previews", "Location_LocationID", "dbo.Locations");
            DropIndex("dbo.Categorys", new[] { "Location_LocationID" });
            DropIndex("dbo.Descriptions", new[] { "Location_LocationID" });
            DropIndex("dbo.Previews", new[] { "Location_LocationID" });
            DropColumn("dbo.Categorys", "Location_LocationID");
            DropColumn("dbo.Descriptions", "Location_LocationID");
            DropColumn("dbo.Previews", "Location_LocationID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Previews", "Location_LocationID", c => c.Int());
            AddColumn("dbo.Descriptions", "Location_LocationID", c => c.Int());
            AddColumn("dbo.Categorys", "Location_LocationID", c => c.Int());
            CreateIndex("dbo.Previews", "Location_LocationID");
            CreateIndex("dbo.Descriptions", "Location_LocationID");
            CreateIndex("dbo.Categorys", "Location_LocationID");
            AddForeignKey("dbo.Previews", "Location_LocationID", "dbo.Locations", "LocationID");
            AddForeignKey("dbo.Descriptions", "Location_LocationID", "dbo.Locations", "LocationID");
            AddForeignKey("dbo.Categorys", "Location_LocationID", "dbo.Locations", "LocationID");
        }
    }
}
