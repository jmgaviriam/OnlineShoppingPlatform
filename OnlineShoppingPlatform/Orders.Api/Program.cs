using AutoMapper.Data;
using Orders.Infrastructure;
using Orders.Infrastructure.Gateway;
using Orders.Infrastructure.Repository;
using Orders.UseCase.Gateway;
using Orders.UseCase.Gateway.Repository;
using Orders.UseCase.UseCase;
using Users.Api.AutoMapper;
using Users.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(ConfigurationProfile));

builder.Services.AddScoped<IOrderUseCase, OrderUseCase>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IPaymentUseCase, PaymentUseCase>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddScoped<IOrderItemUseCase, OrderItemUseCase>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();

builder.Services.AddTransient<IDbConnectionBuilder>(e =>
{
    return new DbConnectionBuilder(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorHandleMiddleware>();

app.MapControllers();

app.Run();