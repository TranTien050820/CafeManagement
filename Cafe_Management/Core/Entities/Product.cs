namespace Cafe_Management.Core.Entities
{
    public class Product
    {
        public int? Product_ID { get; set; }
        public string? Product_Name { get; set; }
        public int? Product_Category { get; set; }
        public int? Price { get; set; }
        public int? Point { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
