using Microsoft.EntityFrameworkCore;
using TodoAPI.dbContext;
using TodoAPI.Services;
using TodoAPI.Services.Implementations;
using TodoAPI.Services.Interfaces.TodoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContextTodo>(dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["DB:ConnectionString"]));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ITodoItemService, TodoItemService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Agrega las rutas de los controladores al pipeline de solicitud HTTP
app.MapControllers();

app.Run();
