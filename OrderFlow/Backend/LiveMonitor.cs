using OrderFlow.Data.Tables;
using System.Threading.Channels;

namespace OrderFlow.Backend
{
    public class LiveMonitor
    {
        public static List<FakeOrder> FakeOrders = new();
        
        public delegate Task AsyncEventHandler(object sender, EventArgs e);
        public static event AsyncEventHandler Notifier;

        public delegate Task FakeOrderAsyncEventHandler(object sender, FakeOrder forder);
        public static event FakeOrderAsyncEventHandler FakeNotifier;

        public static async Task Notify()
        {
            await Notifier.Invoke(null, new EventArgs());
        }

        public static async Task FakeNotify(FakeOrder forder)
        {
            await FakeNotifier.Invoke(null, forder);
        }
    }
}
