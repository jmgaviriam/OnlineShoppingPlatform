using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Domain.DTO;

namespace Orders.UseCase.Gateway
{
    public interface IOrderItemUseCase
    {
        Task<CreateOrderItem> GetOrderItemById(string id);
        Task<CreateOrderItem> CreateOrderItem(CreateOrderItem createOrderItem);
        Task<CreateOrderItem> UpdateOrderItem(UpdateOrderItem updateOrderItem);
        Task<CreateOrderItem> DeleteOrderItem(string id);
    }
}
