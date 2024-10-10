namespace Cafe_Management.Core.Entities
{
    public class Staff
    {
        public int Staff_ID { get; set; }
        public int StaffGroup_ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Staff_FullName { get; set; }
        public string Staff_Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
