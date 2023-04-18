using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Domain.DTO;
using Orders.Domain.Entity;

namespace Orders.UseCase.Gateway.Repository
{
    public interface IPaymentRepository
    {
        Task<Payment> GetPaymentById(string id);
        Task<Payment> CreatePayment(CreatePayment createPayment);
        Task<Payment> UpdatePayment(UpdatePayment updatePayment);
    }
}
