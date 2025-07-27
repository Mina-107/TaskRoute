namespace BusinessLogicLayer.SI.Profiles
{
    public static class ProductProfile
    {
        public static Product ToEntity(this ProductRequest product) {
            return new()
            {
               Name =product.Name ,
               Stock = product.Stock ,
               Price = product.Price ,
                
            };
        }

        public static Product ToEntityUpdate(this ProductUpdate productRequest) {
            return new()
            {
               
            Id = productRequest.Id,
             Name = productRequest.Name,
             Price = productRequest.Price,
             Stock=productRequest.Stock
            };
        }
        public static ProductResponse ToResponses(this Product product) {


            return new ()
            {
              
                Id= product.Id,
                Name= product.Name,
                Price= product.Price,

            };
            
    }
        public static ProductResponseDetails ToResponseDetails(this Product Product) {


            return new ()
            {
               Id= Product.Id,
               Name= Product.Name,  
               Price= Product.Price,
               Stock= Product.Stock
            };
        
        }
}
}
