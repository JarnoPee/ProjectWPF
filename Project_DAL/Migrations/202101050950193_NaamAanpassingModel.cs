namespace Project_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NaamAanpassingModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Descriptions", "DescriptionBeschrijving", c => c.String(nullable: false));
            AddColumn("dbo.Previews", "PreviewBeschrijving", c => c.String(nullable: false));
            DropColumn("dbo.Descriptions", "Beschrijving");
            DropColumn("dbo.Previews", "Beschrijving");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Previews", "Beschrijving", c => c.String(nullable: false));
            AddColumn("dbo.Descriptions", "Beschrijving", c => c.String(nullable: false));
            DropColumn("dbo.Previews", "PreviewBeschrijving");
            DropColumn("dbo.Descriptions", "DescriptionBeschrijving");
        }
    }
}
