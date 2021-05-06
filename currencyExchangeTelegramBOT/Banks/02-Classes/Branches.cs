using System.ComponentModel.DataAnnotations;
using Banks._01_Inerfaces;
using Banks._02_Classes;

namespace Banks
{
    public class Branches : IBranch
    {
        [Key] public string Key { get; set; }
        public string AddrLat { get; set; }
        public string AddrRus { get; set; }
        public string[] Phones { get; set; }
       
        public Branches() { }

        public Branches(string key, string addrLat, string addrRus, string[] phones)
        {
            Key = key;
            AddrLat = addrLat;
            AddrRus = addrRus;
            Phones = phones;
        }
    }
}
