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
    public class SalesRepository: ISalesRepository
    {
        private readonly BikesDBContext _Context;
        private readonly ILogger _Logger;

        public SalesRepository(BikesDBContext context, ILoggerFactory loggerFactory)
        {
            _Context = context;
            _Logger = loggerFactory.CreateLogger("SalesRepository");
        }

        public async Task<List<ViewSale>> GetSalesAsync()
        {
            var sales =  await _Context.Sales.OrderBy(c => c.SalesDate)
                                .Include("Product")
                                .Include("Salesperson")
                                .Include("Customer")
                                .ToListAsync();
            if (sales.Count > 0)
            {
                List<ViewSale> vsl = new List<ViewSale>();
                foreach (var sale in sales)
                {
                    ViewSale vs = new ViewSale()
                    {
                        Id = sale.Id,
                        CustomerName = sale.Customer.FirstName +" " + sale.Customer.LastName,
                        ProductName = sale.Product.Name + " by " + sale.Product.Manufacturer,
                        SaleDate = sale.SalesDate,
                        SalePrice = sale.SalesPrice,
                        Salesperson = sale.Salesperson.FirstName + " " + sale.Salesperson.LastName,
                        SalespersonCommission = sale.Product.CommissionPercentage
                    };
                    vsl.Add(vs);
                }
                return vsl;

            }
            return null;
        }

        public async Task<Sale> GetSaleAsync(int id)
        {
            return await _Context.Sales
                                 .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Sale> InsertSaleAsync(Sale sale)
        {
            _Context.Add(sale);
            try
            {
                await _Context.SaveChangesAsync();
            }
            catch (System.Exception exp)
            {
                _Logger.LogError($"Error in {nameof(InsertSaleAsync)}: " + exp.Message);
            }

            return sale;
        }
    }
}
