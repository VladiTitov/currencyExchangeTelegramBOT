using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IBranchService
    {
        List<BranchDTO> GetData();
        void Add(BaseEntityDTO branch);
        void Update(BaseEntityDTO branch);
        void Delete(BaseEntityDTO item);
    }
}
