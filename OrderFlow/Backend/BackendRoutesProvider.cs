using AngleSharp.Io;
using Microsoft.AspNetCore.Http;
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
            await response.BodyWriter.WriteAsync(
                Encoding.UTF8.GetBytes("Hello World, from API!")
            );
        }
    }
}
