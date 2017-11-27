namespace Paragraff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messagefromuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "FromUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Messages", "FromUserId");
            AddForeignKey("dbo.Messages", "FromUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "FromUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "FromUserId" });
            DropColumn("dbo.Messages", "FromUserId");
        }
    }
}
