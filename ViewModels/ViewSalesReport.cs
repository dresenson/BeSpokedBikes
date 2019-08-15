using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.ViewModels
{
    public class ViewSalesReport
    {
        public string Salesperson { get; set; }
        public float SalespersonCommission { get; set; }
        public DateTime CommissionDate { get; set; }
    }
}
