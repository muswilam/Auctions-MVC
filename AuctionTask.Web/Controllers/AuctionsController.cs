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
    public class AuctionsController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new AuctionsViewModel();

            viewModel.Auctions = AuctionServices.Instance.GetAllAuctions();

            return View(viewModel);
        }

        [HttpPost]
        public JsonResult Save(NewAuctionViewModel auctionViewModel)
        {
            var json = new JsonResult();
            var newAuction = new Auction();

            newAuction.WinnerName = auctionViewModel.WinnerName;
            newAuction.ProductName = auctionViewModel.ProductName;
            newAuction.ProductActualPrice = auctionViewModel.ProductActualPrice;
            newAuction.WinnerPrice = auctionViewModel.WinnerPrice;

            var result = AuctionServices.Instance.SaveAuction(newAuction);

            if (result)
                json.Data = new { success = true };
            else
                json.Data = new { success = false, message = "Can't save auction" };

            return json;
        }
    }
}