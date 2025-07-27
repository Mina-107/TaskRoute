


namespace PersentationLayer.AI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController(IBasketService basketService) : ControllerBase
    {
       
        [HttpGet("{id}")]
        public async Task<ActionResult<BasketDto>> Get(string id)
        {
            var basket = await basketService.GetBasketAsync(id);
            return basket;
        }

        [HttpPost]
        public async Task<ActionResult<BasketDto>> Update(BasketDto basketDto)
        {
            var Basket = await basketService.UpdateBasketAsync(basketDto);
            return Ok(basketDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await basketService.DeleteBasketAsync(id);
            return NoContent();
        }


    }
}
