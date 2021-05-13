﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Banks;

namespace DataAccess.Repo
{
    public interface IBankRepository
    {
        IEnumerable<Bank> Get(string id);
        IEnumerable<Bank> GetAll();
        void Add(Bank bank);
        void Delete(string id);
        void Update(Bank bank);

    }
}
