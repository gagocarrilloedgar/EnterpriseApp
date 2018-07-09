namespace EnterpriseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "Work_WorkId", "dbo.Works");
            DropIndex("dbo.Tasks", new[] { "Work_WorkId" });
            RenameColumn(table: "dbo.Tasks", name: "Work_WorkId", newName: "WorkId");
            AlterColumn("dbo.Tasks", "WorkId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "WorkId");
            AddForeignKey("dbo.Tasks", "WorkId", "dbo.Works", "WorkId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "WorkId", "dbo.Works");
            DropIndex("dbo.Tasks", new[] { "WorkId" });
            AlterColumn("dbo.Tasks", "WorkId", c => c.Int());
            RenameColumn(table: "dbo.Tasks", name: "WorkId", newName: "Work_WorkId");
            CreateIndex("dbo.Tasks", "Work_WorkId");
            AddForeignKey("dbo.Tasks", "Work_WorkId", "dbo.Works", "WorkId");
        }
    }
}
