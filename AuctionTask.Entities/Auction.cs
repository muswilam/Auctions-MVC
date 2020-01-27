using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionTask.Entities
{
    public class Auction
    {
        public int Id { get; set; }

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
