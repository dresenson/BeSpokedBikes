using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeSpokedBikes.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace BeSpokedBikes.Repository
{
    public class CustomersRepository: ICustomersRepository
    {
        private readonly BikesDBContext _Context;
        private readonly ILogger _Logger;

        public CustomersRepository(BikesDBContext context, ILoggerFactory loggerFactory)
        {
            _Context = context;
            _Logger = loggerFactory.CreateLogger("CustomersRepository");
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _Context.Customers.OrderBy(c => c.LastName)
                                 .ToListAsync();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _Context.Customers
                                 .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            //Will update all properties of the Customer
            _Context.Customers.Attach(customer);
            _Context.Entry(customer).State = EntityState.Modified;
            try
            {
                return (await _Context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _Logger.LogError($"Error in {nameof(UpdateCustomerAsync)}: " + exp.Message);
            }
            return false;
        }
    }
}
