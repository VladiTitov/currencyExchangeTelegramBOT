using System.ComponentModel.DataAnnotations;
using Banks._01_Inerfaces;

namespace Banks._02_Classes
{
    public class Currency : IStructure, IUrl
    {
        public string Url { get; set; }
        [Key] public string Key { get; set; }
        public string NameLat { get; set; }
        public string NameRus { get; set; }

        public Currency() { }

        public Currency(string key, string nameLat, string nameRus, string url)
        {
            Key = key;
            NameLat = nameRus.Split(' ')[0];
            NameRus = nameRus.TrimStart(nameLat.ToCharArray());
            Url = url;
        }


    }
}
