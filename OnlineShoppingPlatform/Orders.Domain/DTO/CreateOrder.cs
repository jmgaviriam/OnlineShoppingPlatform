using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.DTO
{
    public class CreateOrder
    {
        public string UserId { get; set; }

        public string PaymentId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ShippingDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string ShippingAddress { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; }
    }
}
