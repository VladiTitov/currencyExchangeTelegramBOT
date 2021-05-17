namespace DataAccess.Repo
{
    interface IRepositoryFactory
    {
        ICurrencyRepository CreateCurrencyRepository();
        IBankRepository CreateBankRepository();
        ICityRepository CreateCityRepository();
        IQuotationRepository CreateQuotationRepository();
        IBranchRepository BranchRepository();
    }
}
