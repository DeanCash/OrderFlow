using Microsoft.AspNetCore.SignalR;

namespace OrderFlow.Backend
{
    public class LiveOrderHub : Hub
    {
        public async Task SendMessage()
        {
            //await Clients.All.SendAsync("ReceiveMessage");
            await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage");
        }
    }
}
