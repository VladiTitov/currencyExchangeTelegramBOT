namespace Banks
{
    public class SiteData
    {
        public string Bank { get; set; }
        public string Adr { get; set; }
        public string Phone { get; set; }
        public string Buy { get; set; }
        public string Sale { get; set; }

        public SiteData() { }

        public SiteData(string bank, string adr, string phone, string buy, string sale)
        {
            Bank = bank;
            Adr = adr;
            Phone = phone;
            Buy = buy;
            Sale = sale;
        }
    }
}
