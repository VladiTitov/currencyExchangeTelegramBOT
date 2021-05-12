using System.Collections.Generic;
using Banks;

namespace DataAccess.Repo
{
    interface IQuotationRepository
    {
        IEnumerable<Quotation> GetId(string id);
        void Add(Quotation quotation);
        void Delete(string id);
        void Update(Quotation quotation);
    }
}
