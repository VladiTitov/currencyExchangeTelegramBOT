using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccess;
using DataAccess.Repo;

namespace BusinessLogic
{
    class BranchService : IBranchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BranchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(BranchDTO branch)
        {
            if (_unitOfWork.BranchRepository.GetAll().All(a => a.AdrRus != branch.AdrRus))
                _unitOfWork.BranchRepository.Add(_mapper.Map<Branches>(branch));
        }
        
        public void Delete(BranchDTO item) =>
            _unitOfWork.BranchRepository.Delete(_mapper.Map<Branches>(item));

        public List<BranchDTO> GetData() =>
            _mapper.Map<List<BranchDTO>>(_unitOfWork.BranchRepository.GetAll());

        public void Update(BranchDTO branch) =>
            _unitOfWork.BranchRepository.Update(_mapper.Map<Branches>(branch));
    }
}
