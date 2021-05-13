using AutoMapper;
using DataAccess;

namespace BusinessLogic
{
    internal class CityMappingProfile : Profile
    {
        public CityMappingProfile() =>
            CreateMap<City, CityDTO>().ReverseMap();
    }
}
