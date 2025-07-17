
using Microsoft.EntityFrameworkCore;
using P0_ClassLibrary;
using P0_ClassLibrary.Interfaces;
using P5_WebApi.Data;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("cloud")));

builder.Services.AddSingleton<ICalculatorService , CalculatorService>();
// builder.Services.AddSingleton<ICloudinaryService , CloudinaryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();



app.Run();

