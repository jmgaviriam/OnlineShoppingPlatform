﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders.Domain.DTO;
using Orders.UseCase.Gateway;
using Orders.UseCase.Gateway.Repository;

namespace Orders.UseCase.UseCase
{
    public class PaymentUseCase : IPaymentUseCase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentUseCase(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<CreatePayment> GetPaymentById(string id)
        {
            return await _paymentRepository.GetPaymentById(id);
        }

        public async Task<CreatePayment> CreatePayment(CreatePayment createPayment)
        {
            return await _paymentRepository.CreatePayment(createPayment);
        }

        public async Task<CreatePayment> UpdatePayment(UpdatePayment updatePayment)
        {
            return await _paymentRepository.UpdatePayment(updatePayment);
        }
    }
}
