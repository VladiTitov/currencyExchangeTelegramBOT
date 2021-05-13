using AutoMapper;
using DataAccess;

namespace BusinessLogic
{
    class BankMappingProfile : Profile
    {
        public BankMappingProfile() =>
            CreateMap<Bank, BankDTO>().ReverseMap();

    }
}
