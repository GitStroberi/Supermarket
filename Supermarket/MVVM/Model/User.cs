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
        public int Id { get; set; } // Primary key, no need for nullable int

        [MaxLength(50), Required]
        public string Username { get; set; }

        [MaxLength(50), Required]
        public string Password { get; set; }

        public bool IsAdmin { get; set; } // Non-nullable bool

        public ICollection<Receipt> Receipts { get; set; }

        public bool IsActive { get; set; } // Default to true in constructor

        public User()
        {
            IsActive = true;
            Receipts = new List<Receipt>();
        }
    }
}
