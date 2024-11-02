using OwnIt.Application.DTOs;
using OwnIt.Application.Interfaces;
using OwnIt.Application.Services.Base;
using OwnIt.Domain.Interfaces.Services;
using OwnIt.Domain.Models;

namespace OwnIt.Application.Services;

public class TransactionAppService : BaseAppService<Transaction>, ITransactionAppService
{
    private readonly ITransactionService _transactionService;

    private readonly ICategoryAppService _categoryAppService;
    private readonly IPaymentMethodAppService _paymentMethodAppService;

    public TransactionAppService(ITransactionService transactionService,
                                 ICategoryAppService categoryAppService,
                                 IPaymentMethodAppService paymentMethodAppService) : base(transactionService)
    {
        _transactionService = transactionService;
        _categoryAppService = categoryAppService;
        _paymentMethodAppService = paymentMethodAppService;
    }

    public async Task<Transaction> Post(TransactionDto dto)
    {
        var category = await _categoryAppService.GetById(dto.CategoryId);
        var paymentMethod = await _paymentMethodAppService.GetById(dto.PaymentMethodId);

        if (category == null || paymentMethod == null)
        {
            return default;
        }

        var transaction = new Transaction()
        {
            Id = Guid.NewGuid(),
            Amount = dto.Amount,
            Date = dto.Date,
            Category = category.Id,
            PaymentMethod = paymentMethod.Id
        };

        return await _transactionService.Post(transaction);
    }

    public async Task<Transaction> Update(Guid id, TransactionDto dto)
    {
        var transaction = await GetById(id);

        if (transaction is null)
        {
            return transaction;
        }

        var category = await _categoryAppService.GetById(dto.CategoryId);
        var paymentMethod = await _paymentMethodAppService.GetById(dto.PaymentMethodId);

        if (category == null || paymentMethod == null)
        {
            return default;
        }

        transaction.Amount = dto.Amount;
        transaction.Date = dto.Date;
        transaction.Category = category.Id;
        transaction.PaymentMethod = paymentMethod.Id;

        return await _transactionService.Update(transaction);
    }
}
