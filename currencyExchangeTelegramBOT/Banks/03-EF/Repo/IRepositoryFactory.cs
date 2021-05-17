namespace DataAccess.Repo
{
    public interface IRepositoryFactory
    {
        ICurrencyRepository CreateCurrencyRepository();
        IBankRepository CreateBankRepository();
        ICityRepository CreateCityRepository();
        IQuotationRepository CreateQuotationRepository();
        IBranchRepository CreateBranchRepository();
    }
}
