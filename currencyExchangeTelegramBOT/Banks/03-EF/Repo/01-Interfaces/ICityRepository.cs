using System.Collections.Generic;
using Banks;

namespace DataAccess.Repo
{
    interface ICityRepository
    {
        IEnumerable<City> GetId(string id);
        void Add(City city);
        void Delete(string id);
        void Update(City city);
    }
}
