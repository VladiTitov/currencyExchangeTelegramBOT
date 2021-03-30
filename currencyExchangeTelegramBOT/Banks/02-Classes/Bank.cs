using System;
using System.Collections.Generic;
using System.Text;
using Banks._01_Inerfaces;

namespace Banks._02_Classes
{
    class Bank : IBank
    {
        public List<Branches> Brancheses { get; set; }

        public Bank(List<string> bestDeal) : base(bestDeal) { }


        private void ReturnAddr(List<string> data)
        {
            data.RemoveRange(0, 3);
            foreach (var d in data) { }
        }
    }
}
