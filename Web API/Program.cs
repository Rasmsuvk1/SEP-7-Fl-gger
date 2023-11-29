using Application.Idao;
using Application.Ilogic;
using Application.Logic;
using DataBaseAccess.DAOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*
builder.Services.AddScoped<DBContext>();

builder.Services.AddScoped<IUserDao, UserDao>();
builder.Services.AddScoped<IPostDao, PostDao>();
*/
builder.Services.AddScoped<IProductLogic, ProductLogic>();
builder.Services.AddScoped<IProductDao, ProductDao>();


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