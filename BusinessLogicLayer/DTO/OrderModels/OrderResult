

namespace BusinessLogicLayer.SI.DTO
{
    public record OrderResult
    {
         public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
        public string PaymentStatus { get; set; }
      
        public string DeliveryMethod { get; set; }
        public decimal SubTotal { get; set; }
        public string PaymentIntentId { get; set; } = string.Empty;
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
         public   decimal Total { get; set; }

    }
}
