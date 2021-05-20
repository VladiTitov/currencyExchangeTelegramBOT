using AutoMapper;
using DataAccess;

namespace BusinessLogic
{
    internal class BranchMappingProfile : Profile
    {
        public BranchMappingProfile() =>
            CreateMap<Branches, BaseEntityDTO>()
                .ForMember(dst => dst.Adr, opts => opts.MapFrom(src => src.AdrRus))
                .ForMember(dst => dst.Adr, opts => opts.MapFrom(src => src.AdrLat))
                .ForMember(dst => dst.Phone, opts=>opts.MapFrom(src=>src.Phones))
                .ReverseMap();
    }
}
