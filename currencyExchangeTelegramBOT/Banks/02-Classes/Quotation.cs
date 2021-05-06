using System.ComponentModel.DataAnnotations;

namespace Banks
{
    public class Quotation : IQuotes
    {
        [Key] public string Key { get; set; }
        public Branches Branch { get; set; }
        public string Sale { get; set; }
        public string Buy { get; set; }

        public Quotation() { }

        public Quotation(string key, Branches branch, string sale, string buy)
        {
            Key = key;
            Branch = branch;
            Sale = sale;
            Buy = buy;
        }
    }
}
