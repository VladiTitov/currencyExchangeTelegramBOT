using System.Collections.Generic;
using System.Linq;
using Banks._01_Inerfaces;

namespace Banks._02_Classes
{
    public class Branches : IBank
    {
        public List<string> Phones { get; set; }

        public Branches(string name, double bestBuy, double bestSale, string[] phones) :
            base(name, bestBuy, bestSale) => Phones = phones.ToList();
    }
}
