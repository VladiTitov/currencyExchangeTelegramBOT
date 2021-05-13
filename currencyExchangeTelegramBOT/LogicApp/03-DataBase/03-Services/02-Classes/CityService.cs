using System;
using System.Collections.Generic;
using AutoMapper;
using Banks;
using DataAccess.Repo;

namespace LogicApp
{
    public class CityService : ICityService
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

        public void Delete(string id) =>
            _cityRepository.Delete(id);


        public List<CityDTO> GetData() =>
            _mapper.Map<List<CityDTO>>(_cityRepository.GetAll());

        public void Update(CityDTO city) =>
            _cityRepository.Update(_mapper.Map<City>(city));
    }
}
