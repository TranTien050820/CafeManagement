namespace Cafe_Management.Core.Entities
{
    public class CustomerLevel
    {
        public int Level_ID { get; set; }
        public string Level_Name { get; set; }
        public int PointApply { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
