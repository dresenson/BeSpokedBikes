using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Style { get; set; }
        public decimal PurchasePrice { get; set; }
        //public decimal SalePrice { get; set; }
        public int QtyOnHand { get; set; }
        public float CommissionPercentage { get; set; }

        public ICollection<Discount> Discounts { get; set; }
        public ICollection<Sale> Sales { get; set; }

    }
}
