using System.Collections.Generic;
using OpenQA.Selenium;

namespace HtmlParse
{
    public  interface IGenericRepository
    {
        IWebElement GetData(By selector);
        IReadOnlyList<IWebElement> GetDataList(By selector);
    }
}
