using Ecommerce.Application.Abstractions.Products.Command.CreateProduct;
using Ecommerce.Application.Abstractions.Products.Command.UpdateProduct;
using Ecommerce.Application.Abstractions.Products.Queries.GetAllProducts;
using Ecommerce.Application.Abstractions.Products.Queries.GetProductById;
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
        public async Task<ActionResult> GetProduct(Guid id)
        {
            //var productId = new GetProductByIdQuery(id);
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            if(product is null)
            {
                return NotFound($"The product with product id :{id} does not exist");
            }

            return Ok(product);
        }

        [HttpPut("updateproduct/{id}")]
        public async Task<ActionResult> UpdateProduct(ProductDto producDto)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(producDto.ProductId));
            if (product is null)
            {
                return NotFound($"The product with product id :{producDto.ProductId} does not exist");
            }

            var mapProduct = await _mediator.Send(new UpdateProductCommand(producDto));
            return Ok(mapProduct);
        }
    }
}
