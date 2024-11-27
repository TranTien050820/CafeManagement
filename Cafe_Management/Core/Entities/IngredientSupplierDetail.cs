using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe_Management.Core.Entities
{
    [Table("Ingredient_Supplier_Detail")]
    public class IngredientSupplierDetail
    {
        [Key]
        public int Detail_ID { get; set; }
        public int Header_ID { get; set; }
        public int Ingredient_ID { get; set; }
        public int Price { get; set; }
        public double Quality { get; set; }
        public int Unit { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
