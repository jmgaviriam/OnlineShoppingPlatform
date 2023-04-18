using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Orders.Domain.DTO;
using Orders.Domain.Entity;
using Orders.UseCase.Gateway;

namespace Orders.Api.Controllers
{
    [EnableCors("AllowAllHeaders")]
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
        public async Task<OrderItem> GetOrderItemById(string id)
        {
            return await _orderItemUseCase.GetOrderItemById(id);
        }
        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        public async Task<OrderItem> CreateOrderItem(CreateOrderItem createOrderItem)
        {
            return await _orderItemUseCase.CreateOrderItem(createOrderItem);
        }

        [HttpPut]
        public async Task<OrderItem> UpdateOrderItem(UpdateOrderItem updateOrderItem)
        {
            return await _orderItemUseCase.UpdateOrderItem(updateOrderItem);
        }

        [HttpDelete]
        public async Task<OrderItem> DeleteOrderItem(string id)
        {
            return await _orderItemUseCase.DeleteOrderItem(id);
        }
    }
}
