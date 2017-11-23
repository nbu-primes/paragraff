namespace Paragraff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userfromuserRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRatings", "FromUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.UserRatings", "FromUserId");
            AddForeignKey("dbo.UserRatings", "FromUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRatings", "FromUserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserRatings", new[] { "FromUserId" });
            DropColumn("dbo.UserRatings", "FromUserId");
        }
    }
}
