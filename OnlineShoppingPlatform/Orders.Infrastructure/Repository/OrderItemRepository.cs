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
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly IDbConnectionBuilder _dbConnectionBuilder;
        private readonly string tableName = "OrderItems";
        private readonly IMapper _mapper;

        public OrderItemRepository(IDbConnectionBuilder dbConnectionBuilder, IMapper mapper)
        {
            _dbConnectionBuilder = dbConnectionBuilder;
            _mapper = mapper;
        }

        public async Task<OrderItem> GetOrderItemById(string id)
        {
            using var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var orderItem = await connection.QueryFirstOrDefaultAsync<CreateOrderItem>(
                $"SELECT * FROM {tableName} WHERE OrderItemId = @Id AND IsDeleted = 0", new { Id = id });
            Guard.Against.Null(orderItem, nameof(orderItem), $"No order item found with ID '{id}'");
            connection.Close();
            return _mapper.Map<OrderItem>(orderItem);
        }

        public async Task<OrderItem> CreateOrderItem(CreateOrderItem createOrderItem)
        {
            using var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var orderItem = _mapper.Map<OrderItem>(createOrderItem);
            orderItem.IsDeleted = false;

            Guard.Against.NullOrEmpty(orderItem.ProductId, nameof(orderItem.ProductId));
            Guard.Against.NegativeOrZero(orderItem.Quantity, nameof(orderItem.Quantity));
            Guard.Against.NegativeOrZero((double)orderItem.Price, nameof(orderItem.Price));
            orderItem.OrderItemId = Guid.NewGuid().ToString();
            var result = await connection.ExecuteAsync(
                $"INSERT INTO {tableName} (OrderItemId, OrderId, ProductId, Quantity, Price, IsDeleted) " +
                $"VALUES (@OrderItemId, @OrderId, @ProductId, @Quantity, @Price, @IsDeleted)",
                new
                {
                    orderItem.OrderItemId,
                    orderItem.OrderId,
                    orderItem.ProductId,
                    orderItem.Quantity,
                    orderItem.Price,
                    orderItem.IsDeleted
                });
            connection.Close();
            return orderItem;
        }

        public async Task<OrderItem> UpdateOrderItem(UpdateOrderItem updateOrderItem)
        {
            using var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var orderItem = _mapper.Map<OrderItem>(updateOrderItem);
            orderItem.IsDeleted = false;

            Guard.Against.NullOrEmpty(orderItem.OrderId, nameof(orderItem.OrderId));
            Guard.Against.NullOrEmpty(orderItem.ProductId, nameof(orderItem.ProductId));
            Guard.Against.NegativeOrZero(orderItem.Quantity, nameof(orderItem.Quantity));
            Guard.Against.NegativeOrZero((double)orderItem.Price, nameof(orderItem.Price));


            var result = await connection.ExecuteAsync(
                $"UPDATE {tableName} SET OrderId = @OrderId, ProductId = @ProductId, Quantity = @Quantity, Price = @Price, IsDeleted = @IsDeleted " +
                $"WHERE OrderItemId = @OrderItemId",
                new
                {
                    orderItem.OrderId,
                    orderItem.ProductId,
                    orderItem.Quantity,
                    orderItem.Price,
                    orderItem.IsDeleted,
                    orderItem.OrderItemId
                });
            connection.Close();
            return _mapper.Map<OrderItem>(orderItem);
        }

        public async Task<OrderItem> DeleteOrderItem(string id)
        {
            using var connection = await _dbConnectionBuilder.CreateConnectionAsync();
            var orderItem = await connection.QueryFirstOrDefaultAsync<OrderItem>(
                $"SELECT * FROM {tableName} WHERE OrderItemId = @Id AND IsDeleted = 0", new { Id = id });
            Guard.Against.Null(orderItem, nameof(orderItem), $"No order item found with ID '{id}'");

            orderItem.IsDeleted = true;
            var result = await connection.ExecuteAsync(
                $"UPDATE {tableName} SET IsDeleted = @IsDeleted WHERE OrderItemId = @OrderItemId",
                new
                {
                    orderItem.IsDeleted,
                    orderItem.OrderItemId
                });
            connection.Close();
            return _mapper.Map<OrderItem>(orderItem);
        }

    }
}


