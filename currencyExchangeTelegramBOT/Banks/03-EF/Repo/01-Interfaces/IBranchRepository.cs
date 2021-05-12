using System.Collections.Generic;
using Banks;

namespace DataAccess.Repo
{
    interface IBranchRepository
    {
        IEnumerable<Branches> GetId(string id);
        void Add(Branches branch);
        void Delete(string id);
        void Update(Branches branch);
    }
}
