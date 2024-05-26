using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.MVVM.Model
{
    public class Category
    {
        public int? id { get; set; }

        [MaxLength(50), Required]
        public string name { get; set; }
        public bool is_active { get; set; }

        public Category()
        {
            is_active = true;
        }
    }
}
