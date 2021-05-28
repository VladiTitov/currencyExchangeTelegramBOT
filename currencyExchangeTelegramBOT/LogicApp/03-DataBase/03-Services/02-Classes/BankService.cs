using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccess;
using DataAccess.Repo;

namespace BusinessLogic
{
    public class BankService : IBankService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BankService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(BaseEntityDTO bank)
        {
            if (_unitOfWork.BankRepository.GetAll().All(a => a.NameRus != bank.Bank))
                _unitOfWork.BankRepository.Add(_mapper.Map<Bank>(bank));
        }
        
        public void Delete(BaseEntityDTO item) =>
            _unitOfWork.BankRepository.Delete(_mapper.Map<Bank>(item));

        public List<BankDTO> GetData() =>
            _mapper.Map<List<BankDTO>>(_unitOfWork.BankRepository.GetAll());

        public void Update(BaseEntityDTO bank) =>
            _unitOfWork.BankRepository.Update(_mapper.Map<Bank>(bank));
    }
}
