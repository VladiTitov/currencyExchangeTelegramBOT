using System;
using System.Collections.Generic;
using System.Text;

namespace MTBank
{
    class MTBank
    {
        private string URL;
        private string cacheless;

        public MTBank(string _url)
        {
            URL = _url;
        }

        public string Code { get; set; }
        public string CodeTo { get; set; }
        public string Purchase { get; set; }
        public string Sale { get; set; }
        public bool Cacheless { get; set; }
        
    }
}
