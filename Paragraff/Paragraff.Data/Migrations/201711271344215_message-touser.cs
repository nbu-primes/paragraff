namespace Paragraff.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messagetouser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ToUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Messages", "ToUserId");
            AddForeignKey("dbo.Messages", "ToUserId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "ToUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "ToUserId" });
            DropColumn("dbo.Messages", "ToUserId");
        }
    }
}
