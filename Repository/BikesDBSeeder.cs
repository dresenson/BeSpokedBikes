using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeSpokedBikes.Models;

namespace BeSpokedBikes.Repository
{
    public class BikesDBSeeder
    {
        readonly ILogger _Logger;

        public BikesDBSeeder(ILoggerFactory loggerFactory)
        {
            _Logger = loggerFactory.CreateLogger("BikesDbSeederLogger");
        }

        public async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var bikesDb = serviceScope.ServiceProvider.GetService<BikesDBContext>();
                if (await bikesDb.Database.EnsureCreatedAsync())
                {
                    if (!await bikesDb.Customers.AnyAsync())
                    {
                        await InsertCustomersSampleData(bikesDb);
                    }
                }
            }
        }

        public async Task InsertCustomersSampleData(BikesDBContext db)
        {
            var customers = GetCustomers();
            db.Customers.AddRange(customers);

            try
            {
                int numAffected = await db.SaveChangesAsync();
                _Logger.LogInformation($"Saved {numAffected} customers");
            }
            catch (Exception exp)
            {
                _Logger.LogError($"Error in {nameof(BikesDBSeeder)}: " + exp.Message);
                throw;
            }

            var products = GetProducts();
            db.Products.AddRange(products);

            try
            {
                int numAffected = await db.SaveChangesAsync();
                _Logger.LogInformation($"Saved {numAffected} products");
            }
            catch (Exception exp)
            {
                _Logger.LogError($"Error in {nameof(BikesDBSeeder)}: " + exp.Message);
                throw;
            }

            var salePersons = GetSalePersons();
            db.Salespersons.AddRange(salePersons);

            try
            {
                int numAffected = await db.SaveChangesAsync();
                _Logger.LogInformation($"Saved {numAffected} SalePersons");
            }
            catch (Exception exp)
            {
                _Logger.LogError($"Error in {nameof(BikesDBSeeder)}: " + exp.Message);
                throw;
            }

            var discounts = GetDiscounts();
            db.Discounts.AddRange(discounts);

            try
            {
                int numAffected = await db.SaveChangesAsync();
                _Logger.LogInformation($"Saved {numAffected} Discount");
            }
            catch (Exception exp)
            {
                _Logger.LogError($"Error in {nameof(BikesDBSeeder)}: " + exp.Message);
                throw;
            }

            var sales = GetSales();
            db.Sales.AddRange(sales);

            try
            {
                int numAffected = await db.SaveChangesAsync();
                _Logger.LogInformation($"Saved {numAffected} Sale");
            }
            catch (Exception exp)
            {
                _Logger.LogError($"Error in {nameof(BikesDBSeeder)}: " + exp.Message);
                throw;
            }
        }

        private List<Customer> GetCustomers()
        {
            //Customers
            List<Customer> customers = new List<Customer>() {
                new Customer(){ FirstName="Ian", LastName="Gillan", Address="1976 Deep Purple Str", Phone="(770)-4555-231", StartDate= DateTime.ParseExact("01/01/2016", "dd/MM/yyyy", null)},
                new Customer(){ FirstName="Steven", LastName="Tyler", Address="13 Aerosmith Str", Phone="(678)-4555-654", StartDate= DateTime.ParseExact("01/01/2017", "dd/MM/yyyy", null)},
                new Customer(){ FirstName="Robert", LastName="Plant", Address="1968 Led Zeppelin Ave", Phone="(404)-4555-121", StartDate= DateTime.ParseExact("01/01/2018", "dd/MM/yyyy", null)}
            };

            return customers;
        }

        private List<Product> GetProducts()
        {
            //Products
            List<Product> products = new List<Product>() {
                new Product(){ Name="Touring Bike", Manufacturer="Nike", Style="Touring", PurchasePrice=200.00m, QtyOnHand=5, CommissionPercentage=15},
                new Product(){ Name="Racing Bike", Manufacturer="Shwin", Style="Racing", PurchasePrice=300.00m, QtyOnHand=2, CommissionPercentage=20},
                new Product(){ Name="Flying Bike", Manufacturer="Dima", Style="Flying", PurchasePrice=1200.00m, QtyOnHand=1, CommissionPercentage=25}
            };

            return products;
        }

        private List<Salesperson> GetSalePersons()
        {
            //Salespersons
            List<Salesperson> salesperson = new List<Salesperson>() {
                new Salesperson(){ FirstName="John", LastName="Lenon", Address="123 Main Str", Phone="(123)-1231-231", StartDate= DateTime.ParseExact("01/01/2015", "dd/MM/yyyy", null),
                TerminationDate= DateTime.ParseExact("02/01/2020", "dd/MM/yyyy", null), Manager="Me"},
                new Salesperson(){ FirstName="Angus", LastName="Young", Address="123 Sub Str", Phone="(321)-5685-453", StartDate= DateTime.ParseExact("01/01/2016", "dd/MM/yyyy", null),
                TerminationDate= DateTime.ParseExact("06/01/2019", "dd/MM/yyyy", null), Manager="Me"}
            };

            return salesperson;
        }

        private List<Discount> GetDiscounts()
        {
            //Salespersons
            List<Discount> discounts = new List<Discount>() {
                new Discount(){ProductId=1, BeginDate= DateTime.ParseExact("01/01/2019", "dd/MM/yyyy", null),
                EndDate= DateTime.ParseExact("12/01/2019", "dd/MM/yyyy", null), DiscountPercentage=15},
                new Discount(){ProductId=2, BeginDate= DateTime.ParseExact("01/01/2018", "dd/MM/yyyy", null),
                EndDate= DateTime.ParseExact("12/01/2019", "dd/MM/yyyy", null), DiscountPercentage=10}
            };

            return discounts;
        }

        private List<Sale> GetSales()
        {
            //Salespersons
            List<Sale> sales = new List<Sale>() {
                new Sale(){ProductId=1, CustomerId=1, SalespersonId =1, SalesPrice=170.00m, SalesDate= DateTime.ParseExact("01/01/2019", "dd/MM/yyyy", null)},
                new Sale(){ProductId=2, CustomerId=2, SalespersonId =1, SalesPrice=270.00m, SalesDate= DateTime.ParseExact("02/01/2019", "dd/MM/yyyy", null)},
                new Sale(){ProductId=3, CustomerId=3, SalespersonId =2, SalesPrice=1200.00m, SalesDate= DateTime.ParseExact("03/01/2019", "dd/MM/yyyy", null)}
            };
            return sales;
        }
    }
}
