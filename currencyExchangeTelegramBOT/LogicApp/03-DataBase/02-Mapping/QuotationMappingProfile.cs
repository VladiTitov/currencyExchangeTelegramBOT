using AutoMapper;
using DataAccess;

namespace BusinessLogic
{
    internal class QuotationMappingProfile : Profile
    {
        public QuotationMappingProfile() =>
            CreateMap<Quotation, QuotationDTO>().ReverseMap();
    }
}
