using Users.Api.AutoMapper;
using AutoMapper.Data;
using Users.Api.Middlewares;
using Users.Infrastructure;
using Users.Infrastructure.Interface;
using Users.Infrastructure.Repository;
using Users.UseCase.Gateway;
using Users.UseCase.Gateway.Repository;
using Users.UseCase.UseCase;

var builder = WebApplication.CreateBuilder(args);

var MyAllowsSpecificOrigins = "_myAllowsSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowsSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                .SetIsOriginAllowedToAllowWildcardSubdomains();
        });
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllHeaders",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(ConfigurationProfile));
builder.Services.AddSingleton<IContext>(provider =>
    new Context(builder.Configuration.GetConnectionString("DefaultConnection"), "OnlineShoppingPlatform"));

builder.Services.AddScoped<IUserUseCase, UserUseCase>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IProductUseCase, ProductUseCase>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IStoreUseCase, StoreUseCase>();
builder.Services.AddScoped<IStoreRepository, StoreRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowsSpecificOrigins);
app.UseCors("AllowAllHeaders");

app.UseHttpsRedirection();

app.UseAuthorization();


app.UseMiddleware<ErrorHandleMiddleware>();

app.MapControllers();


app.Run();