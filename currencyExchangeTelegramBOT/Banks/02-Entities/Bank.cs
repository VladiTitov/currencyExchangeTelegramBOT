using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class Bank
    {
        [Key] public string Key { get; set; }
        public string NameLat { get; set; }
        public string NameRus { get; set; }
        public ICollection<Branches> Branches { get; set; }

    }
}
