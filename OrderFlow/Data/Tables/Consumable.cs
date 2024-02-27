namespace OrderFlow.Data.Tables
{
    public class Consumable
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Price { get; set; }
        public ConsumableType Type { get; set; }

        public ICollection<OrderedConsumable> OrderedConsumables { get; set; } = new List<OrderedConsumable>();

        public Consumable() { }

        public Consumable(string name, string description, int price, ConsumableType type)
        {
            Name = name;
            Description = description;
            Price = price;
            Type = type;
        }

        public Consumable(int id, string name, string description, int price, ConsumableType type)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Type = type;
        }
    }
}
