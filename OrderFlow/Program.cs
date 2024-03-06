using OrderFlow.Backend;
using OrderFlow.Data;
using Toolbelt.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTransient<DatabaseDbContext>();

builder.Services.AddServerSideBlazor().AddHubOptions(options => {
    options.MaximumReceiveMessageSize = null; // no limit or use a number
});

// Custom
builder.Services.AddHttpClient();
builder.Services.AddSignalR();

var app = builder.Build();

// Custom
app.UseWebSockets();

BackendRoutesProvider.ConfigureWSRoutes(app);

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
