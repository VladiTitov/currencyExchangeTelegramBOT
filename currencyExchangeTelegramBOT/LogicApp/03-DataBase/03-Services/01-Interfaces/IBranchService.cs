using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IBranchService
    {
        List<BranchDTO> GetData();
        void Add(BranchDTO branch);
        void Update(BranchDTO branch);
        void Delete(BranchDTO item);
    }
}
