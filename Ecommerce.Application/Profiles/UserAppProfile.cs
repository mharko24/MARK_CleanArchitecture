using AutoMapper;
using Ecommerce.Application.DTOs.Users;
using Ecommerce.Application.Entities;

namespace Ecommerce.Application.Profiles
{
    internal class UserAppProfile:Profile
    {
        public UserAppProfile()
        {
            CreateMap<UserApp, UserAppDto>();
            CreateMap<UserAppDto, UserApp>();
        }
    }
}
