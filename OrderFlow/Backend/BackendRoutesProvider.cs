using AngleSharp.Io;
using Microsoft.AspNetCore.Http;
using OrderFlow.Data;
using System.Text;

namespace OrderFlow.Backend
{
    public class BackendRoutesProvider
    {
        public static void ConfigureRoutes(IRouteBuilder routes)
        {
            routes.MapGet("/api", ApiTestGet);
        }

        private async static Task ApiTestGet(HttpRequest request, HttpResponse response, RouteData data)
        {
            using DatabaseDbContext db = new DatabaseDbContext();

            var cb = (from c in db.Consumables
                      select c).ToList();

            await response.BodyWriter.WriteAsync(
                Encoding.UTF8.GetBytes($"{cb[0].Name}")
                
            );
        }
    }
}
