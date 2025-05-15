using AutoMapper;
using Ecommerce.Application.DTOs.ProductVariants;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Profiles
{
    public class ProductVariantProfile:Profile
    {
        public ProductVariantProfile()
        {
            CreateMap<ProductVariantDto, ProductVariant>();
            CreateMap<ProductVariant, ProductVariantDto>();
            CreateMap<CreateProductVariantDto, ProductVariant>();
        }
    }
}
