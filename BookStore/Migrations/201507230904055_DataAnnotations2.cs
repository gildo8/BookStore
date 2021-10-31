namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stores", "Address", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stores", "Address", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
