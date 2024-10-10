namespace Cafe_Management.Core.Entities
{
    public class Menu
    {
        public int Menu_ID { get; set; }
        public string Menu_Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
