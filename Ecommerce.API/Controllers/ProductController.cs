using Ecommerce.Application.Abstractions.Products.Command.CreateProduct;
using Ecommerce.Application.Abstractions.Products.Queries.GetAllProducts;
using Ecommerce.Application.DTOs.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createproduct")]
        public async Task<ActionResult> CreateProduct(CreateProductDto product)
        {
            var productCommand = new CreateProductCommand(product);
            var productId = await _mediator.Send(productCommand);
            return Ok(productId);

        }

        [HttpGet("getproducts")]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);    
        }

        [HttpGet("getproduct/{id}")]
        public async Task<ActionResult> GetProduct(object id)
        {
            var product = await _mediator.Send(id);
            if(product is null)
            {
                return NotFound($"The product with product id :{id} does not exist");
            }

            return Ok(product);
        }
    }
}
