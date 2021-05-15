using System.Collections.Generic;
using AutoMapper;
using HtmlParse;
using OpenQA.Selenium;

namespace BusinessLogic
{
    public class CityWebDataService : ICityWebDataService
    {
        private readonly ICitiesParserRepository _citiesParserModel;
        private readonly IMapper _mapper;

        public CityWebDataService(ICitiesParserRepository citiesParserModel, IMapper mapper)
        {
            _citiesParserModel = citiesParserModel;
            _mapper = mapper;
        }

        public IEnumerable<CityDTO> GetData(string selector) =>
            _mapper.Map<List<CityDTO>>(_citiesParserModel.GetData(selector, @"https://m.select.by/kurs"));
    }
}
