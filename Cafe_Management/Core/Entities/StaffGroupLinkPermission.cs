namespace Cafe_Management.Core.Entities
{
    public class StaffGroupLinkPermission
    {
        public int Link_ID { get; set; }
        public int Permission_ID { get; set; }
        public int StaffGroup { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
