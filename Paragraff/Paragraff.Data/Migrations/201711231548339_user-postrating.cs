namespace Paragraff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userpostrating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostRatings", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.PostRatings", "UserId");
            AddForeignKey("dbo.PostRatings", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostRatings", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.PostRatings", new[] { "UserId" });
            DropColumn("dbo.PostRatings", "UserId");
        }
    }
}
