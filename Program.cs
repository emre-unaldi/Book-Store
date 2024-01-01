using BookStore.DBOperations;
using BookStore.Middlewares;
using BookStore.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// In Memory Db Context
builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseInMemoryDatabase(databaseName: "BookStoreDB"));

// Add AutoMapper configuration
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Add this line to register controllers
builder.Services.AddControllers();

// Logger
builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// In Memory Initialize Data
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    DataGenerator.Initialize(serviceProvider);
}


//app.UseCustomExceptionMiddleware();
//app.UseExceptionHandlingMiddleware();

// Use this instead of app.MapGet
app.MapControllers();

app.Run();