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
    public class ProductsController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            var json = new JsonResult();
            var newwProduct = new Product();

            newwProduct.ProductName = productViewModel.ProductName;
            newwProduct.ActualPrice = productViewModel.ActualPrice;
            newwProduct.Bidders = new List<Bidder>();

            var productId = ProductServices.Instance.AddProduct(newwProduct);

            if (productId > 0)
                json.Data = new { success = true, id = productId };
            else
                json.Data = new { success = false, message = "Can't create procust." };

            return json;
        }
    }
}