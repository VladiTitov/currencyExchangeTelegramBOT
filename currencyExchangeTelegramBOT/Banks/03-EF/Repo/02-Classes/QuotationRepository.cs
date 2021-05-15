using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repo
{
    public class QuotationRepository : GenericRepository<Quotation>, IQuotationRepository
    {
        public QuotationRepository(DataContext context) : base(context)
        {
        }
    }
}
