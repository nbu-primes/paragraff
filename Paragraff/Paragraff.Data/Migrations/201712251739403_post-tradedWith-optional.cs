namespace Paragraff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class posttradedWithoptional : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "TradedWithId", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "TradedWithId" });
            AlterColumn("dbo.Posts", "TradedWithId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Posts", "TradedWithId");
            AddForeignKey("dbo.Posts", "TradedWithId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "TradedWithId", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "TradedWithId" });
            AlterColumn("dbo.Posts", "TradedWithId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Posts", "TradedWithId");
            AddForeignKey("dbo.Posts", "TradedWithId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
