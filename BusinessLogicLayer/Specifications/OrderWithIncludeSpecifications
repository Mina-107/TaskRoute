
namespace Services.Specifications
{
   public class OrderWithIncludeSpecifications:BaseSpecification<Order>

    {
         public OrderWithIncludeSpecifications(Guid id)
            :base(o=>o.Id==id)
        {
            AddInclude(O => O.DeliveryMethod);
            AddInclude(O => O.OrderItems);


        }
        //Get By Email
        public OrderWithIncludeSpecifications( )
            : base(null)
        {
            AddInclude(O => O.Customer);

        }
        public OrderWithIncludeSpecifications(string id)
    : base(e=>e.CustomerId==id)
        {
            AddInclude(O => O.Customer);

        }

    }
}
