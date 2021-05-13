using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    interface IStructure
    {
        [Key] public string Key { get; set; }
        public string NameLat { get; set; }
        public string NameRus { get; set; }

    } 
}
