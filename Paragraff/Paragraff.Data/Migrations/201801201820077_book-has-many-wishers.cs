namespace Paragraff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookhasmanywishers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "WisherId", "dbo.AspNetUsers");
            DropIndex("dbo.Books", new[] { "WisherId" });
            CreateTable(
                "dbo.UserBooks",
                c => new
                    {
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Book_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Book_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Book_Id);
            
            DropColumn("dbo.Books", "WisherId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "WisherId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.UserBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.UserBooks", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserBooks", new[] { "Book_Id" });
            DropIndex("dbo.UserBooks", new[] { "User_Id" });
            DropTable("dbo.UserBooks");
            CreateIndex("dbo.Books", "WisherId");
            AddForeignKey("dbo.Books", "WisherId", "dbo.AspNetUsers", "Id");
        }
    }
}
