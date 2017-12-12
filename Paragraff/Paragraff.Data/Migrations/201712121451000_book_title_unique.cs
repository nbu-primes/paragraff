namespace Paragraff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class book_title_unique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Title", c => c.String(maxLength: 100));
            CreateIndex("dbo.Books", "Title", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Books", new[] { "Title" });
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false));
        }
    }
}
