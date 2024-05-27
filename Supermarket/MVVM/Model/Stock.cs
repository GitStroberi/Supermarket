using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model
{
    public class Stock
    {
        public int Id { get; set; } // Primary key

        public int ProductId { get; set; }
        public Product Product { get; set; }  // Navigation property to Product

        public int Quantity { get; set; }
        public string UnitOfMeasurement { get; set; } // Consider using an enum for this if possible

        public DateTime SupplyDate { get; set; }
        public DateTime? ExpirationDate { get; set; } // Nullable for non-perishable items

        public decimal AcquisitionPrice { get; set; }
        public decimal SalePrice { get; set; }

        public bool IsActive { get; set; } = true; // Default to active

        public Stock()
        {
            SupplyDate = DateTime.Now;
            IsActive = true;
        }
    }
}
