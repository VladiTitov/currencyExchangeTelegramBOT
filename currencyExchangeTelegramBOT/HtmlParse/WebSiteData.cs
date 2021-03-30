using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HtmlParse
{
    class WebSiteData
    {
        //USD = https://select.by/kurs-dollara
        //EUR = https://select.by/kurs-evro
        //RUB = https://select.by/kurs-rublya

        public WebSiteData(string Part)
        {
            List<string> Addr = new List<string>();

            IWebDriver driver = new ChromeDriver();
            driver.Url = @"https://select.by/kurs-" + $"{Part}";
        }

    }

    
}
