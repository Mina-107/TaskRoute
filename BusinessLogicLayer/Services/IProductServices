
namespace BusinessLogicLayer.SI.Services
{
    public interface IProductServices
    { 

        Task<int> UpdateAsync(ProductUpdate product);
        Task<IEnumerable<ProductResponse>> GetAllAsync(string? name);
        Task<ProductResponseDetails> GetByIdAsync(int id);
        Task<int> AddAsync(ProductRequest product);
    }
}

