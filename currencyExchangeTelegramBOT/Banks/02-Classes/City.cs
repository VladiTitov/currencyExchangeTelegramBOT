using System.ComponentModel.DataAnnotations;
using Banks._01_Inerfaces;

namespace Banks
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
            nameLat = url.Split('/')[1];
            char firstChar = nameLat[0];
            NameLat = $"{firstChar.ToString().ToUpper()}{nameLat.TrimStart(firstChar)}";
            NameRus = nameRus;
            Url = url;
        }
    }
}
