namespace Paragraff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentsuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CreatorId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Comments", "CreatorId");
            AddForeignKey("dbo.Comments", "CreatorId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "CreatorId", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "CreatorId" });
            DropColumn("dbo.Comments", "CreatorId");
        }
    }
}
