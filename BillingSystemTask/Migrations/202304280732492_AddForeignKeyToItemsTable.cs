namespace BillingSystemTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyToItemsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "UserId");
            AddForeignKey("dbo.Items", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "UserId", "dbo.Users");
            DropIndex("dbo.Items", new[] { "UserId" });
            DropColumn("dbo.Items", "UserId");
        }
    }
}
