using System.Collections.Generic;

namespace BusinessLogic
{
    public interface ICityWebDataService
    {
        List<CityDTO> GetData(string key);
    }
}
