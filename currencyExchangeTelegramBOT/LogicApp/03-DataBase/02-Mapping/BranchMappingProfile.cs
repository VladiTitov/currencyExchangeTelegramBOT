using AutoMapper;
using Banks;

namespace LogicApp
{
    class BranchMappingProfile : Profile
    {
        public BranchMappingProfile()
        {
            CreateMap<Branches, BranchDTO>().ReverseMap();
        }
    }
}
