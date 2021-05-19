using AutoMapper;
using DataAccess;

namespace BusinessLogic
{
    internal class QuotationMappingProfile : Profile
    {
        public QuotationMappingProfile() =>
            CreateMap<Quotation, BaseEntityDTO>()
                .ForMember(dst=>dst.Buy, opts=>opts.MapFrom(src=>src.Buy))
                .ForMember(dst => dst.Sale, opts => opts.MapFrom(src => src.Sale))
                .ReverseMap();
    }
}
