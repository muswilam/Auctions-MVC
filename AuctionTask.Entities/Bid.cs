using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionTask.Entities
{
    public class Bid
    {
        public int Id { get; set; }

        public decimal BidAmount { get; set; }
        public decimal TotalLastBidAmount { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int BidderId { get; set; }
        public Bidder Bidder { get; set; }

    }
}
