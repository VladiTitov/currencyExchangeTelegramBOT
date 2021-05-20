using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
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

        public void Add(BaseEntityDTO bank)
        {
            var data = _bankRepository.GetAll();
            if (data.Any(a => a.NameRus == bank.Bank)) return;
            //bank.BankId = data.Count();
            _bankRepository.Add(_mapper.Map<Bank>(bank));
        }
        
        public void Delete(BaseEntityDTO item) =>
            _bankRepository.Delete(_mapper.Map<Bank>(item));

        public List<BankDTO> GetData() =>
            _mapper.Map<List<BankDTO>>(_bankRepository.GetAll());

        public void Update(BaseEntityDTO bank) =>
            _bankRepository.Update(_mapper.Map<Bank>(bank));
    }
}
