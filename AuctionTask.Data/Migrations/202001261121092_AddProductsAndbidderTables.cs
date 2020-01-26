namespace AuctionTask.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProductsAndbidderTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bidders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 500),
                        ActualPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Bidders");
        }
    }
}
