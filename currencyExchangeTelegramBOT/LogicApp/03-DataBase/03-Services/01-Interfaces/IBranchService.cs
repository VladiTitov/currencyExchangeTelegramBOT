using System.Collections.Generic;

namespace LogicApp
{
    public interface IBranchService
    {
        List<BranchDTO> GetData();
        void Add(BranchDTO branch);
        void Update(BranchDTO branch);
        void Delete(string id);
    }
}
