using AuctionTask.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionTask.Data
{
    public class AuctionTaskDbContext : DbContext
    {
        public AuctionTaskDbContext()
            :base("name=AuctionTaskCS")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Bidder> Bidders { get; set; }
        public DbSet<Bid> Bids { get; set; }
    }
}
