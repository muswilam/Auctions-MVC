using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionTask.Web.ViewModels
{
    public class ProductViewModel
    {
        [StringLength(500)]
        [Required]
        public string ProductName { get; set; }

        [Required, Range(1, 1000000)]
        public decimal ActualPrice { get; set; }
    }
}