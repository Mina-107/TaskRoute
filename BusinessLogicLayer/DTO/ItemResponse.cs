

namespace BusinessLogicLayer.SI.DTO
{
    public class ItemResponse
    {
        public Guid Id { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int Discount { get; set; }
        public string ProductName { get; set; }

    }

}
