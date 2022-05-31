using Microsoft.AspNetCore.Mvc;
using ShopOnline.API.Extensions;
using ShopOnline.API.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepoitory;

        public ProductController(IProductRepository productRepoitory)
        {
            this.productRepoitory = productRepoitory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var prodcucts = await this.productRepoitory.GetItems();
                var productCategories = await this.productRepoitory.GetCategories();

                if (prodcucts == null || productCategories == null)
                {
                    return NotFound();
                }
                else
                {
                    var productDtos = prodcucts.ConvertToDto(productCategories);
                    return Ok(productDtos);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                                 "Error retrieving data from the database");
            }
        }

    }
}
