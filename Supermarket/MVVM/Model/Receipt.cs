using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model
{
    public class Receipt
    {
        public int Id { get; set; }

        public DateTime ReleaseDate { get; set; } = DateTime.Now; // Default to current time

        public int CashierId { get; set; }
        public User Cashier { get; set; }  // Navigation property to User

        public decimal Value { get; set; } // Total value of the receipt

        public ICollection<ProductReceipt> ProductReceipts { get; set; } // Many-to-many relationship

        public bool IsActive { get; set; }

        public Receipt()
        {
            IsActive = true;
            ProductReceipts = new List<ProductReceipt>();
        }
    }
}
