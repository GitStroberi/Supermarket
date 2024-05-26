using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.MVVM.Model
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string Name { get; set; }

        [MaxLength(50), Required]
        public string Barcode { get; set; }

        // Foreign keys and navigation properties
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int DistributorId { get; set; }
        public Distributor Distributor { get; set; }

        public bool IsActive { get; set; }

        public Product()
        {
            IsActive = true;
        }
    }
}
