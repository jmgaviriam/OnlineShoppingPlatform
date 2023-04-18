using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Domain.DTO;
using Orders.Domain.Entity;

namespace Orders.UseCase.Gateway
{
    public interface IOrderItemUseCase
    {
        Task<OrderItem> GetOrderItemById(string id);
        Task<OrderItem> CreateOrderItem(CreateOrderItem createOrderItem);
        Task<OrderItem> UpdateOrderItem(UpdateOrderItem updateOrderItem);
        Task<OrderItem> DeleteOrderItem(string id);
    }
}
