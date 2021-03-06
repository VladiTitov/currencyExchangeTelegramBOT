﻿using System;

namespace DataAccess.Repo
{
    public interface IUnitOfWork : IDisposable
    {
        IBankRepository BankRepository { get; }
        ICurrencyRepository CurrencyRepository { get; }
        ICityRepository CityRepository { get; }
        IBranchRepository BranchRepository { get; }
        IQuotationRepository QuotationRepository { get; }
        IPhoneRepository PhoneRepository { get; }

        void Save();
    }
}
