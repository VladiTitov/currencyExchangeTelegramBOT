﻿using System.Collections.Generic;
using AutoMapper;
using DataAccess;
using DataAccess.Repo;

namespace BusinessLogic
{
    public class CityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public void Add(CityDTO city) =>
            _cityRepository.Add(_mapper.Map<City>(city));

        public void Delete(CityDTO item) =>
            _cityRepository.Delete(_mapper.Map<City>(item));


        public IEnumerable<CityDTO> GetData() =>
            _mapper.Map<List<CityDTO>>(_cityRepository.GetAll());

        public void Update(CityDTO city) =>
            _cityRepository.Update(_mapper.Map<City>(city));

    }
}
