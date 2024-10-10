namespace Cafe_Management.Core.Entities
{
    public class BatchRecipeDetail
    {
        public int Detail_ID { get; set; }
        public int BatchRecipe_ID { get; set; }
        public int Ingredient_ID { get; set; }
        public double Quality { get; set; }
        public int Unit { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
