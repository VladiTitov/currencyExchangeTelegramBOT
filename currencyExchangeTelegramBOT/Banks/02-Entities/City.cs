using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class City
    {
        [Key] public int Key { get; set; }
        public string NameLat { get; set; }
        public string NameRus { get; set; }
        public string Url { get; set; }

        public City() =>
            Branches = new List<Branches>();

        public ICollection<Branches> Branches { get; set; }
    }
}
