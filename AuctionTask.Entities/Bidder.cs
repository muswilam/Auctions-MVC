using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionTask.Entities
{
    public class Bidder
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FullName { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public List<Bid> Bids { get; set; }
    }
}
