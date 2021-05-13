using System.Collections.Generic;

namespace LogicApp
{
    public interface ICityService
    {
        List<CityDTO> GetData();
        void Add(CityDTO city);
        void Update(CityDTO city);
        void Delete(string id);
    }
}
