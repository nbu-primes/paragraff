namespace Paragraff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postbook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "BookId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Posts", "BookId");
            AddForeignKey("dbo.Posts", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "BookId", "dbo.Books");
            DropIndex("dbo.Posts", new[] { "BookId" });
            DropColumn("dbo.Posts", "BookId");
        }
    }
}
