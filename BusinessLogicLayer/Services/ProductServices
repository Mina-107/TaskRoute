
namespace BusinessLogicLayer.SI.Services
{
    internal class ProductServices(IUnitOfWork unitOf):IProductServices
    {


        public async Task<int> UpdateAsync(ProductUpdate product)
        {
           
            unitOf.GetRepository<Product, int>().Update(product.ToEntityUpdate());  
           
            return await unitOf.SaveChangesAsync();
        }
        public async Task<IEnumerable<ProductResponse>> GetAllAsync(string? name )
        {
            var spasification = new ProductSpecification(name);
            var products = await unitOf.GetRepository<Product, int>().GetAllAsync(spasification);
        return products.Select(e=>e.ToResponses());
            
        }

        public async Task<ProductResponseDetails> GetByIdAsync(int id)
        {
             var product= await unitOf.GetRepository<Product, int>().GetByIdAsync(id);
            return product.ToResponseDetails();

          
        }

        public async Task<int> AddAsync(ProductRequest product)
        {

            unitOf.GetRepository<Product, int>().Update(product.ToEntity());

            return await unitOf.SaveChangesAsync();
        }


    }
}

