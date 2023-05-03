namespace BillingSystemTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Billing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Billings",
                c => new
                    {
                        BillingId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        customers_Id = c.Int(),
                    })
                .PrimaryKey(t => t.BillingId)
                .ForeignKey("dbo.Customers", t => t.customers_Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId)
                .Index(t => t.customers_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Billings", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Billings", "customers_Id", "dbo.Customers");
            DropIndex("dbo.Billings", new[] { "customers_Id" });
            DropIndex("dbo.Billings", new[] { "ItemId" });
            DropTable("dbo.Billings");
        }
    }
}
