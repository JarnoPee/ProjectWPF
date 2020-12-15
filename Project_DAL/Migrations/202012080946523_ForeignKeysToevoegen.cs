namespace Project_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeysToevoegen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "CategoryID", c => c.Int(nullable: false));
            AddColumn("dbo.Locations", "DescriptionID", c => c.Int(nullable: false));
            AddColumn("dbo.Locations", "PreviewID", c => c.Int(nullable: false));
            CreateIndex("dbo.Locations", "CategoryID");
            CreateIndex("dbo.Locations", "DescriptionID");
            CreateIndex("dbo.Locations", "PreviewID");
            AddForeignKey("dbo.Locations", "CategoryID", "dbo.Categorys", "CategoryID", cascadeDelete: true);
            AddForeignKey("dbo.Locations", "DescriptionID", "dbo.Descriptions", "DescriptionID", cascadeDelete: true);
            AddForeignKey("dbo.Locations", "PreviewID", "dbo.Previews", "PreviewID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "PreviewID", "dbo.Previews");
            DropForeignKey("dbo.Locations", "DescriptionID", "dbo.Descriptions");
            DropForeignKey("dbo.Locations", "CategoryID", "dbo.Categorys");
            DropIndex("dbo.Locations", new[] { "PreviewID" });
            DropIndex("dbo.Locations", new[] { "DescriptionID" });
            DropIndex("dbo.Locations", new[] { "CategoryID" });
            DropColumn("dbo.Locations", "PreviewID");
            DropColumn("dbo.Locations", "DescriptionID");
            DropColumn("dbo.Locations", "CategoryID");
        }
    }
}
