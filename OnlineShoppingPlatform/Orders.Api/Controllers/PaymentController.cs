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
        public async Task<Payment> GetPaymentById(string id)
        {
            return await _paymentUseCase.GetPaymentById(id).ConfigureAwait(false);
        }

        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        public async Task<Payment> CreatePayment(CreatePayment createPayment)
        {
            return await _paymentUseCase.CreatePayment(createPayment);
        }

        [HttpPut]
        public async Task<Payment> UpdatePayment(UpdatePayment updatePayment)
        {
            return await _paymentUseCase.UpdatePayment(updatePayment);
        }
    }
}
