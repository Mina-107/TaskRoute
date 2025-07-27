

using Microsoft.AspNetCore.Authorization;

namespace PersentationLayer.AI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductServices productServices) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable< ProductResponse>>> Index(string? search) {

            return Ok( await productServices.GetAllAsync(search));
        }
        [HttpGet("{id: int}")]
        public async Task<ActionResult<ProductResponseDetails>> GetById(int id)
        {

            return Ok( await productServices.GetByIdAsync(id));
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id: int}")]
        public async Task<ActionResult<int>> Update(ProductUpdate productUpdate, [FromRoute]int id) { 
            if (productUpdate.Id!= id)
                return BadRequest();
        return Ok(await productServices.UpdateAsync(productUpdate));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<int>> Add(ProductRequest productRequest) {

            return Ok(await productServices.AddAsync(productRequest));
        }

    }
}
