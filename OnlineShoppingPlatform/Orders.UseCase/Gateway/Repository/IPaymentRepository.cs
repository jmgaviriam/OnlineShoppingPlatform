using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Domain.DTO;

namespace Orders.UseCase.Gateway.Repository
{
    public interface IPaymentRepository
    {
        Task<CreatePayment> GetPaymentById(string id);
        Task<CreatePayment> CreatePayment(CreatePayment createPayment);
        Task<CreatePayment> UpdatePayment(UpdatePayment updatePayment);
    }
}
