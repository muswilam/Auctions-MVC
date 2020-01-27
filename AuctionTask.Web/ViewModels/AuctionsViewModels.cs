using AuctionTask.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionTask.Web.ViewModels
{
    public class AuctionsViewModel
    {
        public List<Auction> Auctions { get; set; }
    }

    public class NewAuctionViewModel
    {
        [Required]
        [StringLength(255)]
        public string WinnerName { get; set; }

        [Required]
        [StringLength(500)]
        public string ProductName { get; set; }

        public decimal ProductActualPrice { get; set; }
        public decimal WinnerPrice { get; set; }
    }
}