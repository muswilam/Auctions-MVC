namespace AuctionTask.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuctionsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WinnerName = c.String(nullable: false, maxLength: 255),
                        ProductName = c.String(nullable: false, maxLength: 500),
                        ProductActualPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WinnerPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Auctions");
        }
    }
}
