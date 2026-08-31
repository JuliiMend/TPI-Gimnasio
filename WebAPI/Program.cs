using Application.Services;
using Data;
using Microsoft.EntityFrameworkCore;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Configuramos Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuramos Entity Framework para usar SQL Server
builder.Services.AddDbContext<GimnasioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyectamos las dependencias (Repositorios y Servicios)
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<ISocioRepository, SocioRepository>();
builder.Services.AddScoped<IProfesorRepository, ProfesorRepository>();
builder.Services.AddScoped<ITurnoRepository, TurnoRepository>();
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<ISocioService, SocioService>();
builder.Services.AddScoped<ITurnoService, TurnoService>();
builder.Services.AddScoped<IProfesorService, ProfesorService>();

var app = builder.Build();

// Habilitamos Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Mapeamos los Endpoints usando los archivos estáticos
app.MapPlanEndpoints();
app.MapSocioEndpoints();
app.MapTurnoEndpoints();
app.MapProfesorEndpoints();
app.Run();