using BeSpokedBikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.Repository
{
    public interface ICustomersRepository
    {
        Task<List<Customer>> GetCustomersAsync();
        //Task<PagingResult<Customer>> GetCustomersPageAsync(int skip, int take);
        Task<Customer> GetCustomerAsync(int id);

        //Task<Customer> InsertCustomerAsync(Customer customer);
        //Task<bool> UpdateCustomerAsync(Customer customer);
        //Task<bool> DeleteCustomerAsync(int id);
    }
}
