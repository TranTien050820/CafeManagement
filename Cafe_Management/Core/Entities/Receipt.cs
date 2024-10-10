namespace Cafe_Management.Core.Entities
{
    public class Receipt
    {
        public int Receipt_ID { get; set; }
        public int Staff_ID { get; set; }
        public int TotalPrice { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
