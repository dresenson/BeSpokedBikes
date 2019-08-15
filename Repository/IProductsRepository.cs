using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeSpokedBikes.Models;
using BeSpokedBikes.ViewModels;

namespace BeSpokedBikes.Repository
{
    public interface IProductsRepository
    {
        Task<List<ViewProduct>> GetProductsAsync();
        Task<Product> GetProductAsync(int id);

        Task<bool> UpdateProductAsync(Product product);
    }
}
