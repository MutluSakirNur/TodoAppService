using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TodoListApi.Application.Common.Interfaces;
using TodoListApi.Data;
using TodoListApi.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("TodoDb")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<ITodoContext>(provider => provider.GetService<TodoContext>());

builder.Services.AddTransient<IListTasksApiHelper, ListTasksApiHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var todoContext = scope.ServiceProvider.GetRequiredService<TodoContext>();
        todoContext.Database.EnsureCreated();
        todoContext.Seed();
    }
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*app.UseHttpsRedirection();*/

app.UseAuthorization();

app.MapControllers();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
});

app.Run();
