using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AuctionTask.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(500)]
        [Required]
        public string ProductName { get; set; }

        [Required, Range(1, 1000000)]
        public decimal ActualPrice { get; set; }
    }
}
