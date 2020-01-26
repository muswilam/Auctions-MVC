namespace AuctionTask.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BidsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        productId = c.Int(nullable: false),
                        BidderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bidders", t => t.BidderId, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.productId, cascadeDelete: false)
                .Index(t => t.BidderId)
                .Index(t => t.productId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bids", "productId", "dbo.Products");
            DropForeignKey("dbo.Bids", "BidderId", "dbo.Bidders");
            DropIndex("dbo.Bids", new[] { "productId" });
            DropIndex("dbo.Bids", new[] { "BidderId" });
            DropTable("dbo.Bids");
        }
    }
}
