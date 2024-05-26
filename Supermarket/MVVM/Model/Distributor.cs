using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.MVVM.Model
{
    public class Distributor
    {
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string Name { get; set; }

        [MaxLength(50), Required]
        public string Country { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set; } // Use ICollection for better flexibility

        public Distributor()
        {
            IsActive = true;
            Products = new List<Product>(); // Initialize collection
        }
    }
}
