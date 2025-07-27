

namespace BusinessLogicLayer.SI.DTO
{
   public class BasketDto
    {
        public string Id { get; init; }
        public  IEnumerable<BasketItemDto> Items { get; init; }
        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }
        public int? DeliveryMethodId { get; set; }
        public decimal? ShippingPrice { get; set; }

    }
}

