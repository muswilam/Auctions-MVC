namespace AuctionTask.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLastBidAmount : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bids", "productId", "dbo.Products");
            DropIndex("dbo.Bids", new[] { "productId" });
            AddColumn("dbo.Bids", "LastBidAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Bids", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bids", "ProductId");
            AddForeignKey("dbo.Bids", "ProductId", "dbo.Products", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bids", "ProductId", "dbo.Products");
            DropIndex("dbo.Bids", new[] { "ProductId" });
            AlterColumn("dbo.Bids", "ProductId", c => c.Int(nullable: false));
            DropColumn("dbo.Bids", "LastBidAmount");
            CreateIndex("dbo.Bids", "productId");
            AddForeignKey("dbo.Bids", "productId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
