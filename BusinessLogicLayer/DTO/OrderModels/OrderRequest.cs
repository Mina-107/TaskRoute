
namespace BusinessLogicLayer.SI.DTO
{
   public record OrderRequest
    {
        public string BasketId { get; init; }
        public int DeliveryMethodId { get; init; }
       
         //public int DeliverMethodId { get; set; }
    }
}
