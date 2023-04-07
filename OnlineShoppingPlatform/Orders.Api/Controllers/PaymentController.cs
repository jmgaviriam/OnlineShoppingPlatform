using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Orders.Domain.DTO;
using Orders.UseCase.Gateway;

namespace Orders.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IPaymentUseCase _paymentUseCase;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentUseCase paymentUseCase, IMapper mapper)
        {
            _paymentUseCase = paymentUseCase;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<CreatePayment> GetPaymentById(string id)
        {
            return await _paymentUseCase.GetPaymentById(id);
        }

        [HttpPost]
        public async Task<CreatePayment> CreatePayment(CreatePayment createPayment)
        {
            return await _paymentUseCase.CreatePayment(createPayment);
        }

        [HttpPut]
        public async Task<CreatePayment> UpdatePayment(UpdatePayment updatePayment)
        {
            return await _paymentUseCase.UpdatePayment(updatePayment);
        }
    }
}
