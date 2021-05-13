using System.Collections.Generic;

namespace LogicApp
{
    public interface IQuotationService
    {
        List<QuotationDTO> GetData();
        void Add(QuotationDTO quotation);
        void Update(QuotationDTO quotation);
        void Delete(string id);
    }
}
