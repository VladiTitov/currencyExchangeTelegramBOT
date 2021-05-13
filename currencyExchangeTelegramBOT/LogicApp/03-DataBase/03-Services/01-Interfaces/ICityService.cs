using System.Collections.Generic;

namespace BusinessLogic
{
    public interface ICityService
    {
        List<CityDTO> GetData();
        void Add(CityDTO city);
        void Update(CityDTO city);
        void Delete(string id);
    }
}
