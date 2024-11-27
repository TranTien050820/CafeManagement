using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe_Management.Core.Entities
{
    [Table("Ingredient_Categories")]
    public class IngredientCategory
    {
        [Key]
        public int? Ingredient_Category_ID { get; set; }
        public string? Ingredient_Category_Name { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
