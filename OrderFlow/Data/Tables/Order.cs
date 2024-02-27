namespace OrderFlow.Data.Tables
{
    public class Order
    {
        public int Id { get; set; }
        public Table Table { get; set; } = null!;
        public bool IsProcessed { get; set; }
        public DateTime OrderedAt { get; set; }
        public DateTime ProcessedAt { get; set; }

        public ICollection<OrderedConsumable> OrderedConsumables { get; set; } = new List<OrderedConsumable>();

        public Order() { }

        public Order(Table table, bool isProcessed, DateTime orderedAt, DateTime processedAt)
        {
            Table = table;
            IsProcessed = isProcessed;
            OrderedAt = orderedAt;
            ProcessedAt = processedAt;
        }

        public Order(int id, Table table, bool isProcessed, DateTime orderedAt, DateTime processedAt)
        {
            Id = id;
            Table = table;
            IsProcessed = isProcessed;
            OrderedAt = orderedAt;
            ProcessedAt = processedAt;
        }
    }
}
