using AngleSharp.Io;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OrderFlow.Data;
using System.Net.WebSockets;
using System.Text;
using Microsoft.AspNetCore.SignalR;

namespace OrderFlow.Backend
{
    public class BackendRoutesProvider
    {
        public static void ConfigureRoutes(IRouteBuilder routes)
        {
            routes.MapGet("/api", ApiTestGet);
            routes.MapPost("/api/live", OrderMade);
        }

        public static void ConfigureWSRoutes(WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/api/live/ws")
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                        await BackendRoutesProvider.ListenOrders(context, webSocket);
                    }
                    else
                    {
                        await next();
                    }
                }
                else
                {
                    await next();
                }
            });
        }

        // Test
        private async static Task ApiTestGet(HttpRequest request, HttpResponse response, RouteData data)
        {
            using DatabaseDbContext db = new DatabaseDbContext();

            var cb = (from c in db.Consumables
                      select c).ToList();

            await response.BodyWriter.WriteAsync(
                Encoding.UTF8.GetBytes($"{cb[0].Name}")

            );
        }

        // Endpoint to notify the live monitor a order has been made
        // the actual value being sent doesn't matter, it just notifies
        // the reading end, that they need to refresh
        // This shouldn't be a problem since there wont by thousands of orders
        private async static Task OrderMade(HttpRequest request, HttpResponse response, RouteData data)
        {
            LiveMonitor.Notify();
        }

        // Endpoint to listen to new orders
        //private async static Task ListenOrders(HttpRequest request, HttpResponse response, RouteData data)
        public async static Task ListenOrders(HttpContext context, WebSocket socket)
        {
            using var ws = socket;
            using var tokenSource = new CancellationTokenSource();
            tokenSource.Token.ThrowIfCancellationRequested();

            var handler = new EventHandler((object? o, EventArgs e) =>
            {
                Console.WriteLine("GOT CONNECTION");
            });
            LiveMonitor.Notifier += handler;

            try
            {
                while (true)
                {
                    await ws.SendAsync(new byte[] { 0 }, WebSocketMessageType.Binary, true, tokenSource.Token);
                }
            } catch (Exception _e) {
            } finally
            {
                LiveMonitor.Notifier -= handler;
            }

            //while (true)
            //{
            //    bool available = await LiveMonitor.Notifier.Reader.WaitToReadAsync();
            //    if (!available)
            //        break;

            //    await ws.SendAsync(new byte[] { }, WebSocketMessageType.Binary, true, new CancellationToken());
            //}
        }
    }
}
