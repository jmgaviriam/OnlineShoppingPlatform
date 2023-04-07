using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using Dapper;
using Orders.Domain.DTO;
using Orders.Domain.Entity;
using Orders.Infrastructure.Gateway;
using Orders.UseCase.Gateway.Repository;

namespace Orders.Infrastructure.Repository
{
    public class PaymentRepository : IPaymentRepository
    {

        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string nombreTabla = "Payments";
        private readonly IMapper _mapper;

        public PaymentRepository(IDbConnectionBuilder dbConnectionBuilder, IMapper mapper)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
            _mapper = mapper;
        }

        public async Task<CreatePayment> GetPaymentById(string id)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            Guard.Against.Null(connection, nameof(connection));
            var payment = await connection.QuerySingleOrDefaultAsync<Payment>(
                $"SELECT * FROM {nombreTabla} WHERE PaymentId = @Id",
                new { Id = id });
            Guard.Against.Null(payment, nameof(payment), $"No payment found with ID '{id}'");
            connection.Close();
            return _mapper.Map<CreatePayment>(payment);
        }

        public async Task<CreatePayment> CreatePayment(CreatePayment createPayment)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var payment = _mapper.Map<Payment>(createPayment);
            payment.IsCompleted = false;
            var result = await connection.ExecuteAsync(
                $"INSERT INTO {nombreTabla} (PaymentId, PaymentDate, Amount ,PaymentMethod,CardNumber, CardHolderName, CVV)" +
                   $"VALUES (NEWID(), @PaymentDate, @Amount, @PaymentMethod, @CardNumber, @CardHolderName, @CVV)",
                  new
                  {
                      payment.PaymentDate,
                      payment.Amount,
                      payment.PaymentMethod,
                      payment.CardNumber,
                      payment.CardHolderName,
                      payment.CVV
                  });
            connection.Close();
            return _mapper.Map<CreatePayment>(payment);
        }

        public async Task<CreatePayment> UpdatePayment(UpdatePayment updatePayment)
        {
            var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var payment = _mapper.Map<Payment>(updatePayment);
            var result = await connection.ExecuteAsync(
                $"UPDATE {nombreTabla} SET PaymentId = @PaymentId, PaymentDate = @PaymentDate, Amount = @Amount, PaymentMethod = @PaymentMethod, CardNumber = @CardNumber, CardHolderName = @CardHolderName, CVV = @CVV WHERE PaymentId = @PaymentId",
                new
                {
                    payment.PaymentId,
                    payment.PaymentDate,
                    payment.Amount,
                    payment.PaymentMethod,
                    payment.CardNumber,
                    payment.CardHolderName,
                    payment.CVV
                });
            connection.Close();
            return _mapper.Map<CreatePayment>(payment);
        }
    }
}
