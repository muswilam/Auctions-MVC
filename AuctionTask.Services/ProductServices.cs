using AuctionTask.Data;
using AuctionTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionTask.Services
{
    public class ProductServices
    {
        private readonly AuctionTaskDbContext _context;

        #region Singleton 
        public static ProductServices Instance
        {
            get
            {
                if (instance == null) instance = new ProductServices();
                return instance;
            }
        }

        private static ProductServices instance { get; set; }

        private ProductServices()
        {
            _context = new AuctionTaskDbContext();
        }
        #endregion

        public int AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product.Id;
        }
    }
}
