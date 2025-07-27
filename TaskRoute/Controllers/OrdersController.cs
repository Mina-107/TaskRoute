

using Microsoft.AspNetCore.Authorization;

namespace PersentationLayer.AI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class OrdersController(IOrderService orderService) : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> Index()
        {

            return Ok(await orderService.GetAllAsync());
        }
       
        [HttpGet("{id: Guid}")]
        public async Task<ActionResult<OrderResult>> GetOrderById(Guid id)
        {
            var Order = await orderService.GetOrderByIdAsync(id);
            return Ok(Order);
        }
        [HttpGet("DeliveryMethods")]
        public async Task<ActionResult<DeliverMethodResult>> GetDeliveryMethods()

        {
            var Methods = await orderService.GetDeliveryMethodsAsync();
            return Ok(Methods);

        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/status")]
        public async Task<ActionResult<int>> UpdateOrderStatus(Guid id,[FromBody]StatusOrder status)
        {
          
            return Ok(await orderService.UpdateOrderStatusAsync(id ,status));
        }

        [HttpPost]
        public async Task<ActionResult<OrderResult>> Create(OrderRequest orderRequest)
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
           
            var order = await orderService.CreateOrUpdateOrderAsync(orderRequest, id);
            return Ok(order);
        }


    }



}

