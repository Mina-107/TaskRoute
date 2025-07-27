

using Microsoft.AspNetCore.Authorization;

namespace PersentationLayer.AI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class InvoicesController(IInvoiceServices invoiceservices) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceResponse>>> GetAllAsync()
        {

            return Ok(invoiceservices.GetAllAsync());
        }

        [HttpGet]
        public async Task<ActionResult<InvoiceResponseDetails>> GetByIdAsync(int id)
        {

            return Ok(invoiceservices.GetById(id));

        }
      
    }
}
