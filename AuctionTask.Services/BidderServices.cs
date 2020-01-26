using AuctionTask.Data;
using AuctionTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionTask.Services
{
    public class BidderServices
    {
        private readonly AuctionTaskDbContext _context;

        #region Singleton 
        public static BidderServices Instance
        {
            get
            {
                if (instance == null) instance = new BidderServices();
                return instance;
            }
        }

        private static BidderServices instance { get; set; }

        private BidderServices()
        {
            _context = new AuctionTaskDbContext();
        }
        #endregion

        public bool AddBidders(List<Bidder> bidders)
        {
            _context.Bidders.AddRange(bidders);
            return _context.SaveChanges() > 0;
        }
    }
}
