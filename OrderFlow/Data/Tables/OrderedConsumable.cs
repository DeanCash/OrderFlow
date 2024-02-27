using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFlow.Data.Tables
{
    public class OrderedConsumable
    {
        public int Id { get; set; }
        public Consumable Consumable { get; set; } = null!;
        public Order Order { get; set; } = null!;
        public decimal Price { get; set; }

        public OrderedConsumable() { }

        public OrderedConsumable(int id, Consumable consumable, Order order, decimal price)
        {
            Id = id;
            Consumable = consumable;
            Order = order;
            Price = price;
        }
    }
}
