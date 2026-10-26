using API.Clients;
using Blazor.Server;
using Blazor.Server.Components;
using Microsoft.AspNetCore.Components.Server.Circuits;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<CircuitHandler, AuthCircuitHandler>();

var app = builder.Build();

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