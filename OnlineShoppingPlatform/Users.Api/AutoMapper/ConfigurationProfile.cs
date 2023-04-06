using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders.Domain.Entity;
using Users.Domain.DTO;
using Users.Domain.Entity;
using Users.Infrastructure.Entity;

namespace Users.Api.AutoMapper
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<CreateUser, User>().ReverseMap();
            CreateMap<CreateUser, UserMongo>().ReverseMap();
            CreateMap<User, UserMongo>().ReverseMap();
            CreateMap<UpdateUser, UserMongo>().ReverseMap();


            CreateMap<CreateProduct, Product>().ReverseMap();
            CreateMap<CreateProduct, ProductMongo>().ReverseMap();
            CreateMap<Product, ProductMongo>().ReverseMap();
            CreateMap<UpdateProduct, ProductMongo>().ReverseMap();

            CreateMap<CreateStore, Store>().ReverseMap();
            CreateMap<CreateStore, StoreMongo>().ReverseMap();
            CreateMap<Store, StoreMongo>().ReverseMap();
            CreateMap<UpdateStore, StoreMongo>().ReverseMap();

        }
    }
}
