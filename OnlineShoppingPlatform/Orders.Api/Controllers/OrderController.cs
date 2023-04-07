using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Orders.Domain.DTO;
using Orders.Domain.Entity;
using Orders.UseCase.Gateway;

namespace Orders.Api.Controllers
{
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
        public async Task<CreateOrder> GetOrderById(string id)
        {
            return await _orderUseCase.GetOrderById(id);
        }

        [HttpPost]
        public async Task<CreateOrder> CreateOrder(CreateOrder createOrder)
        {
            return await _orderUseCase.CreateOrder(createOrder);
        }

        [HttpPut]
        public async Task<CreateOrder> UpdateOrder(UpdateOrder updateOrder)
        {
            return await _orderUseCase.UpdateOrder(updateOrder);
        }

    }
}
