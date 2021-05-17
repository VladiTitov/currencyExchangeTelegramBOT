using System.Collections.Generic;
using AutoMapper;
using DataAccess;
using DataAccess.Repo;

namespace BusinessLogic
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(CityDTO city) =>
            _unitOfWork.CityRepository.Add(_mapper.Map<City>(city));

        
        public void Delete(CityDTO item) =>
            _unitOfWork.CityRepository.Delete(_mapper.Map<City>(item));

        public IEnumerable<CityDTO> GetData() =>
            _mapper.Map<List<CityDTO>>(_unitOfWork.CityRepository.GetAll());

        public void Update(CityDTO city) =>
            _unitOfWork.CityRepository.Update(_mapper.Map<City>(city));

    }
}
