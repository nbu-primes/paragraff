namespace Paragraff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usertouserRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRatings", "ToUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.UserRatings", "ToUserId");
            AddForeignKey("dbo.UserRatings", "ToUserId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRatings", "ToUserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserRatings", new[] { "ToUserId" });
            DropColumn("dbo.UserRatings", "ToUserId");
        }
    }
}
