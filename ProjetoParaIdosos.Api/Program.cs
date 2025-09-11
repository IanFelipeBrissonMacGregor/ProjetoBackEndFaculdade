using Microsoft.EntityFrameworkCore;
using ProjetoBackEnd.Api.Data;
using ProjetoBackEnd.Api.Repositories;
using ProjetoBackEnd.Api.Repositories.Interfaces;
using ProjetoBackEnd.Api.Services;
using ProjetoBackEnd.Api.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// DbContext PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // precisa do pacote instalado!

// Dependency Injection
builder.Services.AddScoped<IElderlyRepository, ElderlyRepository>();
builder.Services.AddScoped<IElderlyService, ElderlyService>();

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
