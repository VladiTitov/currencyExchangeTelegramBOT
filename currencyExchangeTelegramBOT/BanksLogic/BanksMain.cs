using BanksLogic._03_XML;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanksLogic
{
    class BanksMain
    {
        static void Main(string[] args)
        {
            List<string> banks = new List<string>()
            {
                "http://www.old.mtbank.by/currxml.php?d=22.02.2021",
                "https://bankdabrabyt.by/export_courses.php",
                "https://www.rrb.by/export/get-currency",
                "https://www.vtb-bank.by/sites/default/files/rates.xml",
                "https://belapb.by/CashExRatesDaily.php?ondate=01.02.2021",
                //"https://belarusbank.by/api/kursExchange"

        };

            foreach (string bank in banks)
            {
                MainLogic obj = new MainLogic(bank);
                obj.GetData();
            }
        }
    }
}
