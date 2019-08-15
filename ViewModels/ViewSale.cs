using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.ViewModels
{
    public class ViewSale
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SalePrice { get; set; }
        public string Salesperson { get; set; }
        public float SalespersonCommission { get; set; }
    }
}
