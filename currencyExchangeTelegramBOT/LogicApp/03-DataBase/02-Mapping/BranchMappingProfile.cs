using AutoMapper;
using DataAccess;

namespace BusinessLogic
{
    internal class BranchMappingProfile : Profile
    {
        public BranchMappingProfile() =>
            CreateMap<Branches, BranchDTO>().ReverseMap();
    }
}
