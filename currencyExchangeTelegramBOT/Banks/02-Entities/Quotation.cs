using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class Quotation
    {
        [Key] 
        public int Key { get; set; }
        public string Sale { get; set; }
        public string Buy { get; set; }

        public int? BranchId { get; set; }
        public Branches Branch { get; set; }

        public int? CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}
