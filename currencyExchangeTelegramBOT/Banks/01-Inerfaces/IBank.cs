using System;
using System.Collections.Generic;
using System.Text;
using Banks._02_Classes;

namespace Banks._01_Inerfaces
{
    abstract class IBank
    {
        public IBank(string name, double bestBuy, double bestSale)
        {
            Name = name;
            BestBuy = bestBuy;
            BestSale = bestSale;
        }

        public string Name { get; set; }
        public double BestBuy { get; set; }
        public double BestSale { get; set; }
    }
}
