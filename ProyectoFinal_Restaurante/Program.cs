using Microsoft.EntityFrameworkCore;
using ProyectoFinal_Restaurante.Data;
using ProyectoFinal_Restaurante.Repositories.Implementations;
using ProyectoFinal_Restaurante.Repositories.Interfaces;
using ProyectoFinal_Restaurante.Services.Implementations;
using ProyectoFinal_Restaurante.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped <IProductRepository, ProductRepository>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<ICategoryService,  CategoryService>();

builder.Services.AddDbContext < ProyectoFinal_RestauranteContext> (dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:ProyectoFinal_RestauranteDBConnectionString"]));

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
