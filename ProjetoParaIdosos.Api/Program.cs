using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "API", Version = "v1" });

    // Configuração do JWT no Swagger
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


// ===============================
// PostgreSQL connection
// ===============================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ===============================
// Repositories
// ===============================
builder.Services.AddScoped<IPartnerRepository, PartnerRepository>();
builder.Services.AddScoped<IDependentRepository, DependentRepository>();
builder.Services.AddScoped<IVisitRepository, VisitRepository>();
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// ===============================
// Services
// ===============================
builder.Services.AddScoped<IPartnerService, PartnerService>();
builder.Services.AddScoped<IDependentService, DependentService>();
builder.Services.AddScoped<IVisitService, VisitService>();
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// ===============================
// JWT Authentication
// ===============================

// LÊ EXATAMENTE O QUE TEM NO SEU appsettings.json
var jwtSettings = builder.Configuration.GetSection("Jwt");
var secretKey = jwtSettings.GetValue<string>("Key");

if (string.IsNullOrWhiteSpace(secretKey))
    throw new Exception("JWT Secret Key is missing! Configure 'Jwt:Key' in appsettings.json.");

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,      // Não está usando issuer
            ValidateAudience = false,    // Não está usando audience
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey)
            ),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// ===============================
// HTTP Pipeline
// ===============================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware global de tratamento de exceções
app.UseMiddleware<ApiExceptionMiddleware>();

app.UseHttpsRedirection();

// AUTENTICAÇÃO + AUTORIZAÇÃO
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
