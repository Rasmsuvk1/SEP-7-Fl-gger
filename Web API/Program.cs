using Application.Idao;
using Application.Ilogic;
using Application.Logic;
using DataBaseAccess.DAOs;
using DataBaseAccess.DBContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));


//Adding Logic to scope
builder.Services.AddScoped<IProductLogic, ProductLogic>();
builder.Services.AddScoped<ICustomerLogic, CustomerLogic>();
builder.Services.AddScoped<IOrderLogic, OrderLogic>();
//Adding DAOS to scope
builder.Services.AddScoped<IProductDao, ProductDao>();
builder.Services.AddScoped<IOrderDao, OrderDao>();
builder.Services.AddScoped<ICustomerDao, CustomerDao>();


var app = builder.Build();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());

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