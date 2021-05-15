using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repo
{
    public class CurrencyRepository : GenericRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(DataContext context) : base(context)
        {
        }
    }
}
