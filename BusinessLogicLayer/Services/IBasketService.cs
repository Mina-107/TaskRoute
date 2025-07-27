

namespace Services
{
    public interface IBasketService
    {
        public Task<BasketDto?> GetBasketAsync(string id);
        public Task<BasketDto?> UpdateBasketAsync(BasketDto basket);
        public Task<bool> DeleteBasketAsync(string id);
    }
}

