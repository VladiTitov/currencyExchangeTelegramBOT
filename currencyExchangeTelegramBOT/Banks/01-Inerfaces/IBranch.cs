using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Banks._02_Classes;

namespace Banks._01_Inerfaces
{
    public abstract class IBranch
    {
        public IBranch() { }

        public IBranch(string key, string addr, string bestBuy, string bestSale, string phones)
        {
            Key = key;
            Addr = addr;
            BestBuy = bestBuy;
            BestSale = bestSale;
            Phones = phones;
        }

        [Key] public string Key { get; set; }
        public string Addr { get; set; }
        public string BestBuy { get; set; }
        public string BestSale { get; set; }
        public string Phones { get; set; }
    }
}
