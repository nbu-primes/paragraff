namespace Paragraff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usertrades : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "TradedWithId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Posts", "TradedWithId");
            AddForeignKey("dbo.Posts", "TradedWithId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "TradedWithId", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "TradedWithId" });
            DropColumn("dbo.Posts", "TradedWithId");
        }
    }
}
