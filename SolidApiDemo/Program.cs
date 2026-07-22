using SolidApiDemo.Interfaces;
using SolidApiDemo.Repository;
using SolidApiDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository, OrderRepository>();

builder.Services.AddScoped<IMessageService, EmailService>();

builder.Services.AddScoped<IDiscount, PremiumDiscount>();

builder.Services.AddScoped<OrderService>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.Run();