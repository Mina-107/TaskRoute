
namespace BusinessLogicLayer.SI.Specifications
{
    internal class InvoiceSpacification : BaseSpecification<DataAccessLayer.Data.Entities.Invoice>
    {
        public InvoiceSpacification(int id) : base(e=>e.Id==id)
        {
            AddInclude(e => e.Order);
        }


    }


}
