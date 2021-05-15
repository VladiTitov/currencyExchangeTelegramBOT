using System.Collections.Generic;
using OpenQA.Selenium;

namespace BusinessLogic
{
    public interface IWebDataService
    {
        IEnumerable<IEnumerable<string>> GetData(string selector, string url);
    }
}
