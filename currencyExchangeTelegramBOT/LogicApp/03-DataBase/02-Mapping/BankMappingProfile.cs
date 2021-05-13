using AutoMapper;
using Banks;

namespace LogicApp
{
    class BankMappingProfile : Profile
    {
        public BankMappingProfile()
        {
            CreateMap<Bank, BankDTO>().ReverseMap();
        }
    }
}
