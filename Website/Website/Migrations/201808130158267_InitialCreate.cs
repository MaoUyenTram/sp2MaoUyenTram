namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AId = c.Int(nullable: false, identity: true),
                        QId = c.Int(nullable: false),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.AId)
                .ForeignKey("dbo.Questions", t => t.QId)
                .Index(t => t.QId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QId = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Method = c.String(),
                        Teacher = c.String(),
                    })
                .PrimaryKey(t => t.QId);
            
            CreateTable(
                "dbo.Qanswers",
                c => new
                    {
                        QId = c.Int(nullable: false),
                        AId = c.Int(nullable: false),
                        UId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.QId, t.AId, t.UId })
                .ForeignKey("dbo.Answers", t => t.AId)
                .ForeignKey("dbo.Questions", t => t.QId)
                .ForeignKey("dbo.Users", t => t.UId)
                .Index(t => t.QId)
                .Index(t => t.AId)
                .Index(t => t.UId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UId = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        Psw = c.String(),
                        Teacher = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Qanswers", "UId", "dbo.Users");
            DropForeignKey("dbo.Qanswers", "QId", "dbo.Questions");
            DropForeignKey("dbo.Qanswers", "AId", "dbo.Answers");
            DropForeignKey("dbo.Answers", "QId", "dbo.Questions");
            DropIndex("dbo.Qanswers", new[] { "UId" });
            DropIndex("dbo.Qanswers", new[] { "AId" });
            DropIndex("dbo.Qanswers", new[] { "QId" });
            DropIndex("dbo.Answers", new[] { "QId" });
            DropTable("dbo.Users");
            DropTable("dbo.Qanswers");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
