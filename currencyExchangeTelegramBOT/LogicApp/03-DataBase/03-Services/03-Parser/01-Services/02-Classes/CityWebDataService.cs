using System.Collections.Generic;
using AutoMapper;
using HtmlParse;

namespace BusinessLogic
{
    public class CityWebDataService : ICityWebDataService
    {
        private readonly ICitiesParserRepository _citiesParserModel;
        private readonly IMapper _mapper;

        public List<CityDTO> GetData(string key) =>
            _mapper.Map<List<CityDTO>>(_citiesParserModel.GetData(key));
    }
}
