using AutoMapper;
using DataAccess;

namespace BusinessLogic
{
    class CurrencyMappingProfile : Profile
    {
        public CurrencyMappingProfile() =>
            CreateMap<Currency, CurrencyDTO>().ReverseMap();
    }
}
