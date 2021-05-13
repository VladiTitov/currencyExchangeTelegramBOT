using System.Collections.Generic;

namespace DataAccess.Repo
{
    public interface ICityRepository
    {
        IEnumerable<City> Get(string id);
        IEnumerable<City> GetAll();
        void Add(City city);
        void Delete(string id);
        void Update(City city);
    }
}
