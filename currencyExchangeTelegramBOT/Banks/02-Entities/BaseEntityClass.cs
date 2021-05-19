namespace DataAccess
{
    public class BaseEntityClass
    {
        public string BankId { get; set; }
        public string Bank { get; set; }
        public string AdrId { get; set; }
        public string Adr { get; set; }
        public string Phone { get; set; }
        public string QuotationId { get; set; }
        public string Buy { get; set; }
        public string Sale { get; set; }

        public BaseEntityClass(
            string bankId,
            string bank,
            string adrId,
            string adr,
            string phone,
            string quotationId,
            string buy,
            string sale)
        {
            BankId = bankId;
            Bank = bank;
            AdrId = adrId;
            Adr = adr;
            Phone = phone;
            QuotationId = quotationId;
            Buy = buy;
            Sale = sale;
        }
    }
}
