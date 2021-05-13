using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IQuotationService
    {
        List<QuotationDTO> GetData();
        void Add(QuotationDTO quotation);
        void Update(QuotationDTO quotation);
        void Delete(string id);
    }
}
