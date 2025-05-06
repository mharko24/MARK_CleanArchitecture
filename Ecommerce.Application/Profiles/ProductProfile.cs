using AutoMapper;
using Ecommerce.Application.DTOs.Products;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
