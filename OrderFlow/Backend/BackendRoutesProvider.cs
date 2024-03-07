using AngleSharp.Io;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OrderFlow.Data;
using System.Net.WebSockets;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using OrderFlow.Data.Tables;

namespace OrderFlow.Backend
{
    public class BackendRoutesProvider
    {
        public static void ConfigureRoutes(IRouteBuilder routes)
        {
            routes.MapGet("/api", ApiTestGet);
            routes.MapPost("/api/live", OrderMade);
            routes.MapGet("/api/orders", GetAllOrders);
        }

        public static void ConfigureWSRoutes(WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/api/live/ws/TEMP")
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

            app.MapHub<LiveOrderHub>("/api/live/ws");
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
            FakeOrder order = await request.ReadFromJsonAsync<FakeOrder>();
            await LiveMonitor.FakeNotify(order);
        }

        private async static Task GetAllOrders(HttpRequest request, HttpResponse response, RouteData data)
        {
            using (var db = new DatabaseDbContext())
            {
                var orders = await db.Consumables.Select(o => o).ToListAsync();
                await response.WriteAsJsonAsync(orders);
            }
        }

        // Endpoint to listen to new orders
        //private async static Task ListenOrders(HttpRequest request, HttpResponse response, RouteData data)
        public async static Task ListenOrders(HttpContext context, WebSocket socket)
        {
            using var ws = socket;
            using var tokenSource = new CancellationTokenSource();
            tokenSource.Token.ThrowIfCancellationRequested();

            var handler = new LiveMonitor.AsyncEventHandler(new Func<object, EventArgs, Task>(async (o, e) =>
            {
                Console.WriteLine("GOT CONNECTION");
            }));
            LiveMonitor.Notifier += handler;

            try
            {
                while (true)
                {
                    await ws.SendAsync(new byte[] { 0 }, WebSocketMessageType.Binary, true, tokenSource.Token);
                }
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
