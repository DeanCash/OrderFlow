namespace OrderFlow.Data.Tables
{
    public class FakeOrder
    {
        public int Id { get; set; }
        public DateTime Made { get; set; }
        public List<Consumable> Consumables { get; set; } = null!;
        public string TableCode { get; set; } = null!;

        public FakeOrder(int id, DateTime made, string tableCode)
        {
            Id = id;
            Made = made;
            Consumables = new();
            TableCode = tableCode;
        }
    }
}
