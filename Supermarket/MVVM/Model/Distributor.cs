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
        public int? id { get; set; }

        [MaxLength(50), Required]
        public string name { get; set; }
        [MaxLength(50), Required]
        public string country { get; set; }
        public bool is_active { get; set; }

        public Distributor()
        {
            is_active = true;
        }
    }
}
