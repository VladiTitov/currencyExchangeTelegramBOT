using System.Collections.Generic;

namespace DataAccess.Repo
{
    public interface IBranchRepository
    {
        IEnumerable<Branches> Get(string id);
        IEnumerable<Branches> GetAll();
        void Add(Branches branch);
        void Delete(string id);
        void Update(Branches branch);
    }
}
