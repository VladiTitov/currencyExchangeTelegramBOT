﻿using AutoMapper;
using DataAccess;

namespace BusinessLogic
{
    internal class BankMappingProfile : Profile
    {
        public BankMappingProfile()
        {
            CreateMap<Bank, BankDTO>()
                //.ForMember(dst => dst.Bank, opts => opts.MapFrom(src => src.NameLat))
                //.ForMember(dst => dst.Bank, opts => opts.MapFrom(src => src.NameRus))
                .ReverseMap();
        }
    }
}
