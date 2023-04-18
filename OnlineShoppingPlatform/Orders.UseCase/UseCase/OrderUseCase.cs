using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Domain.DTO;
using Orders.Domain.Entity;
using Orders.UseCase.Gateway;
using Orders.UseCase.Gateway.Repository;

namespace Orders.UseCase.UseCase
{
    public class OrderUseCase : IOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> GetOrderById(string id)
        {
            return await _orderRepository.GetOrderById(id);
        }

        public async Task<Order> CreateOrder(CreateOrder createOrder)
        {
            return await _orderRepository.CreateOrder(createOrder);
        }

        public async Task<Order> UpdateOrder(UpdateOrder updateOrder)
        {
            return await _orderRepository.UpdateOrder(updateOrder);
        }

        public async Task<List<Order>> GetOrdersByUserId(string id)
        {
            return await _orderRepository.GetOrdersByUserId(id);
        }

        public async Task<string> UpdateOrderStatus(string id, string status)
        {
            return await _orderRepository.UpdateOrderStatus(id, status);
        }
    }
}
