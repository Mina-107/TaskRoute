
namespace BusinessLogicLayer.SI.Specifications
{
    internal class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(string? name) : base(null)
        {
            if (name != null) 
               EditCriteria(e=>e.Name.Contains(name)) ;
                
           
        }
       

    }
}
