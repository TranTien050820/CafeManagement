using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe_Management.Core.Entities
{
    [Table("SpoiledIngredientDetails")]
    public class SpoiledIngredientDetail
    {
        [Key]
        public int SpoildDetail_ID { get; set; }
        public int Spoiled_ID { get; set; }
        public int Ingredient_ID { get; set; }
        public double Quality { get; set; }
        public int Unit { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
