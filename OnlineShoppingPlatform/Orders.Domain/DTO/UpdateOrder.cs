using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.DTO
{
    public class UpdateOrder
    {
        public string OrderId { get; set; }

        public string UserId { get; set; }

        public string PaymentId { get; set; }

        public string OrderDate { get; set; }

        public string ShippingDate { get; set; }

        public string DeliveryDate { get; set; }

        public string ShippingAddress { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; }
    }
}
