namespace AuctionTask.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTotalLastBidAmountToTotalBidAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bids", "TotalBidAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Bids", "TotalLastBidAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bids", "TotalLastBidAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Bids", "TotalBidAmount");
        }
    }
}
