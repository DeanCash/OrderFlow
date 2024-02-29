namespace OrderFlow.Data.Tables
{
    public class Consumable
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImagePath { get; set; } = null!;
        public ConsumableType Type { get; set; }

        public ICollection<OrderedConsumable> OrderedConsumables { get; set; } = new List<OrderedConsumable>();

        public Consumable() { }

        public Consumable(string name, string description, int price, string imagePath, ConsumableType type)
        {
            Name = name;
            Description = description;
            Price = price;
            ImagePath = imagePath;
            Type = type;
        }

        public Consumable(int id, string name, string description, int price, string imagePath, ConsumableType type)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            ImagePath = imagePath;
            Type = type;
        }
    }
}
