using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model
{
    public class ProductReceipt
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ReceiptId { get; set; }
        public Receipt Receipt { get; set; }

        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }

        public bool IsActive { get; set; }

        public ProductReceipt()
        {
            Quantity = 1;
            IsActive = true;
        }
    }
}
