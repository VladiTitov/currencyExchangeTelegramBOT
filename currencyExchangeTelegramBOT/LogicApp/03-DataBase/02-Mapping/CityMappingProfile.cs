using AutoMapper;
using DataAccess;

namespace BusinessLogic
{
    class CityMappingProfile : Profile
    {
        public CityMappingProfile()
        {
            CreateMap<City, CityDTO>().ReverseMap();
        }
    }
}
