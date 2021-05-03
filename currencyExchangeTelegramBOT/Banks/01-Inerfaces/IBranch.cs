using System.ComponentModel.DataAnnotations;

namespace Banks._01_Inerfaces
{
    public interface IBranch
    {
        [Key] public string Key { get; set; }
        public string Addr { get; set; }
        public string BestBuy { get; set; }
        public string BestSale { get; set; }
        public string Phones { get; set; }
    }
}
