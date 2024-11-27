using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cafe_Management.Core.Entities
{
    [Table("StoreProduct")]
    public class StoreProduct
    {
        [Key]
        public int StoreProduct_ID { get; set; }
        public int Warehouse_ID { get; set; }
        public int Product_ID { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
