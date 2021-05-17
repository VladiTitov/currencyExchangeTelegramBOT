using System.Collections.Generic;

namespace BusinessLogic
{
    public interface ICityWebDataService
    {
        IEnumerable<CityDTO> GetData(string selector, string url);
    }
}
