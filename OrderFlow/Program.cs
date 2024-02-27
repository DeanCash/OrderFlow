using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using OrderFlow.Backend;
using Toolbelt.Extensions.DependencyInjection;
using RouteData = Microsoft.AspNetCore.Routing.RouteData;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Custom
builder.Services.AddHttpClient();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    // Live reloading for CSS
    app.UseCssLiveReload();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseRouter(routes =>
{
    // Own custom backend routes
    BackendRoutesProvider.ConfigureRoutes(routes);
});

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
