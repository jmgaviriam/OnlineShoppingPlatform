using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Orders.Domain.DTO;
using Orders.UseCase.Gateway;

namespace Orders.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemUseCase _orderItemUseCase;
        private readonly IMapper _mapper;

        public OrderItemController(IOrderItemUseCase orderItemUseCase, IMapper mapper)
        {
            _orderItemUseCase = orderItemUseCase;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<CreateOrderItem> GetOrderItemById(string id)
        {
            return await _orderItemUseCase.GetOrderItemById(id);
        }

        [HttpPost]
        public async Task<CreateOrderItem> CreateOrderItem(CreateOrderItem createOrderItem)
        {
            return await _orderItemUseCase.CreateOrderItem(createOrderItem);
        }

        [HttpPut]
        public async Task<CreateOrderItem> UpdateOrderItem(UpdateOrderItem updateOrderItem)
        {
            return await _orderItemUseCase.UpdateOrderItem(updateOrderItem);
        }

        [HttpDelete]
        public async Task<CreateOrderItem> DeleteOrderItem(string id)
        {
            return await _orderItemUseCase.DeleteOrderItem(id);
        }
    }
}
