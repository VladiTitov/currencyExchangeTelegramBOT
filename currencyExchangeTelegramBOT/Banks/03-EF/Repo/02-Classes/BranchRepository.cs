using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repo
{
    public class BranchRepository : IBranchRepository
    {
        public void Add(Branches branch)
        {
            using (DataContext db = new DataContext())
            {
                db.Branches.Add(branch);
                db.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (DataContext db = new DataContext())
            {
                var tempBranch = db.Branches.Find(id);
                db.Branches.Remove(tempBranch);
                db.SaveChanges();
            }
        }

        public IEnumerable<Branches> Get(string id)
        {
            using (DataContext db = new DataContext())
                return db.Branches.Where(a => a.Key == id).ToList();
        }

        public IEnumerable<Branches> GetAll()
        {
            using (DataContext db = new DataContext())
                return db.Branches.ToList();
        }

        public void Update(Branches branch)
        {
            using (DataContext db = new DataContext())
            {
                var tempBranch = db.Branches.Find(branch.Key);
                tempBranch.AdrLat = branch.AdrLat;
                tempBranch.AdrRus = branch.AdrRus;
                tempBranch.Phones = branch.Phones;
                db.SaveChanges();
            }
        }
    }
}
