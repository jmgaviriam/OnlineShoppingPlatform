using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Domain.DTO;

namespace Orders.UseCase.Gateway
{
    public interface IOrderUseCase
    {
        Task<CreateOrder> GetOrderById(string id);
        Task<CreateOrder> CreateOrder(CreateOrder createOrder);
        Task<CreateOrder> UpdateOrder(UpdateOrder updateOrder);

        Task<List<CreateOrder>> GetOrdersByUserId(string id);
        Task<string> UpdateOrderStatus(string id, string status);
    }
}
