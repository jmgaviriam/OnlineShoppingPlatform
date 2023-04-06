using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        }
    }
}
