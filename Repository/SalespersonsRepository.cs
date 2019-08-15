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
    public class SalespersonsRepository: ISalespersonsRepository
    {
        private readonly BikesDBContext _Context;
        private readonly ILogger _Logger;

        public SalespersonsRepository(BikesDBContext context, ILoggerFactory loggerFactory)
        {
            _Context = context;
            _Logger = loggerFactory.CreateLogger("SalespersonsRepository");
        }

        public async Task<List<Salesperson>> GetSalespersonsAsync()
        {
            return await _Context.Salespersons.OrderBy(c => c.LastName)
                                 .ToListAsync();
        }

        public async Task<List<ViewSalesReport>> GetSalespersonsReportAsync()
        {
            var sales = await _Context.Sales.OrderBy(c => c.SalesDate)
                               .Include("Product")
                               .Include("Salesperson")
                               .ToListAsync();
            if (sales.Count > 0)
            {
                List<ViewSalesReport> vsl = new List<ViewSalesReport>();
                foreach (var sale in sales)
                {
                    ViewSalesReport vs = new ViewSalesReport()
                    {
                        Salesperson = sale.Salesperson.FirstName + " " + sale.Salesperson.LastName,
                        CommissionDate = sale.SalesDate,
                        SalespersonCommission = sale.Product.CommissionPercentage * (float)sale.SalesPrice / 100
                    };
                    vsl.Add(vs);
                }
                return vsl;

            }
            return null;
        }


        public async Task<Salesperson> GetSalespersonAsync(int id)
        {
            return await _Context.Salespersons
                                 .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateSalespersonAsync(Salesperson salesperson)
        {
            //Will update all properties of the Customer
            _Context.Salespersons.Attach(salesperson);
            _Context.Entry(salesperson).State = EntityState.Modified;
            try
            {
                return (await _Context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _Logger.LogError($"Error in {nameof(UpdateSalespersonAsync)}: " + exp.Message);
            }
            return false;
        }
    }
}
