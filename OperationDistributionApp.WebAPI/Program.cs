using Hangfire;
using Microsoft.EntityFrameworkCore;
using OperationDistributionApp.Application.Interfaces;
using OperationDistributionApp.Application.Services;
using OperationDistributionApp.Domain.Entities;
using OperationDistributionApp.Infrastructure;
using OperationDistributionApp.Infrastructure.Abstracts;
using OperationDistributionApp.Infrastructure.Conctrete;
using OperationDistributionApp.Infrastructure.Configs;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

ConnectionConfig.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<OperationDistributionAppContext>(options =>
    options.UseSqlServer(ConnectionConfig.ConnectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(60))
);

// Ensure that all URLs generated and recognized by the routing system are lowercase.
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add services to the container.
// Configure the JSON serializer to use camel casing for property names.
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Hangfire configurations
builder.Services.AddHangfire(config => config.UseSqlServerStorage(ConnectionConfig.ConnectionString));
builder.Services.AddHangfireServer();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IOperationRepository, OperationRepository>();
builder.Services.AddScoped<IHistoryRepository, HistoryRepository>();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IOperationService, OperationService>();
builder.Services.AddScoped<IHistoryService, HistoryService>();
builder.Services.AddScoped<IDistributionService, DistributionService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "OpenCORS",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Hangfire middleware
app.UseHangfireDashboard();

app.MapControllers();

app.UseCors("OpenCORS");

RecurringJob.AddOrUpdate<IDistributionService>(service => service.AutomaticallyDeploy(), Cron.Daily);

app.Run();
