namespace Cafe_Management.Core.Entities
{
    public class Warehouse
    {
        public int WareHouse_ID { get; set; }
        public string WareHouse_Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
