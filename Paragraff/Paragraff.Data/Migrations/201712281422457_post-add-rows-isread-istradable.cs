namespace Paragraff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postaddrowsisreadistradable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "IsRead", c => c.Boolean(nullable: false));
            AddColumn("dbo.Posts", "IsTradable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "IsTradable");
            DropColumn("dbo.Posts", "IsRead");
        }
    }
}
