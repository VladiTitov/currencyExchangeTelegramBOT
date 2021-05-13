using AutoMapper;
using DataAccess;

namespace BusinessLogic
{
    internal class CurrencyMappingProfile : Profile
    {
        public CurrencyMappingProfile() =>
            CreateMap<Currency, CurrencyDTO>().ReverseMap();
    }
}
