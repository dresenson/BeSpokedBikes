using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeSpokedBikes.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BeSpokedBikes.ViewModels;

namespace BeSpokedBikes.Repository
{
    public class ProductsRepository: IProductsRepository
    {
        private readonly BikesDBContext _Context;
        private readonly ILogger _Logger;

        public ProductsRepository(BikesDBContext context, ILoggerFactory loggerFactory)
        {
            _Context = context;
            _Logger = loggerFactory.CreateLogger("ProductsRepository");
        }

        public async Task<List<ViewProduct>> GetProductsAsync()
        {
            var products = await _Context.Products.OrderBy(c => c.Name).
                                  Include("Discounts")
                                 .ToListAsync();

            if (products.Count > 0)
            {
                List<ViewProduct> vpl = new List<ViewProduct>();
                DateTime now = DateTime.Today;
                foreach (var product in products)
                {
                    var discount = product.Discounts.SingleOrDefault();
                    ViewProduct vp = new ViewProduct()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Manufacturer = product.Manufacturer,
                        Style = product.Style,
                        PurchasePrice = product.PurchasePrice,
                        Discount = 0,
                        SalePrice = product.PurchasePrice,
                        QtyOnHand = product.QtyOnHand,
                        CommissionPercentage = product.CommissionPercentage
                    };
                    if (discount != null && (discount.BeginDate < now && discount.EndDate > now))
                    {
                        var disc = vp.PurchasePrice * discount.DiscountPercentage / 100;
                        vp.SalePrice = vp.PurchasePrice - disc;
                        vp.Discount = discount.DiscountPercentage;
                    }
                    vpl.Add(vp);
                }
                return vpl;
            }
            return null;
        }
            
        public async Task<Product> GetProductAsync(int id)
        {
            return await _Context.Products
                                 .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            //Will update all properties of the Customer
            _Context.Products.Attach(product);
            _Context.Entry(product).State = EntityState.Modified;
            try
            {
                return (await _Context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _Logger.LogError($"Error in {nameof(UpdateProductAsync)}: " + exp.Message);
            }
            return false;
        }
    }
}
