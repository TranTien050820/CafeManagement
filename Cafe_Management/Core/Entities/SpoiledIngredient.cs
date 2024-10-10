namespace Cafe_Management.Core.Entities
{
    public class SpoiledIngredient
    {
        public int Spoiled_ID { get; set; }
        public string Reason { get; set; }
        public int Staff_ID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
