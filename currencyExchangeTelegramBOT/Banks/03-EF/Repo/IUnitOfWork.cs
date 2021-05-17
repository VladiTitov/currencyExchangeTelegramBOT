using System;

namespace DataAccess.Repo
{
    interface IUnitOfWork : IDisposable
    {
        IBankRepository BankRepository { get; }
        ICurrencyRepository CurrencyRepository { get; }
        ICityRepository CityRepository { get; }
        IBranchRepository BranchRepository { get; }
        IQuotationRepository QuotationRepository { get; }

        void Save();
    }
}
