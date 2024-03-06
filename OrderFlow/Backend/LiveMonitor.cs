using System.Threading.Channels;

namespace OrderFlow.Backend
{
    public class LiveMonitor
    {
        //public static Channel<object> Notifier = Channel.CreateUnbounded<object>();
        public delegate Task AsyncEventHandler(object sender, EventArgs e);
        public static event AsyncEventHandler Notifier;

        public static async Task Notify()
        {
            await Notifier.Invoke(null, new EventArgs());
        }
    }
}
