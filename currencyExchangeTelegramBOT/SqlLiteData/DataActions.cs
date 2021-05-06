using System.Collections.Generic;
using Banks;

namespace SqlLiteData
{
    public class DataActions
    {
        public void Add<T>(List<T> data)
        {
            using (var db = new DataContext())
            {
                switch (typeof(T).Name)
                {
                    case "City":
                        db.Cities.AddRange((IEnumerable<City>) data);
                        break;
                    case "Currency":
                        db.Currencies.AddRange((IEnumerable<Currency>) data);
                        break;
                    default:
                        db.Quotations.AddRange((IEnumerable<Quotation>) data);
                        break;
                }

                db.SaveChanges();
            }
        }
    }
}
