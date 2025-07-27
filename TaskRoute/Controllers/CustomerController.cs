
namespace PersentationLayer.AI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerServices customerServices) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<bool>> CreateCustomerAsync(CustomerRequest customerRequest)
        {
            return Ok(await customerServices.CreateCustomerAsync(customerRequest));
        }

        [HttpGet("{id}/order")]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetAllOrdersOfUser(string id)
        {
            return Ok(await customerServices.GetAllOrdersOfUser(id));
        }
    }
}
