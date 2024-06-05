using AutoMapper;
using EmlakPortal.API.Dtos;
using EmlakPortal.API.Models;
using EmlakPortal.Dtos;
using EmlakPortal.Models;

namespace EmlakPortal.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Listing, ListingDto>().ReverseMap();
            CreateMap<Estate, EstateDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
