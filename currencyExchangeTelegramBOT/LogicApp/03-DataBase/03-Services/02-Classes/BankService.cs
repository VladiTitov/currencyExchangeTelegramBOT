using System.Collections.Generic;
using AutoMapper;
using DataAccess;
using DataAccess.Repo;

namespace BusinessLogic
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;
        private readonly IMapper _mapper;

        public BankService(IBankRepository bankRepository, IMapper mapper)
        {
            _bankRepository = bankRepository;
            _mapper = mapper;
        }

        public void Add(BankDTO bank) =>
            _bankRepository.Add(_mapper.Map<Bank>(bank));

        public void Delete(BankDTO item) =>
            _bankRepository.Delete(_mapper.Map<Bank>(item));

        public List<BankDTO> GetData() =>
            _mapper.Map<List<BankDTO>>(_bankRepository.GetAll());

        public void Update(BankDTO bank) =>
            _bankRepository.Update(_mapper.Map<Bank>(bank));
    }
}
