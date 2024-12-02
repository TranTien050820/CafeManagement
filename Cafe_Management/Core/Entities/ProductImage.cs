using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe_Management.Core.Entities
{
    [Table ("ProductImage")]
    public class ProductImage
    {
        [Key]
        public int ProductImage_ID { get; set; } // Primary key
        public int Product_ID { get; set; } // Foreign key reference to Product
        public string Image_URL { get; set; }
        public string AltText { get; set; } // Optional: Add alt text for the image

        [JsonIgnore ]
        public Product Product { get; set; } // Navigation property to Product
    }
}
