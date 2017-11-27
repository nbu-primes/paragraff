namespace Paragraff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postcomments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "PostId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Comments", "PostId");
            AddForeignKey("dbo.Comments", "PostId", "dbo.Posts", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropColumn("dbo.Comments", "PostId");
        }
    }
}
