namespace Cafe_Management.Core.Entities
{
    public class IngredientSupplierLink
    {
        public int Link_ID { get; set; }
        public int Supplier_ID { get; set; }
        public int StaffRequest_ID { get; set; }
        public int StaffApproved_ID { get; set; }
        public int StaffReceived_ID { get; set; }
        public int TotalPrice { get; set; }
        public int Status { get; set; }
        public int Warehouse_ID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
