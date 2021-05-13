using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class Branches : IBranch
    {
        [Key] public string Key { get; set; }
        public string AdrLat { get; set; }
        public string AdrRus { get; set; }
        public string Phones { get; set; }

        public ICollection<Quotation> Quotations { get; set; }

        public int? BankId { get; set; }
        public Bank Bank { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }

    }
}
