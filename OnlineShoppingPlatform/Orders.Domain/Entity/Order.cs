using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.Entity
{
    public class Order
    {
        [Key]
        public string OrderId { get; set; }

        public string UserId { get; set; }

        public string PaymentId { get; set; }

        public string OrderDate { get; set; }

        public string ShippingDate { get; set; }

        public string DeliveryDate { get; set; }

        public string ShippingAddress { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Métodos CRUD
    }
}
