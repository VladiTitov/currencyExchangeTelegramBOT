using AutoMapper;
using DataAccess;

namespace BusinessLogic
{
    class BranchMappingProfile : Profile
    {
        public BranchMappingProfile()
        {
            CreateMap<Branches, BranchDTO>().ReverseMap();
        }
    }
}
