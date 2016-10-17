namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldsToViewingTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viewings", "PropertyId", c => c.Int(nullable: false));
            AddColumn("dbo.Viewings", "ViewingAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Viewings", "ViewingAt");
            DropColumn("dbo.Viewings", "PropertyId");
        }
    }
}
