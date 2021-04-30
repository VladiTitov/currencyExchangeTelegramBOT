using System.ComponentModel.DataAnnotations;
using Banks._01_Inerfaces;

namespace Banks._02_Classes
{
    public class City : IStructure, IUrl
    {
        [Key] public string Key { get; set; }
        public string NameLat { get; set; }
        public string NameRus { get; set; }
        public string Url { get; set; }

        public City() { }

        public City(string key, string nameLat, string nameRus, string url)
        {
            Key = key;
            NameLat = nameLat;
            NameRus = nameRus;
            Url = url;
        }
    }
}
