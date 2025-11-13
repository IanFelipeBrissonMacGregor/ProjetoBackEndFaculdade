using Microsoft.EntityFrameworkCore;
using ProjetoBackEnd.Api.Data;
using ProjetoBackEnd.Api.Repositories;
using ProjetoBackEnd.Api.Repositories.Interfaces;
using ProjetoBackEnd.Api.Services;
using ProjetoBackEnd.Api.Services.Interfaces;
using ProjetoBackEnd.Api.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// PostgreSQL connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<IPartnerRepository, PartnerRepository>();
builder.Services.AddScoped<IDependentRepository, DependentRepository>();
builder.Services.AddScoped<IVisitRepository, VisitRepository>();

// Services
builder.Services.AddScoped<IPartnerService, PartnerService>();
builder.Services.AddScoped<IDependentService, DependentService>();
builder.Services.AddScoped<IVisitService, VisitService>();

builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IPlanService, PlanService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware global de exceções
app.UseMiddleware<ApiExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();