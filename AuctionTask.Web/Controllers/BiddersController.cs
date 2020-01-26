using AuctionTask.Entities;
using AuctionTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionTask.Web.Controllers
{
    public class BiddersController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Add(int productId)
        {
            var json = new JsonResult();

            var newBidders = new List<Bidder>();

            var cookieData = Request.Cookies["Bidders"];

            if (cookieData != null && !string.IsNullOrEmpty(cookieData.Value))
            {
                var bidders = cookieData.Value.Split('-').ToList();

                foreach (var bidder in bidders)
                {
                    var bidderName = bidder.Replace("%20", " ");
                    newBidders.Add(new Bidder() { FullName = bidderName, ProductId = productId });
                }
            }

            var result = BidderServices.Instance.AddBidders(newBidders);

            if (result)
                json.Data = new { success = true };
            else
                json.Data = new { success = false, message = "Can't add bidders." };

            return json;
        }
    }
}