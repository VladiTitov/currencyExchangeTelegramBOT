using System.ComponentModel.DataAnnotations;

namespace Banks
{
    public class Quotation : IQuotes
    {
        [Key] public string Key { get; set; }
        public string Sale { get; set; }
        public string Buy { get; set; }

        public int? BranchId { get; set; }
        public Branches Branch { get; set; }

        public int? CurrencyId { get; set; }
        public Currency Currency { get; set; }

        //public Quotation(string key, Branches branch, string sale, string buy)
        //{
        //    Key = key;
        //    Branch = branch;
        //    Sale = sale;
        //    Buy = buy;
        //}
    }
}
