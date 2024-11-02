﻿using OwnIt.Domain.Interfaces.Repositories;
using OwnIt.Domain.Models;
using OwnIt.Persistence.Repositories.Base;

namespace OwnIt.Persistence.Repositories;

public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(OwnItContext context) : base(context)
    {
    }
}