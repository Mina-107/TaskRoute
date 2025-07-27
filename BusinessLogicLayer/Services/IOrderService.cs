

namespace BusinessLogicLayer.SI.Services
{
    public interface IOrderService
    {

        Task<OrderResult> GetOrderByIdAsync(Guid id);
         Task<IEnumerable<OrderResponse>> GetAllAsync();
        Task<IEnumerable<DeliverMethodResult>> GetDeliveryMethodsAsync();
        Task<OrderResult> CreateOrUpdateOrderAsync(OrderRequest request, string userId);
        Task<int> UpdateOrderStatusAsync(Guid id, StatusOrder status);
        

    }
}

