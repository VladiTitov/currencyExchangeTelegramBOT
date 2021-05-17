using System;

namespace DataAccess.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext db = new DataContext();
        private BankRepository _bankRepository;
        private CityRepository _cityRepository;
        private CurrencyRepository _currencyRepository;
        private BranchRepository _branchRepository;
        private QuotationRepository _quotationRepository;

        private bool disposed = false;

        public CityRepository Cities => _cityRepository ??= new CityRepository(db);
        public CurrencyRepository Currencies => _currencyRepository ??= new CurrencyRepository(db);
        public BankRepository Banks => _bankRepository ??= new BankRepository(db);
        public BranchRepository Branches => _branchRepository ??= new BranchRepository(db);
        public QuotationRepository Quotations => _quotationRepository ??= new QuotationRepository(db);

        public IBankRepository BankRepository => throw new NotImplementedException();

        public ICurrencyRepository CurrencyRepository => throw new NotImplementedException();

        public ICityRepository CityRepository => throw new NotImplementedException();

        public IBranchRepository BranchRepository => throw new NotImplementedException();

        public IQuotationRepository QuotationRepository => throw new NotImplementedException();

        public void Save() => db.SaveChanges();

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if(disposing) db.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
