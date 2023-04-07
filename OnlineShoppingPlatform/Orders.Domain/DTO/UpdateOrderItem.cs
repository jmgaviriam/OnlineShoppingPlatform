using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Domain.DTO
{
    public class UpdateOrderItem
    {
        public string OrderItemId { get; set; }

        public string OrderId { get; set; }

        public string ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
