using AuctionTask.Data;
using AuctionTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace AuctionTask.Services
{
    public class BidServices
    {
        private readonly AuctionTaskDbContext _context;

        #region Singleton 
        public static BidServices Instance
        {
            get
            {
                if (instance == null) instance = new BidServices();
                return instance;
            }
        }

        private static BidServices instance { get; set; }

        private BidServices()
        {
            _context = new AuctionTaskDbContext();
        }
        #endregion


        public List<Bid> GetBids(int productId)
        {
            return _context.Bids.Include(b => b.Bidder).Include(b => b.Product).Where(b => b.ProductId == productId).ToList();
        }

        public bool AddBid(Bid bid)
        {
            _context.Entry(bid).State = EntityState.Added;
            return _context.SaveChanges() > 0;
        }

        public decimal GetTotalLastBidAmount(int prodectId)
        {
            var bids  = _context.Bids.Include(b => b.Product);

            if (bids != null && bids.Count() > 0)
            {
                var lastBid = bids.ToList().OrderByDescending(b => b.Id).Where(b => b.ProductId == prodectId).FirstOrDefault();
                return lastBid != null ? lastBid.TotalLastBidAmount : 0;
            }

            return 0;
        }

        public Bid GetWinnerBid(int productId)
        {
            return _context.Bids
                    .Include(b => b.Bidder)
                    .Include(b => b.Product)
                    .Where(b => b.ProductId == productId)
                    .OrderByDescending(b => b.Id)
                    .FirstOrDefault();
        }
    }
}
