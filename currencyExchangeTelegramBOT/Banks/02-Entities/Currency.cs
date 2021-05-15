using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class Currency
    {
        [Key] public string Key { get; set; }
        public string NameLat { get; set; }
        public string NameRus { get; set; }
        public string Url { get; set; }

        public ICollection<Quotation> Quotations { get; set; }
    }
}
