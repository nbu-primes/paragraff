namespace Paragraff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userposts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PublisherId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Posts", "PublisherId");
            AddForeignKey("dbo.Posts", "PublisherId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "PublisherId", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "PublisherId" });
            DropColumn("dbo.Posts", "PublisherId");
        }
    }
}
