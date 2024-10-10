namespace Cafe_Management.Core.Entities
{
    public class RecipeRaw
    {
        public int Recipe_ID { get; set; }
        public int Ingredient_Result { get; set; }
        public int Ingredient_Raw { get; set; }
        public double Quantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
