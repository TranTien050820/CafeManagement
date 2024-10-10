namespace Cafe_Management.Core.Entities
{
    public class StaffGroup
    {
        public int StaffGroup_ID { get; set; }
        public string StaffGroup_Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
