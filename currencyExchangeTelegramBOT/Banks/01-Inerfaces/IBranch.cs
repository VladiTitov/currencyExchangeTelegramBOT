using System.ComponentModel.DataAnnotations;

namespace Banks
{
    interface IBranch
    {
        [Key] public string Key { get; set; }
        public string AddrLat { get; set; }
        public string AddrRus { get; set; }
        public string[] Phones { get; set; }
    }
}
