using OwnIt.Domain.Interfaces.Repositories;
using OwnIt.Persistence.Repositories;

namespace OwnIt.Persistence;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly OwnItContext _context;

    private ICategoryRepository _categoryRepository;
    private IPaymentMethodRepository _paymentMethodRepository;
    private ITransactionRepository _transactionRepository;

    public RepositoryWrapper(OwnItContext context)
    {
        _context = context;
    }

    public ICategoryRepository Category
    {
        get
        {
            _categoryRepository ??= new CategoryRepository(_context);
            return _categoryRepository;
        }
    }

    public IPaymentMethodRepository PaymentMethod
    {
        get
        {
            _paymentMethodRepository ??= new PaymentMethodRepository(_context);
            return _paymentMethodRepository;
        }
    }

    public ITransactionRepository Transaction
    {
        get
        {
            _transactionRepository ??= new TransactionRepository(_context);
            return _transactionRepository;
        }
    }

    public async Task<bool> Commit()
    {
        var rowsAffected = await _context.SaveChangesAsync();
        return rowsAffected > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
