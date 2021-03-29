using BanksLogic._01_Interfaces;

using System;
using System.Collections.Generic;
using System.Text;

namespace BanksLogic._02_Banks
{
    class MTBank : IBank
    {
        private string URL;

        //string URL = "http://www.old.mtbank.by/currxml.php?d=09.03.2021";

        public MTBank(string _url)
        {
            URL = _url;
        }


    }
}
