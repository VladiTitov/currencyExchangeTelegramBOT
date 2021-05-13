using System.Collections.Generic;

namespace DataAccess.Repo
{
    public interface IQuotationRepository
    {
        IEnumerable<Quotation> Get(string id);
        IEnumerable<Quotation> GetAll();
        void Add(Quotation quotation);
        void Delete(string id);
        void Update(Quotation quotation);
    }
}
