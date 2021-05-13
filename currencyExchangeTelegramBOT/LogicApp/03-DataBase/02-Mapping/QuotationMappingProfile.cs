using AutoMapper;
using DataAccess;

namespace BusinessLogic
{
    class QuotationMappingProfile : Profile
    {
        public QuotationMappingProfile()
        {
            CreateMap<Quotation, QuotationDTO>().ReverseMap();
        }
    }
}
