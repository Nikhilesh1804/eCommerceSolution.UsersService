using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Mappers
{
    public class RegisterRequestMappingProfile : Profile
    {
        public RegisterRequestMappingProfile() 
        {
            CreateMap<RegisterRequest, ApplicationUser>().ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName));
            CreateMap<RegisterRequest, ApplicationUser>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<RegisterRequest, ApplicationUser>().ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
            CreateMap<RegisterRequest, ApplicationUser>().ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));
        }
    }
}
