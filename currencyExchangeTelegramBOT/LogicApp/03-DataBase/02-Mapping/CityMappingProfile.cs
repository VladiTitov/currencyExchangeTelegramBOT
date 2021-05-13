using AutoMapper;
using Banks;

namespace LogicApp
{
    class CityMappingProfile : Profile
    {
        public CityMappingProfile()
        {
            CreateMap<City, CityDTO>().ReverseMap();
        }
    }
}
