using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repo
{
    public class BankRepository : IBankRepository
    {
        public void Add(Bank bank)
        {
            using (DataContext db = new DataContext())
            {
                db.Banks.Add(bank);
                db.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (DataContext db = new DataContext())
            {
                var tempBank = db.Banks.Find(id);
                db.Banks.Remove(tempBank);
                db.SaveChanges();
            }
        }

        public IEnumerable<Bank> Get(string bankId)
        {
            using (DataContext db = new DataContext())
                return db.Banks.Where(a => a.Key == bankId).ToList();
        }

        public IEnumerable<Bank> GetAll()
        {
            using (DataContext db = new DataContext())
                return db.Banks.ToList();
        }

        public void Update(Bank bank)
        {
            using (DataContext db = new DataContext())
            {
                var tempBank = db.Banks.Find(bank.Key);
                tempBank.NameLat = bank.NameLat;
                tempBank.NameRus = bank.NameRus;
                db.SaveChanges();
            }
        }
    }
}
