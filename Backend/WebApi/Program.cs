using Application.Ports;
using Application.UseCases.Customers;
using Application.UseCases.Customers.Interfaces;
using Application.UseCases.EventLogs;
using Application.UseCases.EventLogs.Interfaces;
using Microsoft.EntityFrameworkCore;
using ReporitorySqlServer.Context;
using ReporitorySqlServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Conexion Bd
builder.Services.AddDbContext<EntityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDb")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGetCustomersUseCase, GetCustomersUseCase>();
builder.Services.AddScoped<IGetCustomerByIdUseCase, GetCustomerByIdUseCase>();
builder.Services.AddScoped<IAddCustomerUseCase, AddCustomerUseCase>();
builder.Services.AddScoped<IUpdateCustomerUseCase, UpdateCustomerUseCase>();
builder.Services.AddScoped<IGetEventLogsUseCase, GetEventLogsUseCase>();
builder.Services.AddScoped<IGetEventLogByIdUseCase, GetEventLogByIdUseCase>();
builder.Services.AddScoped<IAddEventLogUseCase, AddEventLogUseCase>();
builder.Services.AddScoped<IUpdateEventLogUseCase, UpdateEventLogUseCase>();

builder.Services.AddScoped<ICustomersRepositorySqlServerPort, CustomersRepository>();
builder.Services.AddScoped<IEventLogsRepositorySqlServerPort, EventLogsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
