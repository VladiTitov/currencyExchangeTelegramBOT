using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Banks;
using Banks._02_Classes;

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
                        db.Currencies.AddRange((IEnumerable<Currency>)data);
                        break;
                    default:
                        db.Brancheses.AddRange((IEnumerable<Branches>)data);
                        break;
                }
                db.SaveChanges();
            }
        }
    }
}
