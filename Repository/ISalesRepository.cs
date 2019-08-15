using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeSpokedBikes.Models;
using BeSpokedBikes.ViewModels;

namespace BeSpokedBikes.Repository
{
    public interface ISalesRepository
    {
        Task<List<ViewSale>> GetSalesAsync();
        //Task<PagingResult<Customer>> GetCustomersPageAsync(int skip, int take);
        Task<Sale> GetSaleAsync(int id);

        Task<Sale> InsertSaleAsync(Sale sale);
        //Task<bool> UpdateCustomerAsync(Customer customer);
        //Task<bool> DeleteCustomerAsync(int id);
    }
}
