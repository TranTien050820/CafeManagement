namespace Cafe_Management.Core.Entities
{
    public class MenuDetail
    {
        public int Setup_ID { get; set; }
        public int Menu_ID { get; set; }
        public int Product_ID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
