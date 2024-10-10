namespace Cafe_Management.Core.Entities
{
    public class ProductCategory
    {
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
