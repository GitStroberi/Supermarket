using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.MVVM.Model
{
    public class User
    {
        public int? id { get; set; }

        [MaxLength(50), Required]
        public string username { get; set; }

        [MaxLength(50), Required]
        public string password { get; set; }

        public bool? is_admin { get; set; }

        public bool is_active { get; set; }

        public User()
        {
            is_active = true;
        }
    }
}
