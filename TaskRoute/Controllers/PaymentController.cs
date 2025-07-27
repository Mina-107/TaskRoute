


namespace PersentationLayer.AI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController(IPaymentService PaymentService)
        : ControllerBase
    {
        [HttpPost("{basketId}")]
         
          public  async Task<ActionResult<BasketDto>> CreateOrUpdatePaymentIntent( string basketId)
        {
            var Result = await PaymentService.CreateOrUpdatePaymentIntentAsync(basketId);
            return Ok(Result);

        }

        //For WebHook
        [HttpPost("webhook")]
        public async Task<IActionResult>WebHook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            await PaymentService.UpdateOrderPaymentStatus(json, Request.Headers["Stripe-Signature"]!);
            return new EmptyResult();
        }
    
    }
}
