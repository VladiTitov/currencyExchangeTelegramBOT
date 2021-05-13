using AutoMapper;
using Banks;

namespace LogicApp
{
    class CurrencyMappingProfile : Profile
    {
        public CurrencyMappingProfile()
        {
            CreateMap<Currency, CurrencyDTO>().ReverseMap();
        }
    }
}
