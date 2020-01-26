using AuctionTask.Entities;
using AuctionTask.Services;
using AuctionTask.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionTask.Web.Controllers
{
    public class BidsController : Controller
    {
        public ActionResult Index(int productId)
        {
            var bidViewModel = new BidViewModel();
       
            bidViewModel.Product = ProductServices.Instance.GetProduct(productId);

            bidViewModel.ProductBidders = bidViewModel.Product.Bidders;

            bidViewModel.Bids = BidServices.Instance.GetBids(productId);

            return View(bidViewModel);
        }

        public PartialViewResult Listing(int productId)
        {
            var listBides = new ListBidsViewModel();

            listBides.Product = ProductServices.Instance.GetProduct(productId);

            listBides.Bids = BidServices.Instance.GetBids(productId);

            return PartialView("_Listing", listBides);
        }

        [HttpPost]
        public JsonResult Bid(NewBidViewModel bidViewModel)
        {
            var json = new JsonResult();
            var newBid = new Bid();

            newBid.ProductId = bidViewModel.ProductId;
            newBid.BidderId = bidViewModel.BidderId;
            newBid.BidAmount = bidViewModel.BidAmount;

            var lastBidAmount = BidServices.Instance.GetTotalLastBidAmount(bidViewModel.ProductId);
            if (lastBidAmount > 0)
                newBid.TotalLastBidAmount = lastBidAmount + bidViewModel.BidAmount;
            else
                newBid.TotalLastBidAmount = bidViewModel.BidAmount + bidViewModel.ActualAmount;

            var result = BidServices.Instance.AddBid(newBid);

            if (result)
                json.Data = new { success = true };
            else
                json.Data = new { success = false, message = "Can't add bid!" };

            return json;
        }
    }
}