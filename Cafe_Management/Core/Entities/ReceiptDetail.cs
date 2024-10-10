namespace Cafe_Management.Core.Entities
{
    public class ReceiptDetail
    {
        public int Detail_ID { get; set; }
        public int Receipt_ID { get; set; }
        public int Product_ID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
