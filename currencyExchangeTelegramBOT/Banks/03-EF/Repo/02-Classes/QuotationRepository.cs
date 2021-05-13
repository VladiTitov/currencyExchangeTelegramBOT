using System.Collections.Generic;
using System.Linq;
using Banks;
using SqlLiteData;

namespace DataAccess.Repo
{
    class QuotationRepository : IQuotationRepository
    {
        public IEnumerable<Quotation> Get(string id)
        {
            using (DataContext db = new DataContext())
                return db.Quotations.Where(a => a.Key == id).ToList();
        }

        public IEnumerable<Quotation> GetAll()
        {
            using (DataContext db = new DataContext())
                return db.Quotations.ToList();
        }

        public void Add(Quotation quotation)
        {
            using (DataContext db = new DataContext())
            {
                db.Quotations.Add(quotation);
                db.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (DataContext db = new DataContext())
            {
                var tempQuotation = db.Quotations.Find(id);
                db.Quotations.Remove(tempQuotation);
                db.SaveChanges();
            }
        }

        public void Update(Quotation quotation)
        {
            using (DataContext db = new DataContext())
            {
                var tempQuotation = db.Quotations.Find(quotation.Key);
                tempQuotation.Buy = quotation.Buy;
                tempQuotation.Sale = quotation.Sale;
                db.SaveChanges();
            }
        }
    }
}
