using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Entity
{
    public class Payment
    {
        [Key]
        public string PaymentId { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }

        public string CardNumber { get; set; }

        public string CardHolderName { get; set; }

        public string CVV { get; set; }

        // Métodos CRUD
    }
}
