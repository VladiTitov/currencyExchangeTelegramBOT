using System.Collections.Generic;
using System.Linq;
using Banks;

namespace SqlLiteData
{
    public class DataActions
    {
        public void Add<T>(List<T> data)
        {
            //using (var db = new DataContext())
            //{
            //    //db.Quotations.AddRange((IEnumerable<Quotation>) data);
            //    foreach (var d in (IEnumerable<Quotation>)data)
            //    {
            //        if (db.Branches.Any(a => a.Key == d.Branch.Key))
            //        { 

            //        }
            //        db.Quotations.Add(d);
            //        db.SaveChanges();
            //    }
            //    //db.SaveChanges();
            //}
        }
    }
}
