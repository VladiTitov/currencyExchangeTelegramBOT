using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class Phone
    {
        [Key] public int Key { get; set; }
        public string PhoneNum { get; set; }

        public int? BranchId { get; set; }
        public Branches Branch { get; set; }
    }
}
