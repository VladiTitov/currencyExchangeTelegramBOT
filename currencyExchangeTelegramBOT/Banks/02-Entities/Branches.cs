using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class Branches
    {
        [Key] public int Key { get; set; }
        public string AdrLat { get; set; }
        public string AdrRus { get; set; }

        public ICollection<Quotation> Quotations { get; set; }
        public ICollection<Phone> Phones { get; set; }

        public int? BankId { get; set; }
        public Bank Bank { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }
    }
}
