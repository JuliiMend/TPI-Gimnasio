using Application.Services;
using DTOs;
using Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebAPI;
using WebAPI.Endpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.RateLimiting;
using Domain.Model;
using System.Text;
using System.Threading.RateLimiting;


var builder = WebApplication.CreateBuilder(args);

var jwtSecretKey = builder.Configuration["JwtSettings:SecretKey"];
if (string.IsNullOrWhiteSpace(jwtSecretKey) || Encoding.UTF8.GetByteCount(jwtSecretKey) < 32)
{
    throw new InvalidOperationException(
        "Falta configurar JwtSettings:SecretKey (mínimo 32 caracteres). " +
        "Para desarrollo viene en appsettings.Development.json; también se puede definir con " +
        "'dotnet user-secrets set \"JwtSettings:SecretKey\" \"<clave>\"' en el proyecto WebAPI.");
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey))
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Politicas.SoloAdmin, p => p.RequireRole(Roles.Admin));
    options.AddPolicy(Politicas.AdminOSocio, p => p.RequireRole(Roles.Admin, Roles.Socio));
    options.AddPolicy(Politicas.AdminOProfesor, p => p.RequireRole(Roles.Admin, Roles.Profesor));
});

// Límite de intentos de login por IP (complementa el bloqueo por usuario de ControlIntentosLogin)
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    options.OnRejected = async (context, token) =>
    {
        await context.HttpContext.Response.WriteAsJsonAsync(new LoginResponse
        {
            Exito = false,
            Bloqueado = true,
            Mensaje = "Demasiados intentos de inicio de sesión desde este equipo. Esperá un minuto y volvé a intentar."
        }, token);
    };
    options.AddPolicy(AuthEndpoints.PoliticaLimiteLogin, httpContext =>
        RateLimitPartition.GetFixedWindowLimiter(
            httpContext.Connection.RemoteIpAddress?.ToString() ?? "desconocida",
            _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 20,
                Window = TimeSpan.FromMinutes(1),
                QueueLimit = 0
            }));
});

// Configuramos Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Poné 'Bearer' seguido de un espacio y tu token JWT. Ejemplo: 'Bearer eyJhb...'",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

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
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddSingleton<ControlIntentosLogin>();
builder.Services.AddScoped<ICuotaService, CuotaService>();
builder.Services.AddScoped<ICuotaRepository, CuotaRepository>();
builder.Services.AddScoped<IMaquinaRepository, MaquinaRepository>();
builder.Services.AddScoped<IMaquinaService, MaquinaService>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IAdministradorRepository, AdministradorRepository>();
builder.Services.AddScoped<IAdministradorService, AdministradorService>();
builder.Services.AddScoped<IActividadRepository, ActividadRepository>();
builder.Services.AddScoped<IActividadService, ActividadService>();
builder.Services.AddScoped<IClaseRepository, ClaseRepository>();
builder.Services.AddScoped<IClaseService, ClaseService>();
builder.Services.AddScoped<IInscripcionRepository, InscripcionRepository>();
builder.Services.AddScoped<IInscripcionService, InscripcionService>();
builder.Services.AddScoped<IMantenimientoRepository, MantenimientoRepository>();
builder.Services.AddScoped<IMantenimientoService, MantenimientoService>();
builder.Services.AddScoped<IHistoricoSueldoRepository, HistoricoSueldoRepository>();
builder.Services.AddScoped<IHistoricoSueldoService, HistoricoSueldoService>();

var app = builder.Build();

// Crea la base / aplica las migraciones pendientes y, si la base no tiene usuarios, carga los datos de prueba
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<GimnasioContext>();

    await context.Database.MigrateAsync();

    if (builder.Configuration.GetValue("DatosDePrueba:Cargar", false))
    {
        await DatosDePrueba.CargarAsync(context);
    }
}

// Habilitamos Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Errores de integridad de la BD (FK o clave única) -> 409 con un mensaje legible en vez de un 500
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    // EF envuelve la SqlException en DbUpdateException; los repositorios ADO.NET (Máquinas, Materiales) la lanzan directa
    catch (Exception ex) when ((ex as DbUpdateException)?.InnerException is SqlException ||
                               ex is SqlException { Number: 547 or 2601 or 2627 })
    {
        var sqlEx = ex as SqlException ?? (SqlException)ex.InnerException!;

        var mensaje = sqlEx.Number switch
        {
            547 => "La operación no se puede realizar por una relación con otros datos: el registro tiene datos asociados (por ejemplo, un plan con socios o un socio con cuotas) o hace referencia a uno que no existe.",
            2601 or 2627 => "Ya existe un registro con esos datos (por ejemplo, el username ya está en uso).",
            _ => "No se pudo guardar el cambio en la base de datos."
        };

        context.Response.StatusCode = StatusCodes.Status409Conflict;
        await context.Response.WriteAsJsonAsync(new { mensaje });
    }
    catch (ReglaNegocioException ex)
    {
        context.Response.StatusCode = StatusCodes.Status409Conflict;
        await context.Response.WriteAsJsonAsync(new { mensaje = ex.Message });
    }
    // Datos que no cumplen las validaciones del modelo de dominio
    catch (ValidacionDominioException ex)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsJsonAsync(new { mensaje = ex.Message });
    }
});

// Auth tiene que ir ANTES de mapear los endpoints
app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();

// Mapeamos los Endpoints usando los archivos estáticos
app.MapPlanEndpoints();
app.MapSocioEndpoints();
app.MapTurnoEndpoints();
app.MapProfesorEndpoints();
app.MapAuthEndpoints();
app.MapUsuarioEndpoints();
app.MapCuotaEndpoints();
app.MapMaquinaEndpoints();
app.MapMaterialEndpoints();
app.MapAdministradorEndpoints();
app.MapActividadEndpoints();
app.MapClaseEndpoints();
app.MapInscripcionEndpoints();
app.MapMantenimientoEndpoints();
app.MapHistoricoSueldoEndpoints();

app.Run();