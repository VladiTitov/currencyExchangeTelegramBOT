using System.ComponentModel.DataAnnotations;

namespace Banks._01_Inerfaces
{
    interface IStructure
    {
        [Key] public string Key { get; set; }
        public string NameLat { get; set; }
        public string NameRus { get; set; }

    } 
}
