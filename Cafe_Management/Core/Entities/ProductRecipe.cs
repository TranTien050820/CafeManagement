namespace Cafe_Management.Core.Entities
{
    public class ProductRecipe
    {
        public int Recipe_ID { get; set; }
        public int Product_ID { get; set; }
        public int Ingredient_ID { get; set; }
        public double Quantity { get; set; }
        public int Unit { get; set; }
    }
}
