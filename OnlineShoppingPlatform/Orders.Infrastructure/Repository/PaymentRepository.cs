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

            Guard.Against.Null(connection, nameof(connection));
            Guard.Against.Null(createPayment, nameof(createPayment));

            Guard.Against.NullOrEmpty(createPayment.CardHolderName, nameof(createPayment.CardHolderName));
            Guard.Against.NullOrEmpty(createPayment.PaymentMethod, nameof(createPayment.PaymentMethod));
            Guard.Against.OutOfRange(createPayment.PaymentDate, nameof(createPayment.PaymentDate), DateTime.Now, DateTime.Now.AddYears(1));
            Guard.Against.NegativeOrZero(createPayment.Amount, nameof(createPayment.Amount));
            Guard.Against.NullOrEmpty(createPayment.CardNumber, nameof(createPayment.CardNumber));
            Guard.Against.NullOrEmpty(createPayment.CVV, nameof(createPayment.CVV));


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

            Guard.Against.Null(connection, nameof(connection));
            Guard.Against.Null(updatePayment, nameof(updatePayment));

            Guard.Against.NullOrEmpty(updatePayment.CardHolderName, nameof(updatePayment.CardHolderName));
            Guard.Against.NullOrEmpty(updatePayment.PaymentMethod, nameof(updatePayment.PaymentMethod));
            Guard.Against.OutOfRange(updatePayment.PaymentDate, nameof(updatePayment.PaymentDate), DateTime.Now, DateTime.Now.AddYears(1));
            Guard.Against.NegativeOrZero(updatePayment.Amount, nameof(updatePayment.Amount));
            Guard.Against.NullOrEmpty(updatePayment.CardNumber, nameof(updatePayment.CardNumber));
            Guard.Against.NullOrEmpty(updatePayment.CVV, nameof(updatePayment.CVV));

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
