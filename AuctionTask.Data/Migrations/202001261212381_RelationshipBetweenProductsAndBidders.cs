namespace AuctionTask.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipBetweenProductsAndBidders : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bidders", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bidders", "ProductId");
            AddForeignKey("dbo.Bidders", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bidders", "ProductId", "dbo.Products");
            DropIndex("dbo.Bidders", new[] { "ProductId" });
            DropColumn("dbo.Bidders", "ProductId");
        }
    }
}
