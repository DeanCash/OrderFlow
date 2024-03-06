using System.Threading.Channels;

namespace OrderFlow.Backend
{
    public class LiveMonitor
    {
        //public static Channel<object> Notifier = Channel.CreateUnbounded<object>();
        public static event EventHandler Notifier;

        public static void Notify()
        {
            Notifier.Invoke(null, new EventArgs());
        }
    }
}
