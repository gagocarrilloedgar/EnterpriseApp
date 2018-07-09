namespace EnterpriseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Work_WorkId = c.Int(),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Works", t => t.Work_WorkId)
                .Index(t => t.Work_WorkId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Works",
                c => new
                    {
                        WorkId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.WorkId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Works", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "Work_WorkId", "dbo.Works");
            DropIndex("dbo.Works", new[] { "User_UserId" });
            DropIndex("dbo.Tasks", new[] { "Work_WorkId" });
            DropTable("dbo.Works");
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
        }
    }
}
