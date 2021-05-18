using AutoMapper;
using DataAccess;

namespace BusinessLogic
{
    internal class BankMappingProfile : Profile
    {
        public BankMappingProfile()
        {
            CreateMap<BankDTO, BaseEntityClass>()
                .ForMember(dst =>dst.Bank, opts =>opts.MapFrom(src => src.Key))
                .ForMember(dst => dst.Bank, opts=>opts.MapFrom(src =>src.NameLat))
                .ForMember(dst => dst.Bank, opts => opts.MapFrom(src => src.NameLat));
        }
    }
}
