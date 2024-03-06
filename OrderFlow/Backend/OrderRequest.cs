using OrderFlow.Data;
using OrderFlow.Data.Tables;
using System.ComponentModel;

namespace OrderFlow.Backend
{
    public class OrderRequest
    {
        public static event EventHandler OrderMade;

        public static void Notify()
        {
            OrderMade.Invoke(null, new EventArgs());
        }

        //public delegate void OrderMadeEvent(object sender, Order order);

        //event OrderMadeEvent OrderMade;

        //public void MakeOrder(Order order)
        //{
        //    OrderMade.Invoke(this, order);
        //}

        //public async Task MakeOrder(int order)
        //{
        //    using (var db = new DatabaseDbContext())
        //    {
        //        var _order = db.Orders
        //            .Where(o => o.Id == order)
        //            .First();

        //        OrderMade.Invoke(this, _order);
        //    }
        //}
    }
}
