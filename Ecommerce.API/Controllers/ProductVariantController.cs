using Ecommerce.Application.Abstractions.ProductVariants.Commands.CreateProductVariant;
using Ecommerce.Application.Abstractions.ProductVariants.Commands.UpdateProductVariant;
using Ecommerce.Application.Abstractions.ProductVariants.Queries.GetProductVariants;
using Ecommerce.Application.Abstractions.ProductVariants.Queries.GetProjectVariantById;
using Ecommerce.Application.DTOs.ProductVariants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductVariantController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create_productvariant")]
        public async Task<ActionResult> CreateProductVariant(CreateProductVariantDto dto) 
        {
            var productVariantId = await _mediator.Send(new CreateProductVariantCommand(dto));
            return Ok(productVariantId);
        }

        [HttpGet("getproductvariants")]
        public async Task<ActionResult> GetProductVariants()
        {
            var variants = await _mediator.Send(new GetProductVariantsQuery());
            return Ok(variants);
        }

        [HttpGet("getprojectvariant/{id}")]
        public async Task<ActionResult> GetProjectVariantById(int id)
        {
            var variant = await _mediator.Send(new GetProductVariantByIdQuery(id));
            if(variant is null)
            {
                return NotFound($"The Product Variant with the id :{id} does not exist");
            }

            return Ok(variant);
        }

        [HttpPut("updateprojectvariant/{id}")]
        public async Task<ActionResult> UpdateProductVariant(ProductVariantDto dto)
        {
            var variant = await _mediator.Send(new GetProductVariantByIdQuery(dto.ProductVariantId));
            if (variant is null)
            {
                return NotFound($"The Product Variant with the id :{dto.ProductVariantId} does not exist");
            }

            await _mediator.Send(new UpdateProductVariantCommand(dto));
            return Ok($"Successfully update with the id: {dto.ProductVariantId}");
        }
    }
}
