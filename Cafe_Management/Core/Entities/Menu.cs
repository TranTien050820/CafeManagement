using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe_Management.Core.Entities
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        public int? Menu_ID { get; set; }
        public string? Menu_Name { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [JsonIgnore]
        public ICollection<MenuDetail> MenuDetail { get; set;}

    }
}
