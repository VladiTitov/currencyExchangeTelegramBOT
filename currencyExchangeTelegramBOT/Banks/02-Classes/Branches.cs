using System.Collections.Generic;
using System.Linq;
using Banks._01_Inerfaces;

namespace Banks._02_Classes
{
    public class Branches : IBranch
    {
        public string Phones { get; set; }

        public Branches() { }

        public Branches(string key, string addr, string bestBuy, string bestSale, string phones) : base(key, addr, bestBuy, bestSale, phones)
        {

        }
    }
}
