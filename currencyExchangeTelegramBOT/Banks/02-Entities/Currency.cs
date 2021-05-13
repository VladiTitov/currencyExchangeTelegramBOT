using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class Currency : IStructure, IUrl
    {
        [Key] public string Key { get; set; }
        public string NameLat { get; set; }
        public string NameRus { get; set; }
        public string Url { get; set; }

        public ICollection<Quotation> Quotations { get; set; }

        //public Currency(string key, string nameLat, string nameRus, string url)
        //{
        //    Key = key;
        //    NameLat = nameRus.Split(' ')[0];
        //    NameRus = nameRus.TrimStart(nameLat.ToCharArray());
        //    Url = url;
        //}
    }
}
