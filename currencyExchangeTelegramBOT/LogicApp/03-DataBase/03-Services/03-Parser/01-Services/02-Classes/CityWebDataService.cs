using System.Collections.Generic;
using AutoMapper;
using HtmlParse;

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

        public IEnumerable<CityDTO> GetData(string selector, string url) =>
            _mapper.Map<List<CityDTO>>(_citiesParserModel.GetCities(selector, url));
    }
}
