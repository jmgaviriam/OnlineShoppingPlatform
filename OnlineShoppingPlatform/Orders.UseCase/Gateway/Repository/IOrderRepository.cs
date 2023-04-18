using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Domain.DTO;
using Orders.Domain.Entity;

namespace Orders.UseCase.Gateway.Repository
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderById(string id);
        Task<Order> CreateOrder(CreateOrder createOrder);
        Task<Order> UpdateOrder(UpdateOrder updateOrder);
        Task<List<Order>> GetOrdersByUserId(string id);
        Task<string> UpdateOrderStatus(string id, string status);
    }
}
