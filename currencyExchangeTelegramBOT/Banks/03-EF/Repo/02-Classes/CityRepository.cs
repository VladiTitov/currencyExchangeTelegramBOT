using System;
using Banks;
using System.Collections.Generic;
using System.Linq;
using SqlLiteData;

namespace DataAccess.Repo
{
    public class CityRepository : ICityRepository
    {
        public void Add(City city)
        {
            using (DataContext db = new DataContext())
            {
                db.Cities.Add(city);
                db.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (DataContext db = new DataContext())
            {
                var tempCity = db.Cities.Find(id);
                db.Cities.Remove(tempCity);
                db.SaveChanges();
            }
        }

        public IEnumerable<City> Get(string id)
        {
            using (DataContext db = new DataContext())
                return db.Cities.Where(a => a.Key == id).ToList();
        }

        public IEnumerable<City> GetAll()
        {
            using (DataContext db = new DataContext())
                return db.Cities.ToList();
        }

        public void Update(City city)
        {
            using (DataContext db = new DataContext())
            {
                var tempCity = db.Cities.Find(city.Key);
                tempCity.NameLat = city.NameLat;
                tempCity.NameRus = city.NameRus;
                tempCity.Url = city.Url;
                db.SaveChanges();
            }
        }
    }
}
