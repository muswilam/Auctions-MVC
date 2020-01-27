using AuctionTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionTask.Web.ViewModels
{
    public class BidViewModel
    {
        public Product Product { get; set; }
        public List<Bidder> ProductBidders { get; set; }
        public List<Bid> Bids { get; set; }
    }

    public class ListBidsViewModel
    {
        public Product Product { get; set; }

        public List<Bid> Bids { get; set; }
    }

    public class NewBidViewModel
    {
        public decimal BidAmount { get; set; }
        public int ProductId { get; set; }
        public int BidderId { get; set; }

        public decimal ActualAmount { get; set; }
    }
}