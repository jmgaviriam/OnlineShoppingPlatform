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
    public class OrderController : Controller
    {
        private readonly IOrderUseCase _orderUseCase;
        private readonly IMapper _mapper;

        public OrderController(IOrderUseCase orderUseCase, IMapper mapper)
        {
            _orderUseCase = orderUseCase;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<Order> GetOrderById(string id)
        {
            return await _orderUseCase.GetOrderById(id);
        }

        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        public async Task<Order> CreateOrder(CreateOrder createOrder)
        {
            return await _orderUseCase.CreateOrder(createOrder);
        }

        [HttpPut]
        public async Task<Order> UpdateOrder(UpdateOrder updateOrder)
        {
            return await _orderUseCase.UpdateOrder(updateOrder);
        }

        [HttpGet("ordersbyuser/{id}")]
        public async Task<List<Order>> GetOrdersByUserId(string id)
        {
            return await _orderUseCase.GetOrdersByUserId(id);
        }

        [HttpPut("updateorderstatus/{id}")]
        public async Task<string> UpdateOrderStatus(string id, string status)
        {
            return await _orderUseCase.UpdateOrderStatus(id, status);
        }
    }
}

