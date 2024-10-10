namespace Cafe_Management.Core.Entities
{
    public class BatchRecipe
    {
        public int BatchRecipe_ID { get; set; }
        public int IngredientResult_ID { get; set; }
        public double Quality { get; set; }
        public int Unit { get; set; } // 1 = min, 2 = transfer, 3 = max
        public int Staff_ID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
