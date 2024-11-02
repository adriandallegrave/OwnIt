namespace OwnIt.Domain.Interfaces.Repositories;

public interface IRepositoryWrapper
{
    ICategoryRepository Category { get; }
    IPaymentMethodRepository PaymentMethod { get; }
    ITransactionRepository Transaction { get; }

    Task<bool> Commit();

    void Dispose();
}
