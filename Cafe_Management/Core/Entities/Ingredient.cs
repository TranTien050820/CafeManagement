namespace Cafe_Management.Core.Entities
{
    public class Ingredient
    {
        public int Ingredient_ID { get; set; }
        public string Ingredient_Name { get; set; }
        public int Ingredient_Category { get; set; }
        public int Ingredient_Type { get; set; } // 0 = khong nau, 1 = nau, 2 = khong phai do an
        public string Unit_Transfer { get; set; }
        public string Unit_Min { get; set; }
        public string Unit_Max { get; set; }
        public double TransferPerMin { get; set; }
        public double MaxPerTransfer { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
