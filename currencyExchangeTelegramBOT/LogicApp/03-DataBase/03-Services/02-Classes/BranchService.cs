using System.Collections.Generic;
using AutoMapper;
using Banks;
using DataAccess.Repo;

namespace LogicApp
{
    class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public BranchService(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public void Add(BranchDTO branch) =>
            _branchRepository.Add(_mapper.Map<Branches>(branch));

        public void Delete(string id) =>
            _branchRepository.Delete(id);

        public List<BranchDTO> GetData() =>
            _mapper.Map<List<BranchDTO>>(_branchRepository.GetAll());

        public void Update(BranchDTO branch) =>
            _branchRepository.Update(_mapper.Map<Branches>(branch));
    }
}
