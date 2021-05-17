using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repo
{
    public class BranchRepository : GenericRepository<Branches>, IBranchRepository
    {
        public BranchRepository(DataContext context) : base(context) { }
    }
}
