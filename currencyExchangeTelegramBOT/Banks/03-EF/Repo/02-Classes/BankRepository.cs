using Banks;
using System.Collections.Generic;
using System.Linq;
using SqlLiteData;

namespace DataAccess.Repo
{
    class BankRepository : IBankRepository
    {
        public string Create(Bank bank)
        {
            using (DataContext db = new DataContext())
            {
                db.Banks.Add(bank);
                db.SaveChanges();
            }
            return bank.Key;
        }

        public void DeleteBank(string id)
        {
            using (DataContext db = new DataContext())
            {
                var tempBank = db.Banks.Find(id);
                db.Banks.Remove(tempBank);
                db.SaveChanges();
            }
        }

        public IEnumerable<Bank> GetByBankId(string bankId)
        {
            using (DataContext db = new DataContext())
                return db.Banks.Where(a => a.Key == bankId).ToList();

        }

        public void UpdateBank(Bank bank)
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
