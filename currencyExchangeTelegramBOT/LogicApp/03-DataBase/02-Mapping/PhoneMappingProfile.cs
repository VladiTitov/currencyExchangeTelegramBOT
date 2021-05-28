using AutoMapper;
using DataAccess;

namespace BusinessLogic
{
    class PhoneMappingProfile : Profile
    {
        public PhoneMappingProfile()
        {
            CreateMap<Phone, PhoneDTO>()
                .ReverseMap();
        }
    }
}
