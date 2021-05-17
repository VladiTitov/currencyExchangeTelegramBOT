using System.Collections.Generic;
using OpenQA.Selenium;

namespace HtmlParse
{
    public  interface IGenericRepository
    {
        IReadOnlyList<IWebElement> GetData(By selector, string url);
    }
}
