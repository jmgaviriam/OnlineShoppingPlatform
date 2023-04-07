﻿using System;
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
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string tableName = "Orders";
        private readonly IMapper _mapper;

        public OrderRepository(IDbConnectionBuilder dbConnectionBuilder, IMapper mapper)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
            _mapper = mapper;
        }

        public async Task<CreateOrder> GetOrderById(string id)
        {
            using var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            Guard.Against.Null(connection, nameof(connection));
            var order = await connection.QuerySingleOrDefaultAsync<Order>(
                $"SELECT * FROM {tableName} WHERE OrderId = @Id AND IsDeleted = 0",
                new { Id = id });
            Guard.Against.Null(order, nameof(order), $"No order found with ID '{id}'");
            connection.Close();
            return _mapper.Map<CreateOrder>(order);
        }

        public async Task<CreateOrder> CreateOrder(CreateOrder createOrder)
        {
            using var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var order = _mapper.Map<Order>(createOrder);
            order.IsDeleted = false;
            var result = await connection.ExecuteAsync(
                $"INSERT INTO {tableName} (OrderId, UserId, PaymentId, OrderDate, ShippingDate, DeliveryDate, ShippingAddress, TotalAmount, Status, IsDeleted) " +
                $"VALUES (NEWID(), @UserId, @PaymentId, @OrderDate, @ShippingDate, @DeliveryDate, @ShippingAddress, @TotalAmount, @Status, @IsDeleted)",
                new
                {
                    order.UserId,
                    order.PaymentId,
                    order.OrderDate,
                    order.ShippingDate,
                    order.DeliveryDate,
                    order.ShippingAddress,
                    order.TotalAmount,
                    order.Status,
                    order.IsDeleted
                });
            connection.Close();
            return _mapper.Map<CreateOrder>(order);
        }

        public async Task<CreateOrder> UpdateOrder(UpdateOrder updateOrder)
        {
            using var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var order = _mapper.Map<Order>(updateOrder);

            var result = await connection.ExecuteAsync(
                $"UPDATE {tableName} " +
                "SET UserId = @UserId, PaymentId = @PaymentId, OrderDate = @OrderDate, ShippingDate = @ShippingDate, " +
                "DeliveryDate = @DeliveryDate, ShippingAddress = @ShippingAddress, TotalAmount = @TotalAmount, " +
                "Status = @Status, IsDeleted = @IsDeleted " +
                "WHERE OrderId = @OrderId",
                new
                {
                    order.UserId,
                    order.PaymentId,
                    order.OrderDate,
                    order.ShippingDate,
                    order.DeliveryDate,
                    order.ShippingAddress,
                    order.TotalAmount,
                    order.Status,
                    order.IsDeleted,
                    order.OrderId
                });
            connection.Close();
            return _mapper.Map<CreateOrder>(order);
        }

    }
}
