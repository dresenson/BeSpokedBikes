using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeSpokedBikes.Models;
using BeSpokedBikes.ViewModels;

namespace BeSpokedBikes.Repository
{
    public interface ISalespersonsRepository
    {
        Task<List<Salesperson>> GetSalespersonsAsync();
        Task<List<ViewSalesReport>> GetSalespersonsReportAsync();
        Task<Salesperson> GetSalespersonAsync(int id);

        Task<bool> UpdateSalespersonAsync(Salesperson salesperson);
    }
}
