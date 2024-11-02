using OwnIt.Domain.Interfaces.Repositories;
using OwnIt.Domain.Interfaces.Services;
using OwnIt.Domain.Models;
using System.Linq.Expressions;

namespace OwnIt.Domain.Services;

public class PaymentMethodService : IPaymentMethodService
{
    private readonly IRepositoryWrapper _repository;

    public PaymentMethodService(IRepositoryWrapper repository)
    {
        _repository = repository;
    }

    public async Task<PaymentMethod> Delete(PaymentMethod entity)
    {
        if (entity is null)
        {
            return entity;
        }

        if (await GetById(entity.Id) == default)
        {
            return null;
        }

        _repository.PaymentMethod.Delete(entity);
        var commitSuccessful = await _repository.Commit();

        return !commitSuccessful ? null : entity;
    }

    public async Task<List<PaymentMethod>> GetAll()
    {
        return await _repository.PaymentMethod.Get();
    }

    public async Task<PaymentMethod> GetById(Guid id)
    {
        return await _repository.PaymentMethod.GetFirstByProperty(paymentMethod => paymentMethod.Id == id);
    }

    public async Task<List<PaymentMethod>> GetByProperty(Expression<Func<PaymentMethod, bool>> expression)
    {
        return await _repository.PaymentMethod.GetAllByProperty(expression);
    }

    public async Task<PaymentMethod> Post(PaymentMethod entity)
    {
        if (entity is null)
        {
            return entity;
        }

        await _repository.PaymentMethod.Post(entity);
        var commitSucessful = await _repository.Commit();

        return !commitSucessful ? null : entity;
    }

    public async Task<PaymentMethod> Update(PaymentMethod entity)
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

        old.Name = entity.Name;
        old.Type = entity.Type;
        old.Limit = entity.Limit;
        old.DueDay = entity.DueDay;

        _repository.PaymentMethod.Update(old);
        var commitSucessful = await _repository.Commit();

        return !commitSucessful ? null : entity;
    }
}
