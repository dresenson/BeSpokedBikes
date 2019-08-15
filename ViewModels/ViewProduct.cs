using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.ViewModels
{
    public class ViewProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Style { get; set; }
        public decimal PurchasePrice { get; set; }
        public int Discount { get; set; }
        public decimal SalePrice { get; set; }
        public int QtyOnHand { get; set; }
        public float CommissionPercentage { get; set; }
    }
}
