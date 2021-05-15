using System.Collections.Generic;

namespace BusinessLogic
{
    public interface ICityService
    {
        IEnumerable<CityDTO> GetData();
        void Add(CityDTO item);
        void Update(CityDTO item);
        void Delete(CityDTO item);
    }
}
