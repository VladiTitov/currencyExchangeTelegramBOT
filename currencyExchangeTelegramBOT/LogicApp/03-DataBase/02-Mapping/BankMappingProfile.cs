using AutoMapper;
using DataAccess;

namespace BusinessLogic
{
    internal class BankMappingProfile : Profile
    {
        public BankMappingProfile() =>
            CreateMap<Bank, BankDTO>().ReverseMap();
    }
}
