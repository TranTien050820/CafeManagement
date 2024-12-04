using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Cafe_Management.Core.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Product_ID { get; set; }
        public string? Product_Name { get; set; }
        public int? Product_Category { get; set; }
        public int? Price { get; set; }
        public int? Point { get; set; }
        public bool? IsActive { get; set; }
        public string? Product_Image { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [JsonIgnore]
        public ICollection<ProductRecipe>? ProductRecipe { get; set; }
    }
}
