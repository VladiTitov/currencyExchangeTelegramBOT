namespace DataAccess.Repo
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public ICurrencyRepository CreateCurrencyRepository()
        {
            throw new System.NotImplementedException();
        }

        public IBankRepository CreateBankRepository()
        {
            throw new System.NotImplementedException();
        }

        public ICityRepository CreateCityRepository()
        {
            throw new System.NotImplementedException();
        }

        public IQuotationRepository CreateQuotationRepository()
        {
            throw new System.NotImplementedException();
        }

        public IBranchRepository CreateBranchRepository()
        {
            throw new System.NotImplementedException();
        }
    }
}
