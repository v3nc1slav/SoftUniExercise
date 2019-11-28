using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_SalesDatabase.Data.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MaxLength(80)]
        [Required]
        public string Email { get; set; }

        
        [Required]
        public string CreditCardNumber { get; set; }

        public int SalesId { get; set; }

        public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();

    }
}
