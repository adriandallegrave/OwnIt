using OwnIt.Domain.Interfaces.Repositories;
using OwnIt.Domain.Interfaces.Services;
using OwnIt.Domain.Models;
using System.Linq.Expressions;

namespace OwnIt.Domain.Services;

public class TransactionService : ITransactionService
{
    private readonly IRepositoryWrapper _repository;

    public TransactionService(IRepositoryWrapper repository)
    {
        _repository = repository;
    }

    public async Task<Transaction> Delete(Transaction entity)
    {
        if (entity is null)
        {
            return entity;
        }

        if (await GetById(entity.Id) == default)
        {
            return null;
        }

        _repository.Transaction.Delete(entity);
        var commitSuccessful = await _repository.Commit();

        return !commitSuccessful ? null : entity;
    }

    public async Task<List<Transaction>> GetAll()
    {
        return await _repository.Transaction.Get();
    }

    public async Task<Transaction> GetById(Guid id)
    {
        return await _repository.Transaction.GetFirstByProperty(transaction => transaction.Id == id);
    }

    public async Task<List<Transaction>> GetByProperty(Expression<Func<Transaction, bool>> expression)
    {
        return await _repository.Transaction.GetAllByProperty(expression);
    }

    public async Task<Transaction> Post(Transaction entity)
    {
        if (entity is null)
        {
            return entity;
        }

        await _repository.Transaction.Post(entity);
        var commitSucessful = await _repository.Commit();

        return !commitSucessful ? null : entity;
    }

    public async Task<Transaction> Update(Transaction entity)
    {
        if (entity is null)
        {
            return entity;
        }

        var old = await GetById(entity.Id);

        if (old is null)
        {
            return old;
        }

        old.Amount = entity.Amount;
        old.Date = entity.Date;
        old.Category = entity.Category;
        old.PaymentMethod = entity.PaymentMethod;

        _repository.Transaction.Update(old);
        var commitSucessful = await _repository.Commit();

        return !commitSucessful ? null : entity;
    }
}
