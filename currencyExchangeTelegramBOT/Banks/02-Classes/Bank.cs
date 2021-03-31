using System.Collections.Generic;
using Banks._01_Inerfaces;

namespace Banks._02_Classes
{
    class Bank : IBank
    {
        public List<Branches> Brancheses { get; set; }

        public Bank(string name, double bestBuy, double bestSale, List<Branches> brancheses) : base(name, bestBuy, bestSale) => Brancheses = brancheses;
    }
}
