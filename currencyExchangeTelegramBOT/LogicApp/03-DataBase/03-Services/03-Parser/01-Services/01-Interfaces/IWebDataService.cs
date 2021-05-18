using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IWebDataService
    {
        IEnumerable<BaseEntityDTO> GetData(string selector, string url);
    }
}
