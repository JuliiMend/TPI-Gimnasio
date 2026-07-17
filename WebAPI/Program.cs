using WebAPI;
using Application.Services;
using Data;

var builder = WebApplication.CreateBuilder(args);

// Configuramos Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyectamos las dependencias (Repositorios y Servicios)
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<ISocioRepository, SocioRepository>();
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<ISocioService, SocioService>();

var app = builder.Build();

// Habilitamos Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Mapeamos los Endpoints usando los archivos estáticos
app.MapPlanEndpoints();
app.MapSocioEndpoints();

app.Run();