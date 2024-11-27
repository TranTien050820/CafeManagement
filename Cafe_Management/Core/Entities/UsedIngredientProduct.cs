using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe_Management.Core.Entities
{
    [Table("UsedIngredientProduct")]
    public class UsedIngredientProduct
    {
        [Key]
        public int ID { get; set; }
        public int Ingredient_ID { get; set; }
        public int Product_ID { get; set; }
        public int Receipt_ID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
