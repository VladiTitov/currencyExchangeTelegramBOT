using System;
using System.Collections.Generic;
using System.Text;
using Banks._02_Classes;

namespace Banks._01_Inerfaces
{
    abstract class IBank
    {
        public IBank(List<string> bestDeal)
        {
            Name = bestDeal[0];
            BestBuy = bestDeal[2];
            BestSale = bestDeal[3];
        }

        public string Name { get; set; }
        public string BestBuy { get; set; }
        public string BestSale { get; set; }
    }
}
