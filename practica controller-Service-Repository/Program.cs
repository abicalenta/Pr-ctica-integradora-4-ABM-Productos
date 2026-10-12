using Microsoft.EntityFrameworkCore;
using practica_controller_Service_Repository.Data;
using practica_controller_Service_Repository.Repositories.Implementations;
using practica_controller_Service_Repository.Repositories.Interfaces;
using practica_controller_Service_Repository.Services.Implementations;
using practica_controller_Service_Repository.Services.Interfaces;
using TuProyecto.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de Inyección de Dependencias
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();