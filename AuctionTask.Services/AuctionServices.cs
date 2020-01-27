using AuctionTask.Data;
using AuctionTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionTask.Services
{
    public class AuctionServices
    {
        private readonly AuctionTaskDbContext _context;

        #region Singleton 
        public static AuctionServices Instance
        {
            get
            {
                if (instance == null) instance = new AuctionServices();
                return instance;
            }
        }

        private static AuctionServices instance { get; set; }

        private AuctionServices()
        {
            _context = new AuctionTaskDbContext();
        }
        #endregion

        public List<Auction> GetAllAuctions()
        {
            return _context.Auctions.ToList();
        }

        public bool SaveAuction(Auction newAuction)
        {
            _context.Auctions.Add(newAuction);
            return _context.SaveChanges() > 0;
        }
    }
}
