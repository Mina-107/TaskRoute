
using Invoice = DataAccessLayer.Data.Entities.Invoice;

namespace BusinessLogicLayer.SI.Services
{
    internal class Invoiceservices(IUnitOfWork unitOfWork) : IInvoiceServices
    {

        public async Task<IEnumerable<InvoiceResponse>> GetAllAsync()
        {
          var invoices= await unitOfWork.GetRepository<Invoice, int>().GetAllAsync();
            return invoices.Select(x => x.ToRespose());
                
        }
        public async Task<InvoiceResponseDetails> GetById(int id)
        {
            var invoice= await unitOfWork.GetRepository<Invoice, int>().GetByIdAsync(new InvoiceSpacification(id));
            return invoice.ToResposeDetails();
        }


        }
    

    }

