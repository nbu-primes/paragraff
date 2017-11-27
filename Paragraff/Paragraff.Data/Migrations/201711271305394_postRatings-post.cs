namespace Paragraff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postRatingspost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostRatings", "PostId", c => c.Guid(nullable: false));
            CreateIndex("dbo.PostRatings", "PostId");
            AddForeignKey("dbo.PostRatings", "PostId", "dbo.Posts", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostRatings", "PostId", "dbo.Posts");
            DropIndex("dbo.PostRatings", new[] { "PostId" });
            DropColumn("dbo.PostRatings", "PostId");
        }
    }
}
