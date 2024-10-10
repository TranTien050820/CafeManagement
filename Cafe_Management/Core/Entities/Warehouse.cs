namespace Cafe_Management.Core.Entities
{
    public class Warehouse
    {
        public int Warehouse_ID { get; set; }
        public string Warehouse_Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
