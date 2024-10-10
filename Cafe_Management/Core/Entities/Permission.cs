namespace Cafe_Management.Core.Entities
{
    public class Permission
    {
        public int Permission_ID { get; set; }
        public string Permission_Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
