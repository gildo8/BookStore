namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentsID = c.Int(nullable: false, identity: true),
                        ListID = c.Int(nullable: false),
                        CommentTitle = c.String(nullable: false, maxLength: 30),
                        Writer = c.String(nullable: false, maxLength: 30),
                        Content = c.String(nullable: false, maxLength: 100),
                        Rating = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentsID)
                .ForeignKey("dbo.List", t => t.ListID, cascadeDelete: true)
                .Index(t => t.ListID);
            
            CreateTable(
                "dbo.List",
                c => new
                    {
                        ListID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        Content = c.String(nullable: false, maxLength: 100),
                        Author = c.String(nullable: false, maxLength: 20),
                        Publisher = c.String(nullable: false, maxLength: 30),
                        Genre = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Year = c.Int(nullable: false),
                        Picture = c.String(nullable: false),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ListID);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoresId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Address = c.String(nullable: false, maxLength: 30),
                        Phone = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        OpeningTime = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.StoresId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ListID", "dbo.List");
            DropIndex("dbo.Comments", new[] { "ListID" });
            DropTable("dbo.Stores");
            DropTable("dbo.List");
            DropTable("dbo.Comments");
        }
    }
}
