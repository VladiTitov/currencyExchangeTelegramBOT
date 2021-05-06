using System.ComponentModel.DataAnnotations;
using Banks._02_Classes;

namespace Banks
{
    public class Branches : IBranch
    {
        [Key] public string Key { get; set; }
        public City CityName { get; set; }
        public Bank BankName { get; set; }
        public string AdrLat { get; set; }
        public string AdrRus { get; set; }
        public string Phones { get; set; }
       
        public Branches() { }

        public Branches(string key, Bank bankName, string adrLat, string adrRus, string phones)
        {
            Key = key;
            BankName = bankName;
            AdrLat = adrLat;
            AdrRus = adrRus;
            Phones = phones;
        }
    }
}
