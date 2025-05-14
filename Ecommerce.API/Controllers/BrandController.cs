using Ecommerce.Application.Abstractions.Brands.Commands.CreateBrand;
using Ecommerce.Application.Abstractions.Brands.Commands.DeleteBrand;
using Ecommerce.Application.Abstractions.Brands.Commands.UpdateBrand;
using Ecommerce.Application.Abstractions.Brands.Queries.GetAllBrands;
using Ecommerce.Application.Abstractions.Brands.Queries.GetBrandById;
using Ecommerce.Application.DTOs.Brands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BrandController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createbrand")]
        public async Task<ActionResult> CreateBrand(BrandDto brand)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brandCommand = new CreateBrandCommand(brand);
            var brandId = await _mediator.Send(new CreateBrandCommand(brand));
            return Ok(brandId);
        }

        [HttpGet("getbrand/{id}")]
        public async Task<ActionResult> GetBrandById(int id)
        {
            var brand = await _mediator.Send(new GetBrandByIdQuery(id));
            if(brand is null)
            {
                return NotFound($"The brand with BrandId : {id}, does not exist");
            }

            return Ok(brand);
        }

        [HttpGet("getbrands")]
        public async Task<ActionResult> GetBrands()
        {
            var brands = await _mediator.Send(new GetAllBrandsQuery());
            return Ok(brands);
        }

        [HttpPut("updatebrand")]
        public async Task<ActionResult> UpdateBrand(BrandDto brand)
        {
            var existBrand = await _mediator.Send(new GetBrandByIdQuery(brand.BrandId));
            if (existBrand is null)
            {
                return NotFound($"The brand with BrandId : {brand.BrandId}, does not exist");
            }

            var mapBrand = await _mediator.Send(new UpdateBrandCommand(brand));
            return Ok(mapBrand);
        }

        [HttpDelete("deletebrand/{id}")]
        public async Task<ActionResult> DeleteBrand(int id)
        {
            var existBrand = await _mediator.Send(new GetBrandByIdQuery(id));
            if (existBrand is null)
            {
                return NotFound($"The brand with BrandId : {id}, does not exist");
            }

            await _mediator.Send(new DeleteBrandCommand(id));
            return Ok($"Successfully deleted the Brand with BrandId : {id}");

        }
    }
}
