using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ExamerAPI.Data;
using ExamerAPI.Models;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ExamerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ExamerContext")));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddMvc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSession();

builder.Services.AddCors(p => p.AddPolicy("OpenPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSession();
app.UseCors("OpenPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
