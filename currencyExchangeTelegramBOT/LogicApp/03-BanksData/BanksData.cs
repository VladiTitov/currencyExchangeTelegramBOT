using System;
using System.Collections.Generic;
using System.Text;
using HtmlParse;

namespace LogicApp
{
    class BanksData
    {
        public BanksData()
        {
            var data = new WebSiteData("dollara").GetData();
        }
        
    }
}
