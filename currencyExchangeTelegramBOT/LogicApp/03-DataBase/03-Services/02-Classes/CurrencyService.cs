using System.Collections.Generic;
using AutoMapper;
using DataAccess;
using DataAccess.Repo;

namespace BusinessLogic
{
    class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IMapper _mapper;

        public CurrencyService(ICurrencyRepository currencyRepository, IMapper mapper)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }

        public List<CurrencyDTO> GetData() =>
            _mapper.Map<List<CurrencyDTO>>(_currencyRepository.GetAll());

        public void Add(CurrencyDTO currency) =>
            _currencyRepository.Add(_mapper.Map<Currency>(currency));

        public void Update(CurrencyDTO currency) =>
            _currencyRepository.Update(_mapper.Map<Currency>(currency));

        public void Delete(string id) =>
            _currencyRepository.Delete(id);
    }
}
