using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Domain.DTO;
using Orders.UseCase.Gateway;
using Orders.UseCase.Gateway.Repository;

namespace Orders.UseCase.UseCase
{
    public class OrderItemUseCase : IOrderItemUseCase
    {

        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemUseCase(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<CreateOrderItem> GetOrderItemById(string id)
        {
            return await _orderItemRepository.GetOrderItemById(id);
        }

        public async Task<CreateOrderItem> CreateOrderItem(CreateOrderItem createOrderItem)
        {
            return await _orderItemRepository.CreateOrderItem(createOrderItem);
        }

        public async Task<CreateOrderItem> UpdateOrderItem(UpdateOrderItem updateOrderItem)
        {
            return await _orderItemRepository.UpdateOrderItem(updateOrderItem);
        }

        public async Task<CreateOrderItem> DeleteOrderItem(string id)
        {
            return await _orderItemRepository.DeleteOrderItem(id);
        }
    }
}
