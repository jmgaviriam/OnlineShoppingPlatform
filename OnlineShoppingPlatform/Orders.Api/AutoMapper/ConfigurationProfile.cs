using AutoMapper;
using Orders.Domain.DTO;
using Orders.Domain.Entity;

namespace Users.Api.AutoMapper
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<Order, CreateOrder>().ReverseMap();
            CreateMap<Order, UpdateOrder>().ReverseMap();

            CreateMap<OrderItem, CreateOrderItem>().ReverseMap();
            CreateMap<OrderItem, UpdateOrderItem>().ReverseMap();

            CreateMap<Payment, CreatePayment>().ReverseMap();
            CreateMap<Payment, UpdatePayment>().ReverseMap();

        }
    }
}
