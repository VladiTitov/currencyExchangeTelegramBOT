using AutoMapper;
using Banks;

namespace LogicApp
{
    class QuotationMappingProfile : Profile
    {
        public QuotationMappingProfile()
        {
            CreateMap<Quotation, QuotationDTO>().ReverseMap();
        }
    }
}
