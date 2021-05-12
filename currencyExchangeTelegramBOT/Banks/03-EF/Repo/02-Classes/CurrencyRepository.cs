using System;
using System.Collections.Generic;
using System.Linq;
using Banks;
using SqlLiteData;

namespace DataAccess.Repo
{
    class CurrencyRepository : ICurrencyRepository
    {
        public IEnumerable<Currency> GetId(string id)
        {
            using (DataContext db = new DataContext())
                return db.Currencies.Where(a => a.Key == id).ToList();
        }

        public void Add(Currency currency)
        {
            using (DataContext db = new DataContext())
            {
                db.Currencies.Add(currency);
                db.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (DataContext db = new DataContext())
            {
                var tempCurrency = db.Currencies.Find(id);
                db.Currencies.Remove(tempCurrency);
                db.SaveChanges();
            }
        }

        public void Update(Currency currency)
        {
            using (DataContext db = new DataContext())
            {
                var tempCurrency = db.Currencies.Find(currency.Key);
                tempCurrency.NameLat = currency.NameLat;
                tempCurrency.NameRus = currency.NameRus;
                tempCurrency.Url = currency.Url;
                db.SaveChanges();
            }
        }
    }
}
