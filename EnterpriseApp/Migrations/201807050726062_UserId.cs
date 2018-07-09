namespace EnterpriseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Works", "User_UserId", "dbo.Users");
            DropIndex("dbo.Works", new[] { "User_UserId" });
            RenameColumn(table: "dbo.Works", name: "User_UserId", newName: "UserId");
            AlterColumn("dbo.Works", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Works", "UserId");
            AddForeignKey("dbo.Works", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Works", "UserId", "dbo.Users");
            DropIndex("dbo.Works", new[] { "UserId" });
            AlterColumn("dbo.Works", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Works", name: "UserId", newName: "User_UserId");
            CreateIndex("dbo.Works", "User_UserId");
            AddForeignKey("dbo.Works", "User_UserId", "dbo.Users", "UserId");
        }
    }
}
