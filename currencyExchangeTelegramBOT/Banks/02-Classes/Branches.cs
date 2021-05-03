using System.ComponentModel.DataAnnotations;
using Banks._01_Inerfaces;

namespace Banks._02_Classes
{
    public class Branches : IBranch
    {
        [Key]public string Key { get; set; }
        public string Addr { get; set; }
        public string BestBuy { get; set; }
        public string BestSale { get; set; }
        public string Phones { get; set; }

        public Branches() { }

        public Branches(string key, string addr, string bestBuy, string bestSale, string phones)
        {
            Key = key;
            Addr = addr;
            BestBuy = bestBuy;
            BestSale = bestSale;
            Phones = phones;
        }
    }
}
