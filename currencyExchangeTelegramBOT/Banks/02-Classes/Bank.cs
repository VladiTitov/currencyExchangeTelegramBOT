using System.ComponentModel.DataAnnotations;
using Banks._01_Inerfaces;

namespace Banks._02_Classes
{
    public class Bank : IStructure
    {
        [Key] public string Key { get; set; }
        public string NameLat { get; set; }
        public string NameRus { get; set; }

        public Bank() { }

        public Bank(string key, string nameLat, string nameRus)
        {
            Key = key;
            NameLat = nameLat;
            NameRus = nameRus;
        }

        
    }
}
