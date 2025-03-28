using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Proyectoclase.Data;
using Proyectoclase.Models;
using Proyectoclase.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurar conexion a DB
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseDB")));

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Configuración de controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "H1 API de proyecto Clase",
        Version = "v1",
        Description = "Documentacion de API para proyecto de clase de Programacion Movil"
    });
});

// Configuración de servicios
builder.Services.AddScoped<UsuarioSerice>();
builder.Services.AddScoped<AnunciosService>();

var app = builder.Build();

// Configuración de middleware
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");

app.Run();
