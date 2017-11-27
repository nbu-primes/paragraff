namespace Paragraff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wishlistbookuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "WisherId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Books", "WisherId");
            AddForeignKey("dbo.Books", "WisherId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "WisherId", "dbo.AspNetUsers");
            DropIndex("dbo.Books", new[] { "WisherId" });
            DropColumn("dbo.Books", "WisherId");
        }
    }
}
