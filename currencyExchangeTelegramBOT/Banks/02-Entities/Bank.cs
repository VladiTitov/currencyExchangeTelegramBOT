using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Banks._01_Inerfaces;

namespace Banks
{
    public class Bank : IStructure
    {
        [Key] public string Key { get; set; }
        public string NameLat { get; set; }
        public string NameRus { get; set; }
        public ICollection<Branches> Branches { get; set; }

    }
}
