namespace Cafe_Management.Core.Entities
{
    public class Supplier
    {
        public int? Supplier_ID { get; set; }
        public string? Supplier_Name { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
