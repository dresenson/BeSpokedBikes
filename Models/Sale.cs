using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeSpokedBikes.Models
{
    public class Sale
    {
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Salesperson")]
        public int SalespersonId { get; set; }
        public Salesperson Salesperson { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal SalesPrice { get; set; }

    }
}
