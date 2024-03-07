using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace OrderFlow.Data.Tables
{
    public class Table
    {
        public int Id { get; set; }
        public string TableCode { get; set; } = null!;

        public QR_Code QRCode { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public Table() { }

        public Table(int id, string tableCode)
        {
            Id = id;
            TableCode = tableCode;
        }

        public Table(QR_Code qrCode, string tableCode)
        {
            QRCode = qrCode;
            TableCode = tableCode;
        }

        public Table(int id, QR_Code qrCode, string tableCode)
        {
            Id = id;
            QRCode = qrCode;
            TableCode = tableCode;
        }
    }
}
