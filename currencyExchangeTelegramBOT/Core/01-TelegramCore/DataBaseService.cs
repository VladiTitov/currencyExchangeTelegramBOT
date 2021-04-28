using System;
using System.Collections.Generic;
using System.Text;
using Banks._02_Classes;
using SqlLiteData;

namespace Core._01_TelegramCore
{
    public class DataBaseService
    {
        public void Data()
        {
            using (DataContext db = new DataContext())
            {
                db.Currencies.Add(new Currency(1, "Lat", "Rus"));
                db.SaveChanges();
            }
        }
    
         
    }
}
