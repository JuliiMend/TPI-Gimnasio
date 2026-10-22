using API.Clients;
using Blazor.Server;
using Blazor.Server.Components;
using Microsoft.AspNetCore.Components.Server.Circuits;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Una sesión por usuario (circuito), no una global compartida por todos los navegadores
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<CircuitHandler, AuthCircuitHandler>();

var app = builder.Build();

// Durante el prerenderizado (request HTTP) todavía no hay circuito: se usa la sesión del request
app.Use(async (context, next) =>
{
    AuthServiceProvider.SetActual(context.RequestServices.GetRequiredService<IAuthService>());
    await next();
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();