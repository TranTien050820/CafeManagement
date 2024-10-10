namespace Cafe_Management.Core.Entities
{
    public class StoreIngredient
    {
        public int Store_ID { get; set; }
        public int Warehouse_ID { get; set; }
        public int Ingredient_ID { get; set; }
        public int Price { get; set; }
        public double Quality { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
