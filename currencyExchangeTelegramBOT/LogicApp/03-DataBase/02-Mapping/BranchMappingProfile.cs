using System.IO.Compression;
using AutoMapper;
using DataAccess;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BusinessLogic
{
    internal class BranchMappingProfile : Profile
    {
        public BranchMappingProfile()
        {
            CreateMap<Branches, BranchDTO>()
                .ReverseMap();
        }
    }
}
