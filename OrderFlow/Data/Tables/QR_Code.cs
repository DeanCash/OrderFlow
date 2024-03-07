namespace OrderFlow.Data.Tables
{
    public class QR_Code
    {
        public int Id { get; set; }
        public string ImagePath { get; set; } = null!;

        public QR_Code() { }

        public QR_Code(string imagePath)
        {
            ImagePath = imagePath;
        }

        public QR_Code(int id, string imagePath)
        {
            Id = id;
            ImagePath = imagePath;
        }

        public QR_Code(string imagePath, Table table)
        {
            ImagePath = imagePath;
            //this.Table = table;
        }

        public QR_Code(int id, string imagePath, Table? table)
        {
            Id = id;
            ImagePath = imagePath;
            //this.Table = table;
        }
    }
}
