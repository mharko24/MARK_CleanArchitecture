using AutoMapper;
using Ecommerce.Application.DTOs.Brands;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Profiles
{
    public class BrandProfile:Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<BrandDto,Brand>();
        }
    }
}
