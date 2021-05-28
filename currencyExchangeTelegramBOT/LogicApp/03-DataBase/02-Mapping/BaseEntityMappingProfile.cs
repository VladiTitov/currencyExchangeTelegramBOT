using DataAccess;
using AutoMapper;

namespace BusinessLogic
{
    class BaseEntityMappingProfile : Profile
    {
        public BaseEntityMappingProfile() => 
            CreateMap<BaseEntityClass, BaseEntityDTO>().ReverseMap();
    }
}
