using GoodReads.Application;
using GoodReads.Application.Commands.AddBook;
using GoodReads.Core.Repositories;
using GoodReads.Core.Services;
using GoodReads.Core.UnitOfWork;
using GoodReads.Infrastructure;
using GoodReads.Infrastructure.Repositories;
using GoodReads.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplication()
    .AddInfrastructure();

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
